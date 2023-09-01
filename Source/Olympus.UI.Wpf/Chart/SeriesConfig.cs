// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeriesConfig.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 13 February 2016 12:30:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Collections;
using nGratis.Cop.Olympus.Contract;

public class SeriesConfig
{
    public SeriesConfig(string title, ICollection points, string category, string value)
    {
        Guard
            .Require(title, nameof(title))
            .Is.Not.Empty();

        Guard
            .Require(points, nameof(points))
            .Is.Not.Null();

        Guard
            .Require(category, nameof(category))
            .Is.Not.Empty();

        Guard
            .Require(value, nameof(value))
            .Is.Not.Empty();

        this.Title = title;
        this.Points = points;
        this.Category = category;
        this.Value = value;
    }

    public string Title { get; }

    public ICollection Points { get; }

    public string Category { get; }

    public string Value { get; }
}