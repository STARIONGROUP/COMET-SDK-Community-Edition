// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
            Assert.That(() => this.model.GetActiveParticipant(null), Throws.TypeOf<ArgumentNullException>());
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