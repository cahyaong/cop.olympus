// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductorBaseWithActiveItem.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
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
// <creation_timestamp>Thursday, September 3, 2020 2:16:25 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf.Glue
{
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
}