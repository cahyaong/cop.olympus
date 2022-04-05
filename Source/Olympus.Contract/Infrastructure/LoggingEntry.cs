// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingEntry.cs" company="nGratis">
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
// <creation_timestamp>Monday, 27 April 2015 1:53:07 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class LoggingEntry
{
    public LoggingEntry()
    {
        this.Timestamp = DateTimeOffset.UtcNow;
        this.Component = Text.Undefined;
        this.Verbosity = Verbosity.None;
        this.Exception = null;
        this.Message = string.Empty;
        this.Submessages = Enumerable.Empty<string>();
    }

    public DateTimeOffset Timestamp { get; set; }

    public string Component { get; set; }

    public Verbosity Verbosity { get; set; }

    public Exception Exception { get; set; }

    public string Message { get; set; }

    public IEnumerable<string> Submessages { get; set; }
}