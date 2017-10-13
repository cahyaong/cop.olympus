// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSpecification.cs" company="nGratis">
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
// <creation_timestamp>Friday, 3 April 2015 12:03:14 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using nGratis.Cop.Core.Contract;

    public class DataSpecification : IDataSpecification
    {
        public DataSpecification(string name, Mime contentMime)
            : this(VoidStorageProvider.Default, name, contentMime)
        {
        }

        public DataSpecification(IStorageProvider storageProvider, string name, Mime contentMime)
        {
            Guard.Require.IsNotNull(storageProvider);
            Guard.Require.IsNotEmpty(name);
            Guard.Require.IsNotNull(contentMime);
            Guard.Require.IsNotEqualTo(contentMime, Mime.Unknown);

            this.ContentMime = contentMime;
            this.Name = name;
            this.StorageProvider = storageProvider;
        }

        public Mime ContentMime { get; }

        public string Name { get; }

        public string FullName => $"{this.Name}.{this.ContentMime.Names.First()}";

        public IStorageProvider StorageProvider { get; }

        public Stream LoadData()
        {
            return this.StorageProvider.LoadData(this);
        }

        public void SaveData(Stream dataStream)
        {
            this.StorageProvider.SaveData(this, dataStream);
        }

        public override string ToString()
        {
            return $"ngds://./{this.Name}{this.ContentMime.Names.First()}";
        }
    }
}