// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WritableImage_Test.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Saturday, 18 April 2015 1:49:37 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Vision.UnitTest
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using nGratis.Cop.Core.Testing;
    using nGratis.Cop.Core.Vision.Imaging;

    [DeploymentItem(@"Imaging\WritableImage_Scenarios.xml", "Imaging")]
    public class WritableImage_Test
    {
        [TestClass]
        public class LoadDataMethod
        {
            public TestContext TestContext { get; set; }

            [TestMethod]
            [DataSource(DataDriven.XmlTool, DataDriven.RootFolderPath + @"Imaging\WritableImage_Scenarios.xml", "LoadData_Valid", DataAccessMethod.Sequential)]
            public void WhenLoadingValidData_ShouldGetCorrectPixelCount()
            {
                // Arrange.

                var imagePath = $"Resources\\{this.TestContext.FindScenarioVariableAs<string>("In_FileName")}";
                var writableImage = new WriteableImage();

                using (var imageStream = this.LoadEmbeddedResource(imagePath))
                {
                    // Act.

                    writableImage.LoadData(imageStream);

                    // Assert.

                    var pixels = writableImage.ToPixels().ToList();

                    var dimension = this.TestContext.FindScenarioVariableAs<Size>("Out_Dimension");
                    var width = (int)dimension.Width;
                    var height = (int)dimension.Height;

                    writableImage
                        .Width
                        .Should().Be(width);

                    writableImage
                        .Height
                        .Should().Be(height);

                    pixels
                        .Count
                        .Should().Be(width * height);

                    pixels
                        .Count(pixel => pixel == Colors.White)
                        .Should().Be(this.TestContext.FindScenarioVariableAs<int>("Out_NumOfWhitePixels"));

                    pixels
                        .Count(pixel => pixel != Colors.White && pixel != Colors.Black)
                        .Should().Be(this.TestContext.FindScenarioVariableAs<int>("Out_NumOfGreyPixels"));

                    pixels
                        .Count(pixel => pixel == Colors.Black)
                        .Should().Be(this.TestContext.FindScenarioVariableAs<int>("Out_NumOfBlackPixels"));
                }
            }
        }
    }
}