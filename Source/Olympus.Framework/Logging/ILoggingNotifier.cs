// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoggingNotifier.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, September 13, 2020 6:14:43 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using nGratis.Cop.Olympus.Contract;

public interface ILoggingNotifier
{
    IObservable<LoggingEntry> WhenEntryAdded { get; }
}