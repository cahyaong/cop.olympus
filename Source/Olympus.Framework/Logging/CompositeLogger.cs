// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeLogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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