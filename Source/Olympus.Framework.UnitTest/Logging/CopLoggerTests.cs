// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopLoggerTests.cs" company="nGratis">
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
// <creation_timestamp>Tuesday, April 14, 2020 6:03:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using nGratis.Cop.Olympus.Contract;
    using Xunit;

    public class CopLoggerTests
    {
        public class LogMethod
        {
            [Fact]
            public void WhenGettingSubmessages_ShouldIncludeThemInLogEntry()
            {
                // Arrange.

                var observedEntries = new List<LogEntry>();

                var logger = new CopLogger("[_MOCK_ID_]", "[_MOCK_COMPONENT_]");

                var onEntryAdded = logger
                    .WhenEntryAdded()
                    .Subscribe(observedEntries.Add);

                using (onEntryAdded)
                {
                    // Act.

                    logger.Log(
                        Verbosity.Info,
                        "[_MOCK_MESSAGE_]",
                        "[_MOCK_SUBMESSAGE_01_]", "[_MOCK_SUBMESSAGE_02_]");

                    // Assert.

                    observedEntries
                        .Should().HaveCount(1);

                    var observedEntry = observedEntries.Single();

                    observedEntry
                        .Should().NotBeNull();

                    using (new AssertionScope())
                    {
                        observedEntry
                            .Message
                            .Should().Be("[_MOCK_MESSAGE_]");

                        observedEntry
                            .Submessages
                            .Should().NotBeNull()
                            .And.HaveCount(2)
                            .And.Contain("[_MOCK_SUBMESSAGE_01_]", "[_MOCK_SUBMESSAGE_02_]");
                    }
                }
            }
        }
    }
}