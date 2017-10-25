// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteStateTestFixture.cs" company="RHEA System S.A.">
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
    internal class PossibleFiniteStateTestFixture
    {
        [Test]
        public void TestGetOwner()
        {
            var thing = new PossibleFiniteState();
            var list = new PossibleFiniteStateList();
            list.Owner = new DomainOfExpertise();
            list.PossibleState.Add(thing);

            Assert.IsTrue(ReferenceEquals(list.Owner, thing.Owner));
        }

        [Test]
        public void TestGetOwnerThrowEx()
        {
            var thing = new PossibleFiniteState();
            Assert.Throws<NullReferenceException>(() =>
            {
                var d = thing.Owner;
            });
        }

        [Test]
        public void VerifyIsDefault()
        {
            var thing = new PossibleFiniteState();
            var list = new PossibleFiniteStateList();
            
            list.PossibleState.Add(thing);
            Assert.IsFalse(thing.IsDefault);

            list.DefaultState = thing;
            Assert.IsTrue(thing.IsDefault);
        }
    }
}