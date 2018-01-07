// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CredentialsTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.DAL
{
    using System;

    using CDP4Dal.DAL;

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

            Assert.AreEqual(password, credentials.Password);
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
    }
}
