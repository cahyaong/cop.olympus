// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 Cahya Ong
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
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.Collections.Generic
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using JetBrains.Annotations;
    using nGratis.Cop.Core.Framework;
    using nGratis.Cop.Core.Contract;

    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static IEnumerable<T> Append<T>(this IEnumerable<T> lefts, IEnumerable<T> rights)
        {
            Guard
                .Require(lefts, nameof(lefts))
                .Is.Not.Null();

            Guard
                .Require(rights, nameof(rights))
                .Is.Not.Null();

            foreach (var left in lefts)
            {
                yield return left;
            }

            foreach (var right in rights)
            {
                yield return right;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> lefts, IEnumerable<T> rights)
        {
            Guard
                .Require(lefts, nameof(lefts))
                .Is.Not.Null();

            Guard
                .Require(rights, nameof(rights))
                .Is.Not.Null();

            foreach (var right in rights)
            {
                yield return right;
            }

            foreach (var left in lefts)
            {
                yield return left;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Append<T>(this IEnumerable<T> lefts, T right)
        {
            Guard
                .Require(lefts, nameof(lefts))
                .Is.Not.Null();

            foreach (var left in lefts)
            {
                yield return left;
            }

            yield return right;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> lefts, T right)
        {
            Guard
                .Require(lefts, nameof(lefts))
                .Is.Not.Null();

            yield return right;

            foreach (var left in lefts)
            {
                yield return left;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Except<T>(this IEnumerable<T> lefts, IEnumerable<T> rights, Func<T, T, bool> isEqual)
        {
            Guard
                .Require(lefts, nameof(lefts))
                .Is.Not.Null();

            Guard
                .Require(rights, nameof(rights))
                .Is.Not.Null();

            Guard
                .Require(isEqual, nameof(isEqual))
                .Is.Not.Null();

            return lefts.Except(rights, new DelegateEqualityComparer<T>(isEqual));
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> items, [InstantHandle] Action<T> apply)
        {
            Guard
                .Require(items, nameof(items))
                .Is.Not.Null();

            Guard
                .Require(apply, nameof(apply))
                .Is.Not.Null();

            foreach (var item in items)
            {
                apply(item);
            }
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> items, [InstantHandle] Action<T, int> apply)
        {
            Guard
                .Require(items, nameof(items))
                .Is.Not.Null();

            Guard
                .Require(apply, nameof(apply))
                .Is.Not.Null();

            var index = 0;

            foreach (var item in items)
            {
                apply(item, index++);
            }
        }
    }
}