// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingEntry.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 27 April 2015 1:53:07 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class LoggingEntry
{
    public LoggingEntry()
    {
        this.Timestamp = DateTimeOffset.UtcNow;
        this.Component = DefinedText.Unknown;
        this.Verbosity = Verbosity.None;
        this.Exception = null;
        this.Message = string.Empty;
        this.Submessages = Enumerable.Empty<string>();
    }

    public DateTimeOffset Timestamp { get; set; }

    public string Component { get; set; }

    public Verbosity Verbosity { get; set; }

    public Exception Exception { get; set; }

    public string Message { get; set; }

    public IEnumerable<string> Submessages { get; set; }
}