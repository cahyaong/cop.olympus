// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feature.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 Cahya Ong
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
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System.Collections.Generic;
    using System.Linq;
    using nGratis.Cop.Core.Contract;

    public class Feature : IFeature
    {
        public Feature(string name, params Page[] pages)
            : this(name, pages.AsEnumerable())
        {
        }

        public Feature(string name, int order, params Page[] pages)
            : this(name, order, pages.AsEnumerable())
        {
        }

        public Feature(string name, IEnumerable<Page> pages)
            : this(name, int.MinValue, pages)
        {
        }

        public Feature(string name, int order, IEnumerable<Page> pages)
        {
            Guard.Require.IsNotEmpty(name);

            this.Name = name;
            this.Order = order;
            this.Pages = pages ?? Enumerable.Empty<Page>();
        }

        public string Name { get; }

        public int Order { get; }

        public IEnumerable<IPage> Pages { get; }
    }
}