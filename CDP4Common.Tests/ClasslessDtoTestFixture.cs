// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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

            Assert.AreEqual(23, returned.Count);

            object guid;
            Assert.IsTrue(returned.TryGetValue("DefaultPersonRole", out guid));
            Assert.AreEqual(siteDir.DefaultPersonRole, (guid as Guid?).Value);
        }

        [Test]
        public void TestNullThing()
        {
            Thing thing = null;
            Assert.Throws<ArgumentNullException>(() => ClasslessDtoFactory.FromThing(this.metaDataProvider, thing));
        }

        [Test]
        public void TestNullThing2()
        {
            Thing thing = null;
            Assert.Throws<ArgumentNullException>(() => ClasslessDtoFactory.FullFromThing(this.metaDataProvider, thing));
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
