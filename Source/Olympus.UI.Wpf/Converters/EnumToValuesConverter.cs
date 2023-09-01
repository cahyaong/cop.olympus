// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumToValuesConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 20 February 2016 9:49:05 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using nGratis.Cop.Olympus.Contract;

[ValueConversion(typeof(Type), typeof(IEnumerable<object>))]
internal class EnumToValuesConverter : IValueConverter
{
    public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        Guard
            .Require(value, nameof(value))
            .Is.Not.Null()
            .Is.OfType(typeof(Type));

        return Enum
            .GetValues((Type)value)
            .OfType<object>()
            .Where(item => item.ToString() != "Unknown")
            .ToList();
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}