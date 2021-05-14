// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChildrenMargin.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
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
// <creation_timestamp>Friday, 14 December 2018 9:29:34 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public static class ChildrenMargin
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(Size),
            typeof(ChildrenMargin),
            new PropertyMetadata(Size.Empty, ChildrenMargin.OnValueChanged));

        public static readonly DependencyProperty IsHorizontalExcludedProperty = DependencyProperty.RegisterAttached(
            "IsHorizontalExcluded",
            typeof(bool),
            typeof(ChildrenMargin),
            new PropertyMetadata(false, ChildrenMargin.OnIsHorizontalExcludedChanged));

        public static readonly DependencyProperty IsVerticalExcludedProperty = DependencyProperty.RegisterAttached(
            "IsVerticalExcluded",
            typeof(bool),
            typeof(ChildrenMargin),
            new PropertyMetadata(false, ChildrenMargin.OnIsVerticalExcludedChanged));

        public static Size GetValue(DependencyObject container)
        {
            return (Size)container.GetValue(ChildrenMargin.ValueProperty);
        }

        public static void SetValue(DependencyObject container, Size value)
        {
            container.SetValue(ChildrenMargin.ValueProperty, value);
        }

        public static bool GetIsHorizontalExcluded(DependencyObject container)
        {
            return (bool)container.GetValue(ChildrenMargin.IsHorizontalExcludedProperty);
        }

        public static void SetIsHorizontalExcluded(DependencyObject container, bool value)
        {
            container.SetValue(ChildrenMargin.IsHorizontalExcludedProperty, value);
        }

        public static bool GetIsVerticalExcluded(DependencyObject container)
        {
            return (bool)container.GetValue(ChildrenMargin.IsVerticalExcludedProperty);
        }

        public static void SetIsVerticalExcluded(DependencyObject container, bool value)
        {
            container.SetValue(ChildrenMargin.IsVerticalExcludedProperty, value);
        }

        private static void OnValueChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (container is not Panel panel)
            {
                return;
            }

            panel.Loaded -= ChildrenMargin.OnPanelLoaded;
            panel.Loaded += ChildrenMargin.OnPanelLoaded;
        }

        private static void OnPanelLoaded(object sender, RoutedEventArgs args)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            var value = ChildrenMargin.GetValue(panel);

            // TODO: Take into account orientation and alignment!
            // TODO: Handle a case when it's grid with both rows and columns defined!

            var elements = panel
                .Children
                .OfType<FrameworkElement>()
                .ToArray();

            elements
                .Where((_, index) => index < panel.Children.Count - 1)
                .ForEach(element => element.UpdateMargin(value.Width, value.Height));

            if (elements.Any())
            {
                elements
                    .Last()
                    .UpdateMargin(0, 0);
            }
        }

        private static void UpdateMargin(this FrameworkElement element, double right, double bottom)
        {
            var margin = element.Margin;

            if (!ChildrenMargin.GetIsHorizontalExcluded(element))
            {
                margin.Right = right;
            }

            if (!ChildrenMargin.GetIsVerticalExcluded(element))
            {
                margin.Bottom = bottom;
            }

            element.Margin = margin;
        }

        private static void OnIsHorizontalExcludedChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (container is not FrameworkElement element)
            {
                return;
            }

            var isHorizontalExcluded = (bool)args.NewValue;

            if (!isHorizontalExcluded)
            {
                return;
            }

            var margin = element.Margin;
            margin.Right = 0;
            element.Margin = margin;
        }

        private static void OnIsVerticalExcludedChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (container is not FrameworkElement element)
            {
                return;
            }

            var isVerticalExcluded = (bool)args.NewValue;

            if (!isVerticalExcluded)
            {
                return;
            }

            var margin = element.Margin;
            margin.Bottom = 0;
            element.Margin = margin;
        }
    }
}