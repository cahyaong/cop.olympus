// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTests.String.cs" company="nGratis">
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