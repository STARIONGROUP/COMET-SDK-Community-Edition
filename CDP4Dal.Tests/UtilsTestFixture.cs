// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void AssertThatArgumentNotNullWorks()
        {
            Utils.AssertArgumentNotNull(new SiteDirectory());
            Assert.Throws<ArgumentNullException>(() => Utils.AssertArgumentNotNull(null));
        }

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
        public void VerifyThatTheNullIsAsserted()
        {
            var x = new object();
            Assert.DoesNotThrow(() => Utils.AssertNotNull(x));

            Assert.Throws<NullReferenceException>(() => Utils.AssertNotNull(null));
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
