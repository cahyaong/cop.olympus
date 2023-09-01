// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppBootstrapper.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 6:33:56 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using System.Windows;
using nGratis.Cop.Olympus.UI.Wpf;

public class AppBootstrapper : CopBootstrapper
{
    public AppBootstrapper()
    {
        this.Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs __)
    {
        // TODO: Make theme adjustable dynamically!

        if (sender is Application app)
        {
            var theme = ControlzEx.Theming.ThemeManager.Current.ChangeTheme(app, "Dark.Green");
            app.AdjustAccentColor(theme.PrimaryAccentColor);
        }

        this.DisplayRootViewFor<AppViewModel>();
    }
}