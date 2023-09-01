// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, 24 March 2016 9:04:41 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Windows;
using System.Windows.Media;
using nGratis.Cop.Olympus.Contract;

public static class ApplicationExtensions
{
    public static void AdjustAccentColor(this Application application, Color accentColor)
    {
        Guard
            .Require(application, nameof(application))
            .Is.Not.Null();

        application.Resources["Cop.Color.Accent"] = accentColor;
    }
}