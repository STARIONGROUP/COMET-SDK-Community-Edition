// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRuleVerificationTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class UserRuleVerificationTestFixture
    {
        [Test]
        public void TestGetDerivedName()
        {
            var userRuleVerif = new UserRuleVerification();
            userRuleVerif.Rule = new DecompositionRule(){Name = "rule"};

            Assert.AreEqual("rule", userRuleVerif.Name);
        }
    }
}