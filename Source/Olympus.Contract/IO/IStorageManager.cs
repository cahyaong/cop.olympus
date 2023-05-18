// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStorageManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 29 March 2015 7:01:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Collections.Generic;
using System.IO;

public interface IStorageManager
{
    bool IsAvailable { get; }

    IEnumerable<DataInfo> FindEntries(string pattern, Mime mime);

    bool HasEntry(DataSpec dataSpec);

    Stream LoadEntry(DataSpec dataSpec);

    void SaveEntry(DataSpec dataSpec, Stream dataStream, bool canOverride);
}