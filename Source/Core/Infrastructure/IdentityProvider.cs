// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityProvider.cs" company="nGratis">
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
// <creation_timestamp>Saturday, 25 April 2015 1:01:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using nGratis.Cop.Core.Contract;

    public class IdentityProvider : IIdentityProvider
    {
        static IdentityProvider()
        {
            IdentityProvider.Instance = new IdentityProvider();
        }

        private IdentityProvider()
        {
        }

        public static IIdentityProvider Instance { get; private set; }

        public Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        public Guid CreateGuid(string content)
        {
            Guard.Require.IsNotEmpty(content);

            var md5 = MD5.Create();
            return new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(content)));
        }

        public string CreateId()
        {
            return this
                .CreateGuid()
                .ToString("D")
                .ToUpper(CultureInfo.InvariantCulture);
        }
    }
}