#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;
    using System.Collections.Concurrent;
    using CDP4Common.CommonData;
    using CDP4Common.Exceptions;

    [TestFixture]
    public class ElementDefinitionTestFixture
    {
        private Guid iterationIid;
        private Iteration iteration;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;
        private Uri uri;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.iterationIid = Guid.NewGuid();
            this.iteration = new Iteration(this.iterationIid, this.cache, this.uri);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.iterationIid, null), new Lazy<Thing>(() => this.iteration));
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

            CollectionAssert.Contains(elementDefinition.ContainedGroup(), parameterGroup_1);
            CollectionAssert.Contains(elementDefinition.ContainedGroup(), parameterGroup_2);
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

            CollectionAssert.DoesNotContain(elementDefinition.ContainedParameter(), parameter_1_1);
            CollectionAssert.DoesNotContain(elementDefinition.ContainedParameter(), parameter_1_2);
            CollectionAssert.Contains(elementDefinition.ContainedParameter(), parameter_0);
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

            Assert.IsTrue(def1.HasUsageOf(def1));
            Assert.IsTrue(def1.HasUsageOf(def11));
            Assert.IsTrue(def1.HasUsageOf(def111));
            Assert.IsTrue(def1.HasUsageOf(def1111));
            Assert.IsTrue(def1.HasUsageOf(def12));
            Assert.IsTrue(def1.HasUsageOf(def121));

            Assert.IsTrue(def11.HasUsageOf(def11));
            Assert.IsTrue(def11.HasUsageOf(def111));
            Assert.IsTrue(def11.HasUsageOf(def1111));
            Assert.IsFalse(def11.HasUsageOf(def1));
            Assert.IsFalse(def11.HasUsageOf(def12));
            Assert.IsFalse(def11.HasUsageOf(def121));
        }

        [Test]
        public void VerifyThatHasUsageOfThrowsException()
        {
            var def1 = new ElementDefinition();
            Assert.Throws<ArgumentNullException>(() => def1.HasUsageOf(null));
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResult()
        {
            var elementDefinition = new ElementDefinition();
            var shortname = "Bat";

            elementDefinition.ShortName = shortname;

            Assert.AreEqual(shortname, elementDefinition.ModelCode());
        }

        [Test]
        public void VerifyThatModelCodeThrowsExceptionWhenComponentIndexNotZero()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => elementDefinition.ModelCode(1));
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

            Assert.AreEqual(2, def.RequiredRdls.Count());
            Assert.IsTrue(def.RequiredRdls.Contains(srdl1));
            Assert.IsTrue(def.RequiredRdls.Contains(mrdl));
            Assert.IsFalse(def.RequiredRdls.Contains(srdl2));
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
            
            Assert.AreEqual(2, def1.ReferencingElementUsages().Count());
            Assert.Contains(usage1_1, def1.ReferencingElementUsages().ToList());
            Assert.Contains(usage1_2, def1.ReferencingElementUsages().ToList());
        }

        [Test]
        public void VerifyThatContainmentExceptionIsThrownWhenElementDefinitionIsNotContainedByIteration()
        {
            var def1 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            Assert.Throws<ContainmentException>(() => def1.ReferencingElementUsages());
        }
    }
}
