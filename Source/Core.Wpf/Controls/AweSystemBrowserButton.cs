// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweSystemBrowserButton.cs" company="nGratis">
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
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;
    using FirstFloor.ModernUI.Presentation;
    using nGratis.Cop.Core.Contract;
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
            this.Command = new RelayCommand(this.OnMouseClicked, _ => true);
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

        private void OnMouseClicked(object parameter)
        {
            Guard.Ensure.IsNotEqualTo(this.Mode, BrowsingMode.Unknown);

            var isOkPressed = false;
            var selectedPath = string.Empty;

            if (this.Mode == BrowsingMode.File)
            {
                var fileDialog = new OpenFileDialog
                {
                    InitialDirectory = File.Exists(this.SelectedPath)
                        ? Path.GetDirectoryName(this.SelectedPath)
                        : Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                };

                isOkPressed = fileDialog.ShowDialog() ?? false;
                selectedPath = fileDialog.FileName;
            }
            else if (this.Mode == BrowsingMode.Folder)
            {
                var folderDialog = new FolderBrowserDialog()
                {
                    SelectedPath = !string.IsNullOrEmpty(this.SelectedPath)
                        ? this.SelectedPath
                        : Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                };

                var result = folderDialog.ShowDialog();
                isOkPressed = result == DialogResult.OK || result == DialogResult.Yes;
                selectedPath = folderDialog.SelectedPath;
            }

            if (isOkPressed)
            {
                this.SelectedPath = selectedPath;
            }
        }
    }
}