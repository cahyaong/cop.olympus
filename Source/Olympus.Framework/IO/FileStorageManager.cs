// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileStorageManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 3 April 2015 12:10:59 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using nGratis.Cop.Olympus.Contract;

public class FileStorageManager : IStorageManager
{
    public FileStorageManager(Uri rootUri)
    {
        Guard
            .Require(rootUri, nameof(rootUri))
            .Is.Folder();

        this.RootUri = rootUri;

        if (!Directory.Exists(rootUri.LocalPath))
        {
            Directory.CreateDirectory(rootUri.LocalPath);
        }
    }

    public Uri RootUri { get; }

    public bool IsAvailable => Directory.Exists(this.RootUri.LocalPath);

    public IEnumerable<DataInfo> FindEntries(string pattern, Mime mime)
    {
        Guard
            .Require(mime, nameof(mime))
            .Is.Not.Null();

        if (string.IsNullOrEmpty(pattern))
        {
            pattern = "*";
        }

        return Directory
            .GetFiles(this.RootUri.LocalPath, $"{pattern}{mime.FileExtension}", SearchOption.TopDirectoryOnly)
            .Select(path => new FileInfo(path))
            .Select(info => new DataInfo(Path.GetFileNameWithoutExtension(info.Name), mime)
            {
                CreatedTimestamp = new DateTimeOffset(info.CreationTimeUtc, TimeSpan.Zero)
            });
    }

    public bool HasEntry(DataSpec dataSpec)
    {
        Guard
            .Require(dataSpec, nameof(dataSpec))
            .Is.Not.Null();

        var filePath = Path.Combine(this.RootUri.LocalPath, dataSpec.GetFileName());

        return File.Exists(filePath);
    }

    public Stream LoadEntry(DataSpec dataSpec)
    {
        Guard
            .Require(dataSpec, nameof(dataSpec))
            .Is.Not.Null();

        var fileStream = File.Open(
            Path.Combine(this.RootUri.LocalPath, dataSpec.GetFileName()),
            FileMode.Open);

        if (fileStream.CanSeek)
        {
            fileStream.Position = 0;
        }

        return fileStream;
    }

    public void SaveEntry(DataSpec dataSpec, Stream dataStream, bool canOverride)
    {
        Guard
            .Require(dataSpec, nameof(dataSpec))
            .Is.Not.Null();

        Guard
            .Require(dataStream, nameof(dataStream))
            .Is.Not.Null()
            .Is.Readable();

        var fileUri = new Uri(Path.Combine(this.RootUri.LocalPath, dataSpec.GetFileName()));

        if (!canOverride)
        {
            Guard
                .Require(fileUri, nameof(fileUri))
                .Is.Not.Exist();
        }

        if (dataStream.CanSeek)
        {
            dataStream.Position = 0;
        }

        if (dataSpec.Mime.IsText)
        {
            using var reader = new StreamReader(dataStream);
            using var writer = new StreamWriter(File.OpenWrite(fileUri.LocalPath), Encoding.UTF8);

            writer.Write(reader.ReadToEnd());
            writer.Flush();
        }
        else
        {
            using var fileStream = new FileStream(fileUri.LocalPath, FileMode.Create);

            dataStream.CopyTo(fileStream);
            fileStream.Flush();
        }
    }
}