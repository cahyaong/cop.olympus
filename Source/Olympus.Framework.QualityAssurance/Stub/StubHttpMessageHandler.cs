// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StubHttpMessageHandler.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Thursday, 8 November 2018 10:39:54 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Framework;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using nGratis.Cop.Olympus.Contract;

public class StubHttpMessageHandler : HttpMessageHandler
{
    protected StubHttpMessageHandler(Assembly targetAssembly)
    {
        this.TargetAssembly = targetAssembly;
        this.StubInfoByUriLookup = new Dictionary<Uri, StubInfo>();
    }

    protected IDictionary<Uri, StubInfo> StubInfoByUriLookup { get; }

    protected Assembly TargetAssembly { get; }

    public static StubHttpMessageHandler Create()
    {
        return new StubHttpMessageHandler(Assembly.GetExecutingAssembly());
    }

    public StubHttpMessageHandler WithSuccessfulResponse(string targetUrl, string content)
    {
        Guard
            .Require(targetUrl, nameof(targetUrl))
            .Is.Not.Empty();

        Guard
            .Require(content, nameof(content))
            .Is.Not.Empty();

        var targetUri = new Uri(targetUrl);

        Guard
            .Require(targetUri, nameof(targetUri))
            .Is.Url();

        if (this.StubInfoByUriLookup.ContainsKey(targetUri))
        {
            throw new OlympusTestingException($"Target URI [{targetUri}] must be registered exactly once!");
        }

        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(content)
        };

        this.StubInfoByUriLookup[targetUri] = new StubInfo(targetUri, response);

        return this;
    }

    public StubHttpMessageHandler WithSuccessfulResponseInSession(
        string targetUrl,
        string name,
        string entryKey = "")
    {
        Guard
            .Require(targetUrl, nameof(targetUrl))
            .Is.Not.Empty();

        Guard
            .Require(name, nameof(name))
            .Is.Not.Empty();

        var targetUri = new Uri(targetUrl);

        Guard
            .Require(targetUri, nameof(targetUri))
            .Is.Url();

        if (this.StubInfoByUriLookup.ContainsKey(targetUri))
        {
            throw new OlympusTestingException($"Target URL [{targetUri}] must be registered exactly once!");
        }

        using (var sessionStream = this.TargetAssembly.FetchSessionStream(name, OlympusMime.Session))
        using (var sessionArchive = new ZipArchive(sessionStream, ZipArchiveMode.Read))
        {
            if (string.IsNullOrEmpty(entryKey))
            {
                entryKey = targetUri.Segments.Last();
            }

            var matchedEntry = sessionArchive
                .Entries
                .SingleOrDefault(entry => entry.Name == entryKey);

            if (matchedEntry == null)
            {
                var entryKeys = targetUri
                    .Query[1..]
                    .Split('&')
                    .Select(parameter => parameter.Split('=')[1])
                    .ToArray();

                matchedEntry = sessionArchive
                    .Entries
                    .SingleOrDefault(entry => entryKeys.Contains(entry.Name));
            }

            if (matchedEntry == null)
            {
                throw new OlympusTestingException($"Response for [{entryKey}] is missing from [{name}]!");
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = StubHttpMessageHandler.CreateHttpContent(matchedEntry)
            };

            this.StubInfoByUriLookup[targetUri] = new StubInfo(targetUri, response);
        }

        return this;
    }

    public StubHttpMessageHandler WithResponse(string targetUrl, HttpStatusCode statusCode, string content = "")
    {
        Guard
            .Require(targetUrl, nameof(targetUrl))
            .Is.Not.Empty();

        var targetUri = new Uri(targetUrl);

        Guard
            .Require(targetUri, nameof(targetUri))
            .Is.Url();

        if (this.StubInfoByUriLookup.ContainsKey(targetUri))
        {
            throw new OlympusTestingException($"Target URL [{targetUri}] must be registered exactly once!");
        }

        var response = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(content)
        };

        this.StubInfoByUriLookup[targetUri] = new StubInfo(targetUri, response);

        return this;
    }

    public void VerifyInvoked(string targetUrl, int expectedCount)
    {
        Guard
            .Require(targetUrl, nameof(targetUrl))
            .Is.Not.Empty();

        Guard
            .Require(expectedCount, nameof(expectedCount))
            .Is.ZeroOrPositive();

        var targetUri = new Uri(targetUrl);

        Guard
            .Require(targetUri, nameof(targetUri))
            .Is.Url();

        var isValid =
            this.StubInfoByUriLookup.TryGetValue(targetUri, out var stubInfo) &&
            stubInfo.InvocationCount == expectedCount;

        if (!isValid)
        {
            throw new OlympusTestingException(
                $"Verification failed because URL [{targetUri}] " +
                $"is invoked [{stubInfo?.InvocationCount ?? 0}] time(s), " +
                $"but expected to be invoked [{expectedCount}] time(s)!");
        }
    }

    protected static HttpContent CreateHttpContent(ZipArchiveEntry archiveEntry)
    {
        using var entryStream = archiveEntry.Open();

        return Path.GetExtension(archiveEntry.Name) == Mime.Jpeg.FileExtension
            ? new ByteArrayContent(entryStream.ReadBlob())
            : new StringContent(entryStream.ReadText(Encoding.UTF8));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var targetUri = request.RequestUri;

        if (targetUri == null)
        {
            throw new OlympusTestingException("Request message must have valid URI!");
        }

        if (!this.StubInfoByUriLookup.TryGetValue(targetUri, out var stubInfo))
        {
            stubInfo = new StubInfo(targetUri, new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        stubInfo.InvocationCount++;

        return await Task.FromResult(stubInfo.Response);
    }

    protected sealed class StubInfo
    {
        public StubInfo(Uri targetUri, HttpResponseMessage response)
        {
            Guard
                .Require(targetUri, nameof(targetUri))
                .Is.Url();

            this.TargetUri = targetUri;
            this.Response = response;
            this.InvocationCount = 0;
        }

        public Uri TargetUri { get; }

        public HttpResponseMessage Response { get; }

        public int InvocationCount { get; set; }
    }
}