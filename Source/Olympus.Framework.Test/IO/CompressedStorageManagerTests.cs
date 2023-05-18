// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressedStorageManagerTests.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, October 10, 2020 5:45:01 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework.Test;

using System;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Linq;
using FluentAssertions;
using Moq;
using nGratis.Cop.Olympus.Contract;
using Xunit;

public class CompressedStorageManagerTests
{
    public class FindEntriesMethod
    {
        [Fact]
        public void WhenGettingMatches_ShouldReturnRelevantDataInfo()
        {
            // Arrange.

            var archiveSpec = new DataSpec("[_MOCK_ARCHIVE_NAME_]", Mime.Zip);

            var mockManager = MockBuilder
                .CreateMock<IStorageManager>()
                .WithCompressedEntry(
                    archiveSpec,
                    (new DataSpec("[_MOCK_IMAGE_NAME_01_]", Mime.Jpeg), "[_MOCK_IMAGE_CONTENT_01_]"),
                    (new DataSpec("[_MOCK_IMAGE_NAME_02_]", Mime.Jpeg), "[_MOCK_IMAGE_CONTENT_02_]"),
                    (new DataSpec("[_MOCK_IMAGE_NAME_03_]", Mime.Png), "[_MOCK_IMAGE_CONTENT_03_]"),
                    (new DataSpec("[_MOCK_CSV_NAME_]", Mime.Csv), "[_MOCK_CSV_CONTENT_]"),
                    (new DataSpec("[_MOCK_TEXT_NAME_]", Mime.Text), "[_MOCK_TEXT_CONTENT_]"));

            var compressedManager = new CompressedStorageManager(archiveSpec, mockManager.Object);

            // Act.

            var matchedEntries = compressedManager
                .FindEntries(@"IMAGE_NAME_\d{2}", Mime.Jpeg)?
                .ToImmutableArray();

            // Assert.

            matchedEntries
                .Should().NotBeNull();

            var filteredEntries = matchedEntries?
                .Where(entry => entry != null)
                .ToImmutableArray() ?? new ImmutableArray<DataInfo>();

            filteredEntries
                .Should().HaveCount(2);

            filteredEntries
                .Select(entry => $"{entry.Name}{entry.Mime.FileExtension}")
                .Should().Contain("[_MOCK_IMAGE_NAME_01_].jpeg")
                .And.Contain("[_MOCK_IMAGE_NAME_02_].jpeg");
        }

        [Fact]
        public void WhenGettingNoMatch_ShouldReturnNoDataInfo()
        {
            // Arrange.

            var archiveSpec = new DataSpec("[_MOCK_ARCHIVE_NAME_]", Mime.Zip);

            var mockManager = MockBuilder
                .CreateMock<IStorageManager>()
                .WithCompressedEntry(
                    archiveSpec,
                    (new DataSpec("[_MOCK_IMAGE_NAME_]", Mime.Jpeg), "[_MOCK_IMAGE_CONTENT_]"),
                    (new DataSpec("[_MOCK_CSV_NAME_]", Mime.Csv), "[_MOCK_CSV_CONTENT_]"),
                    (new DataSpec("[_MOCK_TEXT_NAME_]", Mime.Text), "[_MOCK_TEXT_CONTENT_]"));

            var compressedManager = new CompressedStorageManager(archiveSpec, mockManager.Object);

            // Act.

            var matchedEntries = compressedManager
                .FindEntries(@"ZIP_NAME", Mime.Zip)?
                .ToList();

            // Assert.

            matchedEntries
                .Should().NotBeNull()
                .And.BeEmpty();
        }
    }

    public class SaveEntryMethod
    {
        [Fact]
        public void WhenOverridingExistingEntry_ShouldNotCreateNewEntryWithSameSpec()
        {
            // Arrange.

            var archiveSpec = new DataSpec("[_MOCK_ARCHIVE_NAME_]", Mime.Zip);
            var entrySpec = new DataSpec("[_MOCK_IMAGE_NAME_]", Mime.Jpeg);

            var mockManager = MockBuilder
                .CreateMock<IStorageManager>()
                .WithCompressedEntry(archiveSpec, (entrySpec, "[_MOCK_IMAGE_CONTENT_]"));

            var compressedManager = new CompressedStorageManager(archiveSpec, mockManager.Object, true);

            // Act.

            try
            {
                compressedManager.SaveEntry(
                    entrySpec,
                    "[_MOCK_ANOTHER_IMAGE_CONTENT_]".AsStream(),
                    true);
            }
            finally
            {
                compressedManager.Dispose();
            }

            // Assert.

            using var archive = new ZipArchive(
                mockManager.Object.LoadEntry(archiveSpec),
                ZipArchiveMode.Read,
                false);

            var entryKey = $"{entrySpec.Name}{entrySpec.Mime.FileExtension}";

            var matchedEntries = archive
                .Entries
                .Where(entry => entry.FullName == entryKey)
                .ToImmutableArray();

            matchedEntries
                .Should().HaveCount(1);

            using var entryStream = matchedEntries
                .Single()
                .Open();

            entryStream
                .ReadText()
                .Should().Be("[_MOCK_ANOTHER_IMAGE_CONTENT_]");
        }

        [Fact]
        public void WhenFindingExistingEntryButOverrideNotAllowed_ShouldThrowCopException()
        {
            // Arrange.

            var archiveSpec = new DataSpec("[_MOCK_ARCHIVE_NAME_]", Mime.Zip);
            var entrySpec = new DataSpec("[_MOCK_IMAGE_NAME_]", Mime.Jpeg);

            var mockManager = MockBuilder
                .CreateMock<IStorageManager>()
                .WithCompressedEntry(archiveSpec, (entrySpec, "[_MOCK_IMAGE_CONTENT_]"));

            var compressedManager = new CompressedStorageManager(archiveSpec, mockManager.Object, true);

            // Act.

            var action = new Action(() =>
            {
                compressedManager.SaveEntry(
                    entrySpec,
                    "[_MOCK_ANOTHER_IMAGE_CONTENT_]".AsStream(),
                    false);
            });

            // Assert.

            var entryKey = $"{entrySpec.Name}{entrySpec.Mime.FileExtension}";

            action
                .Should().Throw<CopException>()
                .WithMessage($"Entry [{entryKey}] found in archive, but overriding is not allowed!");
        }
    }
}