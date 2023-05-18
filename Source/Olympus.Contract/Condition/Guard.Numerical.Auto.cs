// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.All.Numerical.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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

namespace nGratis.Cop.Olympus.Contract
{
    using System;
    using System.Diagnostics;

    public static partial class Guard
    {
        [DebuggerStepThrough]
        public static ValidationContinuation<int> LessThan(this ClassValidator<int> validator, int expected)
        {
            return validator.Validate(
                actual => actual < expected,
                $"be less than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> LessThanOrEqualTo(this ClassValidator<int> validator, int expected)
        {
            return validator.Validate(
                actual => actual <= expected,
                $"be less than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> GreaterThan(this ClassValidator<int> validator, int expected)
        {
            return validator.Validate(
                actual => actual > expected,
                $"be greater than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> GreaterThanOrEqualTo(this ClassValidator<int> validator, int expected)
        {
            return validator.Validate(
                actual => actual >= expected,
                $"be greater than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> Positive(this ClassValidator<int> validator)
        {
            return validator.Validate(
                actual => actual > 0,
                "be a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> ZeroOrPositive(this ClassValidator<int> validator)
        {
            return validator.Validate(
                actual => actual >= 0,
                "be zero or a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> Negative(this ClassValidator<int> validator)
        {
            return validator.Validate(
                actual => actual < 0,
                "be a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> ZeroOrNegative(this ClassValidator<int> validator)
        {
            return validator.Validate(
                actual => actual <= 0,
                "be zero or a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> Zero(this ClassValidator<int> validator)
        {
            return validator.Validate(
                actual => actual == 0,
                "be zero");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<int> EqualTo(this ClassValidator<int> validator, int expected)
        {
            return validator.Validate(
                actual => actual == expected,
                $"be equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> LessThan(this ClassValidator<long> validator, long expected)
        {
            return validator.Validate(
                actual => actual < expected,
                $"be less than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> LessThanOrEqualTo(this ClassValidator<long> validator, long expected)
        {
            return validator.Validate(
                actual => actual <= expected,
                $"be less than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> GreaterThan(this ClassValidator<long> validator, long expected)
        {
            return validator.Validate(
                actual => actual > expected,
                $"be greater than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> GreaterThanOrEqualTo(this ClassValidator<long> validator, long expected)
        {
            return validator.Validate(
                actual => actual >= expected,
                $"be greater than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> Positive(this ClassValidator<long> validator)
        {
            return validator.Validate(
                actual => actual > 0L,
                "be a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> ZeroOrPositive(this ClassValidator<long> validator)
        {
            return validator.Validate(
                actual => actual >= 0L,
                "be zero or a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> Negative(this ClassValidator<long> validator)
        {
            return validator.Validate(
                actual => actual < 0L,
                "be a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> ZeroOrNegative(this ClassValidator<long> validator)
        {
            return validator.Validate(
                actual => actual <= 0L,
                "be zero or a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> Zero(this ClassValidator<long> validator)
        {
            return validator.Validate(
                actual => actual == 0L,
                "be zero");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<long> EqualTo(this ClassValidator<long> validator, long expected)
        {
            return validator.Validate(
                actual => actual == expected,
                $"be equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> LessThan(this ClassValidator<float> validator, float expected)
        {
            return validator.Validate(
                actual => actual < expected,
                $"be less than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> LessThanOrEqualTo(this ClassValidator<float> validator, float expected)
        {
            return validator.Validate(
                actual => actual <= expected,
                $"be less than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> GreaterThan(this ClassValidator<float> validator, float expected)
        {
            return validator.Validate(
                actual => actual > expected,
                $"be greater than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> GreaterThanOrEqualTo(this ClassValidator<float> validator, float expected)
        {
            return validator.Validate(
                actual => actual >= expected,
                $"be greater than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> Positive(this ClassValidator<float> validator)
        {
            return validator.Validate(
                actual => actual > 0.0F,
                "be a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> ZeroOrPositive(this ClassValidator<float> validator)
        {
            return validator.Validate(
                actual => actual >= 0.0F,
                "be zero or a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> Negative(this ClassValidator<float> validator)
        {
            return validator.Validate(
                actual => actual < 0.0F,
                "be a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> ZeroOrNegative(this ClassValidator<float> validator)
        {
            return validator.Validate(
                actual => actual <= 0.0F,
                "be zero or a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> Zero(this ClassValidator<float> validator)
        {
            return validator.Validate(
                actual => actual >= -float.Epsilon && actual <= float.Epsilon,
                "be zero");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<float> EqualTo(this ClassValidator<float> validator, float expected)
        {
            return validator.Validate(
                actual => Math.Abs(actual - expected) <= float.Epsilon,
                $"be equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> LessThan(this ClassValidator<double> validator, double expected)
        {
            return validator.Validate(
                actual => actual < expected,
                $"be less than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> LessThanOrEqualTo(this ClassValidator<double> validator, double expected)
        {
            return validator.Validate(
                actual => actual <= expected,
                $"be less than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> GreaterThan(this ClassValidator<double> validator, double expected)
        {
            return validator.Validate(
                actual => actual > expected,
                $"be greater than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> GreaterThanOrEqualTo(this ClassValidator<double> validator, double expected)
        {
            return validator.Validate(
                actual => actual >= expected,
                $"be greater than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> Positive(this ClassValidator<double> validator)
        {
            return validator.Validate(
                actual => actual > 0.0,
                "be a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> ZeroOrPositive(this ClassValidator<double> validator)
        {
            return validator.Validate(
                actual => actual >= 0.0,
                "be zero or a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> Negative(this ClassValidator<double> validator)
        {
            return validator.Validate(
                actual => actual < 0.0,
                "be a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> ZeroOrNegative(this ClassValidator<double> validator)
        {
            return validator.Validate(
                actual => actual <= 0.0,
                "be zero or a negative number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> Zero(this ClassValidator<double> validator)
        {
            return validator.Validate(
                actual => actual >= -double.Epsilon && actual <= double.Epsilon,
                "be zero");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<double> EqualTo(this ClassValidator<double> validator, double expected)
        {
            return validator.Validate(
                actual => Math.Abs(actual - expected) <= double.Epsilon,
                $"be equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> LessThan(this ClassValidator<ushort> validator, ushort expected)
        {
            return validator.Validate(
                actual => actual < expected,
                $"be less than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> LessThanOrEqualTo(this ClassValidator<ushort> validator, ushort expected)
        {
            return validator.Validate(
                actual => actual <= expected,
                $"be less than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> GreaterThan(this ClassValidator<ushort> validator, ushort expected)
        {
            return validator.Validate(
                actual => actual > expected,
                $"be greater than [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> GreaterThanOrEqualTo(this ClassValidator<ushort> validator, ushort expected)
        {
            return validator.Validate(
                actual => actual >= expected,
                $"be greater than or equal to [{expected}]");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> Positive(this ClassValidator<ushort> validator)
        {
            return validator.Validate(
                actual => actual > 0,
                "be a positive number");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> Zero(this ClassValidator<ushort> validator)
        {
            return validator.Validate(
                actual => actual == 0,
                "be zero");
        }

        [DebuggerStepThrough]
        public static ValidationContinuation<ushort> EqualTo(this ClassValidator<ushort> validator, ushort expected)
        {
            return validator.Validate(
                actual => actual == expected,
                $"be equal to [{expected}]");
        }
    }
}
