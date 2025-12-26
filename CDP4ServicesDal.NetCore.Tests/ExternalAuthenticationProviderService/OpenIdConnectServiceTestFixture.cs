// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenIdConnectServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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

    /// <summary>
    /// Tests for <see cref="OpenIdConnectService"/>.
    /// </summary>
    [TestFixture]
    public class OpenIdConnectServiceTestFixture
    {
        private readonly JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };

        [Test]
        public async Task VerifyThatRefreshTokenFlowIsUsedWhenNoRedirectUriIsProvided()
        {
            using var listener = this.CreateListener(out var authority);
            var schemeResponse = this.CreateSchemeResponse(authority);
            var expectedToken = new AuthenticationToken("access", "refresh");
            var bodyTask = this.HandleRequestAsync(listener, 200, JsonSerializer.Serialize(expectedToken, this.serializerOptions));

            var service = new OpenIdConnectService();
            var token = await service.RequestAuthenticationToken("refresh-token", schemeResponse, clientSecret: "secret");
            var body = await bodyTask;
            var formValues = this.ParseFormUrlEncoded(body);

            Assert.Multiple(() =>
            {
                Assert.That(token.AccessToken, Is.EqualTo(expectedToken.AccessToken));
                Assert.That(token.RefreshToken, Is.EqualTo(expectedToken.RefreshToken));
                Assert.That(formValues["grant_type"], Is.EqualTo("refresh_token"));
                Assert.That(formValues["refresh_token"], Is.EqualTo("refresh-token"));
                Assert.That(formValues["client_id"], Is.EqualTo(schemeResponse.ClientId));
                Assert.That(formValues["client_secret"], Is.EqualTo("secret"));
            });
        }

        [Test]
        public async Task VerifyThatAuthorizationCodeFlowIsUsedWhenRedirectUriIsProvided()
        {
            using var listener = this.CreateListener(out var authority);
            var schemeResponse = this.CreateSchemeResponse(authority);
            var expectedToken = new AuthenticationToken("access", "refresh");
            var bodyTask = this.HandleRequestAsync(listener, 200, JsonSerializer.Serialize(expectedToken, this.serializerOptions));

            var service = new OpenIdConnectService();
            var token = await service.RequestAuthenticationToken("code-value", schemeResponse, "http://localhost/callback");
            var body = await bodyTask;
            var formValues = this.ParseFormUrlEncoded(body);

            Assert.Multiple(() =>
            {
                Assert.That(token.AccessToken, Is.EqualTo(expectedToken.AccessToken));
                Assert.That(formValues["grant_type"], Is.EqualTo("authorization_code"));
                Assert.That(formValues["code"], Is.EqualTo("code-value"));
                Assert.That(formValues["redirect_uri"], Is.EqualTo("http://localhost/callback"));
            });
        }

        [Test]
        public void VerifyThatUnsupportedSchemesThrow()
        {
            var schemeResponse = new AuthenticationSchemeResponse
            {
                Authority = "http://localhost", 
                ClientId = "client",
                Schemes = new List<AuthenticationSchemeKind> { AuthenticationSchemeKind.Basic }
            };

            var service = new OpenIdConnectService();

            Assert.That(() => service.RequestAuthenticationToken("code", schemeResponse), Throws.InvalidOperationException);
        }

        [Test]
        public async Task VerifyThatHttpErrorsAreSurfaced()
        {
            using var listener = this.CreateListener(out var authority);
            var schemeResponse = this.CreateSchemeResponse(authority);
            var bodyTask = this.HandleRequestAsync(listener, 500, string.Empty);

            var service = new OpenIdConnectService();

            var exception = Assert.ThrowsAsync<HttpRequestException>(() => service.RequestAuthenticationToken("code", schemeResponse));
            await bodyTask;
            Assert.That(exception!.Message, Does.Contain("Status Code: 500"));
        }

        private AuthenticationSchemeResponse CreateSchemeResponse(string authority)
        {
            return new AuthenticationSchemeResponse
            {
                Authority = authority,
                ClientId = "client-id",
                Schemes = new List<AuthenticationSchemeKind> { AuthenticationSchemeKind.ExternalJwtBearer }
            };
        }

        private HttpListener CreateListener(out string authority)
        {
            var port = GetFreeTcpPort();
            authority = $"http://localhost:{port}";
            var listener = new HttpListener();
            listener.Prefixes.Add($"{authority}/");
            listener.Start();
            return listener;
        }

        private async Task<string> HandleRequestAsync(HttpListener listener, int statusCode, string responseContent)
        {
            var context = await listener.GetContextAsync();
            using var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding);
            var body = await reader.ReadToEndAsync();

            context.Response.StatusCode = statusCode;
            if (!string.IsNullOrEmpty(responseContent))
            {
                var buffer = Encoding.UTF8.GetBytes(responseContent);
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }

            context.Response.Close();
            return body;
        }

        private Dictionary<string, string> ParseFormUrlEncoded(string body)
        {
            return body.Split('&', StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split('=', 2))
                .ToDictionary(kvp => Uri.UnescapeDataString(kvp[0]), kvp => Uri.UnescapeDataString(kvp[1]));
        }

        private static int GetFreeTcpPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}
