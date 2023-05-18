// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensionsTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 19 December 2018 11:24:59 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.Test;

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