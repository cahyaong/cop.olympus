// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
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
// <creation_timestamp>Sunday, 29 March 2015 6:39:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        if (!values.Any())
        {
            return nGratis.Cop.Olympus.Contract.Text.Empty;
        }

        var prettifiedValues = values
            .Select(value => !string.IsNullOrEmpty(value)
                ? $"[{value}]"
                : @"[/]")
            .ToArray();

        return string.Join(", ", prettifiedValues);
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