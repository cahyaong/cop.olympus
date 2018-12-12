// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopBootstrapper.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2018 Cahya Ong
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
// <creation_timestamp>Thursday, 6 December 2018 8:41:48 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Wpf
{
    using System;
    using System.Reactive;
    using Caliburn.Micro;
    using FirstFloor.ModernUI.Windows.Controls;
    using nGratis.Cop.Core.Contract;
    using ReactiveUI;

    public class CopBootstrapper : BootstrapperBase
    {
        static CopBootstrapper()
        {
            // TODO: Need to capture unhandled exception produced by RX observable!

            AppDomain.CurrentDomain.UnhandledException += (_, args) => CopBootstrapper
                .OnUnhandledExceptionReceived(ExceptionSource.Application, args.ExceptionObject as Exception);

            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(exception => CopBootstrapper
                .OnUnhandledExceptionReceived(ExceptionSource.Reactive, exception));
        }

        private static void OnUnhandledExceptionReceived(ExceptionSource exceptionSource, Exception exception)
        {
            var dialog = new ModernDialog
            {
                Title = $"Unhandled Exception ({exceptionSource})",
                Content = exception?.ToString() ?? Text.Unknown,
                MaxWidth = int.MaxValue,
                MaxHeight = int.MaxValue
            };

            dialog.Buttons = new[] { dialog.OkButton };
            dialog.ShowDialog();
        }
    }

    public enum ExceptionSource
    {
        Unknown = 0,
        Application,
        Reactive
    }
}