// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweChart.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 6 February 2016 12:26:05 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Windows;
using System.Windows.Controls;

public class AweChart : ItemsControl
{
    public static readonly DependencyProperty ConfigProperty = DependencyProperty.Register(
        "Config",
        typeof(ChartConfig),
        typeof(AweChart),
        new PropertyMetadata(null));

    public ChartConfig Config
    {
        get => (ChartConfig)this.GetValue(AweChart.ConfigProperty);
        set => this.SetValue(AweChart.ConfigProperty, value);
    }
}