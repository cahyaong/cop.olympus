// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageDefinitionAttribute.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 17, 2020 2:05:37 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using nGratis.Cop.Olympus.Contract;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class PageDefinitionAttribute : Attribute
{
    public PageDefinitionAttribute(string displayText)
    {
        this.DisplayText = !string.IsNullOrEmpty(displayText)
            ? displayText
            : DefinedText.Unknown;

        this.Ordering = int.MaxValue;
    }

    public string DisplayText { get; }

    public int Ordering { get; set; }
}