// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringExtensionsTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="SecureStringExtensions"/> class
    /// </summary>
    [TestFixture]
    public class SecureStringExtensionsTestFixture
    {
        [Test]        
        public void VerifyThatAStringIsConvertedToASecureStringAndCanBeConvertedBack()
        {
            var unsecurestring = "this is a string";

            var secureString = unsecurestring.ConvertToSecureString();

            Assert.AreEqual(unsecurestring, secureString.ConvertToUnsecureString());
        }

        [Test]
        public void VerifyThatConvertToSecureStringThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SecureStringExtensions.ConvertToSecureString(null));
            Assert.Throws<ArgumentException>(() => SecureStringExtensions.ConvertToSecureString(string.Empty));
        }

        [Test]
        public void VerifyThatConvertToUnsecureStringThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => SecureStringExtensions.ConvertToUnsecureString(null));
        }
    }
}
