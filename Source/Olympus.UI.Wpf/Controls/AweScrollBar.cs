// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweScrollBar.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 26 March 2016 9:36:09 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

[TemplatePart(Name = "PART_UpButton", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_DownButton", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_LeftButton", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_RightButton", Type = typeof(ButtonBase))]
public class AweScrollBar : ScrollBar
{
    public static readonly DependencyProperty ContentWidthProperty = DependencyProperty.Register(
        "ContentWidth",
        typeof(double),
        typeof(AweScrollBar),
        new PropertyMetadata(double.MaxValue));

    public static readonly DependencyProperty ContentHeightProperty = DependencyProperty.Register(
        "ContentHeight",
        typeof(double),
        typeof(AweScrollBar),
        new PropertyMetadata(double.MaxValue));

    private ButtonBase _leftButton;
    private ButtonBase _rightButton;

    public AweScrollBar()
    {
        this.ValueChanged += (_, _) => this.UpdateButtonStates();
    }

    public double ContentWidth
    {
        get => (double)this.GetValue(AweScrollBar.ContentWidthProperty);
        set => this.SetValue(AweScrollBar.ContentWidthProperty, value);
    }

    public double ContentHeight
    {
        get => (double)this.GetValue(AweScrollBar.ContentHeightProperty);
        set => this.SetValue(AweScrollBar.ContentHeightProperty, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        this._leftButton = (ButtonBase)this.Template.FindName("PART_LeftButton", this);
        this._rightButton = (ButtonBase)this.Template.FindName("PART_RightButton", this);

        this.UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        var value = this.Value;

        if (this.Orientation == Orientation.Vertical)
        {
            throw new NotSupportedException("Updating button states to vertical orientation is not allowed!");
        }

        if (this._leftButton == null || this._rightButton == null)
        {
            return;
        }

        if (value <= 0)
        {
            this._leftButton.IsEnabled = false;
            this._rightButton.IsEnabled = true;
        }
        else if (value + this.ActualWidth >= this.ContentWidth)
        {
            this._leftButton.IsEnabled = true;
            this._rightButton.IsEnabled = false;
        }
        else
        {
            this._leftButton.IsEnabled = true;
            this._rightButton.IsEnabled = true;
        }
    }
}