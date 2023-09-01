// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppViewModel.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, September 3, 2020 6:01:49 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using Caliburn.Micro;
using nGratis.Cop.Olympus.UI.Wpf.Glue;

internal class AppViewModel : ReactiveConductor<IScreen>.Collection.OneActive
{
    public AppViewModel()
    {
        this.Items.AddRange(new ReactiveScreen[]
        {
            new AweWindowViewModel(App.Logger)
            {
                DisplayName = "window"
            },
            new AweFieldViewModel
            {
                DisplayName = "field"
            },
            new ReactiveCaliburnViewModel(App.Logger)
            {
                DisplayName = "reactive-caliburn"
            }
        });
    }
}