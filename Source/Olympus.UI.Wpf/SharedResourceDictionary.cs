// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedResourceDictionary.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 12:14:47 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

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