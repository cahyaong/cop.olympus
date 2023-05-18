// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemporalProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 1:01:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using nGratis.Cop.Olympus.Contract;

internal class TemporalProvider : ITemporalProvider
{
    private TemporalProvider()
    {
    }

    public static ITemporalProvider Instance { get; } = new TemporalProvider();

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}