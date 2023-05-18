// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScenarioExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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