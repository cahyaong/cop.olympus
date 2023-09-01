// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveConductor.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 2:27:53 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf.Glue;

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