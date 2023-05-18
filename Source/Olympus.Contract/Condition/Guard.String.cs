// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.String.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 2 March 2018 9:46:32 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

using System.Diagnostics;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static ValidationContinuation<string> Empty(this ClassValidator<string> validator)
    {
        return validator.Validate(
            string.IsNullOrEmpty,
            "be empty");
    }
}