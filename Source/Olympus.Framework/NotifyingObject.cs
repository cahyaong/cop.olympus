// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyingObject.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 24 December 2014 5:52:27 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public abstract class NotifyingObject : INotifyPropertyChanging, INotifyPropertyChanged
{
    public event PropertyChangingEventHandler PropertyChanging;

    public event PropertyChangedEventHandler PropertyChanged;

    [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
    [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
    protected void RaiseAndSetIfChanged<TValue>(
        ref TValue oldValue,
        TValue newValue,
        [CallerMemberName] string propertyName = null)
    {
        if (object.Equals(oldValue, newValue))
        {
            return;
        }

        this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        oldValue = newValue;

        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}