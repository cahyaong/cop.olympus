// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 20 July 2015 2:25:29 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using nGratis.Cop.Olympus.Contract;

public class ConsoleLogger : LoggerBase
{
    public ConsoleLogger(string component)
        : base(component)
    {
        Guard
            .Require(component, nameof(component))
            .Is.Not.Empty();
    }

    public override void Log(Verbosity verbosity, [Localizable(false)] string message)
    {
        var line = $"{DateTimeOffset.Now:s} | {verbosity.ToConsoleText()} | {message}";

        Console.WriteLine(line);
    }

    public override void Log(Verbosity verbosity, [Localizable(false)] string message, Exception exception)
    {
        var line = $"{DateTimeOffset.Now:s} | {verbosity.ToConsoleText()} | {message} {exception.Message}";

        Console.WriteLine(line);
    }

    public override void Log(Verbosity verbosity, string message, params string[] submessages)
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
}