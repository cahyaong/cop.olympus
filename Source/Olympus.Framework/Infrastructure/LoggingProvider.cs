// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingProvider.cs" company="nGratis">
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
// <creation_timestamp>Saturday, 25 April 2015 12:21:18 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework
{
    using System;
    using System.Collections.Concurrent;
    using nGratis.Cop.Olympus.Contract;

    internal class LoggingProvider : ILoggingProvider
    {
        private readonly LoggingModes _loggingModes;

        private readonly ConcurrentDictionary<string, ILogger> _loggerLookup;

        private readonly CompositeLogger _aggregatingLogger;

        private bool _isDisposed;

        public LoggingProvider(LoggingModes loggingModes)
        {
            Guard
                .Require(loggingModes, nameof(loggingModes))
                .Is.Not.EqualTo(LoggingModes.None);

            this._loggingModes = loggingModes;
            this._loggerLookup = new ConcurrentDictionary<string, ILogger>();
            this._aggregatingLogger = new CompositeLogger();
        }

        ~LoggingProvider()
        {
            this.Dispose(false);
        }

        public ILogger GetLoggerFor(string component = Constant.AggregatingComponent)
        {
            Guard
                .Require(component, nameof(component))
                .Is.Not.Empty();

            if (component == Constant.AggregatingComponent)
            {
                return this._aggregatingLogger;
            }

            var logger = this
                ._loggerLookup
                .GetOrAdd(component, _ => this.CreateLogger(component));

            this._aggregatingLogger.RegisterLoggers(logger);

            return logger;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private ILogger CreateLogger(string component = Text.Undefined)
        {
            var logger = new CompositeLogger();

            if (this._loggingModes.HasFlag(LoggingModes.CommunityOfPractice))
            {
                logger.RegisterLoggers(new CopLogger(component));
            }

            if (this._loggingModes.HasFlag(LoggingModes.NLogger))
            {
                logger.RegisterLoggers(new NLogger(component));
            }

            if (this._loggingModes.HasFlag(LoggingModes.Console))
            {
                logger.RegisterLoggers(new ConsoleLogger(component));
            }

            return logger;
        }

        private void Dispose(bool isDisposing)
        {
            if (this._isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                this._aggregatingLogger.Dispose();
            }

            this._isDisposed = true;
        }

        private static class Constant
        {
            internal const string AggregatingComponent = "*";
        }
    }
}