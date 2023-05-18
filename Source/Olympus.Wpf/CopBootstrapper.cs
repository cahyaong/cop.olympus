// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopBootstrapper.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, 6 December 2018 8:41:48 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Reactive;
using Caliburn.Micro;
using ReactiveUI;

public class CopBootstrapper : BootstrapperBase
{
    // TODO: Add DI and IoC registration!

    public enum ExceptionSource
    {
        Unknown = 0,
        Application,
        Reactive
    }

    static CopBootstrapper()
    {
        AppDomain.CurrentDomain.UnhandledException += (_, args) => CopBootstrapper
            .RaisedUnhandledExceptionTriggered(ExceptionSource.Application, args.ExceptionObject as Exception);

        RxApp.DefaultExceptionHandler = Observer.Create<Exception>(exception => CopBootstrapper
            .RaisedUnhandledExceptionTriggered(ExceptionSource.Reactive, exception));
    }

    public static event EventHandler<UnhandledExceptionEventArgs> UnhandledExceptionTriggered;

    private static void RaisedUnhandledExceptionTriggered(ExceptionSource exceptionSource, Exception exception)
    {
        CopBootstrapper.UnhandledExceptionTriggered?.Invoke(
            typeof(CopBootstrapper).FullName,
            new UnhandledExceptionEventArgs(exceptionSource, exception));
    }

    public class UnhandledExceptionEventArgs
    {
        internal UnhandledExceptionEventArgs(ExceptionSource exceptionSource, Exception exception)
        {
            this.ExceptionSource = exceptionSource;
            this.Exception = exception;
        }

        public ExceptionSource ExceptionSource { get; }

        public Exception Exception { get; }
    }
}