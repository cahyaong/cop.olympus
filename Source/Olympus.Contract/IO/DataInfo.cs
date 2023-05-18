// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataInfo.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 29 March 2015 7:07:28 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;

public class DataInfo : DataSpec
{
    public DataInfo(string name, Mime mime)
        : base(name, mime)
    {
    }

    public DateTimeOffset CreatedTimestamp { get; init; }
}