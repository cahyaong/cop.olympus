// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweSystemBrowserButton.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.UI.Wpf;

using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using nGratis.Cop.Olympus.Contract;
using Button = System.Windows.Controls.Button;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

public class AweSystemBrowserButton : Button
{
    public enum BrowsingMode
    {
        Unknown = 0,
        File,
        Folder
    }

    public static readonly DependencyProperty SelectedPathProperty = DependencyProperty.Register(
        nameof(AweSystemBrowserButton.SelectedPath),
        typeof(string),
        typeof(AweSystemBrowserButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty ModeProperty = DependencyProperty.Register(
        nameof(AweSystemBrowserButton.Mode),
        typeof(BrowsingMode),
        typeof(AweSystemBrowserButton),
        new PropertyMetadata(BrowsingMode.Unknown));

    public AweSystemBrowserButton()
    {
        this.Command = RelayCommand.Create(this.SelectPath);
    }

    public string SelectedPath
    {
        get => (string)this.GetValue(AweSystemBrowserButton.SelectedPathProperty);
        set => this.SetValue(AweSystemBrowserButton.SelectedPathProperty, value);
    }

    public BrowsingMode Mode
    {
        get => (BrowsingMode)this.GetValue(AweSystemBrowserButton.ModeProperty);
        set => this.SetValue(AweSystemBrowserButton.ModeProperty, value);
    }

    private void SelectPath()
    {
        Guard
            .Ensure(this.Mode, nameof(this.Mode))
            .Is.Not.EqualTo(BrowsingMode.Unknown);

        var isOkPressed = false;
        var selectedPath = string.Empty;

        if (this.Mode == BrowsingMode.File)
        {
            var initialPath = default(string);

            if (!string.IsNullOrEmpty(this.SelectedPath) && File.Exists(this.SelectedPath))
            {
                initialPath = Path.GetDirectoryName(this.SelectedPath);
            }

            if (string.IsNullOrEmpty(initialPath))
            {
                initialPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }

            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = initialPath
            };

            isOkPressed = fileDialog.ShowDialog() ?? false;
            selectedPath = fileDialog.FileName;
        }
        else if (this.Mode == BrowsingMode.Folder)
        {
            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = !string.IsNullOrEmpty(this.SelectedPath)
                    ? this.SelectedPath
                    : Environment.GetFolderPath(Environment.SpecialFolder.Personal)
            };

            var result = folderDialog.ShowDialog();
            isOkPressed = result is DialogResult.OK or DialogResult.Yes;
            selectedPath = folderDialog.SelectedPath;
        }

        if (isOkPressed)
        {
            this.SelectedPath = selectedPath;
        }
    }
}