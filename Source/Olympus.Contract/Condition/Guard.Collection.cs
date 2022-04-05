﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.Collection.cs" company="nGratis">
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