// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="nGratis">
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
// <creation_timestamp>Monday, 13 April 2015 2:27:02 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace System
{
    using System.Windows;
    using nGratis.Cop.Core.Contract;

    public static class TypeExtensions
    {
        public static string GetGenericName(this Type type)
        {
            if (type == null)
            {
                return null;
            }

            return type.IsGenericType
                ? type.Name.Remove(type.Name.IndexOf('`'))
                : type.Name;
        }

        public static void AddEventHandler<TInstance, TArgs>(
            this TInstance instance,
            string eventName,
            EventHandler<TArgs> handler)
            where TInstance : class
            where TArgs : EventArgs
        {
            Guard.Require.IsNotNull(instance);
            Guard.Require.IsNotEmpty(eventName);
            Guard.Require.IsNotNull(handler);

            WeakEventManager<TInstance, TArgs>.AddHandler(instance, eventName, handler);
        }

        public static void RemoveEventHandler<TInstance, TArgs>(
            this TInstance instance,
            string eventName,
            EventHandler<TArgs> handler)
            where TInstance : class
            where TArgs : EventArgs
        {
            Guard.Require.IsNotNull(instance);
            Guard.Require.IsNotEmpty(eventName);
            Guard.Require.IsNotNull(handler);

            WeakEventManager<TInstance, TArgs>.RemoveHandler(instance, eventName, handler);
        }
    }
}