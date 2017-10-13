// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyingObject.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 24 December 2014 5:52:27 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using nGratis.Cop.Core.Contract;

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
            Guard.Require.IsNotEmpty(propertyName);

            if (object.Equals(oldValue, newValue))
            {
                return;
            }

            Guard.Require.IsNotNull(propertyName);

            this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

            oldValue = newValue;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}