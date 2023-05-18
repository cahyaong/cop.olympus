// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionValidatorTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 26 March 2018 7:51:29 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using FluentAssertions;
using Xunit;

public class ConditionValidatorTests
{
    public class ValidateMethod
    {
        [Fact]
        public void WhenGettingValidPreConditionValue_ShouldNotThrowException()
        {
            // Arrange.

            var stubValidator = new StubPreConditionValidator("[_MOCK_VALUE_]");

            // Act.

            var validate = new Action(() => stubValidator.Validate(
                value => value == "[_MOCK_VALUE_]",
                "[_MOCK_REASON_]"));

            // Assert.

            validate.Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPreConditionValue_ShouldThrowCopPreConditionException()
        {
            // Arrange.

            var stubValidator = new StubPreConditionValidator("[_MOCK_VALUE_]");

            // Act.

            var validate = new Action(() => stubValidator.Validate(
                value => value == "[_MOCK_ANOTHER_VALUE_]",
                "[_MOCK_REASON_]"));

            // Assert.

            validate
                .Should().Throw<CopPreConditionException>()
                .WithMessage("PRE-CONDITION: Variable [[_MOCK_NAME_]] should [_MOCK_REASON_]!");
        }

        [Fact]
        public void WhenGettingValidPostConditionValue_ShouldNotThrowException()
        {
            // Arrange.

            var stubValidator = new StubPostConditionValidator("[_MOCK_VALUE_]");

            // Act.

            var validate = new Action(() => stubValidator.Validate(
                value => value == "[_MOCK_VALUE_]",
                "[_MOCK_REASON_]"));

            // Assert.

            validate.Should().NotThrow();
        }

        [Fact]
        public void WhenGettingInvalidPostConditionValue_ShouldThrowCopPostConditionException()
        {
            // Arrange.

            var stubValidator = new StubPostConditionValidator("[_MOCK_VALUE_]");

            // Act.

            var validate = new Action(() => stubValidator.Validate(
                value => value == "[_MOCK_ANOTHER_VALUE_]",
                "[_MOCK_REASON_]"));

            // Assert.

            validate
                .Should().Throw<CopPostConditionException>()
                .WithMessage("POST-CONDITION: Variable [[_MOCK_NAME_]] should [_MOCK_REASON_]!");
        }

        [Fact]
        public void WhenGettingInvalidValueWithUnsupportedValidatorKind_ShouldThrowNotSupportedException()
        {
            // Arrange.

            var stubValidator = new StubUnknownConditionValidator("[_MOCK_VALUE_]");

            // Act.

            var validate = new Action(() => stubValidator.Validate(
                value => value == "[_MOCK_ANOTHER_VALUE_]",
                "[_MOCK_REASON_]"));

            // Assert.

            validate
                .Should().Throw<NotSupportedException>()
                .WithMessage("Validator kind [Unknown] is not supported!");
        }
    }
}