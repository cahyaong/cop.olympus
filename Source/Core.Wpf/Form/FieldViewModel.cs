// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldViewModel.cs" company="nGratis">
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
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using nGratis.Cop.Core.Contract;
    using ReactiveUI;

    public class FieldViewModel : ReactiveObject
    {
        public static readonly PropertyInfo UserValueProperty = typeof(FieldViewModel).GetProperty(
            "UserValue",
            BindingFlags.Instance | BindingFlags.Public);

        private FieldMode _mode;

        private FieldType _type;

        private string _label;

        private object _userValue;

        private bool _isValueUpdating;

        private bool _hasError;

        internal FieldViewModel(Type valueType, AsFieldAttribute attribute)
        {
            Guard
                .Require(valueType, nameof(valueType))
                .Is.Not.Null();

            Guard
                .Require(attribute, nameof(attribute))
                .Is.Not.Null();

            this.ValueType = valueType;

            this.Mode = attribute.Mode;
            this.Type = attribute.Type;
            this.Label = attribute.Label;
        }

        public FieldType Type
        {
            get => this._type;
            private set => this.RaiseAndSetIfChanged(ref this._type, value);
        }

        public string Label
        {
            get => this._label;
            private set => this.RaiseAndSetIfChanged(ref this._label, value);
        }

        public object UserValue
        {
            get => this._userValue;

            set
            {
                if (this._userValue != value)
                {
                    if (this._userValue is INotifyPropertyChanged oldNotifier)
                    {
                        oldNotifier.RemoveEventHandler<INotifyPropertyChanged, PropertyChangedEventArgs>(
                            nameof(this.PropertyChanged),
                            this.OnInnerPropertyChanged);
                    }

                    if (value is INotifyPropertyChanged newNotifier)
                    {
                        newNotifier.AddEventHandler<INotifyPropertyChanged, PropertyChangedEventArgs>(
                            nameof(this.PropertyChanged),
                            this.OnInnerPropertyChanged);
                    }
                }

                this.RaiseAndSetIfChanged(ref this._userValue, value);
            }
        }

        public FieldMode Mode
        {
            get => this._mode;
            private set => this.RaiseAndSetIfChanged(ref this._mode, value);
        }

        public Type ValueType
        {
            get;
        }

        public bool IsValueUpdating
        {
            get => this._isValueUpdating;
            set => this.RaiseAndSetIfChanged(ref this._isValueUpdating, value);
        }

        public bool HasError
        {
            get => this._hasError;
            set => this.RaiseAndSetIfChanged(ref this._hasError, value);
        }

        private void OnInnerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            this.RaisePropertyChanged();
        }
    }
}