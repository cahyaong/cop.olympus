// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldGroupViewModel.cs" company="nGratis">
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
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using nGratis.Cop.Core.Contract;
    using ReactiveUI;

    public class FieldGroupViewModel : ReactiveObject
    {
        private FieldMode mode;

        private ICollection<FieldViewModel> fields;

        public FieldGroupViewModel(object instance, FieldMode mode)
        {
            Guard.Require.IsTypeOf<INotifyPropertyChanged>(instance);
            Guard.Require.IsNotDefault(mode);

            var notifyingInstance = (INotifyPropertyChanged)instance;

            this.Mode = mode;
            this.Fields = new ObservableCollection<FieldViewModel>();

            instance
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Select(property => new
                {
                    Property = property,
                    FieldAttribute = property.GetCustomAttribute<AsFieldAttribute>()
                })
                .Where(anon => anon.FieldAttribute != null && anon.FieldAttribute.Mode == mode)
                .ToList()
                .ForEach(anon =>
                    {
                        var field = new FieldViewModel(anon.Property.PropertyType, anon.FieldAttribute);
                        this.Fields.Add(field);

                        var binder = new ObjectBinder(
                            notifyingInstance,
                            anon.Property,
                            field,
                            FieldViewModel.UserValueProperty);

                        binder.BindSourceCallback();

                        binder.BindTargetCallback(
                            () =>
                                {
                                    field.HasError = false;
                                    field.IsValueUpdating = true;
                                },
                            () => field.IsValueUpdating = false,
                            () =>
                                {
                                    field.HasError = true;
                                    field.IsValueUpdating = false;
                                });
                    });
        }

        public FieldMode Mode
        {
            get => this.mode;
            private set => this.RaiseAndSetIfChanged(ref this.mode, value);
        }

        public ICollection<FieldViewModel> Fields
        {
            get => this.fields;
            private set => this.RaiseAndSetIfChanged(ref this.fields, value);
        }
    }
}