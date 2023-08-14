// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldTemplateSelector.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 28 December 2014 12:37:57 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

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
            throw new OlympusException($"This selector must be used within control type [{typeof(AweField)}].");
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