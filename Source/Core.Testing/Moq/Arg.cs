// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Arg.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2018 Cahya Ong
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
// <creation_timestamp>Wednesday, 14 February 2018 11:13:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq
{
    using System.Text.RegularExpressions;
    using nGratis.Cop.Core.Contract;
    using Contract = nGratis.Cop.Core.Contract;

    public class Arg
    {
        public static TValue IsAny<TValue>()
        {
            return It.IsAny<TValue>();
        }

        public class DataSpec
        {
            public static Contract.DataSpec Is(string name, Mime mime)
            {
                Guard
                    .Require(name, nameof(name))
                    .Is.Not.Empty();

                Guard
                    .Require(mime, nameof(mime))
                    .Is.Not.Null();

                return Match.Create<Contract.DataSpec>(spec =>
                    spec.Name == name &&
                    spec.Mime == mime);
            }

            public static Contract.DataSpec IsHtml()
            {
                return Match.Create<Contract.DataSpec>(spec => spec.Mime == Mime.Html);
            }
        }

        public class Stream
        {
            public static System.IO.Stream IsHtml()
            {
                return Match.Create<System.IO.Stream>(stream =>
                {
                    stream.Position = 0;

                    var reader = new System.IO.StreamReader(stream);
                    var content = reader.ReadToEnd();

                    stream.Position = 0;

                    return Regex.IsMatch(content.Trim(), @".*?<html>.*?</html>", RegexOptions.Singleline);
                });
            }
        }
    }
}