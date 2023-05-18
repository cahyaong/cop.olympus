// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataEntity.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 17 November 2017 1:55:33 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.IO;

public class DataEntity
{
    public DataEntity(DataSpec dataSpec, Stream contentStream)
    {
        Guard
            .Require(dataSpec, nameof(dataSpec))
            .Is.Not.Null();

        Guard
            .Require(contentStream, nameof(contentStream))
            .Is.Not.Null();

        this.DataSpec = dataSpec;
        this.ContentStream = contentStream;
    }

    public DataSpec DataSpec { get; }

    public Stream ContentStream { get; }
}