// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerBaseTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, April 14, 2020 5:41:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.Test;

using Moq;
using nGratis.Cop.Olympus.Contract;
using Xunit;

public class LoggerBaseTests
{
    public class LogMethod
    {
        [Fact]
        public void WhenGettingSubmessages_ShouldFormatThemAsPartOfMessage()
        {
            // Arrange.

            var stubLogger = MockBuilder
                .CreateStub<LoggerBase>();

            // Act.

            stubLogger.Object.Log(
                Verbosity.Info,
                "[_MOCK_MESSAGE_]",
                "[_MOCK_SUBMESSAGE_01_]", "[_MOCK_SUBMESSAGE_02_]");

            // Assert.

            stubLogger.Verify(
                stub => stub.Log(It.IsAny<Verbosity>(), It.IsAny<string>()),
                Times.Once);

            var expectedMessage = @"
[_MOCK_MESSAGE_]
  |_ [_MOCK_SUBMESSAGE_01_]
  |_ [_MOCK_SUBMESSAGE_02_]";

            stubLogger.Verify(
                stub => stub.Log(Verbosity.Info, expectedMessage.Trim()),
                Times.Once);
        }
    }
}