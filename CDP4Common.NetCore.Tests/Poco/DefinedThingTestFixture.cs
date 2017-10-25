// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThingTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    public class DefinedThingTestFixture
    {
        private ElementDefinition elementDefinition;

        [SetUp]
        public void SetUp()
        {
            this.elementDefinition = new ElementDefinition()
            {
                Name = "this is a name",
                ShortName = "shortname"
            };
        }

        [Test]
        public void VerifyThatUserFriendlyNameReturnsExpectedResult()
        {
            Assert.AreEqual("this is a name", this.elementDefinition.UserFriendlyName);
        }

        [Test]
        public void VerifyThatUserFriendlyShortNameReturnsExpectedResult()
        {
            Assert.AreEqual("shortname", this.elementDefinition.UserFriendlyShortName);
        }
    }
}
