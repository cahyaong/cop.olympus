// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductor.cs" company="nGratis">
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
// <creation_timestamp>Thursday, September 3, 2020 2:27:53 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf.Glue
{
    using System.Collections.Generic;
    using System.Reactive.Concurrency;
    using System.Threading;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using ReactiveUI;

    public partial class ReactiveConductor<T> : ReactiveConductorBaseWithActiveItem<T>
        where T : class
    {
        public override IEnumerable<T> GetChildren()
        {
            yield return this.ActiveItem;
        }

        public override async Task ActivateItemAsync(T item, CancellationToken cancellationToken)
        {
            if (item != null && item == this.ActiveItem)
            {
                if (this.IsActive)
                {
                    await ScreenExtensions.TryActivateAsync(item, cancellationToken);
                    this.RaisedActivationProcessed(item, true);

                    return;
                }
            }

            var closingResult = await this.ClosingStrategy.ExecuteAsync(new[] { this.ActiveItem }, cancellationToken);

            if (closingResult.CloseCanOccur)
            {
                await this.ChangeActiveItemAsync(item, true, cancellationToken);
            }
            else
            {
                this.RaisedActivationProcessed(item, false);
            }
        }

        public override async Task DeactivateItemAsync(T item, bool isClosed, CancellationToken cancellationToken)
        {
            if (item == null || item != this.ActiveItem)
            {
                return;
            }

            var closingResult = await this.ClosingStrategy.ExecuteAsync(
                new[] { this.ActiveItem },
                CancellationToken.None);

            if (closingResult.CloseCanOccur)
            {
                await this.ChangeActiveItemAsync(default, isClosed, cancellationToken);
            }
        }

        public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken)
        {
            var closingResult = await this.ClosingStrategy.ExecuteAsync(new[] { this.ActiveItem }, cancellationToken);

            return closingResult.CloseCanOccur;
        }

        public override async Task TryCloseAsync(bool? dialogResult)
        {
            if (this.Parent is IConductor conductor)
            {
                await conductor.CloseItemAsync(this, CancellationToken.None);
            }

            var closeAsync = PlatformProvider.Current.GetViewCloseAction(this, this.Views.Values, dialogResult);

            RxApp.MainThreadScheduler.Schedule(async () => await closeAsync(CancellationToken.None));
        }

        protected override Task ActivateCoreAsync(CancellationToken cancellationToken)
        {
            return ScreenExtensions.TryActivateAsync(this.ActiveItem, cancellationToken);
        }

        protected override Task DeactivateCoreAsync(bool isClosed, CancellationToken cancellationToken)
        {
            return ScreenExtensions.TryDeactivateAsync(this.ActiveItem, isClosed, cancellationToken);
        }
    }
}