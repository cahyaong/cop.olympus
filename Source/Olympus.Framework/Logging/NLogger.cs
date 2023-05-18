// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLogger.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 11:41:23 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using nGratis.Cop.Olympus.Contract;
using NLog;

public sealed class NLogger : LoggerBase
{
    private readonly Logger _logger;

    public NLogger(string component)
        : base(component)
    {
        Guard
            .Require(component, nameof(component))
            .Is.Not.Empty();

        this._logger = LogManager.GetLogger(component);
    }

    public override void Log(Verbosity verbosity, string message)
    {
        this._logger.Log(verbosity.ToLogLevel(), message);
    }

    public override void Log(Verbosity verbosity, string message, Exception exception)
    {
        this._logger.Log(verbosity.ToLogLevel(), exception, message);
    }
}