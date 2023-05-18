// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 14 June 2016 9:35:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Diagnostics;
using JetBrains.Annotations;

public static partial class Guard
{
    [DebuggerStepThrough]
    [ContractAnnotation("actual:null => halt")]
    public static ValidationContinuation<T> Require<T>([NoEnumeration] T actual)
    {
        return new(DefinedText.Unknown, actual, ValidatorKind.PreCondition);
    }

    [DebuggerStepThrough]
    [ContractAnnotation("actual:null => halt")]
    public static ValidationContinuation<T> Ensure<T>([NoEnumeration] T actual)
    {
        return new(DefinedText.Unknown, actual, ValidatorKind.PostCondition);
    }

    [DebuggerStepThrough]
    [ContractAnnotation("actual:null => halt")]
    public static ValidationContinuation<T> Require<T>([NoEnumeration] T actual, string name)
    {
        return new(name, actual, ValidatorKind.PreCondition);
    }

    [DebuggerStepThrough]
    [ContractAnnotation("actual:null => halt")]
    public static ValidationContinuation<T> Ensure<T>([NoEnumeration] T actual, string name)
    {
        return new(name, actual, ValidatorKind.PostCondition);
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<T> Null<T>(this ClassValidator<T> validator)
        where T : class
    {
        return validator.Validate(
            actual => actual == null,
            $"be {DefinedText.Null}");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<T> Default<T>(this ConditionValidator<T> validator)
    {
        return validator.Validate(
            actual => object.Equals(actual, default(T)),
            $"be {DefinedText.Default}");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<T> EqualTo<T>(this ClassValidator<T> validator, T expected)
    {
        return validator.Validate(
            actual => object.Equals(actual, expected),
            $"be equal to [{expected}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<T> OfType<T>(this ClassValidator<T> validator, Type expected)
    {
        return validator.Validate(
            actual => actual.GetType() == expected || expected.IsInstanceOfType(actual),
            $"be of type [{expected.FullName}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Type> Interface(this ConditionValidator<Type> validator)
    {
        return validator.Validate(
            actual => actual.IsInterface,
            "be an interface");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Type> AssignableFrom(this ClassValidator<Type> validator, Type expected)
    {
        return validator.Validate(
            actual => actual.IsAssignableFrom(expected),
            $"be assignable from [{expected.FullName}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<Type> AssignableTo(this ClassValidator<Type> validator, Type expected)
    {
        return validator.Validate(
            actual => actual.IsAssignableTo(expected),
            $"be assignable from [{expected.FullName}]");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<bool> True(this ClassValidator<bool> validator)
    {
        return validator.Validate(
            actual => actual,
            $"be {DefinedText.True}");
    }

    [DebuggerStepThrough]
    public static ValidationContinuation<bool> False(this ClassValidator<bool> validator)
    {
        return validator.Validate(
            actual => !actual,
            $"be {DefinedText.False}");
    }
}