// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopLogger.cs" company="nGratis">
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
                : Text.Empty
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
                : Text.Empty,
            Submessages = submessages
                .Select(submessage => !string.IsNullOrEmpty(submessage)
                    ? submessage
                    : Text.Empty)
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
                : Text.Empty
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