// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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

namespace nGratis.Cop.Core
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using JetBrains.Annotations;
    using nGratis.Cop.Core.Contract;

    public static class LoggerExtensions
    {
        public static void LogAsTrace(this ILogger logger, string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Trace, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsTrace(this ILogger logger, string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Trace, string.Format(CultureInfo.CurrentUICulture, format, args));
        }

        public static void LogAsDebug(this ILogger logger, [Localizable(false)] string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Debug, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsDebug(this ILogger logger, [Localizable(false)] string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Debug, string.Format(CultureInfo.CurrentUICulture, format, args));
        }

        public static void LogAsInformation(this ILogger logger, string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Information, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsInformation(this ILogger logger, string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Information, string.Format(CultureInfo.CurrentUICulture, format, args));
        }

        public static void LogAsWarning(this ILogger logger, string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Warning, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsWarning(this ILogger logger, string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Warning, string.Format(CultureInfo.CurrentUICulture, format, args));
        }

        public static void LogAsError(this ILogger logger, string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Error, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsError(this ILogger logger, string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Error, string.Format(CultureInfo.CurrentUICulture, format, args));
        }

        public static void LogAsFatal(this ILogger logger, Exception exception, string message)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Fatal, exception, message);
        }

        [StringFormatMethod("format")]
        public static void LogAsFatal(this ILogger logger, Exception exception, string format, params object[] args)
        {
            Guard.Require.IsNotNull(logger);

            logger.LogWith(Verbosity.Fatal, exception, string.Format(CultureInfo.CurrentUICulture, format, args));
        }
    }
}