// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoResetScroll.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 7 December 2018 10:38:53 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

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
        if (container is not ItemsControl itemsControl)
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
        if (sender is not ItemsControl itemsControl)
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