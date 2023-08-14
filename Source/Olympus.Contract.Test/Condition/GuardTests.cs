// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 26 March 2018 7:48:47 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ConvertToConstant.Local
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using System.IO;
using FluentAssertions;
using Xunit;

public partial class GuardTests
{
    public class RequireMethod
    {
        [Fact]
        public void WhenGettingValidCondition_ShouldNotThrowException()
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
        public void WhenGettingInvalidCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be empty!");
        }

        [Fact]
        public void WhenGettingInvalidConditionWithoutVariableName_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value)
                    .Is.Empty();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable <unknown> should be empty!");
        }

        [Fact]
        public void WhenChainingMultipleValidConditions_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.Not.Empty()
                    .Is.EqualTo("[_MOCK_VALUE_]")
                    .Is.Not.EqualTo("[_MOCK_ANOTHER_VALUE_]");
            });

            // Assert.

            action
                .Should().NotThrow();
        }
    }

    public class EnsureMethod
    {
        [Fact]
        public void WhenGettingValidCondition_ShouldNotThrowException()
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
        public void WhenGettingInvalidCondition_ShouldThrowOlympusPreConditionException()
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
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be empty!");
        }

        [Fact]
        public void WhenGettingInvalidConditionWithoutVariableName_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value)
                    .Is.Empty();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable <unknown> should be empty!");
        }

        [Fact]
        public void WhenChainingMultipleValidConditions_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.Not.Empty()
                    .Is.EqualTo("[_MOCK_VALUE_]")
                    .Is.Not.EqualTo("[_MOCK_ANOTHER_VALUE_]");
            });

            // Assert.

            action
                .Should().NotThrow();
        }
    }

    public class NullMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = default(string);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.Null();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.Null();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be <null>!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = default(string);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.Null();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.Null();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be <null>!");
        }
    }

    public class DefaultMethod
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
                    .Is.Default();
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
                    .Is.Default();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be <default>!");
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
                    .Is.Default();
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
                    .Is.Default();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be <default>!");
        }
    }

    public class EqualToMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.EqualTo("[_MOCK_VALUE_]");
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.EqualTo("[_MOCK_ANOTHER_VALUE_]");
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be equal to [[_MOCK_ANOTHER_VALUE_]]!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.EqualTo("[_MOCK_VALUE_]");
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.EqualTo("[_MOCK_ANOTHER_VALUE_]");
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be equal to [[_MOCK_ANOTHER_VALUE_]]!");
        }
    }

    public class OfTypeMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.OfType(typeof(string));
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.OfType(typeof(int));
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be of type [System.Int32]!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.OfType(typeof(string));
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = "[_MOCK_VALUE_]";

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.OfType(typeof(int));
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be of type [System.Int32]!");
        }
    }

    public class InterfaceMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = typeof(ICloneable);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.Interface();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = typeof(string);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.Interface();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be an interface!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = typeof(ICloneable);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.Interface();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = typeof(string);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.Interface();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be an interface!");
        }
    }

    public class AssignableFromMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = typeof(Stream);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.AssignableFrom(typeof(MemoryStream));
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = typeof(Stream);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.AssignableFrom(typeof(string));
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be assignable from [System.String]!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = typeof(Stream);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.AssignableFrom(typeof(MemoryStream));
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = typeof(Stream);

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.AssignableFrom(typeof(string));
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be assignable from [System.String]!");
        }
    }

    public class TrueMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = true;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.True();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = false;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.True();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be <true>!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = true;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.True();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = false;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.True();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be <true>!");
        }
    }

    public class FalseMethod
    {
        [Fact]
        public void WhenGettingValidPreCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = false;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.False();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreCondition_ShouldThrowOlympusPreConditionException()
        {
            // Arrange.

            var value = true;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Require(value, nameof(value))
                    .Is.False();
            });

            // Assert.

            action
                .Should().Throw<OlympusPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [value] should be <false>!");
        }

        [Fact]
        public void WhenGettingValidPostCondition_ShouldNotThrowException()
        {
            // Arrange.

            var value = false;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.False();
            });

            // Assert.

            action
                .Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostCondition_ShouldThrowOlympusPostConditionException()
        {
            // Arrange.

            var value = true;

            // Act.

            var action = new Action(() =>
            {
                Guard
                    .Ensure(value, nameof(value))
                    .Is.False();
            });

            // Assert.

            action
                .Should().Throw<OlympusPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [value] should be <false>!");
        }
    }
}