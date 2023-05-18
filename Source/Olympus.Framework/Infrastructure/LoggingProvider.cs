// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 12:21:18 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Concurrent;
using nGratis.Cop.Olympus.Contract;

internal class LoggingProvider : ILoggingProvider
{
    private readonly LoggingModes _loggingModes;

    private readonly ConcurrentDictionary<string, ILogger> _loggerLookup;

    private readonly CompositeLogger _aggregatingLogger;

    private bool _isDisposed;

    public LoggingProvider(LoggingModes loggingModes)
    {
        Guard
            .Require(loggingModes, nameof(loggingModes))
            .Is.Not.EqualTo(LoggingModes.None);

        this._loggingModes = loggingModes;
        this._loggerLookup = new ConcurrentDictionary<string, ILogger>();
        this._aggregatingLogger = new CompositeLogger();
    }

    ~LoggingProvider()
    {
        this.Dispose(false);
    }

    public ILogger GetLoggerFor(string component = Constant.AggregatingComponent)
    {
        Guard
            .Require(component, nameof(component))
            .Is.Not.Empty();

        if (component == Constant.AggregatingComponent)
        {
            return this._aggregatingLogger;
        }

        var logger = this
            ._loggerLookup
            .GetOrAdd(component, _ => this.CreateLogger(component));

        this._aggregatingLogger.RegisterLogger(logger);

        return logger;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    private ILogger CreateLogger(string component = DefinedText.Unknown)
    {
        var logger = new CompositeLogger();

        if (this._loggingModes.HasFlag(LoggingModes.CommunityOfPractice))
        {
            logger.RegisterLogger(new CopLogger(component));
        }

        if (this._loggingModes.HasFlag(LoggingModes.NLogger))
        {
            logger.RegisterLogger(new NLogger(component));
        }

        if (this._loggingModes.HasFlag(LoggingModes.Console))
        {
            logger.RegisterLogger(new ConsoleLogger(component));
        }

        return logger;
    }

    private void Dispose(bool isDisposing)
    {
        if (this._isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            this._aggregatingLogger.Dispose();
        }

        this._isDisposed = true;
    }

    private static class Constant
    {
        internal const string AggregatingComponent = "*";
    }
}