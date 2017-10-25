// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleParameterValueTestFixture.cs" company="RHEA System S.A.">
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
    internal class SimpleParameterValueTestFixture
    {
        [Test]
        public void TestGetOwner()
        {
            var simpleParameterValue = new SimpleParameterValue();
            var requirement = new Requirement();
            requirement.Owner = new DomainOfExpertise();
            requirement.ParameterValue.Add(simpleParameterValue);

            Assert.IsTrue(ReferenceEquals(requirement.Owner, simpleParameterValue.Owner));
        }

        [Test]
        public void TestGetOwnerThrowEx()
        {
            var simpleParameterValue = new SimpleParameterValue();

            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(simpleParameterValue.Owner);
            });
        }
    }
}