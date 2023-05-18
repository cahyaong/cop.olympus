// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mime.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 29 March 2015 7:10:38 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Mime
{
    public static readonly Mime Unknown = new("cop/unknown", 0, 0, string.Empty);

    public static readonly Mime None = new("cop/none", 0, 0, string.Empty);

    public static readonly Mime Text = new("text/plain", 0, 0, "txt");

    public static readonly Mime Csv = new("text/csv", 4180, 0, "csv");

    public static readonly Mime Html = new("text/html", 2854, 0, "html");

    public static readonly Mime Json = new("application/json", 4627, 0, "json");

    public static readonly Mime Jpeg = new("image/jpeg", 1341, 10918, "jpeg", "jpg");

    public static readonly Mime Mpeg4 = new("video/mp4", 4337, 0, "mp4");

    public static readonly Mime Saz = new("application/x-fiddler-session-archive", 0, 0, "saz");

    public static readonly Mime Png = new("image/png", 2083, 15948, "png");

    public static readonly Mime Warc = new("application/warc", 0, 28500, "warc");

    public static readonly Mime WebForm = new("application/x-www-form-urlencoded", 0, 0, string.Empty);

    public static readonly Mime Xml = new("text/xml", 3023, 0, "xml");

    public static readonly Mime Yaml = new("none/yaml", 0, 0, "yaml", "yml");

    public static readonly Mime Zip = new("application/zip", 0, 0, "zip", "zipx");

    private static readonly IReadOnlyDictionary<string, Mime> ByUniqueIdLookup;

    private static readonly IReadOnlyDictionary<string, Mime> ByNameLookup;

    static Mime()
    {
        var mimes = typeof(Mime)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field => field.GetValue(typeof(Mime)))
            .OfType<Mime>()
            .ToArray();

        Mime.ByUniqueIdLookup = mimes
            .ToDictionary(mime => mime.UniqueId, mime => mime);

        Mime.ByNameLookup = mimes
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
            .Require(Mime.ByUniqueIdLookup, nameof(Mime.ByUniqueIdLookup))
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
            .Require(Mime.ByUniqueIdLookup, nameof(Mime.ByUniqueIdLookup))
            .Has.Key(uniqueId);

        return Mime.ByUniqueIdLookup[uniqueId];
    }

    public static Mime ParseByExtension(string extension)
    {
        Guard
            .Require(extension, nameof(extension))
            .Is.Not.Empty();

        extension = extension.Replace(".", string.Empty);

        Guard
            .Require(Mime.ByNameLookup, nameof(Mime.ByNameLookup))
            .Has.Key(extension);

        return Mime.ByNameLookup[extension];
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