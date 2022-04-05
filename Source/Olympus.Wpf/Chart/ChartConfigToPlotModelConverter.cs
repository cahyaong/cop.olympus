// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChartConfigToPlotModelConverter.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
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
// <creation_timestamp>Monday, 15 February 2016 8:24:43 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using nGratis.Cop.Olympus.Contract;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using LinearAxis = OxyPlot.Axes.LinearAxis;
using LineSeries = OxyPlot.Series.LineSeries;
using LogarithmicAxis = OxyPlot.Axes.LogarithmicAxis;

[ValueConversion(typeof(ChartConfig), typeof(PlotModel))]
public class ChartConfigToPlotModelConverter : Freezable, IValueConverter
{
    public static readonly DependencyProperty ThemeManagerProperty = DependencyProperty.Register(
        "ThemeManager",
        typeof(IThemeManager),
        typeof(ChartConfigToPlotModelConverter),
        new PropertyMetadata(null));

    public IThemeManager ThemeManager
    {
        get => (IThemeManager)this.GetValue(ChartConfigToPlotModelConverter.ThemeManagerProperty);
        set => this.SetValue(ChartConfigToPlotModelConverter.ThemeManagerProperty, value);
    }

    public object Convert(object value, Type type, object parameter, CultureInfo culture)
    {
        if (value is not ChartConfig chartConfig)
        {
            return null;
        }

        var themeManager = this.ThemeManager;

        Guard
            .Require(themeManager, nameof(themeManager))
            .Is.Not.Null();

        var subcharts = chartConfig
            .SeriesConfigs
            .Select(configuration => new { configuration.Category, configuration.Value })
            .Distinct()
            .ToList();

        if (!subcharts.Any())
        {
            return new PlotModel();
        }

        var subchart = subcharts.Single();

        var textColor = themeManager
            .FindColor("Cop.Color.AweChart.Text")
            .ToOxyColor();

        var borderColor = themeManager
            .FindColor("Cop.Color.AweChart.Border")
            .ToOxyColor();

        var ticklineColor = themeManager
            .FindColor("Cop.Color.AweChart.Tickline")
            .ToOxyColor();

        var plotModel = new PlotModel
        {
            Title = chartConfig.Title,
            TitleColor = textColor,
            SubtitleColor = textColor,
            IsLegendVisible = false,
            PlotAreaBorderColor = borderColor
        };

        // TODO: Add axis configuration concept.

        var horizontalAxis = new LinearAxis
        {
            TicklineColor = ticklineColor,
            Position = AxisPosition.Bottom,
            IsZoomEnabled = false,
            IsPanEnabled = false,
            TextColor = textColor,
            Title = subchart.Category,
            TitleColor = textColor,
            TitleFontSize = 14,
            AxisTitleDistance = 20,
            Minimum = 2002,
            Maximum = 2016
        };

        var verticalAxis = new LogarithmicAxis
        {
            TicklineColor = ticklineColor,
            Position = AxisPosition.Left,
            IsZoomEnabled = false,
            IsPanEnabled = false,
            TextColor = textColor,
            Title = subchart.Value,
            TitleColor = textColor,
            TitleFontSize = 14,
            AxisTitleDistance = 20,
            Minimum = 0,
            Maximum = 100000
        };

        plotModel.Axes.Add(horizontalAxis);
        plotModel.Axes.Add(verticalAxis);

        chartConfig
            .SeriesConfigs
            .Select(configuration => new LineSeries
            {
                Title = configuration.Title,
                ItemsSource = configuration.Points,
                DataFieldX = configuration.Category,
                DataFieldY = configuration.Value
            })
            .ForEach(series => plotModel.Series.Add(series));

        return plotModel;
    }

    public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    protected override Freezable CreateInstanceCore()
    {
        return new ChartConfigToPlotModelConverter();
    }
}