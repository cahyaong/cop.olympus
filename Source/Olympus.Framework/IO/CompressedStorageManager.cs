// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressedStorageManager.cs" company="nGratis">
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
// <creation_timestamp>Thursday, October 8, 2020 6:23:49 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using nGratis.Cop.Olympus.Contract;

    public class CompressedStorageManager : IStorageManager, IDisposable
    {
        private readonly DataSpec _archiveSpec;

        private readonly ReaderWriterLockSlim _archiveLock;

        private readonly IStorageManager _storageManager;

        private readonly Lazy<ZipArchive> _deferredArchive;

        private bool _isDisposed;

        public CompressedStorageManager(DataSpec archiveSpec, IStorageManager storageManager)
            : this(archiveSpec, storageManager, false)
        {
        }

        internal CompressedStorageManager(DataSpec archiveSpec, IStorageManager storageManager, bool shouldLeaveOpen)
        {
            Guard
                .Require(archiveSpec, nameof(archiveSpec))
                .Is.Not.Null();

            Guard
                .Require(storageManager, nameof(storageManager))
                .Is.Not.Null();

            this._archiveSpec = archiveSpec;
            this._archiveLock = new ReaderWriterLockSlim();
            this._storageManager = storageManager;

            this._deferredArchive = new Lazy<ZipArchive>(
                () => this.LoadArchive(shouldLeaveOpen),
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        ~CompressedStorageManager()
        {
            this.Dispose(false);
        }

        public bool IsAvailable => true;

        public IEnumerable<DataInfo> FindEntries(string pattern, Mime mime)
        {
            // TODO: Need to standardize pattern across different storage managers!

            Guard
                .Require(pattern, nameof(pattern))
                .Is.Not.Empty();

            Guard
                .Require(mime, nameof(mime))
                .Is.Not.EqualTo(Mime.Unknown);

            var regex = new Regex($".*{pattern}.*{mime.FileExtension}$", RegexOptions.IgnoreCase);

            this._archiveLock.EnterReadLock();

            try
            {
                return this
                    ._deferredArchive.Value
                    .Entries
                    .Where(entry => regex.IsMatch(entry.Name))
                    .Select(entry => new DataInfo(Path.GetFileNameWithoutExtension(entry.Name), mime)
                    {
                        CreatedTimestamp = DateTimeOffset.MinValue
                    })
                    .ToArray();
            }
            finally
            {
                this._archiveLock.ExitReadLock();
            }
        }

        public bool HasEntry(DataSpec dataSpec)
        {
            Guard
                .Require(dataSpec, nameof(dataSpec))
                .Is.Not.Null();

            if (this._isDisposed)
            {
                return false;
            }

            var key = $"{dataSpec.Name}{dataSpec.Mime.FileExtension}";

            this._archiveLock.EnterReadLock();

            try
            {
                return this
                    ._deferredArchive.Value
                    .Entries
                    .Any(entry => entry.Name == key);
            }
            finally
            {
                this._archiveLock.ExitReadLock();
            }
        }

        public Stream LoadEntry(DataSpec dataSpec)
        {
            Guard
                .Require(dataSpec, nameof(dataSpec))
                .Is.Not.Null();

            if (this._isDisposed)
            {
                return new MemoryStream();
            }

            var key = $"{dataSpec.Name}{dataSpec.Mime.FileExtension}";

            var foundEntry = default(ZipArchiveEntry);

            this._archiveLock.EnterReadLock();

            try
            {
                foundEntry = this
                    ._deferredArchive.Value
                    .Entries
                    .SingleOrDefault(entry => entry.FullName == key);
            }
            finally
            {
                this._archiveLock.ExitReadLock();
            }

            return
                foundEntry?.Open() ??
                new MemoryStream();
        }

        public void SaveEntry(DataSpec dataSpec, Stream dataStream, bool canOverride)
        {
            Guard
                .Require(dataSpec, nameof(dataSpec))
                .Is.Not.Null();

            Guard
                .Require(dataStream, nameof(dataStream))
                .Is.Not.Null()
                .Is.Not.Empty();

            if (this._isDisposed)
            {
                return;
            }

            var canSave =
                canOverride ||
                !this.HasEntry(dataSpec);

            var key = $"{dataSpec.Name}{dataSpec.Mime.FileExtension}";

            if (!canSave)
            {
                throw new CopException($"Entry [{key}] found in archive, but overriding is not allowed!");
            }

            dataStream.Position = 0;

            this._archiveLock.EnterWriteLock();

            try
            {
                var foundEntry = this
                    ._deferredArchive.Value
                    .Entries
                    .SingleOrDefault(entry => entry.FullName == key);

                if (foundEntry == null)
                {
                    foundEntry = this
                        ._deferredArchive.Value
                        .CreateEntry(key, CompressionLevel.Optimal);
                }

                using var entryStream = foundEntry.Open();

                entryStream.SetLength(dataStream.Length);
                dataStream.CopyTo(entryStream);
                entryStream.Flush();
            }
            finally
            {
                this._archiveLock.ExitWriteLock();
            }

            dataStream.Position = 0;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private ZipArchive LoadArchive(bool shouldLeaveOpen)
        {
            if (!this._storageManager.HasEntry(this._archiveSpec))
            {
                var archiveStream = new MemoryStream();

                try
                {
                    var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true);
                    archive.Dispose();

                    this._storageManager.SaveEntry(this._archiveSpec, archiveStream, false);
                }
                finally
                {
                    archiveStream.Dispose();
                }
            }

            var dataStream = this._storageManager.LoadEntry(this._archiveSpec);

            return new ZipArchive(dataStream, ZipArchiveMode.Update, shouldLeaveOpen);
        }

        private void Dispose(bool isDisposing)
        {
            if (this._isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                if (this._deferredArchive.IsValueCreated)
                {
                    this._archiveLock.EnterWriteLock();

                    try
                    {
                        this._deferredArchive.Value.Dispose();
                    }
                    finally
                    {
                        this._archiveLock.ExitWriteLock();
                    }
                }
            }

            this._isDisposed = true;
        }
    }
}