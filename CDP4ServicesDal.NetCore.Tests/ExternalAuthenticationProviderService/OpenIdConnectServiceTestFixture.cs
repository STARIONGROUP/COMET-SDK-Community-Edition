// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenIdConnectServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2026 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.NetCore.Tests.ExternalAuthenticationProviderService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CDP4DalCommon.Authentication;

    using CDP4ServicesDal.ExternalAuthenticationProviderService;

    using NUnit.Framework;

    [TestFixture]
    public class OpenIdConnectServiceTestFixture
    {
        private const string TokenEndpointPath = "/protocol/openid-connect/token";

        private readonly JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };

        private OpenIdConnectService service;

        [SetUp]
        public void SetUp()
        {
            this.service = new OpenIdConnectService();
        }

        [Test]
        public async Task Verify_that_RequestAuthenticationToken_throws_when_response_is_null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await this.service.RequestAuthenticationToken("code", null));
        }

        [Test]
        public async Task Verify_that_RequestAuthenticationToken_throws_when_scheme_missing_ExternalJwtBearer()
        {
            var response = new AuthenticationSchemeResponse
            {
                Schemes = new List<AuthenticationSchemeKind> { AuthenticationSchemeKind.Basic },
                Authority = "https://auth.example.com",
                ClientId = "test-client"
            };

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this.service.RequestAuthenticationToken("code", response));
        }

        [Test]
        public async Task Verify_that_RequestAuthenticationToken_uses_refresh_token_flow_when_no_redirect_uri_is_provided()
        {
            using var listener = CreateListener(out var authority);
            var schemeResponse = CreateSchemeResponse(authority);
            var expectedToken = new AuthenticationToken("access", "refresh");
            var requestTask = HandleRequestAsync(listener, 200, JsonSerializer.Serialize(expectedToken, this.serializerOptions));

            var token = await this.service.RequestAuthenticationToken("refresh-token", schemeResponse, clientSecret: "secret");
            var (path, body) = await requestTask;
            var formValues = ParseFormUrlEncoded(body);

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.EqualTo(TokenEndpointPath));
                Assert.That(token.AccessToken, Is.EqualTo(expectedToken.AccessToken));
                Assert.That(token.RefreshToken, Is.EqualTo(expectedToken.RefreshToken));
                Assert.That(formValues["grant_type"], Is.EqualTo("refresh_token"));
                Assert.That(formValues["refresh_token"], Is.EqualTo("refresh-token"));
                Assert.That(formValues["client_id"], Is.EqualTo(schemeResponse.ClientId));
                Assert.That(formValues["client_secret"], Is.EqualTo("secret"));
                Assert.That(formValues, Does.Not.ContainKey("redirect_uri"));
            });
        }

        [Test]
        public async Task Verify_that_RequestAuthenticationToken_uses_authorization_code_flow_when_redirect_uri_is_provided()
        {
            using var listener = CreateListener(out var authority);
            var schemeResponse = CreateSchemeResponse(authority);
            var expectedToken = new AuthenticationToken("access", "refresh");
            var requestTask = HandleRequestAsync(listener, 200, JsonSerializer.Serialize(expectedToken, this.serializerOptions));

            var token = await this.service.RequestAuthenticationToken("code-value", schemeResponse, "http://localhost/callback");
            var (path, body) = await requestTask;
            var formValues = ParseFormUrlEncoded(body);

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.EqualTo(TokenEndpointPath));
                Assert.That(token.AccessToken, Is.EqualTo(expectedToken.AccessToken));
                Assert.That(formValues["grant_type"], Is.EqualTo("authorization_code"));
                Assert.That(formValues["code"], Is.EqualTo("code-value"));
                Assert.That(formValues["redirect_uri"], Is.EqualTo("http://localhost/callback"));
                Assert.That(formValues, Does.Not.ContainKey("client_secret"));
            });
        }

        [Test]
        public async Task Verify_that_RequestAuthenticationToken_throws_HttpRequestException_on_error_status()
        {
            using var listener = CreateListener(out var authority);
            var schemeResponse = CreateSchemeResponse(authority);
            var requestTask = HandleRequestAsync(listener, 500, string.Empty);

            var exception = await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await this.service.RequestAuthenticationToken("code", schemeResponse));

            await requestTask;

            Assert.That(exception.Message, Does.Contain("Status Code: 500"));
        }

        /// <summary>
        /// Creates an <see cref="AuthenticationSchemeResponse"/> that supports the ExternalJwtBearer scheme
        /// </summary>
        /// <param name="authority">The authority that issues the tokens</param>
        /// <returns>The <see cref="AuthenticationSchemeResponse"/></returns>
        private static AuthenticationSchemeResponse CreateSchemeResponse(string authority)
        {
            return new AuthenticationSchemeResponse
            {
                Authority = authority,
                ClientId = "client-id",
                Schemes = new List<AuthenticationSchemeKind> { AuthenticationSchemeKind.ExternalJwtBearer }
            };
        }

        /// <summary>
        /// Starts an <see cref="HttpListener"/> on a free local port that acts as the token endpoint
        /// </summary>
        /// <param name="authority">The base address of the listener</param>
        /// <returns>The started <see cref="HttpListener"/></returns>
        private static HttpListener CreateListener(out string authority)
        {
            authority = $"http://localhost:{GetFreeTcpPort()}";
            var listener = new HttpListener();
            listener.Prefixes.Add($"{authority}/");
            listener.Start();
            return listener;
        }

        /// <summary>
        /// Answers the next request on the <paramref name="listener"/>
        /// </summary>
        /// <param name="listener">The <see cref="HttpListener"/></param>
        /// <param name="statusCode">The status code of the response</param>
        /// <param name="responseContent">The body of the response</param>
        /// <returns>The path and body of the received request</returns>
        private static async Task<(string Path, string Body)> HandleRequestAsync(HttpListener listener, int statusCode, string responseContent)
        {
            var context = await listener.GetContextAsync();

            using var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding);
            var body = await reader.ReadToEndAsync();

            context.Response.StatusCode = statusCode;

            if (!string.IsNullOrEmpty(responseContent))
            {
                var buffer = Encoding.UTF8.GetBytes(responseContent);
                await context.Response.OutputStream.WriteAsync(buffer);
            }

            context.Response.Close();

            return (context.Request.Url?.AbsolutePath, body);
        }

        /// <summary>
        /// Parses a form url encoded body into its keys and values
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The keys and values</returns>
        private static Dictionary<string, string> ParseFormUrlEncoded(string body)
        {
            return body.Split('&', StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split('=', 2))
                .ToDictionary(pair => WebUtility.UrlDecode(pair[0]), pair => WebUtility.UrlDecode(pair[1]));
        }

        /// <summary>
        /// Gets a free TCP port on the loopback address
        /// </summary>
        /// <returns>The port number</returns>
        private static int GetFreeTcpPort()
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, 0);
            tcpListener.Start();
            var port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            return port;
        }
    }
}
