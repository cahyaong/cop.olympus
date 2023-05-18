// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyToUpperCaseConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof(object), typeof(string))]
public class AnyToUpperCaseConverter : IValueConverter
{
    public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        return value?
            .ToString()?
            .ToUpper(cultureInfo) ?? string.Empty;
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}