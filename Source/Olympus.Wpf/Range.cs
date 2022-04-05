﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Range.cs" company="nGratis">
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
// <creation_timestamp>Sunday, 12 April 2015 1:52:17 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

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