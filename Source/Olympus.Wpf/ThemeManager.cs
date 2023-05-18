// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 19 February 2016 9:05:33 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Windows;
using System.Windows.Media;
using nGratis.Cop.Olympus.Contract;

public class ThemeManager : IThemeManager
{
    private ThemeManager()
    {
        this.AccentBrush = this.FindBrush("Cop.Brush.Accent");
        this.ApplicationBackgroundBrush = this.FindBrush("Cop.Brush.Application.Background");
    }

    // TODO: Replace singleton with DI and IoC!

    public static IThemeManager Instance { get; } = new ThemeManager();

    public Brush AccentBrush { get; }

    public Brush ApplicationBackgroundBrush { get; }

    public Color FindColor(string key)
    {
        return this.FindResource(key, Default.Color);
    }

    public Brush FindBrush(string key)
    {
        return this.FindResource(key, Default.Brush);
    }

    public TValue FindResource<TValue>(string key, TValue defaultValue)
    {
        Guard
            .Require(key, nameof(key))
            .Is.Not.Empty();

        return (TValue)(Application.Current.Resources[key] ?? defaultValue);
    }

    public static class Default
    {
        public static readonly Color Color = Colors.HotPink;

        public static readonly Brush Brush;

        static Default()
        {
            Default.Brush = new SolidColorBrush(Colors.HotPink);
            Default.Brush.Freeze();
        }
    }
}