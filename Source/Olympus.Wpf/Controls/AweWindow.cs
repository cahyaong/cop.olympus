// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweWindow.cs" company="nGratis">
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
// <creation_timestamp>Thursday, 29 November 2018 9:32:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using nGratis.Cop.Olympus.Contract;
    using nGratis.Cop.Olympus.Framework;

    public class AweWindow : MetroWindow, IDisposable
    {
        private static readonly DependencyProperty LoggerProperty = DependencyProperty.Register(
            nameof(AweWindow.Logger),
            typeof(ILogger),
            typeof(AweWindow),
            new PropertyMetadata(VoidLogger.Instance, AweWindow.OnLoggerChanged));

        private AweStatusBar _statusBar;

        private bool _isDisposed;

        public AweWindow()
        {
            this.Closed += this.OnClosed;
        }

        ~AweWindow()
        {
            this.Dispose(false);
        }

        public ILogger Logger
        {
            get => (ILogger)this.GetValue(AweWindow.LoggerProperty);
            set => this.SetValue(AweWindow.LoggerProperty, value ?? VoidLogger.Instance);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.InitializeContentPart();
            this.InitializeUnhandledExceptionHandler();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (this._isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                this._statusBar?.Dispose();
            }

            this._isDisposed = true;
        }

        private void InitializeContentPart()
        {
            if (!(this.GetTemplateChild("PART_Content") is MetroContentControl metroContent))
            {
                return;
            }

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto }
                }
            };

            if (metroContent.Content is FrameworkElement innerContent)
            {
                metroContent.Content = default;
                innerContent.SetValue(Grid.RowProperty, 0);
                innerContent.Margin = new Thickness(8, 2, 8, 2);
                grid.Children.Add(innerContent);
            }

            this._statusBar = new AweStatusBar();
            this._statusBar.SetValue(Grid.RowProperty, 1);
            this._statusBar.VerticalAlignment = VerticalAlignment.Center;

            if (this.Logger != null)
            {
                this._statusBar.Logger = this.Logger;
            }

            grid.Children.Add(this._statusBar);

            metroContent.Content = grid;
        }

        private void InitializeUnhandledExceptionHandler()
        {
            // TODO: Fix unhandled exception handler, so that dialog should be acknowledged before app is closed!

            CopBootstrapper.UnhandledExceptionTriggered += async (_, args) => await this
                .OnUnhandledExceptionReceivedAsync(args.ExceptionSource, args.Exception);
        }

        private static void OnLoggerChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (!(container is AweWindow window))
            {
                return;
            }

            if (window._statusBar != null)
            {
                window._statusBar.Logger = (ILogger)args.NewValue ?? VoidLogger.Instance;
            }
        }

        private void OnClosed(object sender, EventArgs args)
        {
            this.Closed -= this.OnClosed;

            if (Application.Current.Resources["Bootstrapper"] is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        private async Task OnUnhandledExceptionReceivedAsync(CopBootstrapper.ExceptionSource exceptionSource, Exception exception)
        {
            var dialogSettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "OK",
                ColorScheme = MetroDialogColorScheme.Theme,
                DialogButtonFontSize = 11,
                MaximumBodyHeight = this.Height * 0.3
            };

            await this.ShowMessageAsync(
                 $"Unhandled Exception ({exceptionSource})",
                 exception?.ToString() ?? Text.Unknown,
                 MessageDialogStyle.Affirmative,
                 dialogSettings);
        }
    }
}