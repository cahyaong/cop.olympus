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

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using FirstFloor.ModernUI.Windows.Controls;
    using nGratis.Cop.Core.Contract;
    using nGratis.Cop.Core.Framework;

    public class AweWindow : ModernWindow, IDisposable
    {
        private static readonly DependencyProperty LoggerProperty = DependencyProperty.Register(
            nameof(AweWindow.Logger),
            typeof(ILogger),
            typeof(AweWindow),
            new PropertyMetadata(VoidLogger.Instance, AweWindow.OnLoggerChanged));

        private readonly IThemeManager _themeManager;

        private AweStatusBar _statusBar;

        private bool _isDisposed;

        public AweWindow()
            : this(ThemeManager.Instance)
        {
        }

        ~AweWindow()
        {
            this.Dispose(false);
        }

        internal AweWindow(IThemeManager themeManager)
        {
            Guard
                .Require(themeManager, nameof(themeManager))
                .Is.Not.Null();

            this._themeManager = themeManager;

            this.Closed += this.OnClosed;
        }

        public ILogger Logger
        {
            get => (ILogger)this.GetValue(AweWindow.LoggerProperty);
            set => this.SetValue(AweWindow.LoggerProperty, value ?? VoidLogger.Instance);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!(this.GetTemplateChild("LayoutRoot") is Grid layoutGrid))
            {
                return;
            }

            if (!(this.GetTemplateChild("ContentFrame") is ModernFrame contentFrame))
            {
                return;
            }

            if (!(this.GetTemplateChild("ResizeGrip") is Grid resizingGrid))
            {
                return;
            }

            this._statusBar?.Dispose();

            this._statusBar = new AweStatusBar();
            this._statusBar.SetValue(Grid.RowProperty, 3);
            this._statusBar.VerticalAlignment = VerticalAlignment.Bottom;

            if (this.Logger != null)
            {
                this._statusBar.Logger = this.Logger;
            }

            contentFrame.Margin = new Thickness(
                contentFrame.Margin.Left,
                contentFrame.Margin.Top,
                contentFrame.Margin.Right,
                this._themeManager.FindResource("Cop.StatusBar.Height", 0.0) + 8);

            resizingGrid
                .Children
                .Cast<FrameworkElement>()
                .OfType<System.Windows.Shapes.Path>()
                .ToList()
                .ForEach(path => path.Stroke = this._themeManager.ApplicationBackgroundBrush);

            layoutGrid.Children.Remove(resizingGrid);
            layoutGrid.Children.Add(this._statusBar);
            layoutGrid.Children.Add(resizingGrid);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage(
            "Microsoft.Usage",
            "CA2213:DisposableFieldsShouldBeDisposed",
            MessageId = "_statusBar",
            Justification = "Does not work with NULL propagation syntax.")]
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
    }
}