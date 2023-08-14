// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.Collection.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 9 April 2018 9:30:21 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [values] should be empty!");
        }
    }

    public class EmptyMethod_Array
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var values = Array.Empty<int>();

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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [values] should be empty!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var values = Array.Empty<int>();

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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [values] should be empty!");
        }
    }

    public class KeyMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = (IDictionary<string, string>)new Dictionary<string, string>
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
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = (IDictionary<string, string>)new Dictionary<string, string>
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
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should have key [[_MOCK_ANOTHER_KEY_]]!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = (IDictionary<string, string>)new Dictionary<string, string>
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
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = (IDictionary<string, string>)new Dictionary<string, string>
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
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should have key [[_MOCK_ANOTHER_KEY_]]!");
        }
    }
}