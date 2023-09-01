// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweSlider.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 17 April 2015 9:49:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

public class AweSlider : Slider
{
    public static readonly DependencyProperty StableValueProperty = DependencyProperty.Register(
        "StableValue",
        typeof(double),
        typeof(AweSlider),
        new PropertyMetadata(default(double), AweSlider.OnStableValueChanged));

    public double StableValue
    {
        get => (double)this.GetValue(AweSlider.StableValueProperty);
        set => this.SetValue(AweSlider.StableValueProperty, value);
    }

    public bool IsMouseDragging { get; private set; }

    public bool IsKeyPressed { get; private set; }

    protected override void OnThumbDragStarted(DragStartedEventArgs args)
    {
        base.OnThumbDragStarted(args);
        this.IsMouseDragging = true;
    }

    protected override void OnThumbDragCompleted(DragCompletedEventArgs args)
    {
        this.StableValue = this.Value;
        this.IsMouseDragging = false;
        base.OnThumbDragCompleted(args);
    }

    protected override void OnKeyDown(KeyEventArgs args)
    {
        base.OnKeyDown(args);
        this.IsKeyPressed = true;
    }

    protected override void OnKeyUp(KeyEventArgs args)
    {
        this.StableValue = this.Value;
        this.IsKeyPressed = false;
        base.OnKeyUp(args);
    }

    private static void OnStableValueChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        var slider = container as AweSlider;
        var value = (double)args.NewValue;

        if (slider != null && !value.IsCloseTo(slider.Value))
        {
            slider.Value = value;
        }
    }
}