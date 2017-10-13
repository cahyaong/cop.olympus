// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.Ensure.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2017 Cahya Ong
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
// <creation_timestamp>Friday, 17 March 2017 10:53:36 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using JetBrains.Annotations;

    public static partial class Guard
    {
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static partial class Ensure
        {
            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotNull<T>(T value, string reason)
                where T : class
            {
                if (value == null)
                {
                    Fire.PostconditionException(
                        $"Value must not be {Constants.Values.Null}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotEmpty(string value, string reason)
            {
                if (value == null)
                {
                    Fire.PostconditionException(
                        $"Value must not be {Constants.Values.Null}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }

                if (string.IsNullOrEmpty(value))
                {
                    Fire.PostconditionException(
                        $"Value must not be {Constants.Values.Empty}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("enumerable:null => halt")]
            public static void IsNotEmpty<T>(IEnumerable<T> enumerable, string reason)
            {
                if (enumerable == null)
                {
                    Fire.PostconditionException(
                        $"Enumerable must not be {Constants.Values.Null}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }

                if (!enumerable.Any())
                {
                    Fire.PostconditionException(
                        $"Enumerable must not be {Constants.Values.Empty}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
            public static void IsTypeOf<T>(object value, string reason)
            {
                if (value == null)
                {
                    Fire.PostconditionException(
                        $"Value must not be {Constants.Values.Null}. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }

                if (!(value is T))
                {
                    Fire.PostconditionException(
                        $"Value must be assignable to [{typeof(T).FullName}]. " +
                        $"Reason: { reason.Coalesce(Constants.Values.Unknown) }");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:true => halt")]
            public static void IsFalse(bool value, string reason)
            {
                if (value)
                {
                    Fire.PostconditionException(
                         @"Value must be false. " +
                         $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:false => halt")]
            public static void IsTrue(bool value, string reason)
            {
                if (!value)
                {
                    Fire.PostconditionException(
                         @"Value must be true. " +
                         $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(object value, object anotherValue, string reason)
            {
                if (!object.Equals(value, anotherValue))
                {
                    Fire.PostconditionException(
                        $"Value [{value}] must be equal to [{anotherValue}]. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(object value, object anotherValue, string reason)
            {
                if (object.Equals(value, anotherValue))
                {
                    Fire.PostconditionException(
                        $"Value [{value}] must not be equal to [{anotherValue}]. " +
                        $"Reason: {reason.Coalesce(Constants.Values.Unknown)}");
                }
            }
        }
    }
}