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

namespace nGratis.Cop.Core.Contract.UnitTest
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
                        .Is.LessThan(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThan(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.LessThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = int.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.GreaterThan(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThan(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
                        .Is.GreaterThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = int.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be equal to [0]!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be equal to [0]!");
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
                        .Is.LessThan(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThan(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.LessThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = long.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.GreaterThan(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThan(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
                        .Is.GreaterThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = long.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0L);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be equal to [0]!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be equal to [0]!");
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
                        .Is.LessThan(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThan(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.LessThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = float.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.GreaterThan(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThan(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
                        .Is.GreaterThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = float.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0.0F);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be equal to [0]!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be equal to [0]!");
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
                        .Is.LessThan(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThan(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThan(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThan(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than [0]!");
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
                        .Is.LessThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.LessThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.LessThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = double.MaxValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.LessThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be less than or equal to [0]!");
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
                        .Is.GreaterThan(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThan(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThan(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThan(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than [0]!");
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
                        .Is.GreaterThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
                        .Is.GreaterThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = double.MinValue;

                // Act.

                var action = new Action(() => 
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.GreaterThanOrEqualTo(0.0);
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be greater than or equal to [0]!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a positive number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero or a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be a negative number!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be zero!");
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
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
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
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be equal to [0]!");
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
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
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
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be equal to [0]!");
            }
        }
    }
}
