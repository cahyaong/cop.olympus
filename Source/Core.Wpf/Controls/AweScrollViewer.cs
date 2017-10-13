// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweScrollViewer.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Friday, 4 March 2016 9:54:13 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
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
            var scrollViewer = container as AweScrollViewer;

            if (scrollViewer == null)
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
}