// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileSystemStorageManager.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Friday, 3 April 2015 12:10:59 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using nGratis.Cop.Core.Contract;

    public class FileSystemStorageManager : IStorageManager
    {
        public FileSystemStorageManager(Uri rootUri)
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
                using (var reader = new StreamReader(dataStream))
                using (var writer = new StreamWriter(File.OpenWrite(fileUri.LocalPath), Encoding.UTF8))
                {
                    writer.Write(reader.ReadToEnd());
                    writer.Flush();
                }
            }
            else
            {
                using (var fileStream = new FileStream(fileUri.LocalPath, FileMode.Create))
                {
                    dataStream.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
        }
    }
}