// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFreezable.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 5 May 2015 1:38:54 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

public interface IFreezable
{
    bool IsFrozen { get; }

    void Freeze();

    void Thaw();
}