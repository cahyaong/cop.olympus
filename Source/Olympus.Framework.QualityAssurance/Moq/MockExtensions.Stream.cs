// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockExtensions.Stream.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 1 April 2018 4:26:50 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq;

using System.IO;

public static partial class MockExtensions
{
    public static Mock<Stream> WithReadable(this Mock<Stream> mockStream)
    {
        mockStream
            .SetupGet(mock => mock.CanRead)
            .Returns(true)
            .Verifiable();

        return mockStream;
    }

    public static Mock<Stream> WithWritable(this Mock<Stream> mockStream)
    {
        mockStream
            .SetupGet(mock => mock.CanWrite)
            .Returns(true)
            .Verifiable();

        return mockStream;
    }

    public static Mock<Stream> WithContent(this Mock<Stream> mockStream, string content)
    {
        mockStream
            .SetupGet(mock => mock.Length)
            .Returns(content.Length)
            .Verifiable();

        return mockStream;
    }
}