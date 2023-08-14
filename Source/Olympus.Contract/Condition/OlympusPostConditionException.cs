// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OlympusPostConditionException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 4 June 2016 12:09:46 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Runtime.Serialization;

[Serializable]
public sealed class OlympusPostConditionException : OlympusException
{
    public OlympusPostConditionException()
    {
    }

    public OlympusPostConditionException(string message)
        : base($"POST-CONDITION: {message}")
    {
    }

    public OlympusPostConditionException(string message, Exception exception)
        : base($"POST-CONDITION: {message}", exception)
    {
    }

    private OlympusPostConditionException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}