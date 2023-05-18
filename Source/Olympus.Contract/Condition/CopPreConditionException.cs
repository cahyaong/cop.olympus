// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopPreConditionException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 4 June 2016 11:59:24 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Runtime.Serialization;

[Serializable]
public sealed class CopPreConditionException : CopException
{
    public CopPreConditionException()
    {
    }

    public CopPreConditionException(string message)
        : base($"PRE-CONDITION: {message}")
    {
    }

    public CopPreConditionException(string message, Exception exception)
        : base($"PRE-CONDITION: {message}", exception)
    {
    }

    private CopPreConditionException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}