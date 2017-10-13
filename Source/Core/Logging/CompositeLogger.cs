// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeLogger.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 29 April 2015 1:41:08 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using nGratis.Cop.Core.Contract;

    public class CompositeLogger : BaseLogger
    {
        private readonly ConcurrentDictionary<string, ILogger> loggerLookup =
            new ConcurrentDictionary<string, ILogger>();

        private bool isDisposed;

        public CompositeLogger(string id)
            : base(id)
        {
        }

        public override IEnumerable<string> Components
        {
            get
            {
                return this
                    .loggerLookup.Values
                    .SelectMany(logger => logger.Components)
                    .Distinct();
            }
        }

        public void RegisterLoggers(params ILogger[] loggers)
        {
            Guard.Require.IsNotNull(loggers);

            loggers
                .Select(logger => new
                {
                    Key = $"{logger.Id}.{logger.GetType().Name}",
                    Logger = logger
                })
                .Where(anon => !this.loggerLookup.ContainsKey(anon.Key))
                .ForEach(anon =>
                {
                    this.loggerLookup.TryAdd(anon.Key, anon.Logger);

                    if (!(anon.Logger is CompositeLogger))
                    {
                        anon.Logger.LogAsDebug("Registered to composite logger.");
                    }
                });
        }

        public void UnregisterLoggers(params ILogger[] loggers)
        {
            Guard.Require.IsNotNull(loggers);
            Guard.Require.IsNotNull(loggers);

            loggers
                .Select(logger => new
                {
                    Key = $"{logger.Id}.{logger.GetType().Name}",
                    Logger = logger
                })
                .Where(anon => this.loggerLookup.ContainsKey(anon.Key))
                .ForEach(anon =>
                {
                    this.loggerLookup.TryRemove(anon.Key, out ILogger logger);

                    if (!(logger is CompositeLogger))
                    {
                        logger.LogAsDebug("Unregistered from composite logger.");
                    }
                });
        }

        public override void LogWith(Verbosity verbosity, string message)
        {
            this
                .loggerLookup
                .Values
                .ForEach(logger => logger.LogWith(verbosity, message));
        }

        public override void LogWith(Verbosity verbosity, Exception exception, string message)
        {
            this
                .loggerLookup
                .Values
                .ForEach(logger => logger.LogWith(verbosity, exception, message));
        }

        public override IObservable<LogEntry> AsObservable()
        {
            return this
                .loggerLookup
                .Values
                .Select(logger => logger.AsObservable())
                .Merge();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                this
                    .loggerLookup
                    .Values
                    .ForEach(logger => logger.Dispose());
            }

            base.Dispose(isDisposing);

            this.isDisposed = true;
        }
    }
}