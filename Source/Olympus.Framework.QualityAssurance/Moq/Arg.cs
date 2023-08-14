// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Arg.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 14 February 2018 11:13:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.Text.RegularExpressions;
using Moq;
using nGratis.Cop.Olympus.Contract;

using Match = Moq.Match;

public class Arg
{
    public static TValue IsAny<TValue>()
    {
        return It.IsAny<TValue>();
    }

    public static class DataSpec
    {
        public static Contract.DataSpec Is(string name, Mime mime)
        {
            Guard
                .Require(name, nameof(name))
                .Is.Not.Empty();

            return Match.Create<Contract.DataSpec>(spec =>
                spec.Name == name &&
                spec.Mime == mime);
        }

        public static Contract.DataSpec IsHtml()
        {
            return Match.Create<Contract.DataSpec>(spec => spec.Mime == Mime.Html);
        }

        public static Contract.DataSpec IsCache(string name)
        {
            Guard
                .Require(name, nameof(name))
                .Is.Not.Empty();

            return Match.Create<Contract.DataSpec>(spec =>
                spec.Name == name &&
                spec.Mime == OlympusMime.Cache);
        }
    }

    public static class Stream
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