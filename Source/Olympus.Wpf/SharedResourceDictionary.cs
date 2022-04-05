// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedResourceDictionary.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;

public class SharedResourceDictionary : ResourceDictionary
{
    // TODO: Need to make this class thread-safe!

    private static readonly Dictionary<Uri, ResourceDictionary> ByUriLookup = new();

    private Uri _source;

    public new Uri Source
    {
        get => this._source;

        set
        {
            this._source = value;

            if (!SharedResourceDictionary.ByUriLookup.ContainsKey(value))
            {
                base.Source = value;
                SharedResourceDictionary.ByUriLookup.Add(value, this);
            }
            else
            {
                this.MergedDictionaries.Add(SharedResourceDictionary.ByUriLookup[value]);
            }
        }
    }
}