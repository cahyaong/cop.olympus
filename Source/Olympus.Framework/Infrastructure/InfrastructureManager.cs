// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfrastructureManager.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 25 April 2015 1:01:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Diagnostics.CodeAnalysis;
using nGratis.Cop.Olympus.Contract;

public sealed class InfrastructureManager : IInfrastructureManager, IDisposable
{
    private bool _isDisposed;

    public InfrastructureManager(LoggingModes loggingModes)
    {
        this.IdentityProvider = Framework.IdentityProvider.Instance;
        this.LoggingProvider = new LoggingProvider(loggingModes);
        this.TemporalProvider = Framework.TemporalProvider.Instance;
    }

    ~InfrastructureManager()
    {
        this.Dispose(false);
    }

    public static IInfrastructureManager Instance { get; } = new InfrastructureManager(LoggingModes.All);

    public IIdentityProvider IdentityProvider { get; }

    public ITemporalProvider TemporalProvider { get; }

    public ILoggingProvider LoggingProvider { get; }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    [SuppressMessage(
        "Microsoft.Usage",
        "CA2213:DisposableFieldsShouldBeDisposed",
        MessageId = "<LoggingProvider>k__BackingField",
        Justification = "Does not work with NULL propagation syntax.")]
    private void Dispose(bool isDisposing)
    {
        if (this._isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            this.LoggingProvider?.Dispose();
        }

        this._isDisposed = true;
    }
}