// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 28 April 2017 11:39:38 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.IO;

using System.Text;
using nGratis.Cop.Olympus.Contract;

public static class StreamExtensions
{
    private const int BufferSize = 4 * 1024;

    public static byte[] ReadBlob(this Stream stream)
    {
        Guard
            .Require(stream, nameof(stream))
            .Is.Not.Null()
            .Is.Readable();

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        var blob = default(byte[]);

        using (var cachingStream = new MemoryStream())
        {
            stream.CopyTo(cachingStream, StreamExtensions.BufferSize);
            cachingStream.Position = 0;

            blob = cachingStream.ToArray();
        }

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        return blob;
    }

    public static string ReadText(this Stream stream)
    {
        Guard
            .Require(stream, nameof(stream))
            .Is.Not.Null();

        return stream.ReadText(Encoding.UTF8);
    }

    public static string ReadText(this Stream stream, Encoding encoding)
    {
        Guard
            .Require(stream, nameof(stream))
            .Is.Not.Null()
            .Is.Readable();

        Guard
            .Require(encoding, nameof(encoding))
            .Is.Not.Null();

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        using var reader = new StreamReader(stream, encoding, true, StreamExtensions.BufferSize, true);
        var content = reader.ReadToEnd();

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        return content;
    }
}