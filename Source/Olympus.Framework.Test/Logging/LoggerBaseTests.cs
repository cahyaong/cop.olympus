// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerBaseTests.cs" company="nGratis">
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