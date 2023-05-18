// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweWindow.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, 29 November 2018 9:32:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

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
    private static readonly DependencyProperty LoggingNotifierProperty = DependencyProperty.Register(
        nameof(AweWindow.LoggingNotifier),
        typeof(ILoggingNotifier),
        typeof(AweWindow),
        new PropertyMetadata(VoidLogger.Instance, AweWindow.OnLoggingNotifierChanged));

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

    public ILoggingNotifier LoggingNotifier
    {
        get => (ILoggingNotifier)this.GetValue(AweWindow.LoggingNotifierProperty);
        init => this.SetValue(AweWindow.LoggingNotifierProperty, value ?? VoidLogger.Instance);
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

    private static void OnLoggingNotifierChanged(
        DependencyObject container,
        DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweWindow window)
        {
            return;
        }

        if (window._statusBar != null)
        {
            window._statusBar.LoggingNotifier = (ILoggingNotifier)args.NewValue ?? VoidLogger.Instance;
        }
    }

    private void InitializeContentPart()
    {
        if (this.GetTemplateChild("PART_Content") is not MetroContentControl metroContent)
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

        if (this.LoggingNotifier != null)
        {
            this._statusBar.LoggingNotifier = this.LoggingNotifier;
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

    private void OnClosed(object sender, EventArgs args)
    {
        this.Closed -= this.OnClosed;

        if (Application.Current.Resources["Bootstrapper"] is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    private async Task OnUnhandledExceptionReceivedAsync(
        CopBootstrapper.ExceptionSource exceptionSource,
        Exception exception)
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
            exception?.ToString() ?? DefinedText.Unknown,
            MessageDialogStyle.Affirmative,
            dialogSettings);
    }
}