// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, August 14, 2023 5:27:21 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.Reflection;

using System.IO;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Framework;

public static class AssemblyExtensions
{
    public static Stream FetchSessionStream(this Assembly assembly, string name, Mime mime)
    {
        Guard
            .Require(name, nameof(name))
            .Is.Not.Empty();

        var assemblyNamespace = assembly
            .GetName()
            .Name?
            .Replace(".QualityAssurance", string.Empty) ?? DefinedText.Unknown;

        var dataStream = assembly
            .GetManifestResourceStream($"{assemblyNamespace}.Data.{name}{mime.FileExtension}");

        return dataStream
            ?? throw new OlympusTestingException("Session data must be embedded!", ("Name", name));
    }
}