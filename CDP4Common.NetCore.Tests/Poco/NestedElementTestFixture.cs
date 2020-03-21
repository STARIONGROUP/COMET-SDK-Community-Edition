// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
        public void VerifyThatGetNameWorks()
        {
            Assert.AreEqual("ElementUsage2", this.nestedElement.Name);
        }

        [Test]
        public void VerifyThatGetNameWorks2()
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