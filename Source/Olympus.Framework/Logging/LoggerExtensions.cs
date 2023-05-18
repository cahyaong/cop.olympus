// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 11:48:09 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace nGratis.Cop.Olympus.Contract;

using System.Linq;

public static partial class LoggerExtensions
{
    public static void Log(
        this ILogger logger,
        Verbosity verbosity,
        string message,
        params (string Key, object Value)[] details)
    {
        Guard
            .Require(logger, nameof(logger))
            .Is.Not.Null();

        Guard
            .Require(details, nameof(details))
            .Is.Not.Empty();

        var submessages = details
            .Select(detail => new
            {
                Key = !string.IsNullOrEmpty(detail.Key) ? detail.Key : DefinedText.Unknown,
                Value = detail.Value?.ToString() ?? DefinedText.Unknown,
            })
            .Select(anon => $"{anon.Key}: [{anon.Value}]")
            .ToArray();

        logger.Log(verbosity, message, submessages);
    }
}