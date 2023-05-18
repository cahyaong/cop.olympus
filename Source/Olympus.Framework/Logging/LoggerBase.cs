// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerBase.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 27 April 2015 2:44:43 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nGratis.Cop.Olympus.Contract;

public abstract class LoggerBase : ILogger
{
    protected LoggerBase(string component)
    {
        Guard
            .Require(component, nameof(component))
            .Is.Not.Empty();

        this.Component = component;
    }

    protected internal LoggerBase()
        : this("[_MOCK_ID_]")
    {
        // NOTE: This constructor is required for creating a stub during unit testing!
    }

    ~LoggerBase()
    {
        this.Dispose(false);
    }

    public string Component { get; }

    public abstract void Log(Verbosity verbosity, string message);

    public virtual void Log(Verbosity verbosity, string message, params string[] submessages)
    {
        var messageBuilder = new StringBuilder(!string.IsNullOrEmpty(message)
            ? message
            : DefinedText.Empty);

        submessages
            .Select(submessage => !string.IsNullOrEmpty(submessage)
                ? submessage
                : DefinedText.Empty)
            .ForEach(submessage => messageBuilder.AppendFormat(
                "{0}  |_ {1}",
                Environment.NewLine,
                submessage));

        this.Log(verbosity, messageBuilder.ToString());
    }

    public abstract void Log(Verbosity verbosity, string message, Exception exception);

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool isDisposing)
    {
    }
}