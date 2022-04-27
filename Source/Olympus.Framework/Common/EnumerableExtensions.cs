// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
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

namespace System.Collections.Generic;

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using nGratis.Cop.Olympus.Contract;

public static class EnumerableExtensions
{
    [DebuggerStepThrough]
    public static IEnumerable<T> Append<T>(this IEnumerable<T> leftItems, IEnumerable<T> rightItems)
    {
        Guard
            .Require(leftItems, nameof(leftItems))
            .Is.Not.Null();

        Guard
            .Require(rightItems, nameof(rightItems))
            .Is.Not.Null();

        foreach (var leftItem in leftItems)
        {
            yield return leftItem;
        }

        foreach (var rightItem in rightItems)
        {
            yield return rightItem;
        }
    }

    [DebuggerStepThrough]
    public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item)
    {
        return items.Except(ImmutableArray.Create(item));
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
    public static void ForEachAsync<T>(this IEnumerable<T> items, [InstantHandle] Func<T, Task> applyAsync)

    {
        Guard
            .Require(items, nameof(items))
            .Is.Not.Null();

        Guard
            .Require(applyAsync, nameof(applyAsync))
            .Is.Not.Null();

        Task.WaitAll(items
            .Select(applyAsync)
            .ToArray());
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

    [DebuggerStepThrough]
    public static void ForEachAsync<T>(this IEnumerable<T> items, [InstantHandle] Func<T, int, Task> applyAsync)
    {
        Guard
            .Require(items, nameof(items))
            .Is.Not.Null();

        Guard
            .Require(applyAsync, nameof(applyAsync))
            .Is.Not.Null();

        Task.WaitAll(items
            .Select(applyAsync)
            .ToArray());
    }
}