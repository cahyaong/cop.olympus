// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 5 May 2015 2:15:19 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Runtime.Serialization;

[Serializable]
public class CopException : Exception
{
    public CopException()
    {
    }

    public CopException(string message)
        : base(message)
    {
    }

    public CopException(string message, Exception exception)
        : base(message, exception)
    {
    }

    protected CopException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}