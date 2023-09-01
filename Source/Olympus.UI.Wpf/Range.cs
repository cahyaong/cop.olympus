// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Range.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 12 April 2015 1:52:17 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using nGratis.Cop.Olympus.Contract;
using ReactiveUI;

public class Range : ReactiveObject
{
    private double _currentValue;

    private readonly double _interval;

    public Range()
        : this(0.0, 100.0, 1.0)
    {
    }

    public Range(double interval)
        : this(0.0, 100.0, interval)
    {
    }

    public Range(double minValue, double maxValue, double interval)
    {
        Guard
            .Require(minValue, nameof(minValue))
            .Is.LessThan(maxValue);

        this.MinValue = minValue;
        this.MaxValue = maxValue;
        this.Interval = Math.Max(interval, 1.0);
    }

    public double MinValue { get; }

    public double MaxValue { get; }

    public double CurrentValue
    {
        get => this._currentValue;
        set => this.RaiseAndSetIfChanged(ref this._currentValue, value);
    }

    public double Interval
    {
        get => this._interval;
        private init => this.RaiseAndSetIfChanged(ref this._interval, value);
    }
}