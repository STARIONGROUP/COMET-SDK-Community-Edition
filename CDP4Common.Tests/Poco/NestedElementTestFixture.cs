// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTestFixture.cs" company="RHEA System S.A.">
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
    internal class NestedElementTestFixture
    {
        private NestedElement nestedElement;

        private ElementUsage elementUsage;
        private ElementUsage elementUsage2;
        private ElementDefinition elementDef;
        private DomainOfExpertise domain;
        private DomainOfExpertise domain2;

        [SetUp]
        public void Setup()
        {
            this.nestedElement = new NestedElement(Guid.NewGuid(), null, null);
            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null) {Name = "ElementUsage", ShortName = "Use1"};
            this.elementUsage2 = new ElementUsage(Guid.NewGuid(), null, null) { Name = "ElementUsage2", ShortName = "Use2" };
            this.elementDef = new ElementDefinition(Guid.NewGuid(), null, null) { Name = "ElementDef", ShortName = "Def"};
            this.domain = new DomainOfExpertise(Guid.NewGuid(), null, null);
            this.domain2 = new DomainOfExpertise(Guid.NewGuid(), null, null);

            this.elementUsage.Owner = this.domain2;
            this.elementUsage2.Owner = this.domain2;
            this.elementDef.Owner = this.domain;

            this.nestedElement.RootElement = this.elementDef;
            this.nestedElement.ElementUsage.Add(this.elementUsage);
            this.nestedElement.ElementUsage.Add(this.elementUsage2);
        }

        [Test]
        public void VerifyThatGetNAmeWorks()
        {
            Assert.AreEqual("ElementUsage2", this.nestedElement.Name);
        }

        [Test]
        public void VerifyThatGetNAmeWorks2()
        {
            this.nestedElement.ElementUsage.Clear();
            Assert.AreEqual("ElementDef", this.nestedElement.Name);
        }

        [Test]
        public void VerifyShortName()
        {
            Assert.AreEqual("Def.Use1.Use2", this.nestedElement.ShortName);
        }

        [Test]
        public void VerifyGetOwner()
        {
            Assert.IsTrue(ReferenceEquals(this.domain2, this.nestedElement.Owner));
        }

        [Test]
        public void VerifyGetOwner2()
        {
            this.nestedElement.ElementUsage.Clear();
            Assert.IsTrue(ReferenceEquals(this.domain, this.nestedElement.Owner));
        }
    }
}