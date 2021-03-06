﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerExtensions.cs" company="nGratis">
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
// <creation_timestamp>Saturday, 25 April 2015 11:48:09 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace nGratis.Cop.Olympus.Contract
{
    using System;
    using System.ComponentModel;

    public static class LoggerExtensions
    {
        public static void LogTrace(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Trace, message);
        }

        public static void LogDebug(this ILogger logger, [Localizable(false)] string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Debug, message);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Info, message);
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Warning, message);
        }

        public static void LogError(this ILogger logger, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Error, message);
        }

        public static void LogFatal(this ILogger logger, Exception exception, string message)
        {
            Guard
                .Require(logger, nameof(logger))
                .Is.Not.Null();

            logger.Log(Verbosity.Fatal, message, exception);
        }
    }
}