﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweButton.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 10 May 2015 12:54:19 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

[TemplatePart(Name = "PART_Border", Type = typeof(Ellipse))]
[TemplatePart(Name = "PART_Icon", Type = typeof(Path))]
public class AweButton : ButtonBase
{
    public static readonly DependencyProperty IconGeometryProperty = DependencyProperty.Register(
        "IconGeometry",
        typeof(Geometry),
        typeof(AweButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register(
        "AccentColor",
        typeof(Color),
        typeof(AweButton),
        new PropertyMetadata(Color.FromArgb(0xFF, 0x7F, 0x7F, 0x7F)));

    public static readonly DependencyProperty MeasurementProperty = DependencyProperty.Register(
        "Measurement",
        typeof(Measurement),
        typeof(AweButton),
        new PropertyMetadata(
            Measurement.M,
            (container, _) => (container as AweButton)?.UpdateMeasurement()));

    public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register(
        "EllipseDiameter",
        typeof(double),
        typeof(AweButton),
        new PropertyMetadata(0.0));

    public static readonly DependencyProperty IconLengthProperty = DependencyProperty.Register(
        "IconLength",
        typeof(double),
        typeof(AweButton),
        new PropertyMetadata(0.0));

    public static readonly DependencyProperty IsRepeatedProperty = DependencyProperty.Register(
        "IsRepeated",
        typeof(bool),
        typeof(AweButton),
        new PropertyMetadata(false));

    public static readonly DependencyProperty RepeatingIntervalProperty = DependencyProperty.Register(
        "RepeatingInterval",
        typeof(TimeSpan),
        typeof(AweButton),
        new PropertyMetadata(
            TimeSpan.FromMilliseconds(100),
            (container, args) => (container as AweButton)?.UpdateRepeatingTimer((TimeSpan)args.NewValue)));

    public static readonly DependencyProperty IsMousePressedProperty = DependencyProperty.Register(
        "IsMousePressed",
        typeof(bool),
        typeof(AweButton),
        new PropertyMetadata(false));

    public static readonly DependencyProperty IsBorderHiddenProperty = DependencyProperty.Register(
        "IsBorderHidden",
        typeof(bool),
        typeof(AweButton),
        new PropertyMetadata(false));

    private readonly DispatcherTimer _repeatingTimer = new();

    public AweButton()
    {
        this._repeatingTimer.Tick += this.OnRepeatingTimerTicked;
        this._repeatingTimer.Interval = this.RepeatingInterval;

        this.UpdateMeasurement();
    }

    public Geometry IconGeometry
    {
        get => (Geometry)this.GetValue(AweButton.IconGeometryProperty);
        set => this.SetValue(AweButton.IconGeometryProperty, value);
    }

    public Color AccentColor
    {
        get => (Color)this.GetValue(AweButton.AccentColorProperty);
        set => this.SetValue(AweButton.AccentColorProperty, value);
    }

    public Measurement Measurement
    {
        get => (Measurement)this.GetValue(AweButton.MeasurementProperty);
        set => this.SetValue(AweButton.MeasurementProperty, value);
    }

    public double EllipseDiameter
    {
        get => (double)this.GetValue(AweButton.EllipseDiameterProperty);
        private set => this.SetValue(AweButton.EllipseDiameterProperty, value);
    }

    public double IconLength
    {
        get => (double)this.GetValue(AweButton.IconLengthProperty);
        private set => this.SetValue(AweButton.IconLengthProperty, value);
    }

    public bool IsRepeated
    {
        get => (bool)this.GetValue(AweButton.IsRepeatedProperty);
        set => this.SetValue(AweButton.IsRepeatedProperty, value);
    }

    public TimeSpan RepeatingInterval
    {
        get => (TimeSpan)this.GetValue(AweButton.RepeatingIntervalProperty);
        set => this.SetValue(AweButton.RepeatingIntervalProperty, value);
    }

    public bool IsMousePressed
    {
        get => (bool)this.GetValue(AweButton.IsMousePressedProperty);
        private set => this.SetValue(AweButton.IsMousePressedProperty, value);
    }

    public bool IsBorderHidden
    {
        get => (bool)this.GetValue(AweButton.IsBorderHiddenProperty);
        set => this.SetValue(AweButton.IsBorderHiddenProperty, value);
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs args)
    {
        base.OnMouseLeftButtonDown(args);

        if (!this.IsRepeated || this.ClickMode == ClickMode.Hover)
        {
            return;
        }

        if (Mouse.LeftButton == MouseButtonState.Pressed)
        {
            this.IsMousePressed = true;
            this.Focus();
        }

        this._repeatingTimer.Start();
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs args)
    {
        base.OnMouseLeftButtonUp(args);

        if (!this.IsRepeated || this.ClickMode == ClickMode.Hover)
        {
            return;
        }

        this._repeatingTimer.Stop();
        this.IsMousePressed = false;
    }

    protected override void OnLostMouseCapture(MouseEventArgs args)
    {
        base.OnLostMouseCapture(args);

        this._repeatingTimer.Stop();
        this.IsMousePressed = false;
    }

    protected override void OnMouseEnter(MouseEventArgs args)
    {
        base.OnMouseEnter(args);

        if (this.IsRepeated && this.IsMouseOver && this.ClickMode != ClickMode.Hover)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.IsMousePressed = true;
                this.Focus();
            }

            this._repeatingTimer.Start();
        }
    }

    protected override void OnMouseLeave(MouseEventArgs args)
    {
        base.OnMouseLeave(args);

        if (this.IsRepeated && !this.IsMouseOver && this.ClickMode != ClickMode.Hover)
        {
            this._repeatingTimer.Stop();
            this.IsMousePressed = false;
        }
    }

    private void OnRepeatingTimerTicked(object sender, EventArgs args)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed)
        {
            this.IsMousePressed = true;
            this.OnClick();
        }
        else
        {
            this._repeatingTimer.Stop();
            this.IsMousePressed = false;
        }
    }

    private void UpdateMeasurement()
    {
        switch (this.Measurement)
        {
            case Measurement.XS:
                this.EllipseDiameter = 20;
                this.IconLength = 10;
                this.BorderThickness = new Thickness(1);
                break;

            case Measurement.S:
                this.EllipseDiameter = 24;
                this.IconLength = 12;
                this.BorderThickness = new Thickness(1);
                break;

            case Measurement.L:
                this.EllipseDiameter = 64;
                this.IconLength = 36;
                this.BorderThickness = new Thickness(2);
                break;

            case Measurement.XL:
                this.EllipseDiameter = 48;
                this.IconLength = 26;
                this.BorderThickness = new Thickness(2);
                break;

            case Measurement.XXL:
                this.EllipseDiameter = 96;
                this.IconLength = 54;
                this.BorderThickness = new Thickness(3);
                break;

            default:
                this.EllipseDiameter = 32;
                this.IconLength = 16;
                this.BorderThickness = new Thickness(1);
                break;
        }
    }

    private void UpdateRepeatingTimer(TimeSpan interval)
    {
        if (interval < TimeSpan.FromMilliseconds(50))
        {
            interval = TimeSpan.FromMilliseconds(50);
        }

        this._repeatingTimer.Interval = interval;
    }
}