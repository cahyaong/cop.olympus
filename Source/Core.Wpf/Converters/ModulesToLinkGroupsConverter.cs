// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModulesToLinkGroupsConverter.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 Cahya Ong
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
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    using FirstFloor.ModernUI.Presentation;
    using nGratis.Cop.Core.Contract;

    [ValueConversion(typeof(IEnumerable<IModule>), typeof(LinkGroupCollection))]
    public class ModulesToLinkGroupsConverter : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            Guard.Require.IsTypeOf<IEnumerable<IModule>>(value);

            var modules = (IEnumerable<IModule>)value;
            var linkGroups = new LinkGroupCollection();

            // TODO: Need a proper grouping of multiple features based their name.

            var orderedFeatures = modules
                .SelectMany(module => module.Features)
                .OrderBy(feature => feature.Order)
                .ThenBy(feature => feature.Name);

            foreach (var orderedFeature in orderedFeatures)
            {
                var linkGroup = new LinkGroup { DisplayName = orderedFeature.Name };

                orderedFeature
                    .Pages
                    .Select(page => new Link { DisplayName = page.Name, Source = page.SourceUri })
                    .ToList()
                    .ForEach(linkGroup.Links.Add);

                linkGroups.Add(linkGroup);
            }

            return linkGroups;
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}