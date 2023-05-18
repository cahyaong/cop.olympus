// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 14 October 2017 11:24:46 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using nGratis.Cop.Olympus.Contract;
using nGratis.Cop.Olympus.Framework;

public partial class App
{
    static App()
    {
        var logger = new CopLogger(nameof(App));

        App.Logger = logger;
        App.LoggingNotifier = logger;
    }

    public static ILogger Logger { get; }

    public static ILoggingNotifier LoggingNotifier { get; }
}