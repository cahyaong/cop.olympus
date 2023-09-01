// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweLoggingViewer.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 27 April 2015 2:19:34 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Framework;

public class AweLoggingViewer : ContentControl
{
    public static readonly DependencyProperty LoggingNotifierProperty = DependencyProperty.Register(
        "LoggingNotifier",
        typeof(ILoggingNotifier),
        typeof(AweLoggingViewer),
        new PropertyMetadata(null, AweLoggingViewer.OnLoggingNotifierChanged));

    public static readonly DependencyProperty LoggingEntriesProperty = DependencyProperty.Register(
        "LoggingEntries",
        typeof(IList<LoggingEntry>),
        typeof(AweLoggingViewer),
        new PropertyMetadata(new ObservableCollection<LoggingEntry>()));

    private IDisposable _onLoggingEntryAdded;

    public ILoggingNotifier LoggingNotifier
    {
        get => (ILoggingNotifier)this.GetValue(AweLoggingViewer.LoggingNotifierProperty);

        set
        {
            this._onLoggingEntryAdded?.Dispose();
            this.LoggingEntries.Clear();

            this._onLoggingEntryAdded = value
                .WhenEntryAdded
                .Subscribe(this.LoggingEntries.Add);

            this.SetValue(AweLoggingViewer.LoggingNotifierProperty, value);
        }
    }

    public IList<LoggingEntry> LoggingEntries => (IList<LoggingEntry>)this
        .GetValue(AweLoggingViewer.LoggingEntriesProperty);

    private static void OnLoggingNotifierChanged(
        DependencyObject container,
        DependencyPropertyChangedEventArgs args)
    {
        if (container is AweLoggingViewer logViewer && args.NewValue != null)
        {
            logViewer.LoggingNotifier = (ILoggingNotifier)args.NewValue;
        }
    }
}