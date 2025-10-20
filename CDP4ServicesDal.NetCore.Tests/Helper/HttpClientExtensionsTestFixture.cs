// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpClientExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesDal.NetCore.Tests.Helper
{
    using System;
    using System.Net.Http;
    using System.Text;
    using CDP4Dal.DAL;
    using CDP4DalCommon.Authentication;
    using CDP4ServicesDal.Extensions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="HttpClientExtensions"/>.
    /// </summary>
    [TestFixture]
    public class HttpClientExtensionsTestFixture
    {
        [Test]
        public void VerifyThatBasicCredentialsProduceExpectedAuthorizationHeader()
        {
            var credentials = new Credentials("user", "password", new Uri("http://example.com"));

            using var client = new HttpClient();
            client.SetAuthorizationHeader(credentials);

            var expectedParameter = Convert.ToBase64String(Encoding.UTF8.GetBytes("user:password"));

            Assert.Multiple(() =>
            {
                Assert.That(client.DefaultRequestHeaders.Authorization!.Scheme, Is.EqualTo(AuthenticationSchemeKind.Basic.ToString()));
                Assert.That(client.DefaultRequestHeaders.Authorization.Parameter, Is.EqualTo(expectedParameter));
            });
        }

        [Test]
        public void VerifyThatBearerTokenCredentialsProduceExpectedAuthorizationHeader()
        {
            var credentials = new Credentials(new Uri("http://example.com"));
            credentials.ProvideUserToken(new AuthenticationToken("access-token", "refresh-token"), AuthenticationSchemeKind.ExternalJwtBearer);

            using var client = new HttpClient();
            client.SetAuthorizationHeader(credentials);

            Assert.Multiple(() =>
            {
                Assert.That(client.DefaultRequestHeaders.Authorization!.Scheme, Is.EqualTo(AuthenticationSchemeKind.ExternalJwtBearer.ToString()));
                Assert.That(client.DefaultRequestHeaders.Authorization.Parameter, Is.EqualTo("access-token"));
            });
        }
    }
}
