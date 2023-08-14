// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OlympusMemoryLeakException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, November 24, 2021 5:45:42 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Runtime.Serialization;

[Serializable]
public class OlympusMemoryLeakException : OlympusException
{
    public OlympusMemoryLeakException()
    {
    }

    public OlympusMemoryLeakException(string message)
        : base(message)
    {
    }

    public OlympusMemoryLeakException(string message, Exception exception)
        : base(message, exception)
    {
    }

    protected OlympusMemoryLeakException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}