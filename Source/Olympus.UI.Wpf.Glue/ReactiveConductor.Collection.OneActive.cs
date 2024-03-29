﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductor.Collection.OneActive.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 5:00:31 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf.Glue;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

public partial class ReactiveConductor<T>
{
    public class Collection
    {
        public class OneActive : ReactiveConductorBaseWithActiveItem<T>
        {
            private readonly BindableCollection<T> _items;

            public OneActive()
            {
                this._items = new BindableCollection<T>();
                this._items.CollectionChanged += this.OnItemsChanged;
            }

            public IObservableCollection<T> Items => this._items;

            public override IEnumerable<T> GetChildren() => this._items;

            public override async Task ActivateItemAsync(T item, CancellationToken cancellationToken)
            {
                if (item != null && item == this.ActiveItem)
                {
                    if (this.IsActive)
                    {
                        await ScreenExtensions.TryActivateAsync(item, cancellationToken);
                        this.RaisedActivationProcessed(item, true);
                    }

                    return;
                }

                await this.ChangeActiveItemAsync(item, false, cancellationToken);
            }

            public override async Task DeactivateItemAsync(T item, bool isClosed, CancellationToken cancellationToken)
            {
                if (item == null)
                {
                    return;
                }

                if (!isClosed)
                {
                    await ScreenExtensions.TryDeactivateAsync(item, false, cancellationToken);
                }
                else
                {
                    var closingResult = await this.ClosingStrategy.ExecuteAsync(
                        new[] { item },
                        CancellationToken.None);

                    if (closingResult.CloseCanOccur)
                    {
                        if (item == this.ActiveItem)
                        {
                            var index = this._items.IndexOf(item);

                            await this.ChangeActiveItemAsync(
                                OneActive.DetermineNextItemToActivate(this._items, index),
                                true,
                                cancellationToken);
                        }
                        else
                        {
                            await ScreenExtensions.TryDeactivateAsync(item, true, cancellationToken);
                        }

                        this._items.Remove(item);
                    }
                }
            }

            public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken)
            {
                var closingResult = await this.ClosingStrategy.ExecuteAsync(this._items, cancellationToken);

                if (!closingResult.CloseCanOccur && closingResult.Children.Any())
                {
                    var closingItems = closingResult
                        .Children?
                        .ToList();

                    if (closingItems.Contains(this.ActiveItem))
                    {
                        var items = this._items.ToList();
                        var nextItem = this.ActiveItem;

                        do
                        {
                            var previousItem = nextItem;

                            nextItem = OneActive.DetermineNextItemToActivate(items, items.IndexOf(previousItem));
                            items.Remove(previousItem);
                        }
                        while (closingItems.Contains(nextItem));

                        var previousActiveItem = this.ActiveItem;

                        await this.ChangeActiveItemAsync(nextItem, true, CancellationToken.None);

                        this._items.Remove(previousActiveItem);
                        closingItems.Remove(previousActiveItem);
                    }

                    closingItems
                        .OfType<IDeactivate>()
                        .Apply(async item => await item.DeactivateAsync(true, cancellationToken));

                    this._items.RemoveRange(closingItems);
                }

                return closingResult.CloseCanOccur;
            }

            protected override async Task ActivateCoreAsync(CancellationToken cancellationToken)
            {
                await ScreenExtensions.TryActivateAsync(this.ActiveItem, cancellationToken);
            }

            protected override async Task DeactivateCoreAsync(bool isClosed, CancellationToken cancellationToken)
            {
                if (isClosed)
                {
                    this._items
                        .OfType<IDeactivate>()
                        .Apply(async item => await item.DeactivateAsync(true, cancellationToken));

                    this._items.Clear();
                }
                else
                {
                    await ScreenExtensions.TryDeactivateAsync(this.ActiveItem, false, cancellationToken);
                }
            }

            protected override T EnsureItem(T item)
            {
                if (item == null)
                {
                    item = OneActive.DetermineNextItemToActivate(
                        this._items,
                        this.ActiveItem != null ? this._items.IndexOf(this.ActiveItem) : 0);
                }
                else
                {
                    var index = this._items.IndexOf(item);

                    if (index <= -1)
                    {
                        this._items.Add(item);
                    }
                }

                return base.EnsureItem(item);
            }

            private static T DetermineNextItemToActivate(IReadOnlyList<T> items, int index)
            {
                var removalIndex = index - 1;

                if (removalIndex <= -1 && items.Count > 1)
                {
                    return items[1];
                }

                if (removalIndex > -1 && removalIndex < items.Count - 1)
                {
                    return items[removalIndex];
                }

                return default;
            }

            private void OnItemsChanged(object _, NotifyCollectionChangedEventArgs args)
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    {
                        args.NewItems?
                            .OfType<IChild>()
                            .Apply(child => child.Parent = this);

                        break;
                    }

                    case NotifyCollectionChangedAction.Remove:
                    {
                        args.OldItems?
                            .OfType<IChild>()
                            .Apply(child => child.Parent = null);

                        break;
                    }

                    case NotifyCollectionChangedAction.Replace:
                    {
                        args.NewItems?
                            .OfType<IChild>()
                            .Apply(child => child.Parent = this);

                        args.OldItems?
                            .OfType<IChild>()
                            .Apply(child => child.Parent = null);

                        break;
                    }

                    case NotifyCollectionChangedAction.Reset:
                    {
                        this._items
                            .OfType<IChild>()
                            .Apply(child => child.Parent = this);

                        break;
                    }
                }
            }
        }
    }
}