// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.All.Numerical.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 1 April 2018 1:05:37 AM UTC</creation_timestamp>
// <remark>
//
//     _  _   _ _____ ___       ___ ___ _  _ ___ ___    _ _____ ___ ___    _____ _ _  
//    /_\| | | |_   _/ _ \ ___ / __| __| \| | __| _ \  /_\_   _| __|   \  |_   _| | | 
//   / _ \ |_| | | || (_) |___| (_ | _|| .` | _||   / / _ \| | | _|| |) |   | | |_  _|
//  /_/ \_\___/  |_| \___/     \___|___|_|\_|___|_|_\/_/ \_\_| |___|___/    |_|   |_| 
//
// </remark>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local

namespace nGratis.Cop.Olympus.Contract.Test
{
    using System;
    using FluentAssertions;
    using Xunit;

    public partial class GuardTests
    {
        public class LessThanMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than [{(int.MinValue + int.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than [{(int.MinValue + int.MaxValue) / 2}]!");
            }
        }

        public class LessThanOrEqualToMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than or equal to [{(int.MinValue + int.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than or equal to [{(int.MinValue + int.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than [{(int.MinValue + int.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than [{(int.MinValue + int.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanOrEqualToMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than or equal to [{(int.MinValue + int.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((int.MinValue + int.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than or equal to [{(int.MinValue + int.MaxValue) / 2}]!");
            }
        }

        public class PositiveMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a positive number!");
            }
        }

        public class ZeroOrPositiveMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a positive number!");
            }
        }

        public class NegativeMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a negative number!");
            }
        }

        public class ZeroOrNegativeMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a negative number!");
            }
        }

        public class ZeroMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero!");
            }
        }

        public class EqualToMethod_Int32
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be equal to [0]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }

        public class LessThanMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than [{(long.MinValue + long.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than [{(long.MinValue + long.MaxValue) / 2}]!");
            }
        }

        public class LessThanOrEqualToMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than or equal to [{(long.MinValue + long.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than or equal to [{(long.MinValue + long.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than [{(long.MinValue + long.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than [{(long.MinValue + long.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanOrEqualToMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than or equal to [{(long.MinValue + long.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((long.MinValue + long.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than or equal to [{(long.MinValue + long.MaxValue) / 2}]!");
            }
        }

        public class PositiveMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a positive number!");
            }
        }

        public class ZeroOrPositiveMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a positive number!");
            }
        }

        public class NegativeMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a negative number!");
            }
        }

        public class ZeroOrNegativeMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a negative number!");
            }
        }

        public class ZeroMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0L;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0L;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero!");
            }
        }

        public class EqualToMethod_Int64
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0L;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be equal to [0]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0L;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }

        public class LessThanMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than [{(float.MinValue + float.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than [{(float.MinValue + float.MaxValue) / 2}]!");
            }
        }

        public class LessThanOrEqualToMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than or equal to [{(float.MinValue + float.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than or equal to [{(float.MinValue + float.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than [{(float.MinValue + float.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than [{(float.MinValue + float.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanOrEqualToMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than or equal to [{(float.MinValue + float.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((float.MinValue + float.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than or equal to [{(float.MinValue + float.MaxValue) / 2}]!");
            }
        }

        public class PositiveMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a positive number!");
            }
        }

        public class ZeroOrPositiveMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a positive number!");
            }
        }

        public class NegativeMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a negative number!");
            }
        }

        public class ZeroOrNegativeMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a negative number!");
            }
        }

        public class ZeroMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0F;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0F;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero!");
            }
        }

        public class EqualToMethod_Single
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0F;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be equal to [0]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0F;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }

        public class LessThanMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than [{(double.MinValue + double.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than [{(double.MinValue + double.MaxValue) / 2}]!");
            }
        }

        public class LessThanOrEqualToMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than or equal to [{(double.MinValue + double.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than or equal to [{(double.MinValue + double.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than [{(double.MinValue + double.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than [{(double.MinValue + double.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanOrEqualToMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than or equal to [{(double.MinValue + double.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((double.MinValue + double.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than or equal to [{(double.MinValue + double.MaxValue) / 2}]!");
            }
        }

        public class PositiveMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a positive number!");
            }
        }

        public class ZeroOrPositiveMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrPositive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a positive number!");
            }
        }

        public class NegativeMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Negative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a negative number!");
            }
        }

        public class ZeroOrNegativeMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero or a negative number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.ZeroOrNegative();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero or a negative number!");
            }
        }

        public class ZeroMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero!");
            }
        }

        public class EqualToMethod_Double
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be equal to [0]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = 0.0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }

        public class LessThanMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }
        }

        public class LessThanOrEqualToMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be less than or equal to [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be less than or equal to [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }
        }

        public class GreaterThanOrEqualToMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be greater than or equal to [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo((ushort.MinValue + ushort.MaxValue) / 2);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be greater than or equal to [{(ushort.MinValue + ushort.MaxValue) / 2}]!");
            }
        }

        public class PositiveMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be a positive number!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Positive();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be a positive number!");
            }
        }

        public class ZeroMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (ushort)0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be zero!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (ushort)0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Zero();
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be zero!");
            }
        }

        public class EqualToMethod_UInt16
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (ushort)0;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo((ushort)0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.EqualTo((ushort)0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPreConditionException>()
                    .WithMessage($"PRE-CONDITION: Variable [value] should be equal to [0]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (ushort)0;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo((ushort)0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
            {
                // Arrange.

                var value = ushort.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.EqualTo((ushort)0);
                });

                // Assert.

                action
                    .Should().Throw<OlympusPostConditionException>()
                    .WithMessage($"POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }

    }
}
