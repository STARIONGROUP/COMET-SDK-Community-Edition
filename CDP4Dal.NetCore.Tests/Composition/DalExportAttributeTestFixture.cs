// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalExportAttributeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.Composition
{
    using CDP4Dal.Composition;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tess for the <see cref="DalExportAttribute"/>
    /// </summary>
    [TestFixture]
    public class DalExportAttributeTestFixture
    {
        [Test]
        public void VerifyThatThePropertiesAreSet()
        {
            var name = "CDP4";
            var description = "CDP4 Webservices";
            var cdpVersion = "1.1.0";
            var type = DalType.Web;

            var attribute = new DalExportAttribute(name, description, cdpVersion, DalType.Web);
            Assert.AreEqual(name, attribute.Name);
            Assert.AreEqual(description, attribute.Description);
            Assert.AreEqual(cdpVersion, attribute.CDPVersion);
            Assert.AreEqual(type, attribute.DalType);
        }
    }
}
