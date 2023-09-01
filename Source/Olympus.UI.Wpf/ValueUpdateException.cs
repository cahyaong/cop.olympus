// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueUpdateException.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 19 February 2016 10:15:54 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;

[Serializable]
public class ValueUpdateException : Exception
{
    public ValueUpdateException()
    {
    }

    public ValueUpdateException(string message)
        : base(message)
    {
    }

    public ValueUpdateException(string message, Exception exception)
        : base(message, exception)
    {
    }
}