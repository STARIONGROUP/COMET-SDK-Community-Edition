// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProxySettingsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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

namespace CDP4Dal.NetCore.Tests.DAL
{
    using System;
    using CDP4Dal.DAL;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ProxySettings"/> class
    /// </summary>
    [TestFixture]
    public class ProxySettingsTestFixture
    {
        [Test]
        public void Verify_that_null_Address_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ProxySettings(null, "", ""));
        }

        [Test]
        public void Verify_that_properties_are_set()
        {
            var address = new Uri("http://proxy.cdp4.org");
            var userName = "John";
            var password = "Doe";

            var proxySettings = new ProxySettings(address, userName, password);

            Assert.AreEqual(address, proxySettings.Address);
            Assert.AreEqual(userName, proxySettings.UserName);
            Assert.AreEqual(password, proxySettings.Password);
        }
    }
}