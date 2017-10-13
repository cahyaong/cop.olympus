// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.Require.cs" company="nGratis">
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
// <creation_timestamp>Friday, 17 March 2017 10:49:04 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using JetBrains.Annotations;

    public static partial class Guard
    {
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static partial class Require
        {
            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotNull(object value)
            {
                if (value == null)
                {
                    Fire.PreconditionException($"Value cannot be { Constants.Values.Null }.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsEqualTo(object value, object anotherValue)
            {
                if (!object.Equals(value, anotherValue))
                {
                    Fire.PreconditionException($"Value [{value}] must be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotEqualTo(object value, object anotherValue)
            {
                if (object.Equals(value, anotherValue))
                {
                    Fire.PreconditionException($"Value [{value}] must not be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("type:null => halt")]
            [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
            public static void IsEqualTo<T>(Type type)
            {
                if (type == null)
                {
                    Fire.PreconditionException($"Type cannot be {Constants.Values.Null}.");
                }

                if (!typeof(T).IsAssignableFrom(type))
                {
                    Fire.PreconditionException($"Type must be assignable to [{typeof(T).FullName}].");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotDefault<T>(T value)
            {
                if (object.Equals(value, default(T)))
                {
                    Fire.PreconditionException($"Value cannot be {Constants.Values.Default}.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            public static void IsNotEmpty(string value)
            {
                if (value == null)
                {
                    Fire.PreconditionException($"String cannot be {Constants.Values.Null}.");
                }

                if (string.IsNullOrEmpty(value))
                {
                    Fire.PreconditionException($"String cannot be {Constants.Values.Empty}.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("enumerable:null => halt")]
            public static void IsNotEmpty<T>(IEnumerable<T> enumerable)
            {
                if (enumerable == null)
                {
                    Fire.PreconditionException($"Enumerable cannot be {Constants.Values.Null}.");
                }

                if (!enumerable.Any())
                {
                    Fire.PreconditionException($"Enumerable cannot be {Constants.Values.Empty}.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("stream:null => halt")]
            public static void IsNotEmpty(Stream stream)
            {
                if (stream == null)
                {
                    Fire.PreconditionException($"Stream cannot be {Constants.Values.Null}.");
                }

                if (stream.Length == 0)
                {
                    Fire.PreconditionException($"Stream cannot be {Constants.Values.Empty}.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("table:null => halt")]
            public static void IsNotEmpty(DataTable table)
            {
                if (table == null)
                {
                    Fire.PreconditionException($"Table cannot be {Constants.Values.Null}.");
                }

                if (table.Columns.Count == 0 || table.Rows.Count == 0)
                {
                    Fire.PreconditionException($"Table cannot be { Constants.Values.Empty }.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:null => halt")]
            [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
            public static void IsTypeOf<T>(object value)
            {
                if (value == null)
                {
                    Fire.PreconditionException($"Value cannot be {Constants.Values.Null}.");
                }

                if (!(value is T))
                {
                    Fire.PreconditionException($"Value must be assignable to [{typeof(T).FullName}].");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:true => halt")]
            public static void IsFalse(bool value)
            {
                if (value)
                {
                    Fire.PreconditionException("Value cannot be true.");
                }
            }

            [DebuggerStepThrough]
            [ContractAnnotation("value:false => halt")]
            public static void IsTrue(bool value)
            {
                if (!value)
                {
                    Fire.PreconditionException("Value cannot be false.");
                }
            }

            [DebuggerStepThrough]
            public static void IsFile(Uri uri)
            {
                if (uri == null)
                {
                    Fire.PreconditionException($"Value cannot be {Constants.Values.Null}.");
                }

                if (!uri.IsFile)
                {
                    Fire.PreconditionException($"URI must be a file. Path: [{uri}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsFileExist(string path)
            {
                if (!File.Exists(path))
                {
                    Fire.PreconditionException($"File must exist. Path: [{path}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsFileNotExist(string path)
            {
                if (File.Exists(path))
                {
                    Fire.PreconditionException($"File cannot exist. Path: [{path}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsFolderExist(string path)
            {
                if (!Directory.Exists(path))
                {
                    Fire.PreconditionException($"Directory must exist. Path: [{path}].");
                }
            }

            // TODO: Add reason argument for all methods <Require> class!
        }
    }
}