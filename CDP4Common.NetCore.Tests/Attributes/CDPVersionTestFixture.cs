// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDPVersionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Attributes
{
    using System;    
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for hte <see cref="CDPVersionAttribute"/> class.
    /// </summary>
    [TestFixture]
    public class CDPVersionTestFixture
    {
        [Test]
        public void VerifyThatTheVersionIsSet()
        {
            var cdpversion = new CDPVersionAttribute("1.2");
            Assert.AreEqual("1.2", cdpversion.Version);
        }

        [Test]
        public void VerifyThatExceptionIsThrownWhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CDPVersionAttribute(null));
        }
    }
}
