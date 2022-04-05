// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductorBase.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
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
// <creation_timestamp>Sunday, August 30, 2020 3:59:19 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf.Glue;

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