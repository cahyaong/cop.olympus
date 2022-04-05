// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweLoggingViewer.cs" company="nGratis">
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
// <creation_timestamp>Monday, 27 April 2015 2:19:34 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

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