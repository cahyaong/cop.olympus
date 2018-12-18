// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyImage.cs" company="nGratis">
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
// <creation_timestamp>Monday, 17 December 2018 11:34:05 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Vision.Imaging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class EmptyImage : IImage
    {
        private EmptyImage()
        {
        }

        public static IImage Instance { get; } = new EmptyImage();

        public int Width => 0;

        public int Height => 0;

        public Color this[int x, int y]
        {
            get => Colors.HotPink;
            set => throw new NotSupportedException();
        }

        public void LoadData(Stream dataSteam)
        {
            throw new NotSupportedException();
        }

        public Stream SaveData()
        {
            throw new NotSupportedException();
        }

        public ImageSource ToImageSource()
        {
            return new BitmapImage();
        }

        public IEnumerable<Color> ToPixels()
        {
            yield return Colors.HotPink;
        }
    }
}