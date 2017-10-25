// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintTestFixture.cs" company="RHEA System S.A.">
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
    internal class ParametricConstraintTestFixture
    {
        [Test]
        public void TestGetOwner()
        {
            var thuing = new ParametricConstraint();
            var req = new Requirement();
            req.Owner = new DomainOfExpertise();
            req.ParametricConstraint.Add(thuing);

            Assert.IsTrue(ReferenceEquals(req.Owner, thuing.Owner));
        }

        [Test]        
        public void TestGetOwnerThrowEx()
        {
            var parametricConstraint = new ParametricConstraint();

            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(parametricConstraint.Owner);    
            });
        }
    }
}