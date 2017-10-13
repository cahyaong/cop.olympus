// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaliburnContentLoader.cs" company="nGratis">
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
    using System.Windows;
    using Caliburn.Micro;
    using FirstFloor.ModernUI.Windows;
    using nGratis.Cop.Core.Contract;

    public class CaliburnContentLoader : DefaultContentLoader
    {
        protected override object LoadContent(Uri uri)
        {
            var content = base.LoadContent(uri);

            if (content == null)
            {
                return null;
            }

            var vm = ViewModelLocator.LocateForView(content);

            if (vm == null)
            {
                return content;
            }

            if (content is DependencyObject)
            {
                ViewModelBinder.Bind(vm, content as DependencyObject, null);
            }

            var element = content as FrameworkElement;
            var activatable = vm as IActivatable;

            if (element != null && activatable != null)
            {
                element.Loaded += (_, __) => activatable.Activate();
                element.Unloaded += (_, __) => activatable.Deactivate();
            }

            return content;
        }
    }
}