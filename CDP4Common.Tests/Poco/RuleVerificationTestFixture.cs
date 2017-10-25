// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerificationTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class RuleVerificationTestFixture
    {
        [Test]
        public void TestGetOwner()
        {
            var thuing = new UserRuleVerification();
            var list = new RuleVerificationList();
            list.Owner = new DomainOfExpertise();
            list.RuleVerification.Add(thuing);

            Assert.IsTrue(ReferenceEquals(list.Owner, thuing.Owner));
        }

        [Test]        
        public void TestGetOwnerThrowEx()
        {
            var userRuleVerification = new UserRuleVerification();
            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(userRuleVerification.Owner);
            });            
        }
    }
}