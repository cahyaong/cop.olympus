// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweTileGroup.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 14 December 2018 10:34:29 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;

public class AweTileGroup : ContentControl
{
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(AweTileGroup.Header),
        typeof(string),
        typeof(AweTileGroup),
        new PropertyMetadata(DefinedText.Unknown));

    public string Header
    {
        get => (string)this.GetValue(AweTileGroup.HeaderProperty);
        set => this.SetValue(AweTileGroup.HeaderProperty, value);
    }
}