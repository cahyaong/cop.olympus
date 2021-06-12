// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerExtensions.Auto.cs" company="nGratis">
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

        public static void LogTraceWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Trace, message, details);
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

        public static void LogDebugWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Debug, message, details);
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

        public static void LogInfoWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Info, message, details);
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

        public static void LogWarningWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Warning, message, details);
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

        public static void LogErrorWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Error, message, details);
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

        public static void LogFatalWithDetails(
            this ILogger logger, 
            string message, 
            params (string Key, object Value)[] details)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.LogWithDetails(Verbosity.Fatal, message, details);
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