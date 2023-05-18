﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Arg.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 14 February 2018 11:13:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq;

using System.Text.RegularExpressions;
using nGratis.Cop.Olympus.Contract;

using Contract = nGratis.Cop.Olympus.Contract;

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