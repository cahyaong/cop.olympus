// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingCallbackAttribute.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using JetBrains.Annotations;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class BindingCallbackAttribute : Attribute
{
}