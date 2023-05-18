// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSpec.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 3 April 2015 12:03:14 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Linq;

public class DataSpec
{
    public static readonly DataSpec None = new(DefinedText.None, Mime.None);

    public DataSpec(string name, Mime mime)
    {
        Guard
            .Require(name, nameof(name))
            .Is.Not.Empty();

        Guard.Require(mime, nameof(mime))
            .Is.Not.EqualTo(Mime.Unknown);

        this.Mime = mime;
        this.Name = name;
    }

    public Mime Mime { get; }

    public string Name { get; }

    public override string ToString()
    {
        return $"ngds://./{this.Name}.{this.Mime.Extensions.First()}";
    }
}