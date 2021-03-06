﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensionsTests.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 19 December 2018 11:24:59 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.Test
{
    using System.IO;
    using System.Text;
    using FluentAssertions;
    using Xunit;

    public class StreamExtensionsTests
    {
        public class ReadBlobMethod
        {
            [Fact]
            public void WhenGettingReadableStream_ShouldReadFromStartToFinish()
            {
                // Arrange.

                using var stream = new MemoryStream(Encoding.ASCII.GetBytes("[_MOCK_CONTENT_]"));

                stream.Position = stream.Length / 2;

                // Act.

                var blob = stream.ReadBlob();

                // Assert.

                blob
                    .Should().BeEquivalentTo(Encoding.ASCII.GetBytes("[_MOCK_CONTENT_]"));

                stream
                    .Position
                    .Should().Be(0);
            }
        }

        public class ReadTextMethod
        {
            [Fact]
            public void WhenGettingReadableStream_ShouldReadFromStartToFinish()
            {
                // Arrange.

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes("[_MOCK_CONTENT_]"));

                stream.Position = stream.Length / 2;

                // Act.

                var text = stream.ReadText();

                // Assert.

                text
                    .Should().BeEquivalentTo("[_MOCK_CONTENT_]");

                stream
                    .Position
                    .Should().Be(0);
            }
        }
    }
}