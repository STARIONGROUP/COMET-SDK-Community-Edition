// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Kamil Wojnowski, 
//            Nathanael Smiechowski
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
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class NestedElementTestFixture
    {
        private NestedElement nestedElement;

        private ElementUsage elementUsage1;
        private ElementUsage elementUsage2;
        private ElementDefinition rootElementDef;
        private ElementDefinition elementDef1;
        private ElementDefinition elementDef2;
        private DomainOfExpertise domain;
        private DomainOfExpertise domain2;
        private Category category;
        private Option option;
        private Iteration iteration;

        [SetUp]
        public void Setup()
        {
            this.nestedElement = new NestedElement(Guid.NewGuid(), null, null);
            this.rootElementDef = new ElementDefinition(Guid.NewGuid(), null, null) { Name = "ElementDef", ShortName = "Def" };
            this.elementDef1 = new ElementDefinition(Guid.NewGuid(), null, null) { Name = "ElementDef1", ShortName = "Def1" };
            this.elementDef2 = new ElementDefinition(Guid.NewGuid(), null, null) { Name = "ElementDef2", ShortName = "Def2" };
            this.elementUsage1 = new ElementUsage(Guid.NewGuid(), null, null) { Name = "ElementUsage", ShortName = "Use1", ElementDefinition = this.elementDef1};
            this.elementUsage2 = new ElementUsage(Guid.NewGuid(), null, null) { Name = "ElementUsage2", ShortName = "Use2", ElementDefinition = this.elementDef2 };

            this.rootElementDef.ContainedElement.Add(this.elementUsage1);
            this.elementDef1.ContainedElement.Add(this.elementUsage2);

            this.domain = new DomainOfExpertise(Guid.NewGuid(), null, null);
            this.domain2 = new DomainOfExpertise(Guid.NewGuid(), null, null);

            this.elementUsage1.Owner = this.domain2;
            this.elementUsage2.Owner = this.domain2;
            this.elementUsage2.ElementDefinition = this.elementDef2;
            this.rootElementDef.Owner = this.domain;

            this.nestedElement.RootElement = this.rootElementDef;
            this.nestedElement.ElementUsage.Add(this.elementUsage1);
            this.nestedElement.ElementUsage.Add(this.elementUsage2);

            this.category = new Category(Guid.NewGuid(), null, null) { Name = "Category", ShortName = "Cat" };

            this.iteration = new Iteration(Guid.NewGuid(), null, null) {TopElement = this.rootElementDef};
            this.option = new Option(Guid.NewGuid(), null, null) { Container = this.iteration };

            this.iteration.Option.Add(this.option);
        }

        [Test]
        public void VerifyThatGetNameWorks()
        {
            Assert.AreEqual("ElementUsage2", this.nestedElement.Name);
        }

        [Test]
        public void VerifyThatGetNameWorksWhenNoElementUsages()
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
        public void VerifyGetOwnerWhenNoElementUsages()
        {
            this.nestedElement.ElementUsage.Clear();
            Assert.IsTrue(ReferenceEquals(this.domain, this.nestedElement.Owner));
        }

        [Test]
        public void VerifyGetElementBase()
        {
            Assert.IsTrue(ReferenceEquals(this.elementUsage2, this.nestedElement.GetElementBase()));
        }

        [Test]
        public void VerifyGetElementBaseWhenNoElementUsages()
        {
            this.nestedElement.ElementUsage.Clear();
            this.nestedElement.IsRootElement = true;
            Assert.IsTrue(ReferenceEquals(this.rootElementDef, this.nestedElement.GetElementBase()));
        }

        [Test]
        public void VerifyGetElementDefinition()
        {
            Assert.IsTrue(ReferenceEquals(this.elementDef2, this.nestedElement.GetElementDefinition()));
        }

        [Test]
        public void VerifyGetElementDefinitionWhenNoElementUsages()
        {
            this.nestedElement.ElementUsage.Clear();
            this.nestedElement.IsRootElement = true;
            Assert.IsTrue(ReferenceEquals(this.rootElementDef, this.nestedElement.GetElementDefinition()));
        }

        [Test]
        public void VerifyGetElementUsage()
        {
            Assert.IsTrue(ReferenceEquals(this.elementUsage2, this.nestedElement.GetElementUsage()));
        }

        [Test]
        public void VerifyGetElementUsageWhenNoElementUsages()
        {
            this.nestedElement.ElementUsage.Clear();
            this.nestedElement.IsRootElement = true;
            Assert.IsNull(this.nestedElement.GetElementUsage());
        }

        [Test]
        public void VerifyHasCategory()
        {
            Assert.IsFalse(this.nestedElement.HasCategory(this.category));
        }

        [Test]
        public void VerifyHasCategoryWorksForElementDefinition()
        {
            this.elementDef2.Category.Add(this.category);
            Assert.IsTrue(this.nestedElement.HasCategory(this.category));
        }

        [Test]
        public void VerifyHasCategoryWorksForElementUsage()
        {
            this.elementUsage2.Category.Add(this.category);
            Assert.IsTrue(this.nestedElement.HasCategory(this.category));
        }

        [Test]
        public void VerifyHasCategoryWorksForRootElementElementDefinition()
        {
            this.nestedElement.ElementUsage.Clear();
            this.nestedElement.IsRootElement = true;
            this.rootElementDef.Category.Add(this.category);
            Assert.IsTrue(this.nestedElement.HasCategory(this.category));
        }

        [Test]
        public void VerifyGetChildrenWorks()
        {
            var nestedElementTreeGenerator = new NestedElementTreeGenerator();
            var nestedElements = nestedElementTreeGenerator.Generate(this.option, this.domain).ToList();
            Assert.AreEqual(3, nestedElements.Count);

            var children = nestedElements.First(x => x.IsRootElement).GetChildren(nestedElements).ToList();
            Assert.AreEqual(1, children.Count);
            Assert.AreEqual(this.elementUsage1.Name, children.First().Name);

            var children2 = children.First().GetChildren(nestedElements).ToList();
            Assert.AreEqual(1, children2.Count);
            Assert.AreEqual(this.elementUsage2.Name, children2.First().Name);
        }
    }
}
