// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweScrollBar.cs" company="nGratis">
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
// <creation_timestamp>Saturday, 26 March 2016 9:36:09 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
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

        private ButtonBase leftButton;
        private ButtonBase rightButton;

        public AweScrollBar()
        {
            this.ValueChanged += (_, __) => this.UpdateButtonStates();
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

            this.leftButton = (ButtonBase)this.Template.FindName("PART_LeftButton", this);
            this.rightButton = (ButtonBase)this.Template.FindName("PART_RightButton", this);

            this.UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            var value = this.Value;

            if (this.Orientation == Orientation.Vertical)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (this.leftButton == null || this.rightButton == null)
                {
                    return;
                }

                if (value <= 0)
                {
                    this.leftButton.IsEnabled = false;
                    this.rightButton.IsEnabled = true;
                }
                else if (value + this.ActualWidth >= this.ContentWidth)
                {
                    this.leftButton.IsEnabled = true;
                    this.rightButton.IsEnabled = false;
                }
                else
                {
                    this.leftButton.IsEnabled = true;
                    this.rightButton.IsEnabled = true;
                }
            }
        }
    }
}