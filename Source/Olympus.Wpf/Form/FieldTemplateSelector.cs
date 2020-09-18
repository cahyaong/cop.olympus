// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldTemplateSelector.cs" company="nGratis">
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
// <creation_timestamp>Sunday, 28 December 2014 12:37:57 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using nGratis.Cop.Olympus.Contract;

    public class FieldTemplateSelector : DataTemplateSelector
    {
        private readonly IDictionary<string, DataTemplate> _templateLookup;

        public FieldTemplateSelector()
        {
            this._templateLookup = new Dictionary<string, DataTemplate>();
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Guard
                .Require(container, nameof(container))
                .Is.Not.Null();

            var field = container.TryFindParent<AweField>();

            if (field == null)
            {
                throw new CopException($"This selector must be used within control type [{typeof(AweField)}].");
            }

            var key = $"Cop.AweField.{field.Mode}.{field.Kind}";

            if (this._templateLookup.TryGetValue(key, out var template))
            {
                var hasValues = field
                    .Values?
                    .Cast<object>()
                    .Any() == true;

                if (field.Kind.IsMultipleValuesRequired() && !hasValues)
                {
                    template = (DataTemplate)field.TryFindResource(Key.Empty);
                }
            }
            else
            {
                template =
                    (DataTemplate)field.TryFindResource(key) ??
                    (DataTemplate)field.TryFindResource(Key.Default);

                this._templateLookup.Add(key, template);
            }

            return template;
        }

        public static class Key
        {
            public const string Default = "Cop.AweField.Default";

            public const string Empty = "Cop.AweField.Empty";
        }
    }
}