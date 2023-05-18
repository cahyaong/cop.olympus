// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopLogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 20 July 2015 1:58:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Linq;
using System.Reactive.Subjects;
using nGratis.Cop.Olympus.Contract;

public sealed class CopLogger : LoggerBase, ILoggingNotifier
{
    private readonly ReplaySubject<LoggingEntry> _whenEntryBuffered;

    private bool _isDisposed;

    public CopLogger(string component)
        : base(component)
    {
        Guard
            .Require(component, nameof(component))
            .Is.Not.Empty();

        this._whenEntryBuffered = new ReplaySubject<LoggingEntry>();
    }

    public IObservable<LoggingEntry> WhenEntryAdded => this._whenEntryBuffered;

    public override void Log(Verbosity verbosity, string message)
    {
        var entry = new LoggingEntry
        {
            Component = this.Component,
            Verbosity = verbosity,
            Message = !string.IsNullOrEmpty(message)
                ? message
                : DefinedText.Empty
        };

        this._whenEntryBuffered.OnNext(entry);
    }

    public override void Log(Verbosity verbosity, string message, params string[] submessages)
    {
        var entry = new LoggingEntry
        {
            Component = this.Component,
            Verbosity = verbosity,
            Message = !string.IsNullOrEmpty(message)
                ? message
                : DefinedText.Empty,
            Submessages = submessages
                .Select(submessage => !string.IsNullOrEmpty(submessage)
                    ? submessage
                    : DefinedText.Empty)
                .ToArray()
        };

        this._whenEntryBuffered.OnNext(entry);
    }

    public override void Log(Verbosity verbosity, string message, Exception exception)
    {
        var entry = new LoggingEntry
        {
            Component = this.Component,
            Verbosity = verbosity,
            Exception = exception,
            Message = !string.IsNullOrEmpty(message)
                ? message
                : DefinedText.Empty
        };

        this._whenEntryBuffered.OnNext(entry);
    }

    protected override void Dispose(bool isDisposing)
    {
        if (this._isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            this._whenEntryBuffered.Dispose();
        }

        base.Dispose(isDisposing);

        this._isDisposed = true;
    }
}