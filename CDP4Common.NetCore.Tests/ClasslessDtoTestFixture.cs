// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using NUnit.Framework;

    [TestFixture]
    public class ClasslessDtoTestFixture
    {
        private MetaDataProvider metaDataProvider;

        [SetUp]
        public void Setup()
        {
            this.metaDataProvider = new MetaDataProvider();
        }

        [Test]
        public void TestFromThing()
        {
            var siteDir = new SiteDirectory(Guid.NewGuid(), 2);
            siteDir.DefaultPersonRole = Guid.NewGuid();

            var properties = new List<string> {"DefaultPersonRole", "Iid"};

            var returned = ClasslessDtoFactory.FromThing(this.metaDataProvider, siteDir, properties);

            Assert.That(returned.Count, Is.EqualTo(3));

            object guid;
            
            Assert.That(returned.TryGetValue("DefaultPersonRole", out guid), Is.True);
            Assert.That((guid as Guid?).Value, Is.EqualTo(siteDir.DefaultPersonRole));
        }

        [Test]
        public void TestFromThingFull()
        {
            var siteDir = new SiteDirectory(Guid.NewGuid(), 2);
            siteDir.DefaultPersonRole = Guid.NewGuid();
            
            var returned = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, siteDir);

            Assert.That(returned.ContainsKey("ClassKind"), Is.True);
            Assert.That(returned.ContainsKey("Iid"), Is.True);
            Assert.That(returned.ContainsKey("Organization"), Is.True);
            Assert.That(returned.ContainsKey("Person"), Is.True);
            Assert.That(returned.ContainsKey("ParticipantRole"), Is.True);
            Assert.That(returned.ContainsKey("DefaultParticipantRole"), Is.True);
            Assert.That(returned.ContainsKey("SiteReferenceDataLibrary"), Is.True);
            Assert.That(returned.ContainsKey("Model"), Is.True);
            Assert.That(returned.ContainsKey("PersonRole"), Is.True);
            Assert.That(returned.ContainsKey("DefaultPersonRole"), Is.True);
            Assert.That(returned.ContainsKey("LogEntry"), Is.True);
            Assert.That(returned.ContainsKey("DomainGroup"), Is.True);
            Assert.That(returned.ContainsKey("Domain"), Is.True);
            Assert.That(returned.ContainsKey("NaturalLanguage"), Is.True);
            Assert.That(returned.ContainsKey("CreatedOn"), Is.True);
            Assert.That(returned.ContainsKey("Name"), Is.True);
            Assert.That(returned.ContainsKey("ShortName"), Is.True);
            Assert.That(returned.ContainsKey("LastModifiedOn"), Is.True);
            Assert.That(returned.ContainsKey("ModifiedOn"), Is.True);
            Assert.That(returned.ContainsKey("RevisionNumber"), Is.True);            
            Assert.That(returned.ContainsKey("ExcludedDomain"), Is.True);
            Assert.That(returned.ContainsKey("ExcludedPerson"), Is.True);
            Assert.That(returned.ContainsKey("Annotation"), Is.True);
            Assert.That(returned.ContainsKey("ThingPreference"), Is.True);

            Assert.That(returned.Count, Is.EqualTo(24));

            object guid;
            
            Assert.That(returned.TryGetValue("DefaultPersonRole", out guid), Is.True);

            Assert.That((guid as Guid?).Value, Is.EqualTo(siteDir.DefaultPersonRole));
        }

        [Test]
        public void TestNullThing()
        {
            Thing thing = null;
           Assert.That(() => ClasslessDtoFactory.FromThing(this.metaDataProvider, thing), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestNullThing2()
        {
            Thing thing = null;
            Assert.That(() => ClasslessDtoFactory.FullFromThing(this.metaDataProvider, thing), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatNullableIsTakenIntoAccount()
        {
            Thing thing = new ParameterGroup();
            var classlessDTO = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, thing);
            object containingGroup;
            classlessDTO.TryGetValue("ContainingGroup", out containingGroup);
            
            Assert.That(containingGroup, Is.Null);
            
            object name;
            classlessDTO.TryGetValue("Name", out name);
            
            Assert.That(name, Is.Not.Null);

            Assert.That(name, Is.EqualTo(string.Empty));
        }
    }
}
