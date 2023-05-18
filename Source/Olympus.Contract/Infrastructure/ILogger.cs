// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 11:33:09 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;

public interface ILogger : IDisposable
{
    string Component { get; }

    void Log(Verbosity verbosity, string message);

    void Log(Verbosity verbosity, string message, params string[] submessages);

    void Log(Verbosity verbosity, string message, Exception exception);
}