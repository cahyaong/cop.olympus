// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoidLogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 1 May 2015 1:44:25 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Reactive.Subjects;
using nGratis.Cop.Olympus.Contract;

public sealed class VoidLogger : LoggerBase, ILoggingNotifier
{
    private VoidLogger()
        : base(DefinedText.Void)
    {
        this.WhenEntryAdded = new Subject<LoggingEntry>();
    }

    public static VoidLogger Instance { get; } = new();

    public IObservable<LoggingEntry> WhenEntryAdded { get; }

    public override void Log(Verbosity verbosity, string message)
    {
    }

    public override void Log(Verbosity verbosity, string message, Exception exception)
    {
    }
}