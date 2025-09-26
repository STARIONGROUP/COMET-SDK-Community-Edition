﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Concurrent;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.Exceptions;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class ElementDefinitionTestFixture
    {
        private Guid iterationIid;
        private Iteration iteration;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        private Uri uri;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.stariongroup.eu");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            this.iterationIid = Guid.NewGuid();
            this.iteration = new Iteration(this.iterationIid, this.cache, this.uri);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.iterationIid, null), new Lazy<Thing>(() => this.iteration));
        }

        [Test]
        public void VerifyThatContainedGroupsReturnsGroupsThatAreContained()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);
            var parameterGroup_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_2);

            var parameterGroup_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1);
            parameterGroup_1_1.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_2);
            parameterGroup_1_2.ContainingGroup = parameterGroup_1;

            Assert.That(elementDefinition.ContainedGroup(), Does.Contain(parameterGroup_1));
            Assert.That(elementDefinition.ContainedGroup(), Does.Contain(parameterGroup_2));
        }

        [Test]
        public void VerifyThatParameterGroupReturnsContainedParameters()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);

            var parameter_0 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_0);

            var parameter_1_1 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_1_1);
            parameter_1_1.Group = parameterGroup_1;

            var parameter_1_2 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_1_2);
            parameter_1_2.Group = parameterGroup_1;

            Assert.That(elementDefinition.ContainedParameter(),Does.Not.Contain(parameter_1_1));
            Assert.That(elementDefinition.ContainedParameter(), Does.Not.Contain(parameter_1_2));
            Assert.That(elementDefinition.ContainedParameter(), Does.Contain(parameter_0));
        }

        [Test]
        public void VerifyThatHasUsageOfWorks()
        {
            var def1 = new ElementDefinition();
            var def11 = new ElementDefinition();
            var def12 = new ElementDefinition();
            var def111 = new ElementDefinition();
            var def1111 = new ElementDefinition();
            var def121 = new ElementDefinition();

            def1.ContainedElement.Add(new ElementUsage { ElementDefinition = def11 });
            def1.ContainedElement.Add(new ElementUsage { ElementDefinition = def12 });

            def11.ContainedElement.Add(new ElementUsage { ElementDefinition = def111 });
            def111.ContainedElement.Add(new ElementUsage { ElementDefinition = def1111 });

            def12.ContainedElement.Add(new ElementUsage { ElementDefinition = def121 });

            Assert.That(def1.HasUsageOf(def1), Is.True);
            Assert.That(def1.HasUsageOf(def11), Is.True);
            Assert.That(def1.HasUsageOf(def111), Is.True);
            Assert.That(def1.HasUsageOf(def1111), Is.True);
            Assert.That(def1.HasUsageOf(def12), Is.True);
            Assert.That(def1.HasUsageOf(def121), Is.True);

            Assert.That(def11.HasUsageOf(def11), Is.True);
            Assert.That(def11.HasUsageOf(def111), Is.True);
            Assert.That(def11.HasUsageOf(def1111), Is.True);
            Assert.That(def11.HasUsageOf(def1), Is.False);
            Assert.That(def11.HasUsageOf(def12), Is.False);
            Assert.That(def11.HasUsageOf(def121), Is.False);
        }

        [Test]
        public void VerifyThatHasUsageOfThrowsException()
        {
            var def1 = new ElementDefinition();
            Assert.That(() => def1.HasUsageOf(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResult()
        {
            var elementDefinition = new ElementDefinition();
            var shortname = "Bat";

            elementDefinition.ShortName = shortname;

            Assert.That(elementDefinition.ModelCode(), Is.EqualTo(shortname));
        }

        [Test]
        public void VerifyThatModelCodeThrowsExceptionWhenComponentIndexNotZero()
        {
            var elementDefinition = new ElementDefinition();

            Assert.That(() => elementDefinition.ModelCode(1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void VerifyThatGetRequiredRdlsWorks()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var cat1 = new Category(Guid.NewGuid(), null, null);
            var cat2 = new Category(Guid.NewGuid(), null, null);

            mrdl.RequiredRdl = srdl1;
            srdl2.RequiredRdl = srdl1;

            mrdl.DefinedCategory.Add(cat1);
            srdl1.DefinedCategory.Add(cat2);

            var def = new ElementDefinition(Guid.NewGuid(), null, null);
            def.Category.Add(cat1);
            def.Category.Add(cat2);

            Assert.That(def.RequiredRdls.Count(), Is.EqualTo(2));
            Assert.That(def.RequiredRdls.Contains(srdl1), Is.True);
            Assert.That(def.RequiredRdls.Contains(mrdl), Is.True);
            Assert.That(def.RequiredRdls.Contains(srdl2), Is.False);
        }

        [Test]
        public void VerifyThatReferencedByUsagesReturnsTheExpectedResult()
        {
            var def1 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Element.Add(def1);
            
            var def2 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Element.Add(def2);
            
            var usage1_1 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = def1
            };
            
            var usage1_2 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = def1
            };
            
            var usage2_1 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = def2
            };
            
            var usage2_2 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = def2
            };
            
            def1.ContainedElement.Add(usage2_1);
            def1.ContainedElement.Add(usage2_2);

            def2.ContainedElement.Add(usage1_1);
            def2.ContainedElement.Add(usage1_2);
            
            Assert.That(def1.ReferencingElementUsages().Count(), Is.EqualTo(2));
            Assert.That(def1.ReferencingElementUsages().ToList(), Does.Contain(usage1_1));
            Assert.That(def1.ReferencingElementUsages().ToList(), Does.Contain(usage1_2));
        }

        [Test]
        public void VerifyThatContainmentExceptionIsThrownWhenElementDefinitionIsNotContainedByIteration()
        {
            var def1 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            Assert.That(() => def1.ReferencingElementUsages(), Throws.TypeOf<ContainmentException>());
        }

        [Test]
        public void Verify_that_QueryReferencedThings_and_QueryReferencedThingsDeep()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            var superCategory = new Category(Guid.NewGuid(), null, null);
            var category = new Category(Guid.NewGuid(), null, null);
            category.SuperCategory.Add(superCategory);

            elementDefinition.Category.Add(category);

            var referencedThings = elementDefinition.QueryReferencedThings();

            Assert.That(referencedThings, Does.Contain(category));
            Assert.That(referencedThings, Does.Not.Contain(superCategory));

            var referencedThingsDeep = elementDefinition.QueryReferencedThingsDeep();

            Assert.That(referencedThingsDeep, Does.Contain(category));
            Assert.That(referencedThingsDeep, Does.Contain(superCategory));
        }
    }
}
