// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="nGratis">
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
// <creation_timestamp>Friday, 28 April 2017 11:39:38 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.IO
{
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

            using (var reader = new StreamReader(stream, encoding, true, StreamExtensions.BufferSize, true))
            {
                var content = reader.ReadToEnd();

                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }

                return content;
            }
        }
    }
}