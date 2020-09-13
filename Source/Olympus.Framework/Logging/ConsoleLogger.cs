// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
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
// <creation_timestamp>Monday, 20 July 2015 2:25:29 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework
{
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
                : Text.Empty);

            submessages
                .Select(submessage => !string.IsNullOrEmpty(submessage)
                    ? submessage
                    : Text.Empty)
                .ForEach(submessage => messageBuilder.AppendFormat(
                    "{0}  |_ {1}",
                    Environment.NewLine,
                    submessage));

            this.Log(verbosity, messageBuilder.ToString());
        }
    }
}