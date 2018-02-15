#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal.Tests
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void AssertThatUriSchemaAssertionWorksForHttpAndHttps()
        {
            Utils.AssertUriIsHttpOrHttpsSchema(new Uri("http://somehost.com:23/"));
            Utils.AssertUriIsHttpOrHttpsSchema(new Uri("https://someotherhost.com"));
        }

        [Test]
        public void AssertThatNonHttpAndHttpsSchemasThrow()
        {
            Assert.Throws<ArgumentException>(() => Utils.AssertUriIsHttpOrHttpsSchema(new Uri("file://somehost.com")));
            Assert.Throws<ArgumentException>(() => Utils.AssertUriIsHttpOrHttpsSchema(new Uri("ftp://somehost.com")));
        }

        [Test]
        public void AssertThatUriSchemaAssertionWorksForFile()
        {
            Utils.AssertUriIsFileSchema(new Uri("file://localhost/etc/fstab"));
            Utils.AssertUriIsFileSchema(new Uri("file:///c:/WINDOWS/clock.avi"));
        }

        [Test]
        public void AssertThatNonFileSchemasThrow()
        {
            Assert.Throws<ArgumentException>(() => Utils.AssertUriIsFileSchema(new Uri("http://somehost.com")));
            Assert.Throws<ArgumentException>(() => Utils.AssertUriIsFileSchema(new Uri("ftp://somehost.com")));
        }

        [Test]
        public void VerifyCapitalizefirstLetterFunction()
        {
            Assert.AreEqual("A", Utils.CapitalizeFirstLetter("a"));
            Assert.AreEqual("Abcd", Utils.CapitalizeFirstLetter("abcd"));
        }

        [Test]
        public void VerifyLowerCasefirstLetterFunction()
        {
            Assert.AreEqual("a", Utils.LowerCaseFirstLetter("A"));
            Assert.AreEqual("aBCD", Utils.LowerCaseFirstLetter("ABCD"));
        }

        [Test]
        public void VerifyCapitalizefirstLetterThatExceptionIsThrownWhenargumentIsNull()
        {
            Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(null));
            Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(string.Empty));
        }

        [Test]
        public void VerifyLowerCasefirstLetterThatExceptionIsThrownWhenargumentIsNull()
        {
            Assert.Throws<ArgumentException>(() => Utils.LowerCaseFirstLetter(null));
            Assert.Throws<ArgumentException>(() => Utils.LowerCaseFirstLetter(string.Empty));
        }
    }
}
