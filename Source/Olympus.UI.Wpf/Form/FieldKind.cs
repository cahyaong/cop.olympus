// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldKind.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Linq;
using System.Reflection;
using nGratis.Cop.Olympus.Contract;

public enum FieldKind
{
    Unknown,
    Text,
    DropDown,

    [MultipleValuesRequired]
    List,

    [MultipleValuesRequired]
    Chips
}

public static class FieldKindExtensions
{
    public static bool IsMultipleValuesRequired(this FieldKind fieldKind)
    {
        Guard
            .Require(fieldKind, nameof(fieldKind))
            .Is.Not.Default();

        return typeof(FieldKind)
            .GetMember(fieldKind.ToString())
            .Single()
            .GetCustomAttributes<MultipleValuesRequiredAttribute>()
            .Any();
    }
}