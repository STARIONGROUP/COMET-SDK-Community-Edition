// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdCorrespondenceTestFixture.cs" company="RHEA System S.A.">
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
    public class IdCorrespondenceTestFixture
    {
        [Test]
        public void VerifyGetOwner()
        {
            var thing = new IdCorrespondence(Guid.NewGuid(), null, null);
            var externalIdentifierMap = new ExternalIdentifierMap(Guid.NewGuid(), null, null);
            externalIdentifierMap.Owner = new DomainOfExpertise(Guid.NewGuid(), null, null);

            thing.Container = externalIdentifierMap;

            Assert.IsTrue(ReferenceEquals(thing.Owner, externalIdentifierMap.Owner));
        }

        [Test]        
        public void VerifyGetOwnerThrowException()
        {
            var thing = new IdCorrespondence(Guid.NewGuid(), null, null);

            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(thing.Owner);
            });
        }
    }
}