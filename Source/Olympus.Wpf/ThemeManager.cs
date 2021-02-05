// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeManager.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </copyright>
// <author>Cahya Ong - cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 19 February 2016 9:05:33 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf
{
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
}