// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.System.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 6 March 2018 8:41:31 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static ValidationContinuation<Uri> Url(this ClassValidator<Uri> validator)
    {
        return validator.Validate(
            actual => actual.Scheme == Uri.UriSchemeHttp || actual.Scheme == Uri.UriSchemeHttps,
            "be an URL");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Uri> Folder(this ClassValidator<Uri> validator)
    {
        return validator.Validate(
            actual => actual.IsFile && System.IO.File.GetAttributes(actual.LocalPath) == FileAttributes.Directory,
            "be a folder");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Uri> File(this ClassValidator<Uri> validator)
    {
        return validator.Validate(
            actual => actual.IsFile && System.IO.File.GetAttributes(actual.LocalPath) != FileAttributes.Directory,
            "be a file");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Uri> Exist(this ClassValidator<Uri> validator)
    {
        return validator.Validate(
            actual =>
                actual.IsFile &&
                (System.IO.File.Exists(actual.LocalPath) || Directory.Exists(actual.LocalPath)),
            "exist");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Uri> FileExtension(this PropertyValidator<Uri> validator, Mime mime)
    {
        if (mime.Extensions?.Any() != true)
        {
            return validator.Validate(
                actual => string.IsNullOrEmpty(Path.GetExtension(actual.LocalPath)),
                "have no file extension");
        }

        return validator.Validate(
            actual => mime.Extensions.Contains(Path.GetExtension(actual.LocalPath).Replace(".", string.Empty)),
            $"have one of file extensions [{string.Join(", ", mime.Extensions.Select(name => $".{name}"))}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Stream> Readable(this ClassValidator<Stream> validator)
    {
        return validator.Validate(
            actual => actual.CanRead,
            "be readable");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Stream> Writable(this ClassValidator<Stream> validator)
    {
        return validator.Validate(
            actual => actual.CanWrite,
            "be writable");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Stream> Empty(this ClassValidator<Stream> validator)
    {
        return validator.Validate(
            actual => actual.Length <= 0,
            "be empty");
    }

    // TODO: Add <DataTable> validation in a separate project!

    [DebuggerStepThrough]
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public static ValidationContinuation<T?> Value<T>(this PropertyValidator<T?> validator)
        where T : struct
    {
        return validator.Validate(
            actual => actual.HasValue,
            "have value");
    }
}