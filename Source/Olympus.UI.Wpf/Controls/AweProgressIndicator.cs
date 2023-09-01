// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweProgressIndicator.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 21 June 2015 6:14:43 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;

// TODO: Implement a functionality to avoid progress bar if the active flag is toggled under certain threshold.

[TemplatePart(Name = "PART_BusyRing", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_BusyBar", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_Message", Type = typeof(FrameworkElement))]
public class AweProgressIndicator : ContentControl
{
    public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
        "IsActive",
        typeof(bool),
        typeof(AweProgressIndicator),
        new PropertyMetadata(false, AweProgressIndicator.OnIsActiveChanged));

    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
        "Message",
        typeof(string),
        typeof(AweProgressIndicator),
        new PropertyMetadata(null));

    public static readonly DependencyProperty VisualizationModeProperty = DependencyProperty.Register(
        "VisualizationMode",
        typeof(VisualizationMode),
        typeof(AweProgressIndicator),
        new PropertyMetadata(VisualizationMode.Ring));

    public AweProgressIndicator()
    {
        this.Visibility = Visibility.Hidden;
    }

    public bool IsActive
    {
        get => (bool)this.GetValue(AweProgressIndicator.IsActiveProperty);
        set => this.SetValue(AweProgressIndicator.IsActiveProperty, value);
    }

    public string Message
    {
        get => (string)this.GetValue(AweProgressIndicator.MessageProperty);
        set => this.SetValue(AweProgressIndicator.MessageProperty, value);
    }

    public VisualizationMode VisualizationMode
    {
        get => (VisualizationMode)this.GetValue(AweProgressIndicator.VisualizationModeProperty);
        set => this.SetValue(AweProgressIndicator.VisualizationModeProperty, value);
    }

    protected FrameworkElement BusyRingPart { get; private set; }

    protected FrameworkElement BusyBarPart { get; private set; }

    protected FrameworkElement MessagePart { get; private set; }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        this.BusyRingPart = (FrameworkElement)this.Template.FindName("PART_BusyRing", this);
        this.BusyBarPart = (FrameworkElement)this.Template.FindName("PART_BusyBar", this);
        this.MessagePart = (FrameworkElement)this.Template.FindName("PART_Message", this);

        Guard
            .Require(this.BusyRingPart, nameof(this.BusyRingPart))
            .Is.Not.Null();

        Guard
            .Require(this.BusyBarPart, nameof(this.BusyBarPart))
            .Is.Not.Null();

        Guard
            .Require(this.MessagePart, nameof(this.MessagePart))
            .Is.Not.Null();

        this.BusyRingPart.Visibility = Visibility.Collapsed;
        this.BusyBarPart.Visibility = Visibility.Collapsed;
        this.MessagePart.Visibility = Visibility.Collapsed;
    }

    private static void OnIsActiveChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweProgressIndicator indicator)
        {
            return;
        }

        var isActive = (bool)args.NewValue;

        if (!isActive)
        {
            indicator.Visibility = Visibility.Hidden;
            return;
        }

        indicator.Visibility = Visibility.Visible;

        switch ((VisualizationMode)Enum.Parse(typeof(VisualizationMode), indicator.VisualizationMode.ToString()))
        {
            case VisualizationMode.Ring:
                indicator.BusyRingPart.Visibility = Visibility.Visible;
                indicator.BusyBarPart.Visibility = Visibility.Collapsed;
                break;

            case VisualizationMode.Bar:
                indicator.BusyRingPart.Visibility = Visibility.Collapsed;
                indicator.BusyBarPart.Visibility = Visibility.Visible;
                break;

            default:
                indicator.BusyRingPart.Visibility = Visibility.Collapsed;
                indicator.BusyBarPart.Visibility = Visibility.Collapsed;
                break;
        }

        indicator.MessagePart.Visibility = string.IsNullOrWhiteSpace(indicator.Message)
            ? Visibility.Collapsed
            : Visibility.Visible;
    }
}