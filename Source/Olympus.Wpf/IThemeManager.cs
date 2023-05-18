// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IThemeManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 19 February 2016 9:04:10 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Windows.Media;

public interface IThemeManager
{
    Brush AccentBrush { get; }

    Brush ApplicationBackgroundBrush { get; }

    Color FindColor(string key);

    Brush FindBrush(string key);

    TValue FindResource<TValue>(string key, TValue defaultValue);
}