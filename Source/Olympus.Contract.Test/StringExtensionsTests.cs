// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTests.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, July 8, 2020 6:11:54 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using FluentAssertions;
using Xunit;

public class StringExtensionsTests
{
    public class ToPrettifiedText
    {
        [Fact]
        public void WhenGettingEmptyValues_ShouldReturnText()
        {
            // Arrange.

            var values = Array.Empty<string>();

            // Act.

            var text = values.ToPrettifiedText();

            // Assert.

            text
                .Should().Be("<empty>");
        }

        [Fact]
        public void WhenGettingNullOrEmptyValue_ShouldReturnText()
        {
            // Arrange.

            var values = new[]
            {
                default,
                string.Empty
            };

            // Act.

            var text = values.ToPrettifiedText();

            // Assert.

            text
                .Should().Be("[/], [/]");
        }

        [Fact]
        public void WhenGettingMultipleValues_ShouldKeepOrdering()
        {
            // Arrange.

            var values = new[]
            {
                "[_MOCK_VALUE_01_]",
                string.Empty,
                "[_MOCK_VALUE_02_]"
            };

            // Act.

            var text = values.ToPrettifiedText();

            // Assert.

            text
                .Should().Be("[[_MOCK_VALUE_01_]], [/], [[_MOCK_VALUE_02_]]");
        }

        [Fact]
        public void WhenGettingMultipleItemsWithoutValueSelector_ShouldKeepOrdering()
        {
            // Arrange.

            var numbers = new[] { 42, 21, 84 };

            // Act.

            var text = numbers.ToPrettifiedText();

            // Assert.

            text
                .Should().Be("[42], [21], [84]");
        }

        [Fact]
        public void WhenGettingMultipleItemsWithValueSelector_ShouldKeepOrderingAndSelectValue()
        {
            // Arrange.

            var dates = new[]
            {
                new DateTime(2022, 5, 1, 12, 00, 00),
                new DateTime(2000, 1, 1, 12, 15, 00),
                new DateTime(3000, 12, 31, 12, 45, 00)
            };

            // Act.

            var text = dates.ToPrettifiedText(date => date.ToString("MM/dd/yyyy"));

            // Assert.

            text
                .Should().Be("[05/01/2022], [01/01/2000], [12/31/3000]");
        }
    }
}