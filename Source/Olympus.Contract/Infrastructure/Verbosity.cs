// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Verbosity.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 11:36:55 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

public enum Verbosity
{
    None = 0,
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal
}