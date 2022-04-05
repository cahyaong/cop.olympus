// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeakValueDictionary.cs" company="nGratis">
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
// <creation_timestamp>Saturday, August 29, 2020 6:01:05 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf.Glue;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using nGratis.Cop.Olympus.Contract;

public class WeakValueDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    where TValue : class
{
    private readonly Dictionary<TKey, WeakReference> _payloadLookup;

    private readonly WeakReference _sentinel;

    public WeakValueDictionary()
    {
        this._payloadLookup = new Dictionary<TKey, WeakReference>();
        this._sentinel = new WeakReference(new object());
    }

    public TValue this[TKey key]
    {
        get
        {
            if (!this.TryGetValue(key, out var value))
            {
                throw new CopException($"No entry with key [{key}] can be found in collection!");
            }

            return value;
        }

        set
        {
            this.Clean();
            this._payloadLookup[key] = new WeakReference(value);
        }
    }

    public ICollection<TKey> Keys => this._payloadLookup.Keys;

    public ICollection<TValue> Values => this
        ._payloadLookup.Values
        .Select(value => (TValue)value.Target)
        .ToImmutableArray();

    public int Count
    {
        get
        {
            this.Clean();

            return this._payloadLookup.Count;
        }
    }

    public bool IsReadOnly => false;

    public void Add(TKey key, TValue value)
    {
        this.Clean();

        this._payloadLookup.Add(key, new WeakReference(value));
    }

    public void Add(KeyValuePair<TKey, TValue> pair)
    {
        this.Add(pair.Key, pair.Value);
    }

    public bool Remove(TKey key)
    {
        this.Clean();

        return this._payloadLookup.Remove(key);
    }

    public bool Remove(KeyValuePair<TKey, TValue> pair)
    {
        return
            this.Contains(pair) &&
            this.Remove(pair.Key);
    }

    public bool Contains(KeyValuePair<TKey, TValue> pair)
    {
        return
            this.TryGetValue(pair.Key, out var value) &&
            pair.Value == value;
    }

    public bool ContainsKey(TKey key)
    {
        return this.TryGetValue(key, out _);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        this.Clean();

        if (!this._payloadLookup.TryGetValue(key, out var reference))
        {
            value = default;

            return false;
        }

        value = (TValue)reference.Target;

        if (value == null)
        {
            this._payloadLookup.Remove(key);

            return false;
        }

        return true;
    }

    public void Clear()
    {
        this._payloadLookup.Clear();
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
    {
        Guard
            .Require(array, nameof(array))
            .Is.Not.Null();

        if (index < 0 || index >= array.Length)
        {
            throw new CopPreConditionException($"Variable [index] should be between 0 and ${array.Length - 1}!");
        }

        if (index + this.Count > array.Length)
        {
            throw new CopException("Entries in source collection cannot fit target collection!");
        }

        this.ToArray()
            .CopyTo(array, index);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        this.Clean();

        return this
            ._payloadLookup
            .Select(pair => new KeyValuePair<TKey, TValue>(pair.Key, (TValue)pair.Value.Target))
            .Where(pair => pair.Value != null)
            .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Clean()
    {
        var isRequired = false;

        if (this._sentinel.Target == null)
        {
            this._sentinel.Target = new object();
            isRequired = true;
        }

        if (isRequired)
        {
            this._payloadLookup
                .Where(pair => !pair.Value.IsAlive)
                .Select(pair => pair.Key)
                .ToImmutableList()
                .ForEach(key => this._payloadLookup.Remove(key));
        }
    }
}