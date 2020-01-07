// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.System.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </copyright>
// <author>Cahya Ong - cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 6 March 2018 8:41:31 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
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
}