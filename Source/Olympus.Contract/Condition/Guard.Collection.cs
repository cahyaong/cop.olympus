// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.Collection.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 2 March 2018 10:01:54 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static ValidationContinuation<IEnumerable<T>> Empty<T>(this ClassValidator<IEnumerable<T>> validator)
    {
        return validator.Validate(
            actual => !actual.Any(),
            "be empty");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<T[]> Empty<T>(this ClassValidator<T[]> validator)
    {
        return validator.Validate(
            actual => actual.Length <= 0,
            "be empty");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<IReadOnlyCollection<T>> Empty<T>(
        this ClassValidator<IReadOnlyCollection<T>> validator)
    {
        return validator.Validate(
            actual => actual.Count <= 0,
            "be empty");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<IDictionary<TKey, TValue>> Key<TKey, TValue>(
        this PropertyValidator<IDictionary<TKey, TValue>> validator,
        TKey key)
    {
        return validator.Validate(
            actual => actual.ContainsKey(key),
            $"have key [{key}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<IReadOnlyDictionary<TKey, TValue>> Key<TKey, TValue>(
        this PropertyValidator<IReadOnlyDictionary<TKey, TValue>> validator,
        TKey key)
    {
        return validator.Validate(
            actual => actual.ContainsKey(key),
            $"have key [{key}]");
    }
}