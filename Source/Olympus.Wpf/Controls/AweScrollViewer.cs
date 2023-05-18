// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweScrollViewer.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 4 March 2016 9:54:13 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

public class AweScrollViewer : ScrollViewer
{
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
        "Orientation",
        typeof(Orientation),
        typeof(AweScrollViewer),
        new PropertyMetadata(Orientation.Vertical, AweScrollViewer.OnOrientationChanged));

    public Orientation Orientation
    {
        get => (Orientation)this.GetValue(AweScrollViewer.OrientationProperty);
        set => this.SetValue(AweScrollViewer.OrientationProperty, value);
    }

    protected override void OnMouseEnter(MouseEventArgs args)
    {
        base.OnMouseEnter(args);

        if (!this.IsFocused)
        {
            this.Focus();
        }
    }

    protected override void OnMouseWheel(MouseWheelEventArgs args)
    {
        base.OnMouseWheel(args);

        if (this.Orientation == Orientation.Horizontal)
        {
            if (args.Delta > 0)
            {
                ScrollBar.LineLeftCommand.Execute(null, null);
            }
            else
            {
                ScrollBar.LineRightCommand.Execute(null, null);
            }
        }

        args.Handled = true;
    }

    private static void OnOrientationChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweScrollViewer scrollViewer)
        {
            return;
        }

        if ((Orientation)args.NewValue == Orientation.Vertical)
        {
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
        else
        {
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        }
    }
}