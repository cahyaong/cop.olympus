// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSpecExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 17 November 2017 11:04:03 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.Linq;
using nGratis.Cop.Olympus.Contract;

public static class DataSpecExtensions
{
    public static string GetFileName(this DataSpec dataSpec)
    {
        Guard
            .Require(dataSpec, nameof(dataSpec))
            .Is.Not.Null();

        Guard
            .Require(dataSpec.Mime.Extensions, nameof(dataSpec))
            .Is.Not.Empty();

        return $"{dataSpec.Name}.{dataSpec.Mime.Extensions.First()}";
    }
}