﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MimeTests.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2018 Cahya Ong
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
// <creation_timestamp>Tuesday, 24 April 2018 12:53:51 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract.UnitTest
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using nGratis.Cop.Core.Testing;
    using Xunit;

    public class MimeTests
    {
        public class Constructor
        {
            [Fact]
            public void WhenGettingExistingUniqueId_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                // Act.

                var action = new Action(() =>
                {
                    var _ = new Mime(Mime.Text.UniqueId, "[_MOCK_EXTENSION_]");
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>();
            }
        }

        public class ParseByUniqueIdMethod
        {
            [Fact]
            public void WhenGettingExistingUniqueId_ShouldReturnExistingInstance()
            {
                // Arrange.

                // Act.

                var mime = Mime.ParseByUniqueId("text/plain");

                // Assert.

                mime
                    .Should().Be(Mime.Text);
            }

            [Fact]
            public void WhenGettingNonExistedUniqueId_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                // Act.

                var action = new Action(() =>
                {
                    var _ = Mime.ParseByUniqueId("[_MOCK_UNIQUE_ID_]");
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>();
            }
        }

        public class ParseByFileExtensionMethod
        {
            [Fact]
            public void WhenGettingExistingPrimaryFileExtension_ShouldReturnExistingInstance()
            {
                // Arrange.

                // Act.

                var mime = Mime.ParseByFileExtension(".txt");

                // Assert.

                mime
                    .Should().Be(Mime.Text);
            }

            [Fact]
            public void WhenGettingExistingNonPrimaryFileExtension_ShouldReturnExistingInstance()
            {
                // Arrange.

                // Act.

                var mime = Mime.ParseByFileExtension(".jpg");

                // Assert.

                mime
                    .Should().Be(Mime.Jpeg);
            }

            [Fact]
            public void WhenGettingNonExistedFileExtension_ShouldThrowCopPreConditionException()
            {
                // Arrange.

                // Act.

                var action = new Action(() =>
                {
                    var _ = Mime.ParseByFileExtension("[_MOCK_FILE_EXTENSION_]");
                });

                // Assert.

                action
                    .Should().Throw<CopPreConditionException>();
            }
        }

        public class EqualOperator
        {
            [Theory]
            [MemberData(nameof(SharedTestData.EquivalentMimeTheories), MemberType = typeof(SharedTestData))]
            public void WhenGettingEquivalentInstances_ShouldReturnTrue(
                CopTheory<(Mime LeftMime, Mime RightMime)> theory)
            {
                // Arrange.

                // Act.

                var isEqual = theory.Parameter.LeftMime == theory.Parameter.RightMime;

                // Assert.

                isEqual
                    .Should().BeTrue();
            }

            [Theory]
            [MemberData(nameof(SharedTestData.NonEquivalentMimeTheories), MemberType = typeof(SharedTestData))]
            public void WhenGettingNonEquivalentInstances_ShouldReturnFalse(
                CopTheory<(Mime LeftMime, Mime RightMime)> theory)
            {
                // Arrange.

                // Act.

                var isEqual = theory.Parameter.LeftMime == theory.Parameter.RightMime;

                // Assert.

                isEqual
                    .Should().BeFalse();
            }
        }

        public class GetHashCodeMethod
        {
            [Theory]
            [MemberData(nameof(SharedTestData.EquivalentMimeTheories), MemberType = typeof(SharedTestData))]
            public void WhenGettingEquivalentInstances_ShouldReturnSameHashValue(
                CopTheory<(Mime LeftMime, Mime RightMime)> theory)
            {
                // Arrange.

                // Act.

                var leftHash = theory.Parameter.LeftMime.GetHashCode();
                var rightHash = theory.Parameter.RightMime.GetHashCode();

                // Assert.

                leftHash
                    .Should().Be(rightHash);
            }

            [Theory]
            [MemberData(nameof(SharedTestData.NonEquivalentMimeTheories), MemberType = typeof(SharedTestData))]
            public void WhenGettingNonEquivalentInstances_ShouldReturnDifferentHashValue(
                CopTheory<(Mime LeftMime, Mime RightMime)> theory)
            {
                // Arrange.

                // Act.

                var leftHash = theory.Parameter.LeftMime.GetHashCode();
                var rightHash = theory.Parameter.RightMime.GetHashCode();

                // Assert.

                leftHash
                    .Should().NotBe(rightHash);
            }
        }

        public static class SharedTestData
        {
            public static IEnumerable<object[]> EquivalentMimeTheories
            {
                get
                {
                    yield return SharedTestData
                        .CreateTheory(Mime.Text, Mime.Text)
                        .WithLabel("CASE 01 -> Both predefined MIME instances.")
                        .ToXunitTheory();

                    yield return SharedTestData
                        .CreateTheory(
                            new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_]"),
                            new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_]"))
                        .WithLabel("CASE 02 -> Both new MIME instances with same unique ID and extension.")
                        .ToXunitTheory();

                    yield return SharedTestData
                        .CreateTheory(
                            new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_01_]"),
                            new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_02_]"))
                        .WithLabel("CASE 03 -> Both new MIME instances with same unique ID but different extensions.")
                        .ToXunitTheory();
                }
            }

            public static IEnumerable<object[]> NonEquivalentMimeTheories
            {
                get
                {
                    yield return SharedTestData
                        .CreateTheory(Mime.Text, Mime.Xml)
                        .WithLabel("CASE 01 -> Both predefined MIME instances.")
                        .ToXunitTheory();

                    yield return SharedTestData
                        .CreateTheory(
                            new Mime("[_MOCK_UNIQUE_ID_01_]", "[_MOCK_EXTENSION_01_]"),
                            new Mime("[_MOCK_UNIQUE_ID_02_]", "[_MOCK_EXTENSION_02_]"))
                        .WithLabel("CASE 02 -> Both new MIME instances with different unique IDs and extensions.")
                        .ToXunitTheory();

                    yield return SharedTestData
                        .CreateTheory(
                            new Mime("[_MOCK_UNIQUE_ID_01_]", "[_MOCK_EXTENSION_]"),
                            new Mime("[_MOCK_UNIQUE_ID_02_]", "[_MOCK_EXTENSION_]"))
                        .WithLabel("CASE 03 -> Both new MIME instances with different unique IDs but same extension.")
                        .ToXunitTheory();

                    yield return SharedTestData
                        .CreateTheory(
                            Mime.Text,
                            new Mime("[_MOCK_UNIQUE_ID_]", "txt"))
                        .WithLabel("CASE 04 -> Combination MIME instances with different unique IDs but same extension.")
                        .ToXunitTheory();
                }
            }

            private static CopTheory CreateTheory(Mime leftMime, Mime rightMime)
            {
                return new CopTheory<(Mime LeftMime, Mime RightMime)>((leftMime, rightMime));
            }
        }
    }
}