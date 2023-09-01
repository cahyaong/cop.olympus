// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyToLowerCaseConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 2 January 2019 7:28:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof(object), typeof(string))]
public class AnyToLowerCaseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        return value?
            .ToString()?
            .ToLower(cultureInfo) ?? string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}