// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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