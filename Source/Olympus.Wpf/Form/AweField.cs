// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweField.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using nGratis.Cop.Olympus.Contract;

[TemplatePart(Name = "PART_ValuePresenter", Type = typeof(ContentPresenter))]
public class AweField : Control
{
    public static readonly DependencyProperty ModeProperty = DependencyProperty.Register(
        nameof(AweField.Mode),
        typeof(FieldMode),
        typeof(AweField),
        new PropertyMetadata(FieldMode.Unknown));

    public static readonly DependencyProperty KindProperty = DependencyProperty.Register(
        nameof(AweField.Kind),
        typeof(FieldKind),
        typeof(AweField),
        new PropertyMetadata(FieldKind.Unknown));

    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(AweField.Header),
        typeof(string),
        typeof(AweField),
        new PropertyMetadata(DefinedText.Unknown));

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(AweField.Value),
        typeof(object),
        typeof(AweField),
        new PropertyMetadata(default, AweField.OnValueChanged));

    public static readonly DependencyProperty FormattedValueProperty = DependencyProperty.Register(
        nameof(AweField.FormattedValue),
        typeof(string),
        typeof(AweField),
        new PropertyMetadata("???"));

    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
        nameof(AweField.Values),
        typeof(IEnumerable),
        typeof(AweField),
        new PropertyMetadata(Enumerable.Empty<object>(), AweField.OnValuesChanged));

    public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register(
        nameof(AweField.DisplayMemberPath),
        typeof(string),
        typeof(AweField),
        new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty CustomTemplateProperty = DependencyProperty.Register(
        nameof(AweField.CustomTemplate),
        typeof(DataTemplate),
        typeof(AweField),
        new PropertyMetadata(default));

    private ContentPresenter _valuePresenter;

    public FieldMode Mode
    {
        get => (FieldMode)this.GetValue(AweField.ModeProperty);
        set => this.SetValue(AweField.ModeProperty, value);
    }

    public FieldKind Kind
    {
        get => (FieldKind)this.GetValue(AweField.KindProperty);
        set => this.SetValue(AweField.KindProperty, value);
    }

    public string Header
    {
        get => (string)this.GetValue(AweField.HeaderProperty);
        set => this.SetValue(AweField.HeaderProperty, value);
    }

    public object Value
    {
        get => this.GetValue(AweField.ValueProperty);
        set => this.SetValue(AweField.ValueProperty, value);
    }

    public string FormattedValue
    {
        get => (string)this.GetValue(AweField.FormattedValueProperty);
        private set => this.SetValue(AweField.FormattedValueProperty, value);
    }

    public IEnumerable Values
    {
        get => (IEnumerable)this.GetValue(AweField.ValuesProperty);
        set => this.SetValue(AweField.ValuesProperty, value);
    }

    public string DisplayMemberPath
    {
        get => (string)this.GetValue(AweField.DisplayMemberPathProperty);
        set => this.SetValue(AweField.DisplayMemberPathProperty, value);
    }

    public DataTemplate CustomTemplate
    {
        get => (DataTemplate)this.GetValue(AweField.CustomTemplateProperty);
        set => this.SetValue(AweField.CustomTemplateProperty, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        this._valuePresenter = (ContentPresenter)this.Template.FindName("PART_ValuePresenter", this);
    }

    private static void OnValueChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweField field)
        {
            return;
        }

        field.FormattedValue = args.NewValue != null
            ? args.NewValue.ToString()
            : "???";
    }

    private static void OnValuesChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
    {
        if (container is not AweField field)
        {
            return;
        }

        field.Value = default;
        field.RefreshValuePresenterTemplate();
    }

    private void RefreshValuePresenterTemplate()
    {
        if (this._valuePresenter == null)
        {
            return;
        }

        // TODO: Find better way to trigger template selection when values changed after <AweField> is loaded!

        var templateSelector = this._valuePresenter.ContentTemplateSelector;

        this._valuePresenter.ContentTemplateSelector = null;
        this._valuePresenter.ContentTemplateSelector = templateSelector;
    }
}