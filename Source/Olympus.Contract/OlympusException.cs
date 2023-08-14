// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OlympusException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 5 May 2015 2:15:19 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Linq;
using System.Runtime.Serialization;

[Serializable]
public class OlympusException : Exception
{
    public OlympusException()
    {
    }

    public OlympusException(string message)
        : base(message)
    {
    }

    public OlympusException(string message, Exception exception)
        : base(message, exception)
    {
    }

    public OlympusException(string message, params string[] submessages)
        : base(submessages.Aggregate(message, (blob, submessage) => $"{blob} {submessage}"))
    {
    }

    public OlympusException(string message, params (string Key, object Value)[] details)
        : this(message, details.Select(detail => $"{detail.Key}: [{detail.Value}].").ToArray())
    {
    }

    protected OlympusException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}