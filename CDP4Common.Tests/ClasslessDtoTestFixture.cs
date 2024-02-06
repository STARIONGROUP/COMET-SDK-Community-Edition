#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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

            var properties = new List<string> { "DefaultPersonRole", "Iid" };

            var returned = ClasslessDtoFactory.FromThing(this.metaDataProvider, siteDir, properties);

            Assert.AreEqual(3, returned.Count);
            object guid;
            Assert.IsTrue(returned.TryGetValue("DefaultPersonRole", out guid));
            Assert.AreEqual(siteDir.DefaultPersonRole, (guid as Guid?).Value);
        }

        [Test]
        public void TestFromThingFull()
        {
            var siteDir = new SiteDirectory(Guid.NewGuid(), 2);
            siteDir.DefaultPersonRole = Guid.NewGuid();

            var returned = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, siteDir);

            Assert.IsTrue(returned.ContainsKey("ClassKind"));
            Assert.IsTrue(returned.ContainsKey("Iid"));
            Assert.IsTrue(returned.ContainsKey("Organization"));
            Assert.IsTrue(returned.ContainsKey("Person"));
            Assert.IsTrue(returned.ContainsKey("ParticipantRole"));
            Assert.IsTrue(returned.ContainsKey("DefaultParticipantRole"));
            Assert.IsTrue(returned.ContainsKey("SiteReferenceDataLibrary"));
            Assert.IsTrue(returned.ContainsKey("Model"));
            Assert.IsTrue(returned.ContainsKey("PersonRole"));
            Assert.IsTrue(returned.ContainsKey("DefaultPersonRole"));
            Assert.IsTrue(returned.ContainsKey("LogEntry"));
            Assert.IsTrue(returned.ContainsKey("DomainGroup"));
            Assert.IsTrue(returned.ContainsKey("Domain"));
            Assert.IsTrue(returned.ContainsKey("NaturalLanguage"));
            Assert.IsTrue(returned.ContainsKey("CreatedOn"));
            Assert.IsTrue(returned.ContainsKey("Name"));
            Assert.IsTrue(returned.ContainsKey("ShortName"));
            Assert.IsTrue(returned.ContainsKey("LastModifiedOn"));
            Assert.IsTrue(returned.ContainsKey("ModifiedOn"));
            Assert.IsTrue(returned.ContainsKey("RevisionNumber"));
            Assert.IsTrue(returned.ContainsKey("ExcludedDomain"));
            Assert.IsTrue(returned.ContainsKey("ExcludedPerson"));
            Assert.IsTrue(returned.ContainsKey("Annotation"));
            Assert.IsTrue(returned.ContainsKey("ThingPreference"));

            Assert.AreEqual(24, returned.Count);

            object guid;
            Assert.IsTrue(returned.TryGetValue("DefaultPersonRole", out guid));
            Assert.AreEqual(siteDir.DefaultPersonRole, (guid as Guid?).Value);
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
            Assert.IsNull(containingGroup);
            object name;
            classlessDTO.TryGetValue("Name", out name);
            Assert.IsNotNull(name);
            Assert.AreEqual(string.Empty, name);
        }
    }
}
