// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 29 March 2015 6:39:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using nGratis.Cop.Olympus.Contract;

public static class StringExtensions
{
    private static readonly string DefaultHash = new('0', 32);

    public static string Coalesce(this string value, params string[] alternatives)
    {
        return string.IsNullOrWhiteSpace(value)
            ? alternatives.FirstOrDefault(alternative => !string.IsNullOrWhiteSpace(alternative))
            : value;
    }

    public static string CalculateMd5Hash(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return StringExtensions.DefaultHash;
        }

        using var md5 = MD5.Create();
        var hashBuilder = new StringBuilder();

        md5
            .ComputeHash(Encoding.UTF8.GetBytes(text))
            .ToList()
            .ForEach(chunk => hashBuilder.Append(chunk.ToString("x2")));

        return hashBuilder.ToString();
    }

    public static string ToPrettifiedText(this IReadOnlyCollection<string> values)
    {
        // TODO: Update any similar code to use this method!
        // TODO: Rename all To___(...) methods to As___(...) to make it consistent with .NET!

        if (values?.Any() != true)
        {
            return DefinedText.Empty;
        }

        var prettifiedValues = values
            .Select(value => !string.IsNullOrEmpty(value)
                ? $"[{value}]"
                : @"[/]")
            .ToArray();

        return string.Join(", ", prettifiedValues);
    }

    public static string ToPrettifiedText(this IEnumerable<string> values)
    {
        if (values == null)
        {
            return DefinedText.Empty;
        }

        return values
            .ToImmutableArray()
            .ToPrettifiedText();
    }

    public static string ToPrettifiedText<TItem>(this IEnumerable<TItem> items, Func<TItem, string> selectValue = null)
    {
        if (items == null)
        {
            return DefinedText.Empty;
        }

        var values = selectValue != null
            ? items.Select(selectValue)
            : items.Select(item => item.ToString());

        return values
            .ToPrettifiedText();
    }

    public static Stream AsStream(this string text)
    {
        var stream = new MemoryStream();

        if (string.IsNullOrEmpty(text))
        {
            return stream;
        }

        stream.Write(Encoding.UTF8.GetBytes(text));
        stream.Position = 0;

        return stream;
    }
}