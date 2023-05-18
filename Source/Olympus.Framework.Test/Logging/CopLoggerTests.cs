// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopLoggerTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, April 14, 2020 6:03:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.Test;

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

            var observedEntries = new List<LoggingEntry>();

            var logger = new CopLogger("[_MOCK_COMPONENT_]");

            var onEntryAdded = logger
                .WhenEntryAdded
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