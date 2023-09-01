// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Monday, 13 April 2015 2:27:02 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace System;

using System.Windows;
using nGratis.Cop.Olympus.Contract;

public static class TypeExtensions
{
    public static void AddEventHandler<TInstance, TArgs>(
        this TInstance instance,
        string eventName,
        EventHandler<TArgs> handler)
        where TInstance : class
        where TArgs : EventArgs
    {
        Guard
            .Require(instance, nameof(instance))
            .Is.Not.Null();

        Guard
            .Require(eventName, nameof(eventName))
            .Is.Not.Empty();

        Guard
            .Require(handler, nameof(handler))
            .Is.Not.Null();

        WeakEventManager<TInstance, TArgs>.AddHandler(instance, eventName, handler);
    }

    public static void RemoveEventHandler<TInstance, TArgs>(
        this TInstance instance,
        string eventName,
        EventHandler<TArgs> handler)
        where TInstance : class
        where TArgs : EventArgs
    {
        Guard
            .Require(instance, nameof(instance))
            .Is.Not.Null();

        Guard
            .Require(eventName, nameof(eventName))
            .Is.Not.Empty();

        Guard
            .Require(handler, nameof(handler))
            .Is.Not.Null();

        WeakEventManager<TInstance, TArgs>.RemoveHandler(instance, eventName, handler);
    }
}