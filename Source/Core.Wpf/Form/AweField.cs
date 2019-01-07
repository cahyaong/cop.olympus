// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweField.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System.Collections;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using nGratis.Cop.Core.Contract;

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
            new PropertyMetadata(Text.Undefined));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(AweField.Value),
            typeof(object),
            typeof(AweField),
            new PropertyMetadata(null, AweField.OnValueChanged));

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
            new PropertyMetadata(null));

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

        private static void OnValueChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (!(container is AweField field))
            {
                return;
            }

            field.FormattedValue = args.NewValue != null
                ? args.NewValue.ToString()
                : "???";
        }

        private static void OnValuesChanged(DependencyObject container, DependencyPropertyChangedEventArgs args)
        {
            if (!(container is AweField field))
            {
                return;
            }

            field.Value = null;
        }
    }
}