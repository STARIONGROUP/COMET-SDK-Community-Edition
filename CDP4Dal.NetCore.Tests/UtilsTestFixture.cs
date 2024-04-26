// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Nathanael Smiechowski
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

namespace CDP4Dal.NetCore.Tests
{
    using System;
    using NUnit.Framework;
    using CDP4Dal;

    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void AssertThatUriSchemaAssertionWorksForHttpAndHttps()
        {
            UriExtensions.AssertUriIsHttpOrHttpsSchema(new Uri("http://somehost.com:23/"));
            UriExtensions.AssertUriIsHttpOrHttpsSchema(new Uri("https://someotherhost.com"));
        }

        [Test]
        public void AssertThatNonHttpAndHttpsSchemasThrow()
        {
            Assert.Throws<ArgumentException>(() => UriExtensions.AssertUriIsHttpOrHttpsSchema(new Uri("file://somehost.com")));
            Assert.Throws<ArgumentException>(() => UriExtensions.AssertUriIsHttpOrHttpsSchema(new Uri("ftp://somehost.com")));
        }

        [Test]
        public void AssertThatUriSchemaAssertionWorksForFile()
        {
            UriExtensions.AssertUriIsFileSchema(new Uri("file://localhost/etc/fstab"));
            UriExtensions.AssertUriIsFileSchema(new Uri("file:///c:/WINDOWS/clock.avi"));
        }

        [Test]
        public void AssertThatNonFileSchemasThrow()
        {
            Assert.Throws<ArgumentException>(() => UriExtensions.AssertUriIsFileSchema(new Uri("http://somehost.com")));
            Assert.Throws<ArgumentException>(() => UriExtensions.AssertUriIsFileSchema(new Uri("ftp://somehost.com")));
        }

        [Test]
        public void VerifyCapitalizefirstLetterFunction()
        {
            Assert.AreEqual("A", StringExtensions.CapitalizeFirstLetter("a"));
            Assert.AreEqual("Abcd", StringExtensions.CapitalizeFirstLetter("abcd"));
        }

        [Test]
        public void VerifyLowerCasefirstLetterFunction()
        {
            Assert.AreEqual("a", StringExtensions.LowerCaseFirstLetter("A"));
            Assert.AreEqual("aBCD", StringExtensions.LowerCaseFirstLetter("ABCD"));
        }

        [Test]
        public void VerifyCapitalizefirstLetterThatExceptionIsThrownWhenargumentIsNull()
        {
            Assert.Throws<ArgumentException>(() => StringExtensions.CapitalizeFirstLetter(null));
            Assert.Throws<ArgumentException>(() => StringExtensions.CapitalizeFirstLetter(string.Empty));
        }

        [Test]
        public void VerifyLowerCasefirstLetterThatExceptionIsThrownWhenargumentIsNull()
        {
            Assert.Throws<ArgumentException>(() => StringExtensions.LowerCaseFirstLetter(null));
            Assert.Throws<ArgumentException>(() => StringExtensions.LowerCaseFirstLetter(string.Empty));
        }
    }
}
