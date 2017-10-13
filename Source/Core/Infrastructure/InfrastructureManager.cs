// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfrastructureManager.cs" company="nGratis">
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
    using System.Diagnostics.CodeAnalysis;
    using nGratis.Cop.Core.Contract;

    public sealed class InfrastructureManager : IInfrastructureManager, IDisposable
    {
        private bool isDisposed;

        public InfrastructureManager(LoggingModes loggingModes)
        {
            this.IdentityProvider = Core.IdentityProvider.Instance;
            this.LoggingProvider = new LoggingProvider(loggingModes);
            this.TemporalProvider = Core.TemporalProvider.Instance;
        }

        ~InfrastructureManager()
        {
            this.Dispose(false);
        }

        public static IInfrastructureManager Instance { get; } = new InfrastructureManager(LoggingModes.All);

        public IIdentityProvider IdentityProvider { get; }

        public ILoggingProvider LoggingProvider { get; }

        public ITemporalProvider TemporalProvider { get; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed")]
        private void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                this.LoggingProvider.Dispose();
            }

            this.isDisposed = true;
        }
    }
}