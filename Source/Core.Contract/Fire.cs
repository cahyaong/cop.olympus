// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fire.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2016 Cahya Ong
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
// <creation_timestamp>Tuesday, 5 May 2015 2:20:18 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class Fire
    {
        [DebuggerStepThrough]
        [ContractAnnotation(" => halt")]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static void InvalidOperationException([Localizable(false)] string message, Exception exception = null)
        {
            throw new InvalidOperationException(message.Coalesce(Constants.Values.Empty), exception);
        }

        [DebuggerStepThrough]
        [ContractAnnotation(" => halt")]
        public static void EnumerationNotSupportedException(object value)
        {
            throw new NotSupportedException($"Enumeration value [{ value }] is not supported.");
        }

        [DebuggerStepThrough]
        [ContractAnnotation(" => halt")]
        public static void NotSupportedException()
        {
            throw new NotSupportedException();
        }

        [DebuggerStepThrough]
        [ContractAnnotation(" => halt")]
        internal static void PreconditionException([Localizable(false)] string message)
        {
            throw new CopPreconditionException(message.Coalesce(Constants.Values.Empty));
        }

        [DebuggerStepThrough]
        [ContractAnnotation(" => halt")]
        internal static void PostconditionException([Localizable(false)] string message)
        {
            throw new CopPostconditionException(message.Coalesce(Constants.Values.Empty));
        }
    }
}