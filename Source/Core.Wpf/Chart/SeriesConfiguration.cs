// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeriesConfiguration.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Saturday, 13 February 2016 12:30:15 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System.Collections;
    using nGratis.Cop.Core.Contract;

    public class SeriesConfiguration
    {
        public SeriesConfiguration(string title, ICollection points, string category, string value)
        {
            Guard.Require.IsNotEmpty(title);
            Guard.Require.IsNotNull(points);
            Guard.Require.IsNotEmpty(category);
            Guard.Require.IsNotEmpty(value);

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
}