// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweWindowViewModel.cs" company="nGratis">
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
// <creation_timestamp>Friday, 30 November 2018 9:42:15 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Wpf;
using nGratis.Cop.Olympus.Wpf.Glue;
using ReactiveUI;

internal class AweWindowViewModel : ReactiveScreen
{
    private readonly ILogger _logger;

    public AweWindowViewModel(ILogger logger)
    {
        Guard
            .Require(logger, nameof(logger))
            .Is.Not.Null();

        this._logger = logger;

        this.SimulateStatusOneCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await this.SimulateStatusAsync("01");
        });

        this.SimulateStatusTwoCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await this.SimulateStatusAsync("02");
        });

        this.ThrowReactiveExceptionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await this.ThrowReactiveExceptionAsync();
        });

        this.ThrowApplicationExceptionCommand = RelayCommand.Create(this.ThrowApplicationException);
    }

    public ICommand SimulateStatusOneCommand { get; }

    public ICommand SimulateStatusTwoCommand { get; }

    public ICommand ThrowReactiveExceptionCommand { get; }

    public ICommand ThrowApplicationExceptionCommand { get; }

    private async Task SimulateStatusAsync(string key)
    {
        var random = new Random();

        await Task.Run(async () =>
        {
            foreach (var index in Enumerable.Range(1, 10))
            {
                this._logger.LogTrace($"Worker [{key}]: Checking event {index} of 10...");
                await Task.Delay(TimeSpan.FromMilliseconds(random.Next(100, 1000)));
            }
        });

        this._logger.LogInfo($"Worker [{key}]: Completed checking!");
    }

    private async Task ThrowReactiveExceptionAsync()
    {
        this._logger.LogInfo("Manager [X]: Monitoring workers!");

        await Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));

            throw new CopException("Workers are on strike!");
        });
    }

    private void ThrowApplicationException()
    {
        this._logger.LogInfo("Manager [Y]: Monitoring workers!");

        throw new CopException("Workers are running away!");
    }
}