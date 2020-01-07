// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoResetScroll.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
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
// <creation_timestamp>Friday, 7 December 2018 10:38:53 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;

    public static class AutoResetScroll
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(AutoResetScroll),
            new PropertyMetadata(false, AutoResetScroll.OnIsEnabledChanged));

        public static bool GetIsEnabled(DependencyObject container)
        {
            return (bool)container.GetValue(AutoResetScroll.IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject container, bool value)
        {
            container.SetValue(AutoResetScroll.IsEnabledProperty, value);
        }

        private static void OnIsEnabledChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (!(container is ItemsControl itemsControl))
            {
                return;
            }

            var itemsSourceDescriptor = DependencyPropertyDescriptor.FromProperty(
                ItemsControl.ItemsSourceProperty,
                typeof(ItemsControl));

            if ((bool)args.NewValue)
            {
                itemsSourceDescriptor.AddValueChanged(itemsControl, AutoResetScroll.OnItemsSourceChanged);
            }
            else
            {
                itemsSourceDescriptor.RemoveValueChanged(itemsControl, AutoResetScroll.OnItemsSourceChanged);
            }
        }

        private static void OnItemsSourceChanged(object sender, EventArgs args)
        {
            if (!(sender is ItemsControl itemsControl))
            {
                return;
            }

            void OnContainerGeneratorStatusChanged(object _, EventArgs __)
            {
                itemsControl
                    .FindChildren<ScrollViewer>(true)
                    .ForEach(viewer => viewer.ScrollToHome());

                itemsControl.ItemContainerGenerator.StatusChanged -= OnContainerGeneratorStatusChanged;
            }

            itemsControl.ItemContainerGenerator.StatusChanged += OnContainerGeneratorStatusChanged;
        }
    }
}