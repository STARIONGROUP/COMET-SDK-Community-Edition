// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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

namespace CDP4Common.Tests.DTO
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using NUnit.Framework;

    using Thing = CDP4Common.CommonData.Thing;

    /// <summary>
    /// Test fixture for the <see cref="CDP4Common.DTO.Thing"/> class
    /// </summary>
    [TestFixture]
    public class ThingTestFixture
    {
        [Test]
        public void VerifyThatContainersCanBeAddedAndTheRouteIsGenerated()
        {
            BooleanParameterType booleanParameterType;
            var expectedRoute = string.Empty;
            var computedRoute = string.Empty;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();
            var siteDirectoryId = Guid.NewGuid();

            var modelReferenceDataLibraryId = Guid.NewGuid();
            var engineeringModelSetupId = Guid.NewGuid();

            // test that it works for a parameter type contained in SiteReferenceDataLibrary
            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            expectedRoute = $"/SiteDirectory/{siteDirectoryId}/siteReferenceDataLibrary/{siteReferenceDataLibraryId}/parameterType/{booleanParameterTypeId}";
            computedRoute = booleanParameterType.Route;

            Assert.That(computedRoute, Is.EqualTo(expectedRoute));
            
            // test that it works for a parameter type contained in ModelReferenceDataLibrary
            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.ModelReferenceDataLibrary, modelReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.EngineeringModelSetup, engineeringModelSetupId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            expectedRoute = $"/SiteDirectory/{siteDirectoryId}/model/{engineeringModelSetupId}/requiredRdl/{modelReferenceDataLibraryId}/parameterType/{booleanParameterTypeId}";
            computedRoute = booleanParameterType.Route;
            Assert.That(computedRoute, Is.EqualTo(expectedRoute));
        }

        [Test]
        public void VerifyThatContainersCantBeAddedAfterSiteDirectory()
        {
            BooleanParameterType booleanParameterType;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();
            var siteDirectoryId = Guid.NewGuid();

            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            Assert.That(() => booleanParameterType.AddContainer(ClassKind.EngineeringModel, Guid.NewGuid()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatContainersCantBeAddedAfterEngineeringModel()
        {
            ElementDefinition elementDefinition;

            var elementDefinitionId = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            var engineeringModelId = Guid.NewGuid();

            elementDefinition = new ElementDefinition(elementDefinitionId, 1);
            elementDefinition.AddContainer(ClassKind.Iteration, iterationId);
            elementDefinition.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.That(() => elementDefinition.AddContainer(ClassKind.Person, Guid.NewGuid()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatContainmentCanBeResolved()
        {
            ElementDefinition elementDefinition;
            ElementDefinition elementDefinition2;
            Iteration iteration;

            var elementDefinitionId = Guid.NewGuid();
            var elementDefinitionId2 = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            
            elementDefinition = new ElementDefinition(elementDefinitionId, 1);
            elementDefinition2 = new ElementDefinition(elementDefinitionId2, 1);
            iteration = new Iteration(iterationId,1);
            iteration.Element.Add(elementDefinitionId);
            
            Assert.That(iteration.Contains(elementDefinition), Is.True);
            Assert.That(iteration.Contains(elementDefinition2), Is.False);
            
            // check ordered items
            var state1 = new PossibleFiniteState(Guid.NewGuid(), 1);
            var state2 = new PossibleFiniteState(Guid.NewGuid(), 1);
            var state3 = new PossibleFiniteState(Guid.NewGuid(), 1);

            var list = new PossibleFiniteStateList(Guid.NewGuid(), 1);
            list.PossibleState.Add(new OrderedItem { K = 1, V = state1.Iid });
            list.PossibleState.Add(new OrderedItem { K = 100, V = state2.Iid });

            Assert.That(list.Contains(state1), Is.True);
            Assert.That(list.Contains(state2), Is.True);
            Assert.That(list.Contains(state3), Is.False);
        }

        [Test]
        public void VerifyThatTopContainerRouteIsCorrect()
        {
            // iteration thing
            ElementDefinition elementDefinition;

            var elementDefinitionId = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            var engineeringModelId = Guid.NewGuid();

            elementDefinition = new ElementDefinition(elementDefinitionId, 1);
            elementDefinition.AddContainer(ClassKind.Iteration, iterationId);
            elementDefinition.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.That(elementDefinition.GetTopContainerRoute(), Is.EqualTo($"/EngineeringModel/{engineeringModelId}/iteration/{iterationId}"));

            // engineering model thing
            Book book;
            Section section;

            book = new Book(Guid.NewGuid(), 1);
            book.AddContainer(ClassKind.EngineeringModel, engineeringModelId);
            section = new Section(Guid.NewGuid(), 1);
            section.AddContainer(ClassKind.Book, book.Iid);
            section.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.That(book.GetTopContainerRoute(), Is.EqualTo($"/EngineeringModel/{engineeringModelId}"));
            Assert.That(section.GetTopContainerRoute(), Is.EqualTo($"/EngineeringModel/{engineeringModelId}"));
            
            EngineeringModel enModel;
            enModel = new EngineeringModel(Guid.NewGuid(), 1);

            Assert.That(enModel.GetTopContainerRoute(), Is.EqualTo($"/EngineeringModel/{enModel.Iid}"));
            
            // site directory thing
            BooleanParameterType booleanParameterType;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();
            var siteDirectoryId = Guid.NewGuid();
            var siteDirectory = new SiteDirectory(siteDirectoryId, 1);

            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            Assert.That(booleanParameterType.GetTopContainerRoute(), Is.EqualTo($"/SiteDirectory/{siteDirectoryId}"));
            Assert.That(siteDirectory.GetTopContainerRoute(), Is.EqualTo($"/SiteDirectory/{siteDirectoryId}"));
        }

        [Test]
        public void VerifyThatWrongContainerCantBeAdded()
        {
            BooleanParameterType booleanParameterType;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();

            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);

            Assert.That(() => booleanParameterType.AddContainer(ClassKind.Person, Guid.NewGuid()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyClassKindIsCorrect()
        {
            var alias = new CDP4Common.CommonData.Alias() as CDP4Common.CommonData.Thing;
            Assert.That(alias.ClassKind, Is.EqualTo(ClassKind.Alias));

            var aliasdto = new CDP4Common.DTO.Alias() as CDP4Common.DTO.Thing;
            Assert.That(aliasdto.ClassKind, Is.EqualTo(ClassKind.Alias));
        }

        [Test]
        public void VerifyThatExceptionIsRaisedWhenNoClassKindExistsForDTO()
        {
            var thing = new TestDto();
            
            Assert.That(() => { Console.WriteLine(thing.Route); }, Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void VerifyThatDeepCloneWorksWithParameterValueSet()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), 0);
            var manual = new List<string> {"a", "b", "c"};
            valueset.Manual = new ValueArray<string>(manual);

            var clone = valueset.DeepClone<ParameterValueSet>();
            Assert.That(clone.Iid, Is.EqualTo(valueset.Iid));
            
            clone.Manual = new ValueArray<string>();
            Assert.That(valueset.Manual.Count, Is.EqualTo(3));
            Assert.That(clone.Manual.Count, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatDeepCloneWorksWithActualFiniteStateList()
        {
            var actualList = new ActualFiniteStateList(Guid.NewGuid(), 0);
            var item = new OrderedItem {K = 1, V = Guid.NewGuid()};
            actualList.PossibleFiniteStateList.Add(item);
            actualList.ActualState.Add(Guid.NewGuid());

            var clone = actualList.DeepClone<ActualFiniteStateList>();
            Assert.That(clone.PossibleFiniteStateList.Count, Is.EqualTo(1));
            Assert.That(clone.ActualState.Count, Is.EqualTo(1));
            
            clone.ActualState.Add(Guid.NewGuid());
            Assert.That(actualList.ActualState.Count, Is.EqualTo(1));

            var ordereditem = clone.PossibleFiniteStateList.Single();
            Assert.That(ordereditem.K, Is.EqualTo(1));
            Assert.That(ordereditem.V, Is.EqualTo(item.V));
        }

        [Test]
        public void VerifyThatResolveCopyWorksWithOrderedItem()
        {
            var pfsl = new PossibleFiniteStateList(Guid.NewGuid(), 1)
            {
                Name = "test",
                ShortName = "test",
                Owner = Guid.NewGuid()
            };

            pfsl.Category.Add(Guid.NewGuid());

            var ps1 = new PossibleFiniteState(Guid.NewGuid(), 1)
            {
                Name = "ps1",
                ShortName = "ps1"
            };

            var ps2 = new PossibleFiniteState(Guid.NewGuid(), 1)
            {
                Name = "ps2",
                ShortName = "ps2"
            };

            pfsl.PossibleState.Add(new OrderedItem { K = 0, V = ps1.Iid });
            pfsl.PossibleState.Add(new OrderedItem { K = 2, V = ps2.Iid });

            var copypfsl = new PossibleFiniteStateList(Guid.NewGuid(), 1);
            var copyps1 = new PossibleFiniteState(Guid.NewGuid(), 1);
            var copyps2 = new PossibleFiniteState(Guid.NewGuid(), 1);

            var dictionary = new Dictionary<CDP4Common.DTO.Thing, CDP4Common.DTO.Thing>();
            dictionary.Add(pfsl, copypfsl);
            dictionary.Add(ps1, copyps1);
            dictionary.Add(ps2, copyps2);

            copypfsl.ResolveCopy(pfsl, dictionary);
            copyps1.ResolveCopy(ps1, dictionary);
            copyps2.ResolveCopy(ps2, dictionary);
            
            Assert.That(copypfsl.PossibleState.Any(ps => ps.V.ToString() == copyps1.Iid.ToString()), Is.True);
            Assert.That(copypfsl.PossibleState.Any(ps => ps.V.ToString() == copyps2.Iid.ToString()), Is.True);

            Assert.That(copypfsl.Name, Is.EqualTo(pfsl.Name));
            Assert.That(copypfsl.Owner, Is.EqualTo(pfsl.Owner));

            Assert.That(copypfsl.Category.Contains(pfsl.Category.Single()), Is.True);
        }

        [Test]
        public void VerifyThatResolveCopyWorksWithValueArray()
        {
            var parameter = new Parameter(Guid.NewGuid(), 1)
            {
                Owner = Guid.NewGuid(),
            };

            var vs1 = new ParameterValueSet(Guid.NewGuid(), 1)
            {
                Manual = new ValueArray<string>(new [] { "-" })
            };

            var vs2 = new ParameterValueSet(Guid.NewGuid(), 1)
            {
                Computed = new ValueArray<string>(new[] { "-" })
            }; 

            parameter.ValueSet.Add(vs1.Iid);
            parameter.ValueSet.Add(vs2.Iid);

            var copyparam = new Parameter(Guid.NewGuid(), 1);
            var copyvs1 = new ParameterValueSet(Guid.NewGuid(), 1);
            var copyvs2 = new ParameterValueSet(Guid.NewGuid(), 1);

            var dictionary = new Dictionary<CDP4Common.DTO.Thing, CDP4Common.DTO.Thing>();
            dictionary.Add(parameter, copyparam);
            dictionary.Add(vs1, copyvs1);
            dictionary.Add(vs2, copyvs2);

            copyparam.ResolveCopy(parameter, dictionary);
            copyvs1.ResolveCopy(vs1, dictionary);
            copyvs2.ResolveCopy(vs2, dictionary);

            Assert.That(copyparam.ValueSet.Contains(copyvs1.Iid), Is.True);
            Assert.That(copyparam.ValueSet.Contains(copyvs2.Iid), Is.True);
            Assert.That(copyvs1.Manual.Count, Is.AtLeast(1));
            Assert.That(copyvs2.Computed.Count, Is.AtLeast(1));
        }

        [Test]
        public void VerifyThatResolveCopyReferenceWorks()
        {
            var parameter = new Parameter(Guid.NewGuid(), 1)
            {
                Owner = Guid.NewGuid(),
                ParameterType = Guid.NewGuid()
            };

            var pt1 = new BooleanParameterType(parameter.ParameterType, 0);
            var pt2 = new BooleanParameterType(Guid.NewGuid(), 0);

            var originalToCopy = new Dictionary<CDP4Common.DTO.Thing, CDP4Common.DTO.Thing>();
            originalToCopy.Add(pt1, pt2);

            parameter.ResolveCopyReference(originalToCopy);
            Assert.That(pt2.Iid, Is.EqualTo(parameter.ParameterType));
        }

        /// <summary>
        /// Test Thing class
        /// </summary>
        private class TestDto : CDP4Common.DTO.Thing
        {
            protected override ClassKind ComputeCurrentClassKind()
            {
                return ClassKind.Thing;
            }

            public override void ResolveCopy(CDP4Common.DTO.Thing originalThing, IReadOnlyDictionary<CDP4Common.DTO.Thing, CDP4Common.DTO.Thing> originalCopyMap)
            {
                throw new NotImplementedException();
            }

            public override Thing InstantiatePoco(ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache, Uri uri)
            {
                throw new NotImplementedException();
            }

            public override bool ResolveCopyReference(IReadOnlyDictionary<CDP4Common.DTO.Thing, CDP4Common.DTO.Thing> originalCopyMap)
            {
                throw new NotImplementedException();
            }
        }
    }
}
