// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweTile.cs" company="nGratis">
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
// <creation_timestamp>Monday, 26 November 2018 11:32:38 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;

public class AweTile : Control
{
    private static readonly IReadOnlyDictionary<Type, Func<object, string>> FormatterLookup;

    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(AweTile.Header),
        typeof(string),
        typeof(AweTile),
        new PropertyMetadata(Text.Undefined));

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(AweTile.Value),
        typeof(object),
        typeof(AweTile),
        new PropertyMetadata(null, AweTile.OnValueChanged));

    static AweTile()
    {
        AweTile.FormatterLookup = new Dictionary<Type, Func<object, string>>
        {
            [typeof(int)] = value => ((int)value).ToString("N0")
        };
    }

    public static readonly DependencyProperty FormattedValueProperty = DependencyProperty.Register(
        nameof(AweTile.FormattedValue),
        typeof(string),
        typeof(AweTile),
        new PropertyMetadata("-"));

    public string Header
    {
        get => (string)this.GetValue(AweTile.HeaderProperty);
        set => this.SetValue(AweTile.HeaderProperty, value);
    }

    public object Value
    {
        get => this.GetValue(AweTile.ValueProperty);
        set => this.SetValue(AweTile.ValueProperty, value);
    }

    public string FormattedValue
    {
        get => (string)this.GetValue(AweTile.FormattedValueProperty);
        private set => this.SetValue(AweTile.FormattedValueProperty, value);
    }

    private static void OnValueChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweTile tile)
        {
            return;
        }

        if (args.NewValue == null)
        {
            tile.FormattedValue = "-";
        }
        else
        {
            tile.FormattedValue = AweTile.FormatterLookup.TryGetValue(args.NewValue.GetType(), out var format)
                ? format(args.NewValue)
                : args.ToString();
        }
    }
}