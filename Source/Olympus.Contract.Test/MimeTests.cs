// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MimeTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Tuesday, 24 April 2018 12:53:51 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

using System;
using System.Collections.Generic;
using FluentAssertions;
using nGratis.Cop.Olympus.Framework;
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

    public class ParseByExtensionMethod
    {
        [Fact]
        public void WhenGettingExistingPrimaryExtension_ShouldReturnExistingInstance()
        {
            // Arrange.

            // Act.

            var mime = Mime.ParseByExtension(".txt");

            // Assert.

            mime
                .Should().Be(Mime.Text);
        }

        [Fact]
        public void WhenGettingExistingNonPrimaryExtension_ShouldReturnExistingInstance()
        {
            // Arrange.

            // Act.

            var mime = Mime.ParseByExtension(".jpg");

            // Assert.

            mime
                .Should().Be(Mime.Jpeg);
        }

        [Fact]
        public void WhenGettingNonExistedExtension_ShouldThrowCopPreConditionException()
        {
            // Arrange.

            // Act.

            var action = new Action(() =>
            {
                var _ = Mime.ParseByExtension("[_MOCK_FILE_EXTENSION_]");
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
        public void WhenGettingEquivalentInstances_ShouldReturnTrue(MimeEquivalentTheory theory)
        {
            // Arrange.

            // Act.

            var isEqual = theory.LeftMime == theory.RightMime;

            // Assert.

            isEqual
                .Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(SharedTestData.NonEquivalentMimeTheories), MemberType = typeof(SharedTestData))]
        public void WhenGettingNonEquivalentInstances_ShouldReturnFalse(MimeEquivalentTheory theory)
        {
            // Arrange.

            // Act.

            var isEqual = theory.LeftMime == theory.RightMime;

            // Assert.

            isEqual
                .Should().BeFalse();
        }
    }

    public class GetHashCodeMethod
    {
        [Theory]
        [MemberData(nameof(SharedTestData.EquivalentMimeTheories), MemberType = typeof(SharedTestData))]
        public void WhenGettingEquivalentInstances_ShouldReturnSameHashValue(MimeEquivalentTheory theory)
        {
            // Arrange.

            // Act.

            var leftHash = theory.LeftMime.GetHashCode();
            var rightHash = theory.RightMime.GetHashCode();

            // Assert.

            leftHash
                .Should().Be(rightHash);
        }

        [Theory]
        [MemberData(nameof(SharedTestData.NonEquivalentMimeTheories), MemberType = typeof(SharedTestData))]
        public void WhenGettingNonEquivalentInstances_ShouldReturnDifferentHashValue(MimeEquivalentTheory theory)
        {
            // Arrange.

            // Act.

            var leftHash = theory.LeftMime.GetHashCode();
            var rightHash = theory.RightMime.GetHashCode();

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
                yield return MimeEquivalentTheory
                    .Create(
                        Mime.Text,
                        Mime.Text)
                    .WithLabel(1, "Both predefined MIME instances.")
                    .ToXunitTheory();

                yield return MimeEquivalentTheory
                    .Create(
                        new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_]"),
                        new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_]"))
                    .WithLabel(2, "Both new MIME instances with same unique ID and extension.")
                    .ToXunitTheory();

                yield return MimeEquivalentTheory
                    .Create(
                        new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_01_]"),
                        new Mime("[_MOCK_UNIQUE_ID_]", "[_MOCK_EXTENSION_02_]"))
                    .WithLabel(3, "Both new MIME instances with same unique ID but different extensions.")
                    .ToXunitTheory();
            }
        }

        public static IEnumerable<object[]> NonEquivalentMimeTheories
        {
            get
            {
                yield return MimeEquivalentTheory
                    .Create(
                        Mime.Text,
                        Mime.Xml)
                    .WithLabel(1, "Both predefined MIME instances.")
                    .ToXunitTheory();

                yield return MimeEquivalentTheory
                    .Create(
                        new Mime("[_MOCK_UNIQUE_ID_01_]", "[_MOCK_EXTENSION_01_]"),
                        new Mime("[_MOCK_UNIQUE_ID_02_]", "[_MOCK_EXTENSION_02_]"))
                    .WithLabel(2, "Both new MIME instances with different unique IDs and extensions.")
                    .ToXunitTheory();

                yield return MimeEquivalentTheory
                    .Create(
                        new Mime("[_MOCK_UNIQUE_ID_01_]", "[_MOCK_EXTENSION_]"),
                        new Mime("[_MOCK_UNIQUE_ID_02_]", "[_MOCK_EXTENSION_]"))
                    .WithLabel(3, "Both new MIME instances with different unique IDs but same extension.")
                    .ToXunitTheory();

                yield return MimeEquivalentTheory
                    .Create(
                        Mime.Text,
                        new Mime("[_MOCK_UNIQUE_ID_]", "txt"))
                    .WithLabel(4, "Combination MIME instances with different unique IDs but same extension.")
                    .ToXunitTheory();
            }
        }
    }

    public class MimeEquivalentTheory : CopTheory
    {
        public Mime LeftMime { get; private init; }

        public Mime RightMime { get; private init; }

        public static MimeEquivalentTheory Create(Mime leftMime, Mime rightMime)
        {
            return new()
            {
                LeftMime = leftMime,
                RightMime = rightMime
            };
        }
    }
}