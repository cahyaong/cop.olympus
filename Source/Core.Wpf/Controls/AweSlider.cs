// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweSlider.cs" company="nGratis">
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
// <creation_timestamp>Friday, 17 April 2015 9:49:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
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
}