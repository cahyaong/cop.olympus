// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChartConfig.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 13 February 2016 12:20:50 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Collections.Generic;
using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Framework;

public class ChartConfig : NotifyingObject
{
    public ChartConfig(string title, IEnumerable<SeriesConfig> seriesConfigs)
    {
        Guard
            .Require(title, nameof(title))
            .Is.Not.Empty();

        Guard
            .Require(seriesConfigs, nameof(seriesConfigs))
            .Is.Not.Null()
            .Is.Not.Empty();

        this.Title = title;
        this.SeriesConfigs = seriesConfigs;
    }

    public string Title { get; }

    public IEnumerable<SeriesConfig> SeriesConfigs { get; }
}