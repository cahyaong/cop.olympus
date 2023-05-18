// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockBuilder.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 31 March 2018 5:14:34 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Moq;

public class MockBuilder
{
    public static Mock<T> CreateMock<T>(params object[] args)
        where T : class
    {
        return new Mock<T>(args);
    }

    public static Mock<T> CreateStub<T>(params object[] args)
        where T : class
    {
        return new Mock<T>(args)
        {
            CallBase = true
        };
    }
}