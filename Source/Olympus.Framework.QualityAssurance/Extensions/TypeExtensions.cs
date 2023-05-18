// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 18 April 2015 5:06:16 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using System.IO;
using nGratis.Cop.Olympus.Contract;

public static class TypeExtensions
{
    public static Stream LoadEmbeddedResource<T>(this T instance, string resourcePath)
        where T : class
    {
        Guard
            .Require(instance, nameof(instance))
            .Is.Not.Null();

        Guard
            .Require(resourcePath, nameof(resourcePath))
            .Is.Not.Empty();

        var assembly = typeof(T).Assembly;
        resourcePath = $"{assembly.GetName().Name}.{resourcePath.Replace("\\", ".")}";
        var stream = assembly.GetManifestResourceStream(resourcePath);

        Guard
            .Ensure(stream, nameof(stream))
            .Is.Not.Null();

        return stream;
    }
}