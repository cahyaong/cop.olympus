// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagingDataProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 7 December 2018 10:58:00 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

public interface IPagingDataProvider<TItem>
{
    TItem DefaultItem { get; }

    [SuppressMessage(
        "Microsoft.Design",
        "CA1024:UsePropertiesWhereAppropriate",
        Justification = "Getting count must be done asynchronously!")]
    Task<int> GetCountAsync();

    [SuppressMessage(
        "Microsoft.Design",
        "CA1006:DoNotNestGenericTypesInMemberSignatures",
        Justification = "Task returning collection of specific type.")]
    Task<IReadOnlyCollection<TItem>> GetItemsAsync(int pagingIndex, int itemCount);
}