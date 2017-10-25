// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTestFixture.cs" company="RHEA Systen S.A.">
//   Copyright (c) 2017 RHEA Systen  S.A.
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
        public void VerifityThatContainersCanBeAddedAndTheRouteIsGenerated()
        {
            BooleanParameterType booleanParameterType;
            string expectedRoute = string.Empty;
            string computedRoute = string.Empty;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();
            var siteDirectoryId = Guid.NewGuid();

            var modelReferenceDataLibraryId = Guid.NewGuid();
            var engineeringModelSetupId = Guid.NewGuid();

            // test that it works for a parameter type contained in SiteReferenceDataLibrary
            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            expectedRoute = string.Format("/SiteDirectory/{0}/siteReferenceDataLibrary/{1}/parameterType/{2}", siteDirectoryId, siteReferenceDataLibraryId, booleanParameterTypeId);
            computedRoute = booleanParameterType.Route;
            Assert.AreEqual(expectedRoute, computedRoute);

            // test that it works for a parameter type contained in ModelReferenceDataLibrary
            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.ModelReferenceDataLibrary, modelReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.EngineeringModelSetup, engineeringModelSetupId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            expectedRoute = string.Format("/SiteDirectory/{0}/model/{1}/requiredRdl/{2}/parameterType/{3}", siteDirectoryId, engineeringModelSetupId, modelReferenceDataLibraryId, booleanParameterTypeId);
            computedRoute = booleanParameterType.Route;
            Assert.AreEqual(expectedRoute, computedRoute);
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

            Assert.Throws<InvalidOperationException>(() => booleanParameterType.AddContainer(ClassKind.EngineeringModel, Guid.NewGuid()));
        }

        [Test]
        public void VerifyThatContainersCantBeAddedAfterEngineeringModel()
        {
            ElementDefinition elementDefenition;

            var elementDefinitionId = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            var engineeringModelId = Guid.NewGuid();

            elementDefenition = new ElementDefinition(elementDefinitionId, 1);
            elementDefenition.AddContainer(ClassKind.Iteration, iterationId);
            elementDefenition.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.Throws<InvalidOperationException>(() => elementDefenition.AddContainer(ClassKind.Person, Guid.NewGuid()));
        }

        [Test]
        public void VerifyThatContainmentCanBeResolved()
        {
            ElementDefinition elementDefenition;
            ElementDefinition elementDefenition2;
            Iteration iteration;

            var elementDefinitionId = Guid.NewGuid();
            var elementDefinitionId2 = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            
            elementDefenition = new ElementDefinition(elementDefinitionId, 1);
            elementDefenition2 = new ElementDefinition(elementDefinitionId2, 1);
            iteration = new Iteration(iterationId,1);
            iteration.Element.Add(elementDefinitionId);
            
            Assert.IsTrue(iteration.Contains(elementDefenition));
            Assert.IsFalse(iteration.Contains(elementDefenition2));

            // check ordered items
            PossibleFiniteState state1 = new PossibleFiniteState(Guid.NewGuid(), 1);
            PossibleFiniteState state2 = new PossibleFiniteState(Guid.NewGuid(), 1);
            PossibleFiniteState state3 = new PossibleFiniteState(Guid.NewGuid(), 1);

            PossibleFiniteStateList list = new PossibleFiniteStateList(Guid.NewGuid(), 1);
            list.PossibleState.Add(new OrderedItem { K = 1, V = state1.Iid });
            list.PossibleState.Add(new OrderedItem { K = 100, V = state2.Iid });

            Assert.IsTrue(list.Contains(state1));
            Assert.IsTrue(list.Contains(state2));
            Assert.IsFalse(list.Contains(state3));
        }

        [Test]
        public void VerifyThatTopContainerRouteIsCorrect()
        {
            // iteration thing
            ElementDefinition elementDefenition;

            var elementDefinitionId = Guid.NewGuid();
            var iterationId = Guid.NewGuid();
            var engineeringModelId = Guid.NewGuid();

            elementDefenition = new ElementDefinition(elementDefinitionId, 1);
            elementDefenition.AddContainer(ClassKind.Iteration, iterationId);
            elementDefenition.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.AreEqual(string.Format("/EngineeringModel/{0}/iteration/{1}", engineeringModelId, iterationId), elementDefenition.GetTopContainerRoute());

            // engineering model thing
            Book book;
            Section section;

            book = new Book(Guid.NewGuid(), 1);
            book.AddContainer(ClassKind.EngineeringModel, engineeringModelId);
            section = new Section(Guid.NewGuid(), 1);
            section.AddContainer(ClassKind.Book, book.Iid);
            section.AddContainer(ClassKind.EngineeringModel, engineeringModelId);

            Assert.AreEqual(string.Format("/EngineeringModel/{0}", engineeringModelId), book.GetTopContainerRoute());
            Assert.AreEqual(string.Format("/EngineeringModel/{0}", engineeringModelId), section.GetTopContainerRoute());


            EngineeringModel enModel;
            enModel = new EngineeringModel(Guid.NewGuid(), 1);

            Assert.AreEqual(string.Format("/EngineeringModel/{0}", enModel.Iid), enModel.GetTopContainerRoute());
            
            // site directory thing
            BooleanParameterType booleanParameterType;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();
            var siteDirectoryId = Guid.NewGuid();
            var siteDirectory = new SiteDirectory(siteDirectoryId, 1);

            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);
            booleanParameterType.AddContainer(ClassKind.SiteDirectory, siteDirectoryId);

            Assert.AreEqual(string.Format("/SiteDirectory/{0}", siteDirectoryId), booleanParameterType.GetTopContainerRoute());
            Assert.AreEqual(string.Format("/SiteDirectory/{0}", siteDirectoryId), siteDirectory.GetTopContainerRoute());
        }

        [Test]
        public void VerifyThatWrongContainerCantBeAdded()
        {
            BooleanParameterType booleanParameterType;

            var booleanParameterTypeId = Guid.NewGuid();
            var siteReferenceDataLibraryId = Guid.NewGuid();

            booleanParameterType = new BooleanParameterType(booleanParameterTypeId, 1);
            booleanParameterType.AddContainer(ClassKind.SiteReferenceDataLibrary, siteReferenceDataLibraryId);

            Assert.Throws<InvalidOperationException>(() => booleanParameterType.AddContainer(ClassKind.Person, Guid.NewGuid()));
        }

        [Test]
        public void VerifyClassKindIsCorrect()
        {
            var alias = new CDP4Common.CommonData.Alias() as CDP4Common.CommonData.Thing;
            Assert.AreEqual(ClassKind.Alias, alias.ClassKind);

            var aliasdto = new CDP4Common.DTO.Alias() as CDP4Common.DTO.Thing;
            Assert.AreEqual(ClassKind.Alias, aliasdto.ClassKind);
        }

        [Test]
        public void VerifyThatExceptionIsRaisedWhenNoClassKindExistsForDTO()
        {
            var thing = new TestDto();
            Assert.Throws<NotSupportedException>(() =>
            {
                Console.WriteLine(thing.Route);
            });
        }

        [Test]
        public void VerifyThatDeepCloneWorksWithParameterValueSet()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), 0);
            var manual = new List<string> {"a", "b", "c"};
            valueset.Manual = new ValueArray<string>(manual);

            var clone = valueset.DeepClone<ParameterValueSet>();
            Assert.AreEqual(valueset.Iid, clone.Iid);
            
            clone.Manual = new ValueArray<string>();
            Assert.AreEqual(3, valueset.Manual.Count());
            Assert.AreEqual(0, clone.Manual.Count());
        }

        [Test]
        public void VerifyThatDeepCloneWorksWithActualFinteStateList()
        {
            var actualList = new ActualFiniteStateList(Guid.NewGuid(), 0);
            var item = new OrderedItem {K = 1, V = Guid.NewGuid()};
            actualList.PossibleFiniteStateList.Add(item);
            actualList.ActualState.Add(Guid.NewGuid());

            var clone = actualList.DeepClone<ActualFiniteStateList>();
            Assert.AreEqual(1, clone.PossibleFiniteStateList.Count);
            Assert.AreEqual(1, clone.ActualState.Count);

            clone.ActualState.Add(Guid.NewGuid());
            Assert.AreEqual(1, actualList.ActualState.Count);

            var ordereditem = clone.PossibleFiniteStateList.Single();
            Assert.AreEqual(ordereditem.K, 1);
            Assert.AreEqual(ordereditem.V, item.V);
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

            Assert.IsTrue(copypfsl.PossibleState.Any(ps => ps.V.ToString() == copyps1.Iid.ToString()));
            Assert.IsTrue(copypfsl.PossibleState.Any(ps => ps.V.ToString() == copyps2.Iid.ToString()));
            Assert.AreEqual(pfsl.Name, copypfsl.Name);
            Assert.AreEqual(pfsl.Owner, copypfsl.Owner);
            Assert.IsTrue(copypfsl.Category.Contains(pfsl.Category.Single()));
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

            Assert.IsTrue(copyparam.ValueSet.Contains(copyvs1.Iid));
            Assert.IsTrue(copyparam.ValueSet.Contains(copyvs2.Iid));
            Assert.IsTrue(copyvs1.Manual.Any());
            Assert.IsTrue(copyvs2.Computed.Any());
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
            Assert.AreEqual(parameter.ParameterType, pt2.Iid);
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

            public override Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri uri)
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
