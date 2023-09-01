// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorToSolidBrushConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 11 March 2016 11:43:22 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

[ValueConversion(typeof(Color), typeof(SolidColorBrush))]
public class ColorToSolidBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        return new SolidColorBrush((Color)(value ?? Colors.Gray));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
    {
        return (value as SolidColorBrush)?.Color ?? Colors.Gray;
    }
}