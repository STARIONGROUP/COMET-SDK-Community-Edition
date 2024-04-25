// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizedCategoryRuleTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests.RuleVerification
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterizedCategoryRuleTestFixture
    {
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

        private SiteDirectory sitedir;
        private EngineeringModelSetup modelsetup;
        private IterationSetup iterationsetup;
        private SiteReferenceDataLibrary srdl;
        private ModelReferenceDataLibrary mrdl;

        private ParameterType parameterType;
        private Category category;

        private ParameterizedCategoryRule rule;

        private EngineeringModel model;
        private Iteration iteration;
        private BinaryRelationship relation1;
        private BinaryRelationship relation2;
        private RequirementsSpecification spec1;
        private RequirementsSpecification spec2;

        private Requirement req1;
        private Requirement req2;

        private RequirementsGroup gr1;
        private RequirementsGroup gr2;

        private ElementDefinition def1;
        private ElementDefinition def2;

        [SetUp]
        public void Setup()
        {
            this.sitedir = new SiteDirectory(Guid.NewGuid(), this.cache, null);
            this.modelsetup = new EngineeringModelSetup(Guid.NewGuid(), this.cache, null);
            this.iterationsetup = new IterationSetup(Guid.NewGuid(), this.cache, null);
            this.srdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, null);
            this.mrdl = new ModelReferenceDataLibrary(Guid.NewGuid(), this.cache, null) {RequiredRdl = this.srdl};
            this.parameterType = new BooleanParameterType(Guid.NewGuid(), this.cache, null) {Name = "boolean", ShortName = "bool"};
            this.category = new Category(Guid.NewGuid(), this.cache, null) {Name = "cat", ShortName = "cat", };
            this.rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, null) {Category = this.category, ShortName = "rule", Name = "rule"};
            this.rule.ParameterType.Add(this.parameterType);

            this.sitedir.Model.Add(this.modelsetup);
            this.sitedir.SiteReferenceDataLibrary.Add(this.srdl);
            this.modelsetup.IterationSetup.Add(this.iterationsetup);
            this.modelsetup.RequiredRdl.Add(this.mrdl);

            this.srdl.ParameterType.Add(this.parameterType);
            this.srdl.DefinedCategory.Add(this.category);
            this.srdl.Rule.Add(this.rule);

            this.model = new EngineeringModel(Guid.NewGuid(), this.cache, null) {EngineeringModelSetup = this.modelsetup};
            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null) {IterationSetup = this.iterationsetup};

            this.relation1 = new BinaryRelationship(Guid.NewGuid(), this.cache, null);
            this.relation2 = new BinaryRelationship(Guid.NewGuid(), this.cache, null);
            this.spec1 = new RequirementsSpecification(Guid.NewGuid(), this.cache, null) { Name = "spec1", ShortName = "spec1" };
            this.spec2 = new RequirementsSpecification(Guid.NewGuid(), this.cache, null) { Name = "spec2", ShortName = "spec2" };

            this.gr1 = new RequirementsGroup(Guid.NewGuid(), this.cache, null) { Name = "gr1", ShortName = "gr1" };
            this.gr2 = new RequirementsGroup(Guid.NewGuid(), this.cache, null) { Name = "gr2", ShortName = "gr2" };

            this.req1 = new Requirement(Guid.NewGuid(), this.cache, null) { Name = "r1", ShortName = "r1" };
            this.req2 = new Requirement(Guid.NewGuid(), this.cache, null) { Name = "r2", ShortName = "r2" };

            this.def1 = new ElementDefinition(Guid.NewGuid(), this.cache, null) { Name = "d1", ShortName = "d1" };
            this.def2 = new ElementDefinition(Guid.NewGuid(), this.cache, null) { Name = "d2", ShortName = "d2" };

            this.model.Iteration.Add(this.iteration);
            this.iteration.Relationship.Add(this.relation1);
            this.iteration.Relationship.Add(this.relation2);
            this.iteration.RequirementsSpecification.Add(this.spec1);
            this.iteration.RequirementsSpecification.Add(this.spec2);

            this.spec1.Group.Add(this.gr1);
            this.spec1.Group.Add(this.gr2);
            this.spec1.Requirement.Add(this.req1);
            this.spec1.Requirement.Add(this.req2);

            this.iteration.Element.Add(this.def1);
            this.iteration.Element.Add(this.def2);

            this.relation1.Category.Add(this.category);
            this.relation2.Category.Add(this.category);
            this.spec1.Category.Add(this.category);
            this.spec2.Category.Add(this.category);
            this.req1.Category.Add(this.category);
            this.req2.Category.Add(this.category);
            this.gr1.Category.Add(this.category);
            this.gr2.Category.Add(this.category);
            this.def1.Category.Add(this.category);
            this.def2.Category.Add(this.category);

            this.relation1.ParameterValue.Add(new RelationshipParameterValue(Guid.NewGuid(), this.cache, null) {ParameterType = this.parameterType});
            this.spec1.ParameterValue.Add(new RequirementsContainerParameterValue(Guid.NewGuid(), this.cache, null) {ParameterType = this.parameterType});
            this.req1.ParameterValue.Add(new SimpleParameterValue(Guid.NewGuid(), this.cache, null) {ParameterType = this.parameterType});
            this.def1.Parameter.Add(new Parameter(Guid.NewGuid(), this.cache, null) {ParameterType = this.parameterType});
            this.gr1.ParameterValue.Add(new RequirementsContainerParameterValue(Guid.NewGuid(), this.cache, null) {ParameterType = this.parameterType});
        }

        [Test]
        public void VerifythatRuleVerificationWorks()
        {
            var violations = this.rule.Verify(this.iteration).ToList();
            Assert.That(violations.Count, Is.EqualTo(5));
            Assert.That(violations.Count(x => x.ViolatingThing.Contains(this.def2.Iid)), Is.EqualTo(1));
            Assert.That(violations.Count(x => x.ViolatingThing.Contains(this.relation2.Iid)), Is.EqualTo(1));
            Assert.That(violations.Count(x => x.ViolatingThing.Contains(this.spec2.Iid)), Is.EqualTo(1));
            Assert.That(violations.Count(x => x.ViolatingThing.Contains(this.gr2.Iid)), Is.EqualTo(1));
            Assert.That(violations.Count(x => x.ViolatingThing.Contains(this.req2.Iid)), Is.EqualTo(1));
        }
    }
}