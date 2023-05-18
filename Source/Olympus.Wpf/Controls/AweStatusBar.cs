// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweStatusBar.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 30 November 2018 12:08:39 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Framework;

[TemplatePart(Name = "PART_ResponsivenessIndicator", Type = typeof(Grid))]
public sealed class AweStatusBar : Control, IDisposable
{
    public static readonly DependencyProperty LoggingNotifierProperty = DependencyProperty.Register(
        nameof(AweStatusBar.LoggingNotifier),
        typeof(ILoggingNotifier),
        typeof(AweStatusBar),
        new PropertyMetadata(VoidLogger.Instance, AweStatusBar.OnLoggingNotifierChanged));

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

    private IDisposable _onLoggingEntryAdded;

    private bool _isDisposed;

    ~AweStatusBar()
    {
        this.Dispose(false);
    }

    public ILoggingNotifier LoggingNotifier
    {
        get => (ILoggingNotifier)this.GetValue(AweStatusBar.LoggingNotifierProperty);
        set => this.SetValue(AweStatusBar.LoggingNotifierProperty, value ?? VoidLogger.Instance);
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

    private static void OnLoggingNotifierChanged(
        DependencyObject container,
        DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweStatusBar statusBar)
        {
            return;
        }

        statusBar._onLoggingEntryAdded?.Dispose();

        var loggingNotifier = (ILoggingNotifier)args.NewValue;

        if (loggingNotifier != null)
        {
            statusBar._onLoggingEntryAdded = loggingNotifier
                .WhenEntryAdded?
                .ObserveOnDispatcher()
                .Subscribe(statusBar.UpdateMessage);
        }
    }

    private void UpdateMessage(LoggingEntry loggingEntry)
    {
        Guard
            .Require(loggingEntry, nameof(loggingEntry))
            .Is.Not.Null();

        this.Message = loggingEntry.Message;
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
            this._onLoggingEntryAdded?.Dispose();
        }

        this._isDisposed = true;
    }
}