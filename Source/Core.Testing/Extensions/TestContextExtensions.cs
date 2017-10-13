// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestContextExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Monday, 20 April 2015 1:14:19 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using nGratis.Cop.Core.Contract;

    public static class TestContextExtensions
    {
        private static readonly IDictionary<Type, MethodInfo> ParsingMethodLookup;

        static TestContextExtensions()
        {
            TestContextExtensions.ParsingMethodLookup = typeof(ScenarioExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => method.IsDefined(typeof(ExtensionAttribute), false))
                .Select(method => new { Method = method, Parameters = method.GetParameters() })
                .Where(anon => anon.Parameters.Length == 2)
                .Where(anon =>
                    anon.Parameters[0].ParameterType == typeof(DataRow) &&
                    anon.Parameters[1].ParameterType == typeof(string))
                .ToDictionary(anon => anon.Method.ReturnType, anon => anon.Method);
        }

        public static TValue FindScenarioVariableAs<TValue>(this TestContext context, string name)
        {
            Guard.Require.IsNotNull(context);

            var isFound = TestContextExtensions.ParsingMethodLookup.TryGetValue(typeof(TValue), out MethodInfo method);
            Guard.Require.IsTrue(isFound);

            return (TValue)method.Invoke(null, new object[] { context.DataRow, name });
        }
    }
}