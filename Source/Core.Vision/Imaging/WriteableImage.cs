// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WriteableImage.cs" company="nGratis">
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

namespace nGratis.Cop.Core.Vision.Imaging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class WriteableImage : IImage
    {
        private WriteableBitmap writeableBitmap;

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Color this[int x, int y]
        {
            get => this.writeableBitmap.GetPixel(x, y);
            set => this.writeableBitmap.SetPixel(x, y, value);
        }

        public void LoadData(Stream dataSteam)
        {
            // TODO: Handle a case when input data contains transparency.

            dataSteam.Position = 0;

            var bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = dataSteam;
            bitmap.EndInit();

            this.writeableBitmap = new WriteableBitmap(bitmap);

            this.Width = this.writeableBitmap.PixelWidth;
            this.Height = this.writeableBitmap.PixelHeight;
        }

        public Stream SaveData()
        {
            throw new NotImplementedException();
        }

        public ImageSource ToImageSource()
        {
            return this.writeableBitmap;
        }

        public IEnumerable<Color> ToPixels()
        {
            for (var y = 0; y < this.Height; y++)
            {
                for (var x = 0; x < this.Width; x++)
                {
                    yield return this[x, y];
                }
            }
        }
    }
}