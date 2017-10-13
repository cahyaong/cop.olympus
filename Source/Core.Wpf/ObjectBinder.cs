// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectBinder.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </copyright>
// <author>Cahya Ong - cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using nGratis.Cop.Core.Contract;

    public sealed class ObjectBinder
    {
        private readonly INotifyPropertyChanged source;

        private readonly INotifyPropertyChanged target;

        private readonly PropertyInfo sourceProperty;

        private readonly PropertyInfo targetProperty;

        private readonly bool isCallbackInvokedBothWays;

        private MethodInfo sourceCallbackMethod;

        private MethodInfo targetCallbackMethod;

        private Action onSourceValueUpdated;

        private Action onSourceValueUpdating;

        private Action onTargetValueUpdating;

        private Action onTargetValueUpdated;

        private Action onSourceErrorEncountered;

        private Action onTargetErrorEncountered;

        public ObjectBinder(
            INotifyPropertyChanged source,
            PropertyInfo sourceProperty,
            INotifyPropertyChanged target,
            PropertyInfo targetProperty,
            bool isCallbackInvokedBothWays = true)
        {
            Guard.Require.IsNotNull(source);
            Guard.Require.IsNotNull(sourceProperty);
            Guard.Require.IsNotNull(target);
            Guard.Require.IsNotNull(targetProperty);

            this.source = source;
            this.target = target;
            this.sourceProperty = sourceProperty;
            this.targetProperty = targetProperty;
            this.isCallbackInvokedBothWays = isCallbackInvokedBothWays;

            source.PropertyChanged += async (_, args) => await this.OnSourcePropertyChangedAsync(args.PropertyName);
            target.PropertyChanged += async (_, args) => await this.OnTargetPropertyChangedAsync(args.PropertyName);
        }

        public void BindSourceCallback(
            Action onValueUpdating = null,
            Action onValueUpdated = null,
            Action onErrorEncountered = null)
        {
            var methodName = $"On{this.sourceProperty.Name}Changed";

            this.sourceCallbackMethod = this
                .source
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .SingleOrDefault(method =>
                    method.GetCustomAttribute<AsFieldCallbackAttribute>() != null &&
                    method.Name == methodName && !method.GetParameters().Any());

            this.onSourceValueUpdating = onValueUpdating;
            this.onSourceValueUpdated = onValueUpdated;
            this.onSourceErrorEncountered = onErrorEncountered;
        }

        public void BindTargetCallback(
            Action onValueUpdating = null,
            Action onValueUpdated = null,
            Action onErrorEncountered = null)
        {
            var methodName = $"On{this.sourceProperty.Name}Changed";

            this.targetCallbackMethod = this
                .target
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .SingleOrDefault(method =>
                    method.GetCustomAttribute<AsFieldCallbackAttribute>() != null &&
                    method.Name == methodName && !method.GetParameters().Any());

            this.onTargetValueUpdating = onValueUpdating;
            this.onTargetValueUpdated = onValueUpdated;
            this.onTargetErrorEncountered = onErrorEncountered;
        }

        private async Task OnSourcePropertyChangedAsync(string propertyName)
        {
            if (this.sourceProperty.Name != propertyName)
            {
                return;
            }

            try
            {
                var value = this.sourceProperty.GetValue(this.source);
                this.targetProperty.SetValue(this.target, value);

                this.onSourceValueUpdating?.Invoke();

                if (this.targetCallbackMethod != null)
                {
                    if (typeof(Task<CallbackResult>).IsAssignableFrom(this.targetCallbackMethod.ReturnType))
                    {
                        var result = await (Task<CallbackResult>)this.targetCallbackMethod.Invoke(this.target, null);

                        if (result.HasError)
                        {
                            this.onSourceErrorEncountered?.Invoke();
                            return;
                        }
                    }
                    else if (typeof(Task).IsAssignableFrom(this.targetCallbackMethod.ReturnType))
                    {
                        await (Task)this.targetCallbackMethod.Invoke(this.target, null);
                    }
                    else
                    {
                        this.targetCallbackMethod.Invoke(this.target, null);
                    }
                }

                this.onSourceValueUpdated?.Invoke();

                if (this.isCallbackInvokedBothWays)
                {
                    await this.OnTargetPropertyChangedAsync(propertyName);
                }
            }
            catch (ValueUpdateException)
            {
                this.onSourceErrorEncountered?.Invoke();
            }
        }

        private async Task OnTargetPropertyChangedAsync(string propertyName)
        {
            if (this.targetProperty.Name != propertyName)
            {
                return;
            }

            try
            {
                var value = this.targetProperty.GetValue(this.target);
                this.sourceProperty.SetValue(this.source, value);

                this.onTargetValueUpdating?.Invoke();

                if (this.sourceCallbackMethod != null)
                {
                    if (typeof(Task<CallbackResult>).IsAssignableFrom(this.sourceCallbackMethod.ReturnType))
                    {
                        var result = await (Task<CallbackResult>)this.sourceCallbackMethod.Invoke(this.source, null);

                        if (result.HasError)
                        {
                            this.onTargetErrorEncountered?.Invoke();
                            return;
                        }
                    }
                    else if (typeof(Task).IsAssignableFrom(this.sourceCallbackMethod.ReturnType))
                    {
                        await (Task)this.sourceCallbackMethod.Invoke(this.source, null);
                    }
                    else
                    {
                        this.sourceCallbackMethod.Invoke(this.source, null);
                    }
                }

                this.onTargetValueUpdated?.Invoke();

                if (this.isCallbackInvokedBothWays)
                {
                    await this.OnSourcePropertyChangedAsync(propertyName);
                }
            }
            catch (ValueUpdateException)
            {
                this.onTargetErrorEncountered?.Invoke();
            }
        }
    }
}