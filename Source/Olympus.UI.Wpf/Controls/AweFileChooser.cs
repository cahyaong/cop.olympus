// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweFileChooser.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Sunday, 9 April 2017 2:25:09 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class AweFileChooser : ContentControl
{
    public static readonly DependencyProperty SelectedFilePathProperty = DependencyProperty.Register(
        nameof(AweFileChooser.SelectedFilePath),
        typeof(string),
        typeof(AweFileChooser),
        new PropertyMetadata(null));

    public static readonly DependencyProperty AuxiliaryTextProperty = DependencyProperty.Register(
        nameof(AweFileChooser.AuxiliaryText),
        typeof(string),
        typeof(AweFileChooser),
        new PropertyMetadata("<AUX>"));

    public static readonly DependencyProperty AuxiliaryCommandProperty = DependencyProperty.Register(
        nameof(AweFileChooser.AuxiliaryCommand),
        typeof(ICommand),
        typeof(AweFileChooser),
        new PropertyMetadata(null));

    public string SelectedFilePath
    {
        get => (string)this.GetValue(AweFileChooser.SelectedFilePathProperty);
        set => this.SetValue(AweFileChooser.SelectedFilePathProperty, value);
    }

    public string AuxiliaryText
    {
        get => (string)this.GetValue(AweFileChooser.AuxiliaryTextProperty);
        set => this.SetValue(AweFileChooser.AuxiliaryTextProperty, value);
    }

    public ICommand AuxiliaryCommand
    {
        get => (ICommand)this.GetValue(AweFileChooser.AuxiliaryCommandProperty);
        set => this.SetValue(AweFileChooser.AuxiliaryCommandProperty, value);
    }
}