// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerExtensions.Auto.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, June 12, 2021 5:53:55 PM UTC</creation_timestamp>
// <remark>
//
//     _  _   _ _____ ___       ___ ___ _  _ ___ ___    _ _____ ___ ___    _____ _ _  
//    /_\| | | |_   _/ _ \ ___ / __| __| \| | __| _ \  /_\_   _| __|   \  |_   _| | | 
//   / _ \ |_| | | || (_) |___| (_ | _|| .` | _||   / / _ \| | | _|| |) |   | | |_  _|
//  /_/ \_\___/  |_| \___/     \___|___|_|\_|___|_|_\/_/ \_\_| |___|___/    |_|   |_| 
//
// </remark>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace nGratis.Cop.Olympus.Contract
{
    using System;

    public static partial class LoggerExtensions
    {
        public static void LogTrace(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Trace, message);
        }

        public static void LogTrace(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Trace, message, submessages);
        }

        public static void LogTrace(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Trace, message, details);
        }

        public static void LogDebug(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Debug, message);
        }

        public static void LogDebug(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Debug, message, submessages);
        }

        public static void LogDebug(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Debug, message, details);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Info, message);
        }

        public static void LogInfo(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Info, message, submessages);
        }

        public static void LogInfo(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Info, message, details);
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Warning, message);
        }

        public static void LogWarning(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Warning, message, submessages);
        }

        public static void LogWarning(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Warning, message, details);
        }

        public static void LogError(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Error, message);
        }

        public static void LogError(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Error, message, submessages);
        }

        public static void LogError(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Error, message, details);
        }

        public static void LogError(this ILogger logger, string message, Exception exception)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Error, message, exception);
        }

        public static void LogFatal(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Fatal, message);
        }

        public static void LogFatal(this ILogger logger, string message, params string[] submessages)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Fatal, message, submessages);
        }

        public static void LogFatal(this ILogger logger, string message, params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Fatal, message, details);
        }

        public static void LogFatal(this ILogger logger, string message, Exception exception)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Fatal, message, exception);
        }

    }
}