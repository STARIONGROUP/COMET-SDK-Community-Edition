// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingExtensionTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the ToDto method
    /// </summary>
    [TestFixture]
    public class ThingExtensionTestFixture
    {
        private Alias alias;
        private SiteDirectory siteDir;
        private DefinedThing definedThing;
        private SiteReferenceDataLibrary srdl;

        [SetUp]
        public void SetUp()
        {
            this.siteDir = new SiteDirectory(Guid.NewGuid(), null, null);
            this.definedThing = new DomainOfExpertise(Guid.NewGuid(), null, null);
            this.definedThing.Container = this.siteDir;
            this.alias = new Alias { Iid = Guid.NewGuid(), IsSynonym = true, Content = "test", LanguageCode = "test2" };
            this.alias.Container = this.definedThing;

            this.srdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            this.srdl.Container = this.siteDir;
        }

        /// <summary>
        /// the objective of this test is to verify the method with ValueType properties
        /// </summary>
        [Test]
        public void VerifyToDtoMethodWithValueType()
        {
            var aliasDto = this.alias.ToDto() as CDP4Common.DTO.Alias;

            Assert.That(aliasDto, Is.Not.Null);
            Assert.That(aliasDto.Iid, Is.EqualTo(this.alias.Iid));
            Assert.That(aliasDto.IsSynonym, Is.EqualTo(this.alias.IsSynonym));
            Assert.That(aliasDto.Content, Is.EqualTo(this.alias.Content));
            Assert.That(aliasDto.LanguageCode, Is.EqualTo(this.alias.LanguageCode));
            Assert.That(aliasDto.Route, Is.EqualTo(this.alias.Route));

            Assert.That(aliasDto.QuerySourceThing(), Is.EqualTo(this.alias));
        }

        /// <summary>
        /// Objective : Test with a List{Thing}
        /// </summary>
        [Test]        
        public void VerifyToDtoMethodWithListThing()
        {
            var dateParameterType = new DateParameterType { Iid = new Guid() };
            dateParameterType.Container = this.srdl;

            var hyperlink = new HyperLink(Guid.NewGuid(), null, null);
            var hyperlink2 = new HyperLink(Guid.NewGuid(), null, null);

            dateParameterType.HyperLink.Add(hyperlink);
            dateParameterType.HyperLink.Add(hyperlink2);

            var dto = dateParameterType.ToDto() as CDP4Common.DTO.DateParameterType;

            Assert.That(dto, Is.Not.Null);
            Assert.That(dto.HyperLink.Count, Is.EqualTo(2));
            Assert.That(dto.HyperLink[1], Is.EqualTo(dateParameterType.HyperLink[1].Iid));
            Assert.That(dto.HyperLink[0], Is.EqualTo(dateParameterType.HyperLink[0].Iid));
            Assert.That(dto.Route, Is.EqualTo(dateParameterType.Route));

            Assert.That(dto.QuerySourceThing(), Is.EqualTo(dateParameterType));
        }

        /// <summary>
        /// Objective: test with a single Thing
        /// </summary>
        [Test]        
        public void VerifyToDtoMethodWithSingleThing()
        {
            var person = new Person() { Iid = Guid.NewGuid() };
            var organization = new Organization(Guid.NewGuid(), null, null);
            person.Organization = organization;
            person.Container = this.siteDir;

            var dto = person.ToDto() as CDP4Common.DTO.Person;

            Assert.That(dto, Is.Not.Null);
            Assert.That(organization.Iid, Is.EqualTo(dto.Organization));
            Assert.That(dto.Route, Is.EqualTo(person.Route));

            Assert.That(dto.QuerySourceThing(), Is.EqualTo(person));
        }

        /// <summary>
        /// Objective: test with a orderedItem
        /// </summary>
        [Test]
        public void VerifyToDtoMethodWithOrderedItem()
        {
            var compoundParameterType = new CompoundParameterType {Iid = Guid.NewGuid(), Container = this.srdl};
            compoundParameterType.Component.Add(new ParameterTypeComponent(Guid.NewGuid(), null, null) { ShortName = "test1" });
            compoundParameterType.Component.Add(new ParameterTypeComponent(Guid.NewGuid(), null, null) { ShortName = "test2" });

            var dto = compoundParameterType.ToDto() as CDP4Common.DTO.CompoundParameterType;

            Assert.That(dto, Is.Not.Null);
            Assert.That(compoundParameterType.Component.SortedItems.Keys.First(), Is.EqualTo(dto.Component.First().K));
            Assert.That(compoundParameterType.Component.SortedItems.Values.First().Iid, Is.EqualTo(dto.Component.First().V));

            Assert.That(compoundParameterType.Component.SortedItems.Keys.Last(), Is.EqualTo(dto.Component.Last().K));
            Assert.That(compoundParameterType.Component.SortedItems.Values.Last().Iid, Is.EqualTo(dto.Component.Last().V));

            Assert.That(dto.Route, Is.EqualTo(compoundParameterType.Route));

            Assert.That(dto.QuerySourceThing(), Is.EqualTo(compoundParameterType));
        }

        [Test]
        public void VerifyToDtoMethodWithValueArrayType()
        {
            var constant = new Constant(Guid.NewGuid(), null, new Uri("http://test.be"));

            var valuestrings = new List<string>() { "test1", "test2" };
            constant.Value = new ValueArray<string>(valuestrings);

            constant.Container = this.siteDir;

            var dto = constant.ToDto() as CDP4Common.DTO.Constant;
            Assert.That(dto.Value.Count, Is.EqualTo(2));
        }

        [Test]
        public void VerifyNullableToNullable()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);
            
            var modelSetup = new EngineeringModelSetup(Guid.NewGuid(), null, null);
            modelSetup.SourceEngineeringModelSetupIid = Guid.NewGuid();
            siteDirectory.Model.Add(modelSetup);

            var dto = modelSetup.ToDto() as CDP4Common.DTO.EngineeringModelSetup;
            Assert.That(dto.SourceEngineeringModelSetupIid, Is.EqualTo(modelSetup.SourceEngineeringModelSetupIid));

            Assert.That(dto.QuerySourceThing(), Is.EqualTo(modelSetup));
        }

        [Test]
        public void VerifyThingToNullableGuid()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);
            var role = new PersonRole(Guid.NewGuid(), null, null);
            
            siteDirectory.PersonRole.Add(role);
            siteDirectory.DefaultPersonRole = role;

            var dto = siteDirectory.ToDto() as CDP4Common.DTO.SiteDirectory;

            Assert.That(dto.DefaultPersonRole.HasValue, Is.True);
            Assert.That(dto.DefaultPersonRole.Value, Is.EqualTo(role.Iid));

            Assert.That(dto.QuerySourceThing(), Is.EqualTo(siteDirectory));
        }

        [Test]
        public void VerifyThatIterationDataToDtoWork()
        {
            var model = new EngineeringModel(Guid.NewGuid(), null, null);
            var iteratio = new Iteration(Guid.NewGuid(), null, null);
            var elementdef = new ElementDefinition(Guid.NewGuid(), null, null);

            model.Iteration.Add(iteratio);
            iteratio.Element.Add(elementdef);

            var iterationDto = iteratio.ToDto();
            var defDto = elementdef.ToDto();

            Assert.That(iterationDto.IterationContainerId, Is.Null);
            Assert.That(defDto.IterationContainerId, Is.EqualTo(iteratio.Iid));
        }
    }
}