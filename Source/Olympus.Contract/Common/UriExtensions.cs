// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 3 April 2015 9:35:37 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using System.IO;
using nGratis.Cop.Olympus.Contract;

public static class UriExtensions
{
    public static DataSpec ToDataSpec(this Uri uri)
    {
        Guard
            .Require(uri, nameof(uri))
            .Is.Not.Null();

        if (uri.IsFile)
        {
            var name = Path.GetFileNameWithoutExtension(uri.AbsoluteUri);
            var contentMime = Mime.ParseByExtension(Path.GetExtension(uri.AbsoluteUri));

            return new DataSpec(name, contentMime);
        }

        throw new NotSupportedException();
    }
}