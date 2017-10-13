// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FILENAME" company="nGratis">
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
// <creation_timestamp>Friday, 24 March 2017 10:30:19 PM UTC</creation_timestamp>
//
//     _  _   _ _____ ___       ___ ___ _  _ ___ ___    _ _____ ___ ___    _____ _ _  
//    /_\| | | |_   _/ _ \ ___ / __| __| \| | __| _ \  /_\_   _| __|   \  |_   _| | | 
//   / _ \ |_| | | || (_) |___| (_ | _|| .` | _||   / / _ \| | | _|| |) |   | | |_  _|
//  /_/ \_\___/  |_| \___/     \___|___|_|\_|___|_|_\/_/ \_\_| |___|___/    |_|   |_| 
//
// </remark>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable RedundantTypeArgumentsOfMethod

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
        public static partial class Ensure
        {
            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotNull<T>(T value)
                where T : class
            {
                Guard.Ensure.IsNotNull<T>(value, null);
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotEmpty(string value)
            {
                Guard.Ensure.IsNotEmpty(value, null);
            }

            [DebuggerStepThrough]
            [ContractAnnotation("enumerable:null => halt")]
            public static void IsNotEmpty<T>(IEnumerable<T> enumerable)
                where T : class
            {
                Guard.Ensure.IsNotEmpty<T>(enumerable, null);
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
            public static void IsTypeOf<T>(object value)
            {
                Guard.Ensure.IsTypeOf<T>(value, null);
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:true => halt")]
            public static void IsFalse(bool value)
            {
                Guard.Ensure.IsFalse(value, null);
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:false => halt")]
            public static void IsTrue(bool value)
            {
                Guard.Ensure.IsTrue(value, null);
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(object value, object anotherValue)
            {
                Guard.Ensure.IsEqualTo(value, anotherValue, null);
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(object value, object anotherValue)
            {
                Guard.Ensure.IsNotEqualTo(value, anotherValue, null);
            }
        }
    }
}

// ReSharper restore RedundantTypeArgumentsOfMethod