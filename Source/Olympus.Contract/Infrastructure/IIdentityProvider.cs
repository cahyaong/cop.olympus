// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIdentityProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 12:59:14 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System;

public interface IIdentityProvider
{
    Guid CreateGuid();

    Guid CreateGuid(string content);

    string CreateId();
}