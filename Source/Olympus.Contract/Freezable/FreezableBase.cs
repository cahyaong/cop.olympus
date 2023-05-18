// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FreezableBase.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 5 May 2015 2:01:21 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

public abstract class FreezableBase : IFreezable
{
    public bool IsFrozen { get; private set; }

    public virtual void Freeze()
    {
        if (this.IsFrozen)
        {
            return;
        }

        this.IsFrozen = true;
    }

    public virtual void Thaw()
    {
        if (!this.IsFrozen)
        {
            return;
        }

        this.IsFrozen = false;
    }
}