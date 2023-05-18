// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultipleValuesRequiredAttribute.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 8 January 2019 11:18:06 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;

[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
public class MultipleValuesRequiredAttribute : Attribute
{
}