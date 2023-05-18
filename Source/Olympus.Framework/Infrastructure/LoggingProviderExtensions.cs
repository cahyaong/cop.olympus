// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingProviderExtensions.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 1 May 2015 1:04:31 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System.Diagnostics;
using System.Linq;
using System.Reflection;
using nGratis.Cop.Olympus.Contract;

public static class LoggingProviderExtensions
{
    public static ILogger GetLoggerFromCaller(this ILoggingProvider loggingProvider)
    {
        Guard
            .Require(loggingProvider, nameof(loggingProvider))
            .Is.Not.Null();

        var stackTrace = new StackTrace();
        var stackFrames = stackTrace.GetFrames();
        var category = default(string);

        if (stackFrames.Any())
        {
            var loggingAttribute = stackFrames
                .Select(frame => frame
                    .GetMethod()?
                    .DeclaringType?
                    .GetCustomAttributes<LoggingAttribute>()
                    .SingleOrDefault())
                .FirstOrDefault(attribute => attribute != null);

            if (loggingAttribute != null)
            {
                category = loggingAttribute.Category;
            }
        }

        return loggingProvider.GetLoggerFor(category ?? "<default>");
    }
}