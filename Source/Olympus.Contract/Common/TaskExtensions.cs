// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, May 1, 2021 7:03:50 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System.Threading.Tasks;

using nGratis.Cop.Olympus.Contract;

public static class TaskExtensions
{
    public static T RunSynchronously<T>(this Task<T> task)
    {
        Guard
            .Require(task, nameof(task))
            .Is.Not.Null();

        return task
            .GetAwaiter()
            .GetResult();
    }
}