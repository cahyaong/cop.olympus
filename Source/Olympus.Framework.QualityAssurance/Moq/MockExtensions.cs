// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 9 April 2018 9:56:54 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq;

using System.Collections.Generic;
using System.Linq;
using nGratis.Cop.Olympus.Contract;

public static partial class MockExtensions
{
    public static T[] ToObjects<T>(this IEnumerable<Mock<T>> mocks)
        where T : class

    {
        Guard
            .Require(mocks, nameof(mocks))
            .Is.Not.Null()
            .Is.Not.Empty();

        return mocks
            .Select(mock => mock.Object)
            .ToArray();
    }
}