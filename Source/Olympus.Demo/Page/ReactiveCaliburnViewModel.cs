// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveCaliburnViewModel.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 6:07:11 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using System.Threading;
using System.Threading.Tasks;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.UI.Wpf.Glue;

public class ReactiveCaliburnViewModel : ReactiveScreen
{
    private readonly ILogger _logger;

    public ReactiveCaliburnViewModel(ILogger logger)
    {
        Guard
            .Require(logger, nameof(logger))
            .Is.Not.Null();

        this._logger = logger;
    }

    protected override async Task ActivateCoreAsync(CancellationToken cancellationToken)
    {
        this._logger.Log(Verbosity.Info, "Activating <Reactive.Caliburn> screen...");

        await Task.CompletedTask;
    }

    protected override async Task DeactivateCoreAsync(bool isClosed, CancellationToken cancellationToken)
    {
        this._logger.Log(Verbosity.Info, "Deactivating <Reactive.Caliburn> screen...");

        await Task.CompletedTask;
    }
}