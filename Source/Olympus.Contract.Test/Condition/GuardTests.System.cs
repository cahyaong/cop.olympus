// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.System.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 1 April 2018 2:06:48 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable ExpressionIsAlwaysNull

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using System.IO;
using FluentAssertions;
using Moq;
using nGratis.Cop.Olympus.Framework;
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should have value!");
        }
    }
}