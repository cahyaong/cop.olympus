// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweStatusBar.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2017 Cahya Ong
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
// <creation_timestamp>Friday, 30 November 2018 12:08:39 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using nGratis.Cop.Core.Contract;

    [TemplatePart(Name = "PART_ResponsivenessIndicator", Type = typeof(Grid))]
    public sealed class AweStatusBar : Control, IDisposable
    {
        public static readonly DependencyProperty LoggerProperty = DependencyProperty.Register(
            nameof(AweStatusBar.Logger),
            typeof(ILogger),
            typeof(AweStatusBar),
            new PropertyMetadata(VoidLogger.Instance, AweStatusBar.OnLoggerChanged));

        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            nameof(AweStatusBar.IsBusy),
            typeof(bool),
            typeof(AweStatusBar),
            new PropertyMetadata(false));

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(AweStatusBar.Message),
            typeof(string),
            typeof(AweStatusBar),
            new PropertyMetadata(string.Empty));

        private IDisposable _onLogEntryAdded;

        private bool _isDisposed;

        ~AweStatusBar()
        {
            this.Dispose(false);
        }

        public ILogger Logger
        {
            get => (ILogger)this.GetValue(AweStatusBar.LoggerProperty);
            set => this.SetValue(AweStatusBar.LoggerProperty, value ?? VoidLogger.Instance);
        }

        public bool IsBusy
        {
            get => (bool)this.GetValue(AweStatusBar.IsBusyProperty);
            private set => this.SetValue(AweStatusBar.IsBusyProperty, value);
        }

        public string Message
        {
            get => (string)this.GetValue(AweStatusBar.MessageProperty);
            private set => this.SetValue(AweStatusBar.MessageProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

#if !DEBUG
            if (this.GetTemplateChild("PART_ResponsivenessIndicator") is Grid responsivenessGrid)
            {
                responsivenessGrid.Children.Clear();
                responsivenessGrid.Visibility = Visibility.Collapsed;
            }
#endif
        }

        private static void OnLoggerChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (!(container is AweStatusBar statusBar))
            {
                return;
            }

            statusBar._onLogEntryAdded?.Dispose();

            var logger = (ILogger)args.NewValue;

            if (logger != null)
            {
                statusBar._onLogEntryAdded = logger
                    .WhenLogEntryAdded()?
                    .ObserveOnDispatcher()
                    .Subscribe(statusBar.UpdateMessage);
            }
        }

        private void UpdateMessage(LogEntry logEntry)
        {
            Guard
                .Require(logEntry, nameof(logEntry))
                .Is.Not.Null();

            this.Message = logEntry.Message;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (this._isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                this._onLogEntryAdded?.Dispose();
            }

            this._isDisposed = true;
        }
    }
}