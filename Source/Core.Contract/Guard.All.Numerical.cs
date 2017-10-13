// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.All.Numerical.cs" company="nGratis">
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
// <creation_timestamp>Friday, 17 March 2017 11:20:18 PM UTC</creation_timestamp>
// <remark>
//
//     _  _   _ _____ ___       ___ ___ _  _ ___ ___    _ _____ ___ ___    _____ _ _  
//    /_\| | | |_   _/ _ \ ___ / __| __| \| | __| _ \  /_\_   _| __|   \  |_   _| | | 
//   / _ \ |_| | | || (_) |___| (_ | _|| .` | _||   / / _ \| | | _|| |) |   | | |_  _|
//  /_/ \_\___/  |_| \___/     \___|___|_|\_|___|_|_\/_/ \_\_| |___|___/    |_|   |_| 
//
// </remark>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static partial class Guard
    {
        public static partial class Require
        {
            [DebuggerStepThrough]
            public static void IsLessThan(int value, int anotherValue)
            {
                if (value >= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be less than [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsGreaterThan(int value, int anotherValue)
            {
                if (value <= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be greater than [{anotherValue}].");
                }
            }

            
            [DebuggerStepThrough]
            public static void IsZeroOrPositive(int value)
            {
                if (value <= 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsPositive(int value)
            {
                if (value < 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZeroNegative(int value)
            {
                if (value > 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNegative(int value)
            {
                if (value >= 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZero(int value)
            {
                if (value != 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZero(int value)
            {
                if (value == 0)
                {
                    Fire.PreconditionException($"Value [{value}] must not be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(int value, int anotherValue)
            {
                if (value != anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(int value, int anotherValue)
            {
                if (value == anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be not equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsLessThan(long value, long anotherValue)
            {
                if (value >= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be less than [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsGreaterThan(long value, long anotherValue)
            {
                if (value <= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be greater than [{anotherValue}].");
                }
            }

            
            [DebuggerStepThrough]
            public static void IsZeroOrPositive(long value)
            {
                if (value <= 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsPositive(long value)
            {
                if (value < 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZeroNegative(long value)
            {
                if (value > 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNegative(long value)
            {
                if (value >= 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZero(long value)
            {
                if (value != 0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZero(long value)
            {
                if (value == 0)
                {
                    Fire.PreconditionException($"Value [{value}] must not be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(long value, long anotherValue)
            {
                if (value != anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(long value, long anotherValue)
            {
                if (value == anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be not equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsLessThan(float value, float anotherValue)
            {
                if (value >= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be less than [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsGreaterThan(float value, float anotherValue)
            {
                if (value <= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be greater than [{anotherValue}].");
                }
            }

            
            [DebuggerStepThrough]
            public static void IsZeroOrPositive(float value)
            {
                if (value <= 0.0F)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsPositive(float value)
            {
                if (value < 0.0F)
                {
                    Fire.PreconditionException($"Value [{value}] must be positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZeroNegative(float value)
            {
                if (value > 0.0F)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNegative(float value)
            {
                if (value >= 0.0F)
                {
                    Fire.PreconditionException($"Value [{value}] must be negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZero(float value)
            {
                if (value < -float.Epsilon || value > float.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZero(float value)
            {
                if (value >= -float.Epsilon && value <= float.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must not be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(float value, float anotherValue)
            {
                if (Math.Abs(value - anotherValue) > float.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(float value, float anotherValue)
            {
                if (Math.Abs(value - anotherValue) <= float.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be not equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsLessThan(double value, double anotherValue)
            {
                if (value >= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be less than [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsGreaterThan(double value, double anotherValue)
            {
                if (value <= anotherValue)
                {
                    Fire.PreconditionException($"Value [{value}] must be greater than [{anotherValue}].");
                }
            }

            
            [DebuggerStepThrough]
            public static void IsZeroOrPositive(double value)
            {
                if (value <= 0.0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsPositive(double value)
            {
                if (value < 0.0)
                {
                    Fire.PreconditionException($"Value [{value}] must be positive.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZeroNegative(double value)
            {
                if (value > 0.0)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero or negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNegative(double value)
            {
                if (value >= 0.0)
                {
                    Fire.PreconditionException($"Value [{value}] must be negative.");
                }
            }

            [DebuggerStepThrough]
            public static void IsZero(double value)
            {
                if (value < -double.Epsilon || value > double.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotZero(double value)
            {
                if (value >= -double.Epsilon && value <= double.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must not be zero.");
                }
            }

            [DebuggerStepThrough]
            public static void IsEqualTo(double value, double anotherValue)
            {
                if (Math.Abs(value - anotherValue) > double.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be equal to [{anotherValue}].");
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEqualTo(double value, double anotherValue)
            {
                if (Math.Abs(value - anotherValue) <= double.Epsilon)
                {
                    Fire.PreconditionException($"Value [{value}] must be not equal to [{anotherValue}].");
                }
            }
        }
    }
}
