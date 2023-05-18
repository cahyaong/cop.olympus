// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoidStorageManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 3 April 2015 9:22:12 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using nGratis.Cop.Olympus.Contract;

public class VoidStorageManager : IStorageManager
{
    private VoidStorageManager()
    {
    }

    public static VoidStorageManager Default { get; } = new();

    public bool IsAvailable => false;

    public IEnumerable<DataInfo> FindEntries(string pattern, Mime mime)
    {
        return Enumerable.Empty<DataInfo>();
    }

    public bool HasEntry(DataSpec dataSpec)
    {
        return false;
    }

    public Stream LoadEntry(DataSpec dataSpec)
    {
        return new MemoryStream();
    }

    public void SaveEntry(DataSpec dataSpec, Stream dataStream, bool canOverride)
    {
    }
}