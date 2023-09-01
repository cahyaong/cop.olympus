// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductorBase.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, August 30, 2020 3:59:19 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf.Glue;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

public abstract class ReactiveConductorBase<T> : ReactiveScreen, IConductor, IParent<T>
    where T : class
{
    private ICloseStrategy<T> _closingStrategy;

    public ICloseStrategy<T> ClosingStrategy
    {
        get => this._closingStrategy ??= new DefaultCloseStrategy<T>();
        set => this._closingStrategy = value;
    }

    public event EventHandler<ActivationProcessedEventArgs> ActivationProcessed;

    public abstract IEnumerable<T> GetChildren();

    IEnumerable IParent.GetChildren()
    {
        return this.GetChildren();
    }

    public abstract Task ActivateItemAsync(T item, CancellationToken cancellationToken);

    async Task IConductor.ActivateItemAsync(object item, CancellationToken cancellationToken)
    {
        await this.ActivateItemAsync((T)item, cancellationToken);
    }

    public abstract Task DeactivateItemAsync(T item, bool isClosed, CancellationToken cancellationToken);

    async Task IConductor.DeactivateItemAsync(object item, bool isClosed, CancellationToken cancellationToken)
    {
        await this.DeactivateItemAsync((T)item, isClosed, cancellationToken);
    }

    protected void RaisedActivationProcessed(T item, bool isSuccessful)
    {
        if (item == null)
        {
            return;
        }

        var args = new ActivationProcessedEventArgs
        {
            Item = item,
            Success = isSuccessful
        };

        this.ActivationProcessed?.Invoke(this, args);
    }

    protected virtual T EnsureItem(T item)
    {
        if (item is IChild child && child.Parent != this)
        {
            child.Parent = this;
        }

        return item;
    }
}