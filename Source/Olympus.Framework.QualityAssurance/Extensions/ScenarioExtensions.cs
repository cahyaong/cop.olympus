// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScenarioExtensions.cs" company="nGratis">
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
// <creation_timestamp>Monday, 20 April 2015 1:14:58 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.Data;

using System;
using System.Globalization;
using nGratis.Cop.Olympus.Contract;

public static class ScenarioExtensions
{
    public static Guid AsGuid(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        var isValid = Guid.TryParse(row.AsString(column), out var value);

        Guard
            .Ensure(isValid, nameof(isValid))
            .Is.True();

        return value;
    }

    public static short AsInt16(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        var isValid = short.TryParse(
            row.AsString(column),
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            out var value);

        Guard
            .Ensure(isValid, nameof(isValid))
            .Is.True();

        return value;
    }

    public static int AsInt32(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        var isValid = int.TryParse(
            row.AsString(column),
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            out var value);

        Guard
            .Ensure(isValid, nameof(isValid))
            .Is.True();

        return value;
    }

    public static DateTime AsDateTime(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        var isValid = DateTime.TryParseExact(
            row.AsString(column),
            "O",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal,
            out var value);

        Guard
            .Ensure(isValid, nameof(isValid))
            .Is.True();

        return value;
    }

    public static DateTimeOffset AsDateTimeOffset(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        var isValid = DateTimeOffset.TryParseExact(
            row.AsString(column),
            "O",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal,
            out var value);

        Guard
            .Ensure(isValid, nameof(isValid))
            .Is.True();

        return value;
    }

    public static string AsString(this DataRow row, string column)
    {
        Guard
            .Require(row, nameof(row))
            .Is.Not.Null();

        Guard
            .Require(column, nameof(column))
            .Is.Not.Empty();

        var value = row[column] as string;

        Guard
            .Ensure(value, nameof(value))
            .Is.Not.Empty();

        return value.Trim();
    }
}