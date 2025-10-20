// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationInformationTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Dal.NetCore.Tests.DAL
{
    using CDP4Dal.DAL;
    using CDP4DalCommon.Authentication;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="AuthenticationInformation"/>.
    /// </summary>
    [TestFixture]
    public class AuthenticationInformationTestFixture
    {
        [Test]
        public void VerifyConstructorWithUserNameAndPassword()
        {
            const string expectedUserName = "user";
            const string expectedPassword = "pass";

            var information = new AuthenticationInformation(expectedUserName, expectedPassword);

            Assert.Multiple(() =>
            {
                Assert.That(information.UserName, Is.EqualTo(expectedUserName));
                Assert.That(information.Password, Is.EqualTo(expectedPassword));
                Assert.That(information.Token, Is.Null);
            });
        }

        [Test]
        public void VerifyConstructorWithAuthenticationToken()
        {
            var expectedToken = new AuthenticationToken("access", "refresh");

            var information = new AuthenticationInformation(expectedToken);

            Assert.Multiple(() =>
            {
                Assert.That(information.Token, Is.SameAs(expectedToken));
                Assert.That(information.UserName, Is.Null);
                Assert.That(information.Password, Is.Null);
            });
        }
    }
}
