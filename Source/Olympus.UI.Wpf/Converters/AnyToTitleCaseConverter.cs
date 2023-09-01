// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyToTitleCaseConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 20 February 2016 10:17:26 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;
using Humanizer;

[ValueConversion(typeof(object), typeof(string))]
public class AnyToTitleCaseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        return value?
            .ToString()
            .Humanize(LetterCasing.Title);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}