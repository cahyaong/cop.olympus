// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweTile.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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
        new PropertyMetadata(DefinedText.Unknown));

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