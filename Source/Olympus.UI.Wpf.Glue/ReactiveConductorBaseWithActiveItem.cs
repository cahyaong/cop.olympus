// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductorBaseWithActiveItem.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 2:16:25 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf.Glue;

using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using ReactiveUI;

public abstract class ReactiveConductorBaseWithActiveItem<T> : ReactiveConductorBase<T>, IConductActiveItem
    where T : class
{
    private T _activeItem;

    public T ActiveItem
    {
        get => this._activeItem;
        set => this.ActivateItemAsync(value, CancellationToken.None);
    }

    object IHaveActiveItem.ActiveItem
    {
        get => this.ActiveItem;
        set => this.ActiveItem = (T)value;
    }

    protected virtual async Task ChangeActiveItemAsync(
        T item,
        bool isClosingCurrent,
        CancellationToken cancellationToken)
    {
        await ScreenExtensions.TryDeactivateAsync(this._activeItem, isClosingCurrent, cancellationToken);

        item = this.EnsureItem(item);
        this.RaiseAndSetIfChanged(ref this._activeItem, item, nameof(this.ActiveItem));

        if (this.IsActive)
        {
            await ScreenExtensions.TryActivateAsync(item, cancellationToken);
        }

        this.RaisedActivationProcessed(this._activeItem, true);
    }
}