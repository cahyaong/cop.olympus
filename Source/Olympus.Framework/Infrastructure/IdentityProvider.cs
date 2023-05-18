// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 1:01:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using nGratis.Cop.Olympus.Contract;

public class IdentityProvider : IIdentityProvider
{
    private IdentityProvider()
    {
    }

    public static IIdentityProvider Instance { get; } = new IdentityProvider();

    public Guid CreateGuid()
    {
        return Guid.NewGuid();
    }

    public Guid CreateGuid(string content)
    {
        Guard
            .Require(content, nameof(content))
            .Is.Not.Empty();

        var md5 = MD5.Create();

        return new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(content)));
    }

    public string CreateId()
    {
        return this
            .CreateGuid()
            .ToString("D")
            .ToUpper(CultureInfo.InvariantCulture);
    }
}