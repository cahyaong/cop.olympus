// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

public static class DoubleExtensions
{
    public static bool IsCloseTo(this double firstValue, double secondValue)
    {
        return firstValue.IsCloseTo(secondValue, 0.00001);
    }

    public static bool IsCloseTo(this double firstValue, double secondValue, double tolerance)
    {
        return Math.Abs(firstValue - secondValue) <= tolerance;
    }
}