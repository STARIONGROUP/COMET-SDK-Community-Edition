// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CredentialsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.DAL
{
    using System;

    using CDP4Dal.DAL;

    using CDP4DalCommon.Authentication;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Credentials"/> class
    /// </summary>
    [TestFixture]
    public class CredentialsTestFixture
    {
        [Test]
        public void VerifyThatPasswordThatisPRovidedIsEqualToTheRetrievedPsssword()
        {
            var password = "this is a password";

            var credentials = new Credentials("John", password, new Uri("file://someuri"));

            Assert.That(password, Is.EqualTo(credentials.Password));
        }

        [Test]
        public void VerifyThatArgumentNullExceptionsAreThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new Credentials(null, null, null));

            Assert.Throws<ArgumentNullException>(() => new Credentials(string.Empty, null, null));

            Assert.Throws<ArgumentNullException>(() => new Credentials("John", null, null));

            Assert.Throws<ArgumentNullException>(() => new Credentials("John", string.Empty, null));

            Assert.Throws<ArgumentNullException>(() => new Credentials("John", "a password", null));
        }

        [Test]
        public void VerifyThatProvideUserCredentialsSetsExpectedValues()
        {
            var credentials = new Credentials(new Uri("http://example.com"));

            credentials.ProvideUserCredentials("user", "password", AuthenticationSchemeKind.Basic);

            Assert.That(credentials.UserName, Is.EqualTo("user"));
            Assert.That(credentials.Password, Is.EqualTo("password"));
            Assert.That(credentials.AuthenticationScheme, Is.EqualTo(AuthenticationSchemeKind.Basic));
            Assert.That(credentials.IsFullyInitialized, Is.True);
        }

        [Test]
        public void VerifyThatProvideUserCredentialsSupportsLocalJwt()
        {
            var credentials = new Credentials(new Uri("http://example.com"));

            credentials.ProvideUserCredentials("user", "password", AuthenticationSchemeKind.LocalJwtBearer);

            Assert.That(credentials.AuthenticationScheme, Is.EqualTo(AuthenticationSchemeKind.LocalJwtBearer));
        }

        [Test]
        public void VerifyThatProvideUserCredentialsThrowsForUnsupportedScheme()
        {
            var credentials = new Credentials(new Uri("http://example.com"));

            Assert.That(() => credentials.ProvideUserCredentials("user", "password", AuthenticationSchemeKind.ExternalJwtBearer),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void VerifyThatProvideUserTokenSetsExpectedValues()
        {
            var credentials = new Credentials(new Uri("http://example.com"));
            var token = new AuthenticationToken("access", "refresh");

            credentials.ProvideUserToken(token, AuthenticationSchemeKind.ExternalJwtBearer);

            Assert.That(credentials.Token, Is.EqualTo(token));
            Assert.That(credentials.AuthenticationScheme, Is.EqualTo(AuthenticationSchemeKind.ExternalJwtBearer));
            Assert.That(credentials.IsFullyInitialized, Is.True);
        }

        [Test]
        public void VerifyThatProvideUserTokenValidatesArguments()
        {
            var credentials = new Credentials(new Uri("http://example.com"));

            Assert.That(() => credentials.ProvideUserToken(null, AuthenticationSchemeKind.ExternalJwtBearer),
                Throws.TypeOf<ArgumentNullException>());

            var token = new AuthenticationToken(string.Empty, string.Empty);

            Assert.That(() => credentials.ProvideUserToken(token, AuthenticationSchemeKind.ExternalJwtBearer),
                Throws.TypeOf<ArgumentException>());

            var validToken = new AuthenticationToken("token", "refresh");

            Assert.That(() => credentials.ProvideUserToken(validToken, AuthenticationSchemeKind.Basic),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void VerifyThatIsFullyInitializedRequiresAuthenticationInformation()
        {
            var credentials = new Credentials(new Uri("http://example.com"));

            Assert.That(credentials.IsFullyInitialized, Is.False);

            credentials.ProvideUserCredentials("user", "password", AuthenticationSchemeKind.Basic);
            Assert.That(credentials.IsFullyInitialized, Is.True);

            var tokenCredentials = new Credentials(new Uri("http://example.com"));
            tokenCredentials.ProvideUserToken(new AuthenticationToken("access", "refresh"), AuthenticationSchemeKind.LocalJwtBearer);
            Assert.That(tokenCredentials.IsFullyInitialized, Is.True);
        }
    }
}
