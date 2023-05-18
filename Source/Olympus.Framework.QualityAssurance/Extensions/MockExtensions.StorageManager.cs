// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockExtensions.StorageManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, October 10, 2020 5:32:49 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.IO;
using System.IO.Compression;
using System.Text;
using Moq;
using nGratis.Cop.Olympus.Contract;

public static partial class MockExtensions
{
    // TODO: Replace tuple with C# 9 record!

    public static Mock<IStorageManager> WithCompressedEntry(
        this Mock<IStorageManager> mockManager,
        DataSpec entrySpec,
        params (DataSpec ContentSpec, string Content)[] entries)
    {
        Guard
            .Require(mockManager, nameof(mockManager))
            .Is.Not.Null();

        Guard
            .Require(entrySpec, nameof(entrySpec))
            .Is.Not.Null();

        Guard
            .Require(entries, nameof(entries))
            .Is.Not.Null()
            .Is.Not.Empty();

        var archiveStream = new MemoryStream();

        using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
        {
            foreach (var (contentSpec, content) in entries)
            {
                var archiveEntry = archive.CreateEntry($"{contentSpec.Name}{contentSpec.Mime.FileExtension}");
                var buffer = Encoding.UTF8.GetBytes(content);

                using var archiveEntrySteam = archiveEntry.Open();

                archiveEntrySteam.Write(buffer, 0, buffer.Length);
                archiveEntrySteam.Flush();
            }
        }

        mockManager
            .Setup(mock => mock.LoadEntry(Arg.DataSpec.Is(entrySpec.Name, entrySpec.Mime)))
            .Returns(() => archiveStream)
            .Verifiable();

        return mockManager
            .WithAvailability(entrySpec);
    }

    public static Mock<IStorageManager> WithAvailability(
        this Mock<IStorageManager> mockManager,
        DataSpec entrySpec)
    {
        mockManager
            .Setup(mock => mock.IsAvailable)
            .Returns(true)
            .Verifiable();

        mockManager
            .Setup(mock => mock.FindEntries(entrySpec.Name, entrySpec.Mime))
            .Returns(new[] { new DataInfo(entrySpec.Name, entrySpec.Mime) })
            .Verifiable();

        mockManager
            .Setup(mock => mock.HasEntry(Arg.DataSpec.Is(entrySpec.Name, entrySpec.Mime)))
            .Returns(true)
            .Verifiable();

        return mockManager;
    }
}