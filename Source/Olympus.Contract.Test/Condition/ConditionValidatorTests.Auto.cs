// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.All.Numerical.cs" company="nGratis">
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