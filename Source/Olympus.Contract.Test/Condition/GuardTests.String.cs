// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.String.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 9 April 2018 9:46:28 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using FluentAssertions;
using Xunit;

public partial class GuardTests
{
    public class EmptyMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = string.Empty;

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

            var value = "[_MOCK_VALUE_]";

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

            var value = string.Empty;

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

            var value = "[_MOCK_VALUE_]";

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
}