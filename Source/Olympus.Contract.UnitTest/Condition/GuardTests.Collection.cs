// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.Collection.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
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
// <creation_timestamp>Monday, 9 April 2018 9:30:21 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming

namespace nGratis.Cop.Olympus.Contract.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public partial class GuardTests
    {
        public class EmptyMethod_Enumerable
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var values = Enumerable.Empty<int>();

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var values = Enumerable.Range(0, 42);

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [values] should be empty!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var values = Enumerable.Empty<int>();

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var values = Enumerable.Range(0, 42);

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [values] should be empty!");
            }
        }

        public class EmptyMethod_Array
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var values = new int[0];

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var values = Enumerable
                    .Range(0, 42)
                    .ToArray();

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [values] should be empty!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var values = new int[0];

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var values = Enumerable
                    .Range(0, 42)
                    .ToArray();

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(values, nameof(values))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [values] should be empty!");
            }
        }

        public class KeyMethod
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Dictionary<string, string>
                {
                    ["[_MOCK_KEY_]"] = "[_MOCK_VALUE_]"
                };

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Has.Key("[_MOCK_KEY_]");
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = new Dictionary<string, string>
                {
                    ["[_MOCK_KEY_]"] = "[_MOCK_VALUE_]"
                };

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Has.Key("[_MOCK_ANOTHER_KEY_]");
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should have key [[_MOCK_ANOTHER_KEY_]]!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Dictionary<string, string>
                {
                    ["[_MOCK_KEY_]"] = "[_MOCK_VALUE_]"
                };

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Has.Key("[_MOCK_KEY_]");
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = new Dictionary<string, string>
                {
                    ["[_MOCK_KEY_]"] = "[_MOCK_VALUE_]"
                };

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Has.Key("[_MOCK_ANOTHER_KEY_]");
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should have key [[_MOCK_ANOTHER_KEY_]]!");
            }
        }
    }
}