// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.All.Numerical.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 31 March 2018 5:14:34 AM UTC</creation_timestamp>
// <remark>
//
//     _  _   _ _____ ___       ___ ___ _  _ ___ ___    _ _____ ___ ___    _____ _ _  
//    /_\| | | |_   _/ _ \ ___ / __| __| \| | __| _ \  /_\_   _| __|   \  |_   _| | | 
//   / _ \ |_| | | || (_) |___| (_ | _|| .` | _||   / / _ \| | | _|| |) |   | | |_  _|
//  /_/ \_\___/  |_| \___/     \___|___|_|\_|___|_|_\/_/ \_\_| |___|___/    |_|   |_| 
//
// </remark>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class ClassValidatorTests
    {
        public class NotProperty
        {
            [Fact]
            public void WhenGettingValidPreConditionValue_ShouldNotThrowException()
            {
                // Arrange.

                var validator = new ClassValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PreCondition);

                validator = validator.Not;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_ANOTHER_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate.Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreConditionValue_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var validator = new ClassValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PreCondition);

                validator = validator.Not;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [[_MOCK_NAME_]] should NOT [_MOCK_REASON_]!");
            }

            [Fact]
            public void WhenGettingValidPostConditionValue_ShouldNotThrowException()
            {
                // Arrange.

                var validator = new ClassValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PostCondition);

                validator = validator.Not;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_ANOTHER_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate.Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostConditionValue_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var validator = new ClassValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PostCondition);

                validator = validator.Not;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [[_MOCK_NAME_]] should NOT [_MOCK_REASON_]!");
            }
        }
    }

    public class PropertyValidatorTests
    {
        public class NoProperty
        {
            [Fact]
            public void WhenGettingValidPreConditionValue_ShouldNotThrowException()
            {
                // Arrange.

                var validator = new PropertyValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PreCondition);

                validator = validator.No;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_ANOTHER_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate.Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPreConditionValue_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                var validator = new PropertyValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PreCondition);

                validator = validator.No;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate
                    .Should().Throw<CopPreConditionException>()
                    .WithMessage("PRE-CONDITION: Variable [[_MOCK_NAME_]] should NOT [_MOCK_REASON_]!");
            }

            [Fact]
            public void WhenGettingValidPostConditionValue_ShouldNotThrowException()
            {
                // Arrange.

                var validator = new PropertyValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PostCondition);

                validator = validator.No;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_ANOTHER_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate.Should().NotThrow();
            }

            [Fact]
            public void WhenGettingInvalidPostConditionValue_ShouldThrowCopPostConditionException()
            {
                // Arrange.

                var validator = new PropertyValidator<string>(
                    "[_MOCK_NAME_]",
                    "[_MOCK_VALUE_]",
                    ValidatorKind.PostCondition);

                validator = validator.No;

                // Act.

                var validate = new Action(() => validator.Validate(
                    value => value == "[_MOCK_VALUE_]",
                    "[_MOCK_REASON_]"));

                // Assert.

                validate
                    .Should().Throw<CopPostConditionException>()
                    .WithMessage("POST-CONDITION: Variable [[_MOCK_NAME_]] should NOT [_MOCK_REASON_]!");
            }
        }
    }
}