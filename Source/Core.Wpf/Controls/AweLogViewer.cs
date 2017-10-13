// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweLogViewer.cs" company="nGratis">
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
// <creation_timestamp>Monday, 27 April 2015 2:19:34 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using nGratis.Cop.Core.Contract;

    public class AweLogViewer : ContentControl
    {
        public static readonly DependencyProperty LoggerProperty = DependencyProperty.Register(
            "Logger",
            typeof(ILogger),
            typeof(AweLogViewer),
            new PropertyMetadata(null, AweLogViewer.OnLoggerPropertyChanged));

        public static readonly DependencyProperty LogEntriesProperty = DependencyProperty.Register(
            "LogEntries",
            typeof(IList<LogEntry>),
            typeof(AweLogViewer),
            new PropertyMetadata(new ObservableCollection<LogEntry>()));

        private IDisposable loggingSubscription;

        public ILogger Logger
        {
            get => (ILogger)this.GetValue(AweLogViewer.LoggerProperty);

            set
            {
                this.loggingSubscription?.Dispose();

                this.LogEntries.Clear();

                this.loggingSubscription = value
                    .AsObservable()
                    .ObserveOn(Application.Current.Dispatcher)
                    .Subscribe(entry => this.LogEntries.Add(entry));

                this.SetValue(AweLogViewer.LoggerProperty, value);
            }
        }

        public IList<LogEntry> LogEntries => (IList<LogEntry>)this.GetValue(AweLogViewer.LogEntriesProperty);

        private static void OnLoggerPropertyChanged(
            DependencyObject container,
            DependencyPropertyChangedEventArgs args)
        {
            if (container is AweLogViewer logViewer && args.NewValue != null)
            {
                logViewer.Logger = (ILogger)args.NewValue;
            }
        }
    }
}