// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 28 April 2017 11:27:29 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Newtonsoft.Json;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using nGratis.Cop.Olympus.Contract;

public static class SerializationExtensions
{
    public static Stream SerializeManyToJson<TItem>(this IEnumerable<TItem> instances)
    {
        Guard
            .Require(instances, nameof(instances))
            .Is.Not.Null();

        return instances
            .ToArray()
            .SerializeToJson();
    }

    [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    public static Stream SerializeToJson<TInstance>(this TInstance instance)
        where TInstance : class
    {
        Guard
            .Require(instance, nameof(instance))
            .Is.Not.Null();

        var serializer = new JsonSerializer();
        serializer.Converters.Add(new StringEnumConverter());

        var stream = new MemoryStream();
        using var streamWriter = new StreamWriter(stream, Encoding.UTF8, 4096, true);

        using var jsonWriter = new JsonTextWriter(streamWriter)
        {
            Formatting = Formatting.Indented,
            IndentChar = ' ',
            Indentation = 2
        };

        serializer.Serialize(jsonWriter, instance, typeof(TInstance));
        jsonWriter.Flush();
        stream.Position = 0;

        return stream;
    }
}