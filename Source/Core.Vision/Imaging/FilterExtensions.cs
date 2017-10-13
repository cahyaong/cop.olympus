// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2017 Cahya Ong
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
// <creation_timestamp>Tuesday, 25 April 2017 6:51:18 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Vision.Imaging
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using AForge;
    using AForge.Imaging.Filters;
    using nGratis.Cop.Core.Contract;

    public static class FilterExtensions
    {
        public static ColorFiltering ToColorFiltering(this Color color, int threshold)
        {
            Guard.Require.IsZeroOrPositive(threshold);

            var halfThreshold = (int)Math.Ceiling(threshold / 2.0);

            return new ColorFiltering(
                new IntRange((color.R - halfThreshold).Clamp(0, 255), (color.R + halfThreshold).Clamp(0, 255)),
                new IntRange((color.G - halfThreshold).Clamp(0, 255), (color.G + halfThreshold).Clamp(0, 255)),
                new IntRange((color.B - halfThreshold).Clamp(0, 255), (color.B + halfThreshold).Clamp(0, 255)));
        }
    }
}