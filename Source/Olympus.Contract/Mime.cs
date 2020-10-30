// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mime.cs" company="nGratis">
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
// <creation_timestamp>Sunday, 29 March 2015 7:10:38 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    public class Mime
    {
        public static readonly Mime Unknown = new Mime("cop/unknown", 0, 0, string.Empty);

        public static readonly Mime None = new Mime("cop/none", 0, 0, string.Empty);

        public static readonly Mime Text = new Mime("text/plain", 0, 0, "txt");

        public static readonly Mime Csv = new Mime("text/csv", 4180, 0, "csv");

        public static readonly Mime Html = new Mime("text/html", 2854, 0, "html");

        public static readonly Mime Json = new Mime("application/json", 4627, 0, "json");

        public static readonly Mime Jpeg = new Mime("image/jpeg", 1341, 10918, "jpeg", "jpg");

        public static readonly Mime Mpeg4 = new Mime("video/mp4", 4337, 0, "mp4");

        public static readonly Mime Saz = new Mime("application/x-fiddler-session-archive", 0, 0, "saz");

        public static readonly Mime Png = new Mime("image/png", 2083, 15948, "png");

        public static readonly Mime Warc = new Mime("application/warc", 0, 28500, "warc");

        public static readonly Mime WebForm = new Mime("application/x-www-form-urlencoded", 0, 0, string.Empty);

        public static readonly Mime Xml = new Mime("text/xml", 3023, 0, "xml");

        public static readonly Mime Yaml = new Mime("none/yaml", 0, 0, "yaml", "yml");

        public static readonly Mime Zip = new Mime("application/zip", 0, 0, "zip", "zipx");

        private static readonly Dictionary<string, Mime> UniqueIdLookup;

        private static readonly Dictionary<string, Mime> NameLookup;

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        [SuppressMessage("Microsoft.Usage", "CA2207:InitializeValueTypeStaticFieldsInline")]
        static Mime()
        {
            var mimes = typeof(Mime)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(field => field.GetValue(typeof(Mime)))
                .OfType<Mime>()
                .ToArray();

            Mime.UniqueIdLookup = mimes
                .ToDictionary(mime => mime.UniqueId, mime => mime);

            Mime.NameLookup = mimes
                .SelectMany(mime => mime
                    .Extensions
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Select(name => new { Name = name, Mime = mime }))
                .ToDictionary(anon => anon.Name, anon => anon.Mime);
        }

        public Mime(string uniqueId, params string[] extensions)
        {
            Guard
                .Require(uniqueId, nameof(uniqueId))
                .Is.Not.Empty();

            Guard
                .Require(extensions, nameof(extensions))
                .Is.Not.Null()
                .Is.Not.Empty();

            Guard
                .Require(Mime.UniqueIdLookup, nameof(Mime.UniqueIdLookup))
                .Has.No.Key(uniqueId);

            this.UniqueId = uniqueId;
            this.RfcId = int.MinValue;
            this.IsoId = int.MinValue;
            this.Extensions = extensions;
        }

        private Mime(string uniqueId, int rfcId, int isoId, params string[] extensions)
        {
            Guard
                .Require(uniqueId, nameof(uniqueId))
                .Is.Not.Empty();

            Guard
                .Require(extensions, nameof(extensions))
                .Is.Not.Null()
                .Is.Not.Empty();

            this.UniqueId = uniqueId;
            this.RfcId = rfcId;
            this.IsoId = isoId;
            this.Extensions = extensions;
        }

        public string UniqueId { get; }

        public int RfcId { get; }

        public int IsoId { get; }

        public IEnumerable<string> Extensions { get; }

        public string FileExtension => $".{this.Extensions.First()}";

        public bool IsText => this.UniqueId.Split('/').First() == "text";

        public bool IsImage => this.UniqueId.Split('/').First() == "image";

        public static Mime ParseByUniqueId(string uniqueId)
        {
            Guard
                .Require(uniqueId, nameof(uniqueId))
                .Is.Not.Empty();

            Guard
                .Require(Mime.UniqueIdLookup, nameof(Mime.UniqueIdLookup))
                .Has.Key(uniqueId);

            return Mime.UniqueIdLookup[uniqueId];
        }

        public static Mime ParseByExtension(string extension)
        {
            Guard
                .Require(extension, nameof(extension))
                .Is.Not.Empty();

            extension = extension.Replace(".", string.Empty);

            Guard
                .Require(Mime.NameLookup, nameof(Mime.NameLookup))
                .Has.Key(extension);

            return Mime.NameLookup[extension];
        }

        public static bool operator ==(Mime left, Mime right)
        {
            return
                !object.Equals(left, null) && !object.Equals(right, null) &&
                left.UniqueId == right.UniqueId;
        }

        public static bool operator !=(Mime left, Mime right)
        {
            return !(left == right);
        }

        public override bool Equals(object value)
        {
            return value is Mime mime && this == mime;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + this.UniqueId?.GetHashCode() ?? 0;

            return hash;
        }

        public override string ToString()
        {
            return this.UniqueId;
        }
    }
}