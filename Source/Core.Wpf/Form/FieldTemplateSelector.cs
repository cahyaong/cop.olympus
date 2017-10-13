// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldTemplateSelector.cs" company="nGratis">
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
// <creation_timestamp>Sunday, 28 December 2014 12:37:57 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using nGratis.Cop.Core.Contract;

    public class FieldTemplateSelector : DataTemplateSelector
    {
        private const string DefaultKey = "Cop.AweField.Default";

        private readonly IDictionary<string, DataTemplate> templateLookup;

        public FieldTemplateSelector()
        {
            this.templateLookup = new Dictionary<string, DataTemplate>();
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var control = (FrameworkElement)container;
            var context = item as FieldViewModel;

            Guard.Require.IsNotNull(context);

            var key = "Cop.AweField.{0}.{1}".Bake(
                context.Mode,
                context.Type == FieldType.Auto
                    ? context.ValueType.IsEnum ? "Enumeration" : context.ValueType.GetGenericName()
                    : context.Type.ToString());

            if (this.templateLookup.ContainsKey(key))
            {
                return this.templateLookup[key];
            }

            var template =
                (DataTemplate)control.TryFindResource(key) ??
                (DataTemplate)control.TryFindResource(FieldTemplateSelector.DefaultKey);

            this.templateLookup.Add(key, template);

            return template;
        }
    }
}