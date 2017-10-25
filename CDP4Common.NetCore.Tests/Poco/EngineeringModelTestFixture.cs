// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class EngineeringModelTestFixture
    {
        private EngineeringModel model;
        private EngineeringModelSetup modelsetup;
        private Participant participant;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            this.model = new EngineeringModel();
            this.modelsetup = new EngineeringModelSetup();
            this.participant = new Participant();
            this.person = new Person();

            this.participant.Person = this.person;
            this.modelsetup.Participant.Add(this.participant);
            this.model.EngineeringModelSetup = this.modelsetup;
        }

        [Test]
        public void VerifyThatGetParticipantWorks()
        {
            Assert.IsNotNull(this.model.GetActiveParticipant(this.person));
        }

        [Test]
        public void VerifyThatMethodThrow()
        {
            Assert.Throws<ArgumentNullException>(() => this.model.GetActiveParticipant(null));
        }

        [Test]
        public void VerifyThatRequiredRdlsReturnsExpectedResult()
        {
            var genericRdl = new SiteReferenceDataLibrary();
            var familyOfRdl = new SiteReferenceDataLibrary();

            familyOfRdl.RequiredRdl = genericRdl;

            var modelRdl = new ModelReferenceDataLibrary();
            modelRdl.RequiredRdl = familyOfRdl;

            this.modelsetup.RequiredRdl.Add(modelRdl);

            var expectedRdls = new List<ReferenceDataLibrary>();
            expectedRdls.Add(genericRdl);
            expectedRdls.Add(familyOfRdl);
            expectedRdls.Add(modelRdl);

            CollectionAssert.AreEquivalent(expectedRdls, this.model.RequiredRdls);
        }
    }
}