// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectBinder.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using nGratis.Cop.Olympus.Contract;

public sealed class ObjectBinder
{
    private readonly INotifyPropertyChanged _source;

    private readonly INotifyPropertyChanged _target;

    private readonly PropertyInfo _sourceProperty;

    private readonly PropertyInfo _targetProperty;

    private readonly bool _isCallbackInvokedBothWays;

    private MethodInfo _sourceCallbackMethod;

    private MethodInfo _targetCallbackMethod;

    private Action _onSourceValueUpdated;

    private Action _onSourceValueUpdating;

    private Action _onTargetValueUpdating;

    private Action _onTargetValueUpdated;

    private Action _onSourceErrorEncountered;

    private Action _onTargetErrorEncountered;

    public ObjectBinder(
        INotifyPropertyChanged source,
        PropertyInfo sourceProperty,
        INotifyPropertyChanged target,
        PropertyInfo targetProperty,
        bool isCallbackInvokedBothWays = true)
    {
        Guard
            .Require(source, nameof(source))
            .Is.Not.Null();

        Guard
            .Require(sourceProperty, nameof(sourceProperty))
            .Is.Not.Null();

        Guard
            .Require(target, nameof(target))
            .Is.Not.Null();

        Guard
            .Require(targetProperty, nameof(targetProperty))
            .Is.Not.Null();

        this._source = source;
        this._target = target;
        this._sourceProperty = sourceProperty;
        this._targetProperty = targetProperty;
        this._isCallbackInvokedBothWays = isCallbackInvokedBothWays;

        source.PropertyChanged += async (_, args) => await this.OnSourcePropertyChangedAsync(args.PropertyName);
        target.PropertyChanged += async (_, args) => await this.OnTargetPropertyChangedAsync(args.PropertyName);
    }

    public void BindSourceCallback(
        Action onValueUpdating = null,
        Action onValueUpdated = null,
        Action onErrorEncountered = null)
    {
        var methodName = $"On{this._sourceProperty.Name}Changed";

        this._sourceCallbackMethod = this
            ._source
            .GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .SingleOrDefault(method =>
                method.GetCustomAttribute<BindingCallbackAttribute>() != null &&
                method.Name == methodName && !method.GetParameters().Any());

        this._onSourceValueUpdating = onValueUpdating;
        this._onSourceValueUpdated = onValueUpdated;
        this._onSourceErrorEncountered = onErrorEncountered;
    }

    public void BindTargetCallback(
        Action onValueUpdating = null,
        Action onValueUpdated = null,
        Action onErrorEncountered = null)
    {
        var methodName = $"On{this._sourceProperty.Name}Changed";

        this._targetCallbackMethod = this
            ._target
            .GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .SingleOrDefault(method =>
                method.GetCustomAttribute<BindingCallbackAttribute>() != null &&
                method.Name == methodName && !method.GetParameters().Any());

        this._onTargetValueUpdating = onValueUpdating;
        this._onTargetValueUpdated = onValueUpdated;
        this._onTargetErrorEncountered = onErrorEncountered;
    }

    // TODO: Need to refactor and simplify this crusty implementation of property changed event handling!

    private async Task OnSourcePropertyChangedAsync(string propertyName)
    {
        if (this._sourceProperty.Name != propertyName)
        {
            return;
        }

        try
        {
            var value = this._sourceProperty.GetValue(this._source);
            this._targetProperty.SetValue(this._target, value);

            this._onSourceValueUpdating?.Invoke();

            if (this._targetCallbackMethod != null)
            {
                if (typeof(Task<CallbackResult>).IsAssignableFrom(this._targetCallbackMethod.ReturnType))
                {
                    var task = (Task<CallbackResult>)this._targetCallbackMethod.Invoke(this._target, null);

                    if (task != null)
                    {
                        var result = await task;

                        if (result.HasError)
                        {
                            this._onSourceErrorEncountered?.Invoke();
                            return;
                        }
                    }
                }
                else if (typeof(Task).IsAssignableFrom(this._targetCallbackMethod.ReturnType))
                {
                    var task = (Task)this._targetCallbackMethod.Invoke(this._target, null);

                    if (task != null)
                    {
                        await task;
                    }
                }
                else
                {
                    this._targetCallbackMethod.Invoke(this._target, null);
                }
            }

            this._onSourceValueUpdated?.Invoke();

            if (this._isCallbackInvokedBothWays)
            {
                await this.OnTargetPropertyChangedAsync(propertyName);
            }
        }
        catch (ValueUpdateException)
        {
            this._onSourceErrorEncountered?.Invoke();
        }
    }

    private async Task OnTargetPropertyChangedAsync(string propertyName)
    {
        if (this._targetProperty.Name != propertyName)
        {
            return;
        }

        try
        {
            var value = this._targetProperty.GetValue(this._target);
            this._sourceProperty.SetValue(this._source, value);

            this._onTargetValueUpdating?.Invoke();

            if (this._sourceCallbackMethod != null)
            {
                if (typeof(Task<CallbackResult>).IsAssignableFrom(this._sourceCallbackMethod.ReturnType))
                {
                    var task = (Task<CallbackResult>)this._sourceCallbackMethod.Invoke(this._source, null);

                    if (task != null)
                    {
                        var result = await task;

                        if (result.HasError)
                        {
                            this._onTargetErrorEncountered?.Invoke();
                            return;
                        }
                    }
                }
                else if (typeof(Task).IsAssignableFrom(this._sourceCallbackMethod.ReturnType))
                {
                    var task = (Task)this._sourceCallbackMethod.Invoke(this._source, null);

                    if (task != null)
                    {
                        await task;
                    }
                }
                else
                {
                    this._sourceCallbackMethod.Invoke(this._source, null);
                }
            }

            this._onTargetValueUpdated?.Invoke();

            if (this._isCallbackInvokedBothWays)
            {
                await this.OnSourcePropertyChangedAsync(propertyName);
            }
        }
        catch (ValueUpdateException)
        {
            this._onTargetErrorEncountered?.Invoke();
        }
    }
}