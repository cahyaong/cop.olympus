// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlNamespaceAttribute.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 4 June 2017 12:57:40 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class XmlNamespaceAttribute : Attribute
{
    public XmlNamespaceAttribute(string prefix, string uri)
    {
        Guard
            .Require(prefix, nameof(prefix))
            .Is.Not.Empty();

        Guard
            .Require(uri, nameof(uri))
            .Is.Not.Null();

        this.Prefix = prefix;
        this.Uri = uri;
    }

    public string Prefix { get; }

    public string Uri { get; }
}