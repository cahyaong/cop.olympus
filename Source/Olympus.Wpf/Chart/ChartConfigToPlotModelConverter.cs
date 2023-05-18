// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChartConfigToPlotModelConverter.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
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