// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerbosityExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 1:23:52 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace nGratis.Cop.Olympus.Contract;

using System;
using NLog;

internal static class VerbosityExtensions
{
    public static LogLevel ToLogLevel(this Verbosity verbosity)
    {
        Guard
            .Require(verbosity, nameof(verbosity))
            .Is.Not.EqualTo(Verbosity.None);

        return verbosity switch
        {
            Verbosity.Trace => LogLevel.Trace,
            Verbosity.Debug => LogLevel.Debug,
            Verbosity.Info => LogLevel.Info,
            Verbosity.Warning => LogLevel.Warn,
            Verbosity.Error => LogLevel.Error,
            Verbosity.Fatal => LogLevel.Fatal,
            _ => throw new NotSupportedException($"Verbosity [{verbosity}] is not supported.")
        };
    }

    public static string ToConsoleText(this Verbosity verbosity)
    {
        Guard
            .Require(verbosity, nameof(verbosity))
            .Is.Not.EqualTo(Verbosity.None);

        return verbosity switch
        {
            Verbosity.Trace => "TRC",
            Verbosity.Debug => "DBG",
            Verbosity.Info => "INF",
            Verbosity.Warning => "WRN",
            Verbosity.Error => "ERR",
            Verbosity.Fatal => "FTL",
            _ => throw new NotSupportedException($"Verbosity [{verbosity}] is not supported.")
        };
    }
}