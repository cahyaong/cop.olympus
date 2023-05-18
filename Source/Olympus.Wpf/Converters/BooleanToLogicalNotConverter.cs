// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToLogicalNotConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 29 January 2016 11:47:24 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof(bool), typeof(bool))]
public class BooleanToLogicalNotConverter : IValueConverter
{
    public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        return value != null && !(bool)value;
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        return value != null && !(bool)value;
    }
}