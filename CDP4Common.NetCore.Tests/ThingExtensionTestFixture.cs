// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingExtensionTestFixture.cs" company="RHEA System S.A.">
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

            Assert.IsNotNull(aliasDto);
            Assert.AreEqual(this.alias.Iid, aliasDto.Iid);
            Assert.AreEqual(this.alias.IsSynonym, aliasDto.IsSynonym);
            Assert.AreEqual(this.alias.Content, aliasDto.Content);
            Assert.AreEqual(this.alias.LanguageCode, aliasDto.LanguageCode);
            Assert.AreEqual(this.alias.Route, aliasDto.Route);

            Assert.AreEqual(this.alias, aliasDto.QuerySourceThing());
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

            Assert.IsNotNull(dto);
            Assert.AreEqual(2, dto.HyperLink.Count);
            Assert.AreEqual(dateParameterType.HyperLink[1].Iid, dto.HyperLink[1]);
            Assert.AreEqual(dateParameterType.HyperLink[0].Iid, dto.HyperLink[0]);
            Assert.AreEqual(dateParameterType.Route, dto.Route);

            Assert.AreEqual(dateParameterType, dto.QuerySourceThing());
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

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Organization, organization.Iid);
            Assert.AreEqual(person.Route, dto.Route);

            Assert.AreEqual(person, dto.QuerySourceThing());
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

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Component.First().K, compoundParameterType.Component.SortedItems.Keys.First());
            Assert.AreEqual(dto.Component.First().V, compoundParameterType.Component.SortedItems.Values.First().Iid);

            Assert.AreEqual(dto.Component.Last().K, compoundParameterType.Component.SortedItems.Keys.Last());
            Assert.AreEqual(dto.Component.Last().V, compoundParameterType.Component.SortedItems.Values.Last().Iid);

            Assert.AreEqual(compoundParameterType.Route, dto.Route);

            Assert.AreEqual(compoundParameterType, dto.QuerySourceThing());
        }

        [Test]
        public void VerifyToDtoMethodWithValueArrayType()
        {
            var constant = new Constant(Guid.NewGuid(), null, new Uri("http://test.be"));

            var valuestrings = new List<string>() { "test1", "test2" };
            constant.Value = new ValueArray<string>(valuestrings);

            constant.Container = this.siteDir;

            var dto = constant.ToDto() as CDP4Common.DTO.Constant;
            Assert.AreEqual(2, dto.Value.Count);
        }

        [Test]
        public void VerifyNullableToNullable()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);
            
            var modelSetup = new EngineeringModelSetup(Guid.NewGuid(), null, null);
            modelSetup.SourceEngineeringModelSetupIid = Guid.NewGuid();
            siteDirectory.Model.Add(modelSetup);

            var dto = modelSetup.ToDto() as CDP4Common.DTO.EngineeringModelSetup;
            Assert.AreEqual(modelSetup.SourceEngineeringModelSetupIid, dto.SourceEngineeringModelSetupIid);

            Assert.AreEqual(modelSetup, dto.QuerySourceThing());
        }

        [Test]
        public void VerifyThingToNullableGuid()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);
            var role = new PersonRole(Guid.NewGuid(), null, null);
            
            siteDirectory.PersonRole.Add(role);
            siteDirectory.DefaultPersonRole = role;

            var dto = siteDirectory.ToDto() as CDP4Common.DTO.SiteDirectory;

            Assert.IsTrue(dto.DefaultPersonRole.HasValue);
            Assert.AreEqual(role.Iid, dto.DefaultPersonRole.Value);

            Assert.AreEqual(siteDirectory, dto.QuerySourceThing());
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

            Assert.IsNull(iterationDto.IterationContainerId);
            Assert.AreEqual(iteratio.Iid, defDto.IterationContainerId);
        }
    }
}