// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallbackResult.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 31 January 2016 7:00:05 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

public class CallbackResult
{
    private CallbackResult()
    {
    }

    public bool HasError { get; private init; }

    public static CallbackResult OnSuccessful()
    {
        return new();
    }

    public static CallbackResult OnFailure()
    {
        return new()
        {
            HasError = true
        };
    }
}