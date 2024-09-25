// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 25 April 2017 6:56:26 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using nGratis.Cop.Olympus.Contract;

public static class IntegerExtensions
{
    public static int Clamp(this int value, int min, int max)
    {
        Guard
            .Require(min, nameof(min))
            .Is.LessThan(max);

        if (value < min)
        {
            value = min;
        }
        else if (value > max)
        {
            value = max;
        }

        return value;
    }
}