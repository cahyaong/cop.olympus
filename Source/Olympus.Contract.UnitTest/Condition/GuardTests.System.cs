// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.System.cs" company="nGratis">
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
// <creation_timestamp>Sunday, 1 April 2018 2:06:48 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable ExpressionIsAlwaysNull

namespace nGratis.Cop.Olympus.Contract.UnitTest
{
    using System;
    using System.IO;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public partial class GuardTests
    {
        public class UrlMethod
        {
            [Fact]
            public void WhenGettingValidHttpPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Uri("http://www.mock-url.com");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingValidHttpsPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Uri("https://www.mock-url.com");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = new Uri(@"C:\[_MOCK_LOCAL_PATH_]");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be an URL!");
            }

            [Fact]
            public void WhenGettingValidHttpPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Uri("http://www.mock-url.com");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingValidHttpsPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = new Uri("https://www.mock-url.com");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = new Uri(@"C:\[_MOCK_LOCAL_PATH_]");

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Url();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be an URL!");
            }
        }

        public class ReadableMethod
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithReadable()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Readable();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Readable();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be readable!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithReadable()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Readable();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Readable();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be readable!");
            }
        }

        public class WritableMethod
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithWritable()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Writable();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Writable();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be writable!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithWritable()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Writable();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Writable();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be writable!");
            }
        }

        public class EmptyMethod_Stream
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithContent(string.Empty)
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
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

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithContent("[_MOCK_CONTENT_]")
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should be empty!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithContent(string.Empty)
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
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

                var value = MockBuilder
                    .CreateMock<Stream>()
                    .WithContent("[_MOCK_CONTENT_]")
                    .Object;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Is.Empty();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should be empty!");
            }
        }

        public class ValueMethod
        {
            [Fact]
            public void WhenGettingValidPreCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (int?)42;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Has.Value();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreCondition_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var value = default(int?);

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Require(value, nameof(value))
                        .Has.Value();
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [value] should have value!");
            }

            [Fact]
            public void WhenGettingValidPostCondition_ShouldNotThrowException()
            {
                // Arrange.

                var value = (int?)42;

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Has.Value();
                });

                // Assert.

                action
                    .Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostCondition_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var value = default(int?);

                // Act.

                var action = new Action(() =>
                {
                    Guard
                        .Ensure(value, nameof(value))
                        .Has.Value();
                });

                // Assert.

                action
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [value] should have value!");
            }
        }
    }
}