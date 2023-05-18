// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDisposableCollection.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 12 December 2018 9:07:10 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;
using System.Collections.Generic;

public interface IDisposableCollection<TItem> : IList<TItem>, IDisposable
{
}