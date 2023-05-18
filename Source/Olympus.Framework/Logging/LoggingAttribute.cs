// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingAttribute.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 1 May 2015 1:00:44 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using nGratis.Cop.Olympus.Contract;

[AttributeUsage(AttributeTargets.Class)]
public sealed class LoggingAttribute : Attribute
{
    public LoggingAttribute(string category)
    {
        Guard
            .Require(category, nameof(category))
            .Is.Not.Empty();

        this.Category = category;
    }

    public string Category { get; }
}