// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class NestedParameterTestFixture
    {
        private SimpleQuantityKind simpleQuantityKind;
        private Parameter parameter;
        private NestedParameter nestedParameter;

        [SetUp]
        public void SetUp()
        {
            this.simpleQuantityKind = new SimpleQuantityKind() {ShortName = "TST", Name = "TEST" };
            this.parameter = new Parameter() { ParameterType = this.simpleQuantityKind };
            this.nestedParameter =new NestedParameter() { AssociatedParameter = this.parameter };
        }

        [Test]
        public void VerifyThatUserFriendlyShortNameReturnsExpectedResult()
        {
            Assert.AreEqual("TST", this.nestedParameter.UserFriendlyShortName );
        }

        [Test]
        public void VerifyThatUserFriendlyNameReturnsExpectedResult()
        {
            Assert.AreEqual("TST", this.nestedParameter.UserFriendlyName);
        }
    }
}
