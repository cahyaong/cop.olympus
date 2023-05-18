// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableToCountConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 12:08:32 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

[ValueConversion(typeof(IEnumerable), typeof(int))]
public class EnumerableToCountConverter : IValueConverter
{
    public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        if (value is IEnumerable enumerable)
        {
            return enumerable
                .Cast<object>()
                .Count();
        }

        return 0;
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}