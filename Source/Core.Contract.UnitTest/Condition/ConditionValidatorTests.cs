// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionValidatorTests.cs" company="nGratis">
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
// <creation_timestamp>Monday, 26 March 2018 7:51:29 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract.UnitTest
{
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

                validate.ShouldNotThrow();
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
                    .ShouldThrow<CopPreConditionException>()
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

                validate.ShouldNotThrow();
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
                    .ShouldThrow<CopPostConditionException>()
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
                    .ShouldThrow<NotSupportedException>()
                    .WithMessage("Validator kind [Unknown] is not supported!");
            }
        }
    }
}