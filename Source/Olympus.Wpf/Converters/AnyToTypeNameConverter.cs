// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyToTypeNameConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Globalization;
using System.Windows.Data;
using nGratis.Cop.Olympus.Contract;

[ValueConversion(typeof(object), typeof(string))]
public class AnyToTypeNameConverter : IValueConverter
{
    public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        Guard
            .Require(type, nameof(type))
            .Is.EqualTo(typeof(string));

        return value != null ? value.GetType().FullName : DefinedText.Null;
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}