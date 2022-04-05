// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveCaliburnViewModel.cs" company="nGratis">
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
// <creation_timestamp>Thursday, September 3, 2020 6:07:11 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using System.Threading;
using System.Threading.Tasks;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Wpf.Glue;

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