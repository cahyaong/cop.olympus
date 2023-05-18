// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModuleProvider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Collections.Generic;
using System.Reflection;

public interface IModuleProvider
{
    IEnumerable<Assembly> FindModuleAssemblies();

    IEnumerable<Assembly> FindInternalAssemblies();
}