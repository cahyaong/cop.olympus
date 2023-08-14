// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockExtensions.KeyCalculator.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, August 13, 2023 3:43:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq;

using System;
using System.IO;
using nGratis.Cop.Olympus.Contract;

public static partial class MockExtensions
{
    public static Mock<IKeyCalculator> WithMapping(
        this Mock<IKeyCalculator> mockCalculator,
        string url,
        string key)
    {
        Guard
            .Require(mockCalculator, nameof(mockCalculator))
            .Is.Not.Null();

        Guard
            .Require(url, nameof(url))
            .Is.Not.Empty();

        Guard
            .Require(key, nameof(key))
            .Is.Not.Empty();

        var name = Path.GetFileNameWithoutExtension(key);
        var extension = Path.GetExtension(key);

        var mime = !string.IsNullOrEmpty(extension)
            ? Mime.ParseByExtension(extension)
            : Mime.Text;

        mockCalculator
            .Setup(mock => mock.Calculate(It.Is<Uri>(uri => uri.ToString() == url)))
            .Returns(new DataSpec(name, mime))
            .Verifiable();

        return mockCalculator;
    }
}