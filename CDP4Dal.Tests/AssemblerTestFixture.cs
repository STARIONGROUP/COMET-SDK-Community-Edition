// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal.Events;
    using NUnit.Framework;
    using Dto = CDP4Common.DTO;

    [TestFixture]
    public class AssemblerTestFixture
    {
        private List<Dto.Thing> testInput;
        private Dto.SiteDirectory siteDir;
        private Dto.SiteReferenceDataLibrary siteRdl;
        private Uri uri;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");

            this.testInput = new List<Dto.Thing>();

            //Top container
            this.siteDir = new Dto.SiteDirectory(Guid.NewGuid(), 1);

            this.siteRdl = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 1);
            this.siteDir.SiteReferenceDataLibrary.Add(this.siteRdl.Iid);

            var category1 = new Dto.Category(Guid.NewGuid(), 1);
            category1.PermissibleClass.Add(ClassKind.ParameterType);
            category1.PermissibleClass.Add(ClassKind.Person);
            var category2 = new Dto.Category(Guid.NewGuid(), 1);
            category2.PermissibleClass.Add(ClassKind.TelephoneNumber);
            category2.PermissibleClass.Add(ClassKind.EmailAddress);

            this.siteRdl.DefinedCategory.Add(category1.Iid);
            this.siteRdl.DefinedCategory.Add(category2.Iid);

            //topContainer
            var siteRDL2 = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 1);
            this.siteDir.SiteReferenceDataLibrary.Add(siteRDL2.Iid);

            var booleanParameterType = new Dto.BooleanParameterType(Guid.NewGuid(), 1);
            booleanParameterType.Category = new List<Guid> { category1.Iid, category2.Iid };
            var definition = new Dto.Definition(Guid.NewGuid(), 1);
            booleanParameterType.Definition.Add(definition.Iid);

            siteRDL2.ParameterType.Add(booleanParameterType.Iid);

            this.testInput.Add(this.siteDir);
            this.testInput.Add(this.siteRdl);
            this.testInput.Add(category1);
            this.testInput.Add(category2);

            this.testInput.Add(definition);
            this.testInput.Add(siteRDL2);
            this.testInput.Add(booleanParameterType);
        }

        [TearDown]
        public void TearDown()
        {
            this.testInput.Clear();
            CDPMessageBus.Current.ClearSubscriptions();
        }

        [Test]
        //[ExpectedException(typeof(NullReferenceException))]
        public void VerifyThatAssemblerThrowsNullReferenceExceptionWhenUriIsNull()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var assembler = new Assembler(null);
            });
        }

        [Test]
        public void AssertThatCacheCanStoreThings()
        {
            var assembler = new Assembler(this.uri);

            // Check that the cache is empty
            Assert.IsFalse(assembler.Cache.Skip(0).Any());

            var id = Guid.NewGuid();
            var testThing = new Lazy<Thing>(() => new Alias(id, assembler.Cache, this.uri));
            testThing.Value.Cache.TryAdd(new CacheKey(testThing.Value.Iid, null), testThing);

            // Check that the cache is not empty anymore
            Assert.IsTrue(assembler.Cache.Skip(0).Any());

            // Update the thing and the cache
            testThing = new Lazy<Thing>(() => new Alias(id, assembler.Cache, this.uri));
            testThing.Value.Cache.AddOrUpdate(new CacheKey(testThing.Value.Iid, null), testThing, (key, oldValue) => testThing);

            // Check that the thing retrieved from the cache has the updated value
            Lazy<Thing> updatedThing;
            testThing.Value.Cache.TryGetValue(new CacheKey(testThing.Value.Iid, null), out updatedThing);
            Assert.IsNotNull(updatedThing);

            // Check that we can remove things from the cache
            testThing.Value.Cache.TryRemove(new CacheKey(testThing.Value.Iid, null), out updatedThing);
            Assert.IsFalse(assembler.Cache.Skip(0).Any());
            Assert.IsFalse(testThing.Value.Cache.Skip(0).Any());
        }

        [Test]
        public async Task AssertThatAssemblerSynchronizationWorks()
        {
            var assembler = new Assembler(this.uri);

            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            // Modification of the input Dtos
            Assert.IsNotEmpty(assembler.Cache);
            Assert.AreEqual(7, assembler.Cache.Count);

            // check containerList Element
            var siteDirId = this.testInput[0].Iid;
            Lazy<Thing> lazySiteDir;
            assembler.Cache.TryGetValue(new CacheKey(siteDirId, null), out lazySiteDir);
            var siteDir = lazySiteDir.Value as SiteDirectory;
            Assert.AreEqual(siteDirId, siteDir.SiteReferenceDataLibrary[0].Container.Iid);

            // get category to removes
            var categoryToRemove = this.testInput[3] as Dto.Category;

            // parametertype
            var parameterTypeId = this.testInput[6].Iid;
            Lazy<Thing> lazyPt;
            assembler.Cache.TryGetValue(new CacheKey(parameterTypeId, null), out lazyPt);
            Assert.AreEqual(2, (lazyPt.Value as ParameterType).Category.Count);

            //Check that route works
            Lazy<Thing> lazyCat;
            assembler.Cache.TryGetValue(new CacheKey(categoryToRemove.Iid, null), out lazyCat);
            Assert.IsNotNull(lazyCat.Value.Route);

            var siteRdl = this.testInput[1] as Dto.SiteReferenceDataLibrary;
            siteRdl.DefinedCategory.Remove(categoryToRemove.Iid);

            // 2nd call with updated values, sRdl lost a category
            var newInput = this.testInput.GetRange(0, 3);
            foreach (var thing in newInput)
            {
                thing.RevisionNumber++;
            }

            await assembler.Synchronize(newInput);

            // checks that the removed category is no longer in the cache
            Assert.AreEqual(6, assembler.Cache.Count);            
            Assert.IsFalse(assembler.Cache.TryGetValue(new CacheKey(categoryToRemove.Iid, null), out lazyCat));
        }

        [Test]
        public async Task VerifyThatAssemblerCanUpdateExistingPoco()
        {
            var assembler = new Assembler(this.uri);
            await assembler.Synchronize(this.testInput);

            var siteDir = assembler.Cache.Select(x => x.Value)
                    .Select(x => x.Value)
                    .OfType<SiteDirectory>()
                    .Single(x => x.Iid == this.siteDir.Iid);

            var siteRdl1 =
                assembler.Cache.Select(x => x.Value)
                    .Select(x => x.Value)
                    .OfType<SiteReferenceDataLibrary>()
                    .Single(x => x.Iid == this.siteRdl.Iid);

            await assembler.Synchronize(new List<Dto.Thing> { this.siteRdl });

            var siteRdl2 =
                assembler.Cache.Select(x => x.Value)
                    .Select(x => x.Value)
                    .OfType<SiteReferenceDataLibrary>()
                    .Single(x => x.Iid == this.siteRdl.Iid);
            
            Assert.AreEqual(siteRdl1, siteRdl2);
            Assert.AreEqual(siteDir, siteRdl2.Container);
        }

        [Test]
        public void VerifyThatArgumentThrown()
        {
            var assembler = new Assembler(this.uri);
            
            Assert.ThrowsAsync<ArgumentNullException>(async() =>
            {
                await assembler.Synchronize(null);
            });
        }

        [Test]
        public async Task VerifyThatAssemblerCanMoveThings()
        {
            var sitedir = new Dto.SiteDirectory(Guid.NewGuid(), 0);
            var srdl1 = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 0);
            var srdl2 = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 0);
            var category = new Dto.Category(Guid.NewGuid(), 0);

            sitedir.SiteReferenceDataLibrary.Add(srdl1.Iid);
            sitedir.SiteReferenceDataLibrary.Add(srdl2.Iid);
            srdl1.DefinedCategory.Add(category.Iid);

            var dtos = new List<Dto.Thing>
            {
                sitedir,
                srdl1,
                srdl2,
                category
            };

            var assembler = new Assembler(this.uri);
            await assembler.Synchronize(dtos);

            Assert.AreEqual(4, assembler.Cache.Count);

            srdl1.DefinedCategory.Clear();
            srdl2.DefinedCategory.Add(category.Iid);

            // move category
            var movedDtos = new List<Dto.Thing>
            {
                sitedir,
                srdl1,
                srdl2
            };

            await assembler.Synchronize(movedDtos);
            var srdl1poco = (SiteReferenceDataLibrary)assembler.Cache[new CacheKey(srdl1.Iid, null)].Value;
            var srdl2poco = (SiteReferenceDataLibrary)assembler.Cache[new CacheKey(srdl2.Iid, null)].Value;
            var catpoco = assembler.Cache[new CacheKey(category.Iid, null)].Value;

            Assert.AreEqual(4, assembler.Cache.Count);
            Assert.IsEmpty(srdl1poco.DefinedCategory);
            Assert.IsTrue(srdl2poco.DefinedCategory.Contains(catpoco));
        }

        [Test]
        public void VerifyThatMultipleIterationCanBeSynchronized()
        {
            var sitedir = new Dto.SiteDirectory(Guid.NewGuid(), 0);
            var srdl1 = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 0);
            var srdl2 = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 0);
            var category = new Dto.Category(Guid.NewGuid(), 0);

            var modeldto = new Dto.EngineeringModel(Guid.NewGuid(), 1);
            var iteration1dto = new Dto.Iteration(Guid.NewGuid(), 1);
            var iteration2dto = new Dto.Iteration(Guid.NewGuid(), 1);

            var element1dto = new Dto.ElementDefinition(Guid.NewGuid(), 1);
            element1dto.IterationContainerId = iteration1dto.Iid;
            element1dto.Category.Add(category.Iid);

            var element2dto = new Dto.ElementDefinition(element1dto.Iid, 1);
            element2dto.IterationContainerId = iteration2dto.Iid;
            element2dto.Category.Add(category.Iid);

            var usage1dto = new Dto.ElementUsage(Guid.NewGuid(), 1);
            usage1dto.IterationContainerId = iteration1dto.Iid;
            usage1dto.Category.Add(category.Iid);

            var usage2dto = new Dto.ElementUsage(usage1dto.Iid, 1);
            usage2dto.IterationContainerId = iteration2dto.Iid;
            usage2dto.Category.Add(category.Iid);

            sitedir.SiteReferenceDataLibrary.Add(srdl1.Iid);
            sitedir.SiteReferenceDataLibrary.Add(srdl2.Iid);
            srdl1.DefinedCategory.Add(category.Iid);

            modeldto.Iteration.Add(iteration1dto.Iid);
            modeldto.Iteration.Add(iteration2dto.Iid);

            iteration1dto.Element.Add(element1dto.Iid);
            iteration2dto.Element.Add(element2dto.Iid);

            element1dto.ContainedElement.Add(usage1dto.Iid);
            element2dto.ContainedElement.Add(usage2dto.Iid);

            var dtos = new List<Dto.Thing>
            {
                sitedir,
                srdl1,
                srdl2,
                category
            };

            var assembler = new Assembler(this.uri);
            assembler.Synchronize(dtos);

            dtos = new List<Dto.Thing>
            {
                modeldto,
                iteration1dto,
                iteration2dto,
                element1dto,
                element2dto,
                usage1dto,
                usage2dto
            };

            assembler.Synchronize(dtos);

            Assert.AreEqual(11, assembler.Cache.Count);
        }

        [Test]
        public async Task VerifyThatCloseRdlWorks()
        {
            var assembler = new Assembler(this.uri);
            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            Lazy<Thing> lazyrdl;
            assembler.Cache.TryGetValue(new CacheKey(this.siteRdl.Iid, null), out lazyrdl);
            var rdl = (ReferenceDataLibrary)lazyrdl.Value;
            await assembler.CloseRdl(rdl);

            Assert.IsEmpty(rdl.DefinedCategory);
            Assert.AreEqual(5, assembler.Cache.Count); // 2 categories should have been removed
        }

        [Test]
        public async Task VerifyThatCitationIsResolvedWhenRdlIsLoaded()
        {
            var sitedir = new Dto.SiteDirectory(Guid.NewGuid(), 1);
            var domain = new Dto.DomainOfExpertise(Guid.NewGuid(), 1);
            var definition = new Dto.Definition(Guid.NewGuid(), 1);
            var citation = new Dto.Citation(Guid.NewGuid(), 1);

            var referenceSource = new Dto.ReferenceSource(Guid.NewGuid(), 1);
            var srdl = new Dto.SiteReferenceDataLibrary(Guid.NewGuid(), 1);
            srdl.ReferenceSource.Add(referenceSource.Iid);

            citation.Source = referenceSource.Iid;

            sitedir.Domain.Add(domain.Iid);
            domain.Definition.Add(definition.Iid);
            definition.Citation.Add(citation.Iid);

            var assembler = new Assembler(this.uri);
            var input = new List<Dto.Thing>();
            input.Add(sitedir);
            input.Add(domain);
            input.Add(definition);
            input.Add(citation);

            await assembler.Synchronize(input);

            var citationPoco = (Citation)
                assembler.Cache.Select(x => x.Value).Select(x => x.Value).Single(x => x.Iid == citation.Iid);
            Assert.AreEqual(citationPoco.Source.Iid, Guid.Empty);
            Assert.IsNotEmpty(citationPoco.ValidationErrors);

            sitedir.SiteReferenceDataLibrary.Add(srdl.Iid);
            input.Clear();

            input.Add(sitedir);
            input.Add(srdl);
            input.Add(referenceSource);

            await assembler.Synchronize(input);
            Assert.IsNotNull(citationPoco.Source);
        }

        [Test]
        public async Task VerifyThatIterationIsDeletedWhenSetupIsDeleted()
        {
            var assembler = new Assembler(this.uri);

            var model = new EngineeringModel(Guid.NewGuid(), assembler.Cache, this.uri);
            var it1 = new Iteration(Guid.NewGuid(), assembler.Cache, this.uri);
            var it2 = new Iteration(Guid.NewGuid(), assembler.Cache, this.uri);
            model.Iteration.Add(it1);
            model.Iteration.Add(it2);

            var sitedir = new SiteDirectory(Guid.NewGuid(), assembler.Cache, this.uri);
            var modelsetup = new EngineeringModelSetup(Guid.NewGuid(), assembler.Cache, this.uri){EngineeringModelIid = model.Iid};
            var iterationsetup1 = new IterationSetup(Guid.NewGuid(), assembler.Cache, this.uri){IterationIid = it1.Iid};
            var iterationsetup2 = new IterationSetup(Guid.NewGuid(), assembler.Cache, this.uri){IterationIid = it2.Iid};

            sitedir.Model.Add(modelsetup);
            modelsetup.IterationSetup.Add(iterationsetup1);
            modelsetup.IterationSetup.Add(iterationsetup2);

            assembler.Cache.TryAdd(new CacheKey(sitedir.Iid, null), new Lazy<Thing>(() => sitedir));
            assembler.Cache.TryAdd(new CacheKey(modelsetup.Iid, null), new Lazy<Thing>(() => modelsetup));
            assembler.Cache.TryAdd(new CacheKey(iterationsetup1.Iid, null), new Lazy<Thing>(() => iterationsetup1));
            assembler.Cache.TryAdd(new CacheKey(iterationsetup2.Iid, null), new Lazy<Thing>(() => iterationsetup2));
            assembler.Cache.TryAdd(new CacheKey(model.Iid, null), new Lazy<Thing>(() => model));
            assembler.Cache.TryAdd(new CacheKey(it1.Iid, null), new Lazy<Thing>(() => it1));
            assembler.Cache.TryAdd(new CacheKey(it2.Iid, null), new Lazy<Thing>(() => it2));

            var sitedirdto = new Dto.SiteDirectory(sitedir.Iid, 1);
            sitedirdto.Model.Add(modelsetup.Iid);

            var itdto = (Dto.IterationSetup)iterationsetup1.ToDto();
            itdto.IsDeleted = true;

            Assert.IsTrue(assembler.Cache.ContainsKey(new CacheKey(it1.Iid, null)));
            await assembler.Synchronize(new List<Dto.Thing> {sitedirdto, itdto});
            Assert.IsFalse(assembler.Cache.ContainsKey(new CacheKey(it1.Iid, null)));
        }

        [Test]
        public async Task VerifyThatModelIsDeletedWhenSetupIsDeleted()
        {
            var assembler = new Assembler(this.uri);

            var model = new EngineeringModel(Guid.NewGuid(), assembler.Cache, this.uri);
            var it1 = new Iteration(Guid.NewGuid(), assembler.Cache, this.uri);
            var it2 = new Iteration(Guid.NewGuid(), assembler.Cache, this.uri);
            model.Iteration.Add(it1);
            model.Iteration.Add(it2);

            var sitedir = new SiteDirectory(Guid.NewGuid(), assembler.Cache, this.uri);
            var modelsetup = new EngineeringModelSetup(Guid.NewGuid(), assembler.Cache, this.uri) { EngineeringModelIid = model.Iid };
            var iterationsetup1 = new IterationSetup(Guid.NewGuid(), assembler.Cache, this.uri) { IterationIid = it1.Iid };
            var iterationsetup2 = new IterationSetup(Guid.NewGuid(), assembler.Cache, this.uri) { IterationIid = it2.Iid };

            sitedir.Model.Add(modelsetup);
            modelsetup.IterationSetup.Add(iterationsetup1);
            modelsetup.IterationSetup.Add(iterationsetup2);

            assembler.Cache.TryAdd(new CacheKey(sitedir.Iid, null), new Lazy<Thing>(() => sitedir));
            assembler.Cache.TryAdd(new CacheKey(modelsetup.Iid, null), new Lazy<Thing>(() => modelsetup));
            assembler.Cache.TryAdd(new CacheKey(iterationsetup1.Iid, null), new Lazy<Thing>(() => iterationsetup1));
            assembler.Cache.TryAdd(new CacheKey(iterationsetup2.Iid, null), new Lazy<Thing>(() => iterationsetup2));
            assembler.Cache.TryAdd(new CacheKey(model.Iid, null), new Lazy<Thing>(() => model));
            assembler.Cache.TryAdd(new CacheKey(it1.Iid, null), new Lazy<Thing>(() => it1));
            assembler.Cache.TryAdd(new CacheKey(it2.Iid, null), new Lazy<Thing>(() => it2));

            var sitedirdto = new Dto.SiteDirectory(sitedir.Iid, 1);

            Assert.AreEqual(7, assembler.Cache.Count);
            await assembler.Synchronize(new List<Dto.Thing> { sitedirdto });
            Assert.AreEqual(1, assembler.Cache.Count);
        }

        [Test]
        public async Task Verify_that_assembler_clear_empties_cache_and_sends_remove_messages()
        {
            var engineeringModelIid = Guid.NewGuid();
            var engineeringModelSetupIid = Guid.NewGuid();
            var iterationIid = Guid.NewGuid();            
            var iterationSetupIid = Guid.NewGuid();
            
            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(EngineeringModel)).Subscribe(x =>
            {
                Assert.AreEqual(engineeringModelIid, x.ChangedThing.Iid);
            });

            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(EngineeringModelSetup)).Subscribe(x =>
            {
                Assert.AreEqual(engineeringModelSetupIid, x.ChangedThing.Iid);
            });

            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(Iteration)).Subscribe(x =>
            {
                Assert.AreEqual(iterationIid, x.ChangedThing.Iid);
            });

            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(IterationSetup)).Subscribe(x =>
            {
                Assert.AreEqual(iterationSetupIid, x.ChangedThing.Iid);
            });

            var assembler = new Assembler(this.uri);

            var model = new EngineeringModel(engineeringModelIid, assembler.Cache, this.uri);
            var iteration = new Iteration(iterationIid, assembler.Cache, this.uri);            
            model.Iteration.Add(iteration);
            
            var sitedir = new SiteDirectory(Guid.NewGuid(), assembler.Cache, this.uri);
            var modelsetup = new EngineeringModelSetup(engineeringModelSetupIid, assembler.Cache, this.uri) { EngineeringModelIid = model.Iid };
            model.EngineeringModelSetup = modelsetup;
            var iterationsetup = new IterationSetup(iterationSetupIid, assembler.Cache, this.uri) { IterationIid = iteration.Iid };
            iteration.IterationSetup = iterationsetup;


            sitedir.Model.Add(modelsetup);
            modelsetup.IterationSetup.Add(iterationsetup);
            
            assembler.Cache.TryAdd(new CacheKey(sitedir.Iid, null), new Lazy<Thing>(() => sitedir));
            assembler.Cache.TryAdd(new CacheKey(modelsetup.Iid, null), new Lazy<Thing>(() => modelsetup));
            assembler.Cache.TryAdd(new CacheKey(iterationsetup.Iid, null), new Lazy<Thing>(() => iterationsetup));            
            assembler.Cache.TryAdd(new CacheKey(model.Iid, null), new Lazy<Thing>(() => model));
            assembler.Cache.TryAdd(new CacheKey(iteration.Iid, null), new Lazy<Thing>(() => iteration));
            
            Assert.AreEqual(5, assembler.Cache.Count);

            await assembler.Clear();

            Assert.AreEqual(0, assembler.Cache.Count);
        }

        [Test]
        public async Task VerifyThatSynchronizationPreservesKeysOfOrderedItemList()
        {
            var assembler = new Assembler(this.uri);

            var simpleUnit = new Dto.SimpleUnit(Guid.NewGuid(), 1) { Name = "Unit", ShortName = "unit" };
            var ratioScale = new Dto.RatioScale(Guid.NewGuid(), 1) { Name = "Ration", ShortName = "ratio", NumberSet = NumberSetKind.INTEGER_NUMBER_SET };
            ratioScale.Unit = simpleUnit.Iid;

            var simpleQuantityKind1 = new Dto.SimpleQuantityKind(Guid.NewGuid(), 1) { Name = "Kind1", ShortName = "kind1", Symbol = "symbol" };
            simpleQuantityKind1.DefaultScale = ratioScale.Iid;
            var orderedItem1 = new OrderedItem() { K = 1, V = simpleQuantityKind1.Iid };

            var simpleQuantityKind2 = new Dto.SimpleQuantityKind(Guid.NewGuid(), 1) { Name = "Kind2", ShortName = "kind2", Symbol = "symbol" };
            simpleQuantityKind2.DefaultScale = ratioScale.Iid;
            var orderedItem2 = new OrderedItem() { K = 2, V = simpleQuantityKind2.Iid };

            this.siteRdl.Unit.Add(simpleUnit.Iid);
            this.siteRdl.Scale.Add(ratioScale.Iid);
            this.siteRdl.BaseQuantityKind.Add(orderedItem1);
            this.siteRdl.BaseQuantityKind.Add(orderedItem2);

            this.testInput.Add(simpleUnit);
            this.testInput.Add(ratioScale);
            this.testInput.Add(simpleQuantityKind1);
            this.testInput.Add(simpleQuantityKind2);

            await assembler.Synchronize(this.testInput);

            Lazy<Thing> lazySiteRdl;
            assembler.Cache.TryGetValue(new CacheKey(this.siteRdl.Iid, null), out lazySiteRdl);
            var siteRdl = lazySiteRdl.Value as SiteReferenceDataLibrary;
            var orderedItemList = siteRdl.BaseQuantityKind.ToDtoOrderedItemList();

            Assert.AreEqual(1, orderedItemList.ToList()[0].K);
            Assert.AreEqual(simpleQuantityKind1.Iid, orderedItemList.ToList()[0].V);

            Assert.AreEqual(2, orderedItemList.ToList()[1].K);
            Assert.AreEqual(simpleQuantityKind2.Iid, orderedItemList.ToList()[1].V);
        }
    }
}