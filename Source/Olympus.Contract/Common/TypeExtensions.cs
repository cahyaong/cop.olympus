// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 13 April 2015 2:27:02 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

public static class TypeExtensions
{
    public static string GetGenericName(this Type type)
    {
        if (type == null)
        {
            return null;
        }

        return type.IsGenericType
            ? type.Name.Remove(type.Name.IndexOf('`'))
            : type.Name;
    }
}