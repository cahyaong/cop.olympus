// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppView.xaml.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 14 October 2017 11:24:46 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

public partial class AppView
{
    public AppView()
    {
        this.InitializeComponent();

        this.LoggingNotifier = App.LoggingNotifier;
    }
}