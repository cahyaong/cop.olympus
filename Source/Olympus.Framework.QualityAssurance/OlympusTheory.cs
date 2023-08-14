// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OlympusTheory.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 19 October 2018 10:28:44 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using nGratis.Cop.Olympus.Contract;

public abstract class OlympusTheory
{
    public string Label { get; private set; }

    public OlympusTheory WithLabel(ushort caseNumber, string description)
    {
        Guard
            .Require(description, nameof(description))
            .Is.Not.Empty();

        this.Label = $"CASE {caseNumber:000} -> {description}";

        return this;
    }

    public object[] ToXunitTheory()
    {
        return new object[] { this };
    }

    public override string ToString() => !string.IsNullOrEmpty(this.Label)
        ? $"[ {this.Label} ]"
        : base.ToString();
}