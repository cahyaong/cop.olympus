// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="nGratis">
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
// <creation_timestamp>Tuesday, 14 June 2016 9:35:08 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract
{
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;

    public static partial class Guard
    {
        [DebuggerStepThrough]
        [ContractAnnotation("actual:null => halt")]
        public static ValidationContinuation<T> Require<T>([NoEnumeration] T actual)
        {
            return new(Text.Unknown, actual, ValidatorKind.PreCondition);
        }

        [DebuggerStepThrough]
        [ContractAnnotation("actual:null => halt")]
        public static ValidationContinuation<T> Ensure<T>([NoEnumeration] T actual)
        {
            return new(Text.Unknown, actual, ValidatorKind.PostCondition);
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
                $"be {Text.Null}");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<T> Default<T>(this ConditionValidator<T> validator)
        {
            return validator.Validate(
                actual => object.Equals(actual, default(T)),
                $"be {Text.Default}");
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
        public static ValidationContinuation<Type> AssignableFrom(
            this ClassValidator<Type> validator,
            Type expected)
        {
            return validator.Validate(
                actual => actual.IsAssignableFrom(expected),
                $"be assignable from [{expected.FullName}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<bool> True(this ClassValidator<bool> validator)
        {
            // ReSharper disable once RedundantBoolCompare
            return validator.Validate(
                actual => actual == true,
                $"be {Text.True}");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<bool> False(this ClassValidator<bool> validator)
        {
            return validator.Validate(
                actual => actual == false,
                $"be {Text.False}");
        }
    }
}