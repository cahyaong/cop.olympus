// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingModes.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 20 July 2015 2:22:28 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;

[Flags]
public enum LoggingModes
{
    None = 0,

    CommunityOfPractice = 1,

    NLogger = 1 << 1,

    Console = 1 << 2,

    All = LoggingModes.CommunityOfPractice | LoggingModes.NLogger | LoggingModes.Console
}