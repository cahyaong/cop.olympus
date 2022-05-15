// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeLogger.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 29 April 2015 1:41:08 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using nGratis.Cop.Olympus.Contract;

public class CompositeLogger : LoggerBase
{
    private readonly ConcurrentDictionary<string, ILogger> _loggerLookup;

    private bool _isDisposed;

    public CompositeLogger()
        : base("Composite")
    {
        this._loggerLookup = new ConcurrentDictionary<string, ILogger>();
    }

    public void RegisterLogger(params ILogger[] loggers)
    {
        Guard
            .Require(loggers, nameof(loggers))
            .Is.Not.Null();

        loggers
            .Where(logger => logger != null)
            .Select(logger => new
            {
                Key = $"{this.Component}.{logger.Component}",
                Logger = logger
            })
            .Where(anon => !this._loggerLookup.ContainsKey(anon.Key))
            .ForEach(anon =>
            {
                this._loggerLookup.TryAdd(anon.Key, anon.Logger);

                if (anon.Logger is not CompositeLogger)
                {
                    anon.Logger.LogDebug("Registered to composite logger.");
                }
            });
    }

    public void UnregisterLogger(params ILogger[] loggers)
    {
        Guard
            .Require(loggers, nameof(loggers))
            .Is.Not.Null();

        loggers
            .Where(logger => logger != null)
            .Select(logger => new
            {
                Key = $"{this.Component}.{logger.Component}",
                Logger = logger
            })
            .Where(anon => this._loggerLookup.ContainsKey(anon.Key))
            .ForEach(anon =>
            {
                this._loggerLookup.TryRemove(anon.Key, out var logger);

                if (logger is not CompositeLogger)
                {
                    logger.LogDebug("Unregistered from composite logger.");
                }
            });
    }

    public override void Log(Verbosity verbosity, string message)
    {
        this
            ._loggerLookup.Values
            .ForEach(logger => logger.Log(verbosity, message));
    }

    public override void Log(Verbosity verbosity, string message, params string[] submessages)
    {
        this
            ._loggerLookup.Values
            .ForEach(logger => logger.Log(verbosity, message, submessages));
    }

    public override void Log(Verbosity verbosity, string message, Exception exception)
    {
        this
            ._loggerLookup.Values
            .ForEach(logger => logger.Log(verbosity, message, exception));
    }

    protected override void Dispose(bool isDisposing)
    {
        if (this._isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            this
                ._loggerLookup.Values
                .ForEach(logger => logger.Dispose());
        }

        base.Dispose(isDisposing);

        this._isDisposed = true;
    }
}