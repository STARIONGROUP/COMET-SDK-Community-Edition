// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
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
    using System.Diagnostics;
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
        private CDPMessageBus messageBus;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.stariongroup.eu");

            this.messageBus = new CDPMessageBus();

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
            this.messageBus.ClearSubscriptions();
        }

        [Test]
        public void VerifyThatAssemblerThrowsNullReferenceExceptionWhenUriIsNull()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var assembler = new Assembler(null, this.messageBus);
            });
        }

        [Test]
        public void AssertThatCacheCanStoreThings()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

            // Check that the cache is empty
            Assert.That(assembler.Cache.Skip(0).Any(), Is.False);

            var id = Guid.NewGuid();
            var testThing = new Lazy<Thing>(() => new Alias(id, assembler.Cache, this.uri));
            testThing.Value.Cache.TryAdd(new CacheKey(testThing.Value.Iid, null), testThing);

            // Check that the cache is not empty anymore
            Assert.That(assembler.Cache.Skip(0).Any(), Is.True);

            // Update the thing and the cache
            testThing = new Lazy<Thing>(() => new Alias(id, assembler.Cache, this.uri));
            testThing.Value.Cache.AddOrUpdate(new CacheKey(testThing.Value.Iid, null), testThing, (key, oldValue) => testThing);

            // Check that the thing retrieved from the cache has the updated value
            Lazy<Thing> updatedThing;
            testThing.Value.Cache.TryGetValue(new CacheKey(testThing.Value.Iid, null), out updatedThing);
            Assert.That(updatedThing, Is.Not.Null);

            // Check that we can remove things from the cache
            testThing.Value.Cache.TryRemove(new CacheKey(testThing.Value.Iid, null), out updatedThing);
            Assert.That(assembler.Cache.Skip(0).Any(), Is.False);
            Assert.That(testThing.Value.Cache.Skip(0).Any(), Is.False);
        }

        [Test]
        public async Task AssertThatAssemblerSynchronizationWorks()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            // Modification of the input Dtos
            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(7, Is.EqualTo(assembler.Cache.Count));

            // check containerList Element
            var siteDirId = this.testInput[0].Iid;
            Lazy<Thing> lazySiteDir;
            assembler.Cache.TryGetValue(new CacheKey(siteDirId, null), out lazySiteDir);
            var siteDir = lazySiteDir.Value as SiteDirectory;
            Assert.That(siteDirId, Is.EqualTo(siteDir.SiteReferenceDataLibrary[0].Container.Iid));

            // get category to removes
            var categoryToRemove = this.testInput[3] as Dto.Category;

            // parametertype
            var parameterTypeId = this.testInput[6].Iid;
            Lazy<Thing> lazyPt;
            assembler.Cache.TryGetValue(new CacheKey(parameterTypeId, null), out lazyPt);
            Assert.That(2, Is.EqualTo((lazyPt.Value as ParameterType).Category.Count));

            //Check that route works
            Lazy<Thing> lazyCat;
            assembler.Cache.TryGetValue(new CacheKey(categoryToRemove.Iid, null), out lazyCat);
            Assert.That(lazyCat.Value.Route, Is.Not.Null);

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
            Assert.That(6, Is.EqualTo(assembler.Cache.Count));            
            Assert.That(assembler.Cache.TryGetValue(new CacheKey(categoryToRemove.Iid, null), out lazyCat), Is.False);
        }

        [Test]
        public async Task AssertThatAssemblerSynchronizationWorksFastEnough()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

            var domain = new Dto.DomainOfExpertise(Guid.NewGuid(), 1);
            this.testInput.Add(domain);

            for (var i = 0; i < 20000; i++)
            {
                this.testInput.Add(new Dto.ElementDefinition(Guid.NewGuid(), 1) {Owner = domain.Iid});
            }

            var sw = new Stopwatch();

            sw.Reset();
            sw.Start();
            
            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);
            
            sw.Stop();
            var elapsed = sw.Elapsed;
            await TestContext.Progress.WriteLineAsync($"First synchronize took {elapsed}");
            // Modification of the input Dtos
            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(this.testInput.Count, Is.EqualTo(assembler.Cache.Count));

            sw.Reset();
            sw.Start();

            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            sw.Stop();
            elapsed = sw.Elapsed;
            await TestContext.Progress.WriteLineAsync($"Second synchronize took {elapsed}");
            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(this.testInput.Count, Is.EqualTo(assembler.Cache.Count));

            sw.Reset();
            sw.Start();

            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            sw.Stop();
            elapsed = sw.Elapsed;
            await TestContext.Progress.WriteLineAsync($"Third synchronize took {elapsed}");
            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(this.testInput.Count, Is.EqualTo(assembler.Cache.Count));
        }

        [Test]
        public async Task AssertThatRevisionsAreCachedCorrectly()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

            var parameterIid = Guid.NewGuid();
            var parameterRevision1 = new Dto.Parameter(parameterIid, 1); //The Parameter's 1st Revision
            var parameterRevision2 = new Dto.Parameter(parameterIid, 2); //The Parameter's 2nd Revision
            var parameterRevision3 = new Dto.Parameter(parameterIid, 3); //The Parameter's 3rd Revision

            var valueSet1 = new Dto.ParameterValueSet(Guid.NewGuid(), 1); //ValueSet that belongs to the parameter's 1st Revision
            var valueSet2 = new Dto.ParameterValueSet(Guid.NewGuid(), 1); //ValueSet that belongs to the parameter's 2nd Revision
            var valueSet3 = new Dto.ParameterValueSet(Guid.NewGuid(), 1); //ValueSet that belongs to the parameter's 3rd Revision

            parameterRevision1.ValueSet.Add(valueSet1.Iid);
            parameterRevision2.ValueSet.Add(valueSet2.Iid);
            parameterRevision3.ValueSet.Add(valueSet3.Iid);

            //******************************************************************************************************************
            // 1st call of Synchronize for Revision 2, which is the currently active revision
            //******************************************************************************************************************
            await assembler.Synchronize(new List<Dto.Thing> { parameterRevision2, valueSet2 });
            
            //Cache should not be empty
            Assert.That(assembler.Cache, Is.Not.Empty);

            //Cache should contain 2 items
            Assert.That(2, Is.EqualTo(assembler.Cache.Count));

            //Get the cached version of the parameter
            var cachedParameter = assembler.Cache.First(x => x.Value.Value.Iid == parameterRevision2.Iid).Value.Value as Parameter;

            //Revision number should be 2 now
            Assert.That(parameterRevision2.RevisionNumber, Is.EqualTo(cachedParameter.RevisionNumber));

            //Parameter should contain a ValueSet
            Assert.That(1, Is.EqualTo(cachedParameter.ValueSet.Count));

            //Parameter should contain the correct ValueSet
            Assert.That(cachedParameter.ValueSet.First().Iid, Is.EqualTo(valueSet2.Iid));

            //******************************************************************************************************************
            // 2st call of Synchronize which introduces a newer revision: Revision nr. 3.
            //******************************************************************************************************************
            await assembler.Synchronize(new List<Dto.Thing> { parameterRevision3, valueSet3 });

            //Cache should still contain 2 things, because parameterRevision2 is removed from cache together with valueSet2
            //parameterRevision2 now is contained in the Revisions property of the cached version of the parameter
            Assert.That(2, Is.EqualTo(assembler.Cache.Count));

            cachedParameter = assembler.Cache.First(x => x.Value.Value.Iid == parameterRevision3.Iid).Value.Value as Parameter;

            //Current cached parameter version is Revision 3
            Assert.That(parameterRevision3.RevisionNumber, Is.EqualTo(cachedParameter.RevisionNumber));

            //cached parameter should contain a ValueSet
            Assert.That(1, Is.EqualTo(cachedParameter.ValueSet.Count));

            //cached parameter should contain exactly 1 revision
            Assert.That(1, Is.EqualTo(cachedParameter.Revisions.Count));

            //cached parameter should contain the correct ValueSet
            Assert.That(cachedParameter.ValueSet.First().Iid, Is.EqualTo(valueSet3.Iid));
            
            //Revisions property of current cached item should contain the right revision number
            Assert.That(cachedParameter.Revisions.First().Value.RevisionNumber, Is.EqualTo(parameterRevision2.RevisionNumber));

            //******************************************************************************************************************
            // 3rd call of Synchronize with older revision, that should be added as a revision to an existing cached poco
            //******************************************************************************************************************
            await assembler.Synchronize(new List<Dto.Thing> { parameterRevision1, valueSet1 });

            //Cache should still contain 2 things, because parameterRevision1 is added to the Revisions property of the current cached parameter
            Assert.That(2, Is.EqualTo(assembler.Cache.Count));

            cachedParameter = assembler.Cache.First(x => x.Value.Value.Iid == parameterRevision1.Iid).Value.Value as Parameter;

            //parameterRevision3 is still the current cached version
            Assert.That(parameterRevision3.RevisionNumber, Is.EqualTo(cachedParameter.RevisionNumber));

            //cached parameter should contain a ValueSet
            Assert.That(1, Is.EqualTo(cachedParameter.ValueSet.Count));

            //cached parameter should contain the correct ValueSet
            Assert.That(cachedParameter.ValueSet.First().Iid, Is.EqualTo(valueSet3.Iid));

            //cached parameter should contain exactly 2 revisions
            Assert.That(2, Is.EqualTo(cachedParameter.Revisions.Count));

            var revisionParameter1 = cachedParameter.Revisions.Single(x => x.Value.Iid == parameterRevision1.Iid && x.Value.RevisionNumber == parameterRevision1.RevisionNumber).Value as Parameter;
            var revisionParameter2 = cachedParameter.Revisions.Single(x => x.Value.Iid == parameterRevision2.Iid && x.Value.RevisionNumber == parameterRevision2.RevisionNumber).Value as Parameter;

            //Should be empty, because an older revision than the one currently in the cache was asked for
            //In that case the ValueSet belonging to the Parameter doens't get cloned (because it is unknown at that moment)
            Assert.That(0, Is.EqualTo(revisionParameter1.ValueSet.Count));

            //Should be 1, because the ValueSet2 was cloned and added to the Parameter added to the Revisions property of the cached parameter
            //when revision 3 was added to the cache
            Assert.That(1, Is.EqualTo(revisionParameter2.ValueSet.Count));
        }

        [Test]
        public async Task VerifyThatAssemblerCanUpdateExistingPoco()
        {
            var assembler = new Assembler(this.uri, this.messageBus);
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
            
            Assert.That(siteRdl1, Is.EqualTo(siteRdl2));
            Assert.That(siteDir, Is.EqualTo(siteRdl2.Container));
        }

        [Test]
        public void VerifyThatArgumentThrown()
        {
            var assembler = new Assembler(this.uri, this.messageBus);
            
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

            var assembler = new Assembler(this.uri, this.messageBus);
            await assembler.Synchronize(dtos);

            Assert.That(4, Is.EqualTo(assembler.Cache.Count));

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

            Assert.That(4, Is.EqualTo(assembler.Cache.Count));
            Assert.That(srdl1poco.DefinedCategory, Is.Empty);
            Assert.That(srdl2poco.DefinedCategory.Contains(catpoco), Is.True);
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

            var assembler = new Assembler(this.uri, this.messageBus);
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

            Assert.That(11, Is.EqualTo(assembler.Cache.Count));
        }

        [Test]
        public async Task VerifyThatCloseRdlWorks()
        {
            var assembler = new Assembler(this.uri, this.messageBus);
            // 1st call of Synnchronize
            await assembler.Synchronize(this.testInput);

            Lazy<Thing> lazyrdl;
            assembler.Cache.TryGetValue(new CacheKey(this.siteRdl.Iid, null), out lazyrdl);
            var rdl = (ReferenceDataLibrary)lazyrdl.Value;
            await assembler.CloseRdl(rdl);

            Assert.That(rdl.DefinedCategory, Is.Empty);
            Assert.That(5, Is.EqualTo(assembler.Cache.Count)); // 2 categories should have been removed
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

            var assembler = new Assembler(this.uri, this.messageBus);
            var input = new List<Dto.Thing>();
            input.Add(sitedir);
            input.Add(domain);
            input.Add(definition);
            input.Add(citation);

            await assembler.Synchronize(input);

            var citationPoco = (Citation)
                assembler.Cache.Select(x => x.Value).Select(x => x.Value).Single(x => x.Iid == citation.Iid);
            Assert.That(citationPoco.Source.Iid, Is.EqualTo(Guid.Empty));
            Assert.That(citationPoco.ValidationErrors, Is.Not.Empty);

            sitedir.SiteReferenceDataLibrary.Add(srdl.Iid);
            input.Clear();

            input.Add(sitedir);
            input.Add(srdl);
            input.Add(referenceSource);

            await assembler.Synchronize(input);
            Assert.That(citationPoco.Source, Is.Not.Null);
        }

        [Test]
        public async Task VerifyThatIterationIsDeletedWhenSetupIsDeleted()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

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

            Assert.That(assembler.Cache.ContainsKey(new CacheKey(it1.Iid, null)), Is.True);
            await assembler.Synchronize(new List<Dto.Thing> {sitedirdto, itdto});
            Assert.That(assembler.Cache.ContainsKey(new CacheKey(it1.Iid, null)), Is.False);
        }

        [Test]
        public async Task VerifyThatModelIsDeletedWhenSetupIsDeleted()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

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

            Assert.That(7, Is.EqualTo(assembler.Cache.Count));
            await assembler.Synchronize(new List<Dto.Thing> { sitedirdto });
            Assert.That(1, Is.EqualTo(assembler.Cache.Count));
        }

        [Test]
        public async Task Verify_that_assembler_clear_empties_cache_and_sends_remove_messages()
        {
            var engineeringModelIid = Guid.NewGuid();
            var engineeringModelSetupIid = Guid.NewGuid();
            var iterationIid = Guid.NewGuid();            
            var iterationSetupIid = Guid.NewGuid();

            this.messageBus.Listen<ObjectChangedEvent>(typeof(EngineeringModel)).Subscribe(x =>
            {
                Assert.That(engineeringModelIid, Is.EqualTo(x.ChangedThing.Iid));
            });

            this.messageBus.Listen<ObjectChangedEvent>(typeof(EngineeringModelSetup)).Subscribe(x =>
            {
                Assert.That(engineeringModelSetupIid, Is.EqualTo(x.ChangedThing.Iid));
            });

            this.messageBus.Listen<ObjectChangedEvent>(typeof(Iteration)).Subscribe(x =>
            {
                Assert.That(iterationIid, Is.EqualTo(x.ChangedThing.Iid));
            });

            this.messageBus.Listen<ObjectChangedEvent>(typeof(IterationSetup)).Subscribe(x =>
            {
                Assert.That(iterationSetupIid, Is.EqualTo(x.ChangedThing.Iid));
            });

            var assembler = new Assembler(this.uri, this.messageBus);

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
            
            Assert.That(5, Is.EqualTo(assembler.Cache.Count));

            await assembler.Clear();

            Assert.That(0, Is.EqualTo(assembler.Cache.Count));
        }

        [Test]
        public async Task VerifyThatSynchronizationPreservesKeysOfOrderedItemList()
        {
            var assembler = new Assembler(this.uri, this.messageBus);

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

            Assert.That(1, Is.EqualTo(orderedItemList.ToList()[0].K));
            Assert.That(simpleQuantityKind1.Iid, Is.EqualTo(orderedItemList.ToList()[0].V));

            Assert.That(2, Is.EqualTo(orderedItemList.ToList()[1].K));
            Assert.That(simpleQuantityKind2.Iid, Is.EqualTo(orderedItemList.ToList()[1].V));
        }

        [Test]
        public async Task AssertThatIterationIdsForCommonFileStoreRelatedDtosIsNull()
        {
            var assembler = new Assembler(this.uri, this.messageBus);
            var iterationIid = Guid.NewGuid();
            var commonFileStore = new Dto.CommonFileStore(Guid.NewGuid(), 1);
            var folder = new Dto.Folder(Guid.NewGuid(), 1) { IterationContainerId = iterationIid };
            var file = new Dto.File(Guid.NewGuid(), 1) { IterationContainerId = iterationIid };
            var fileRevision = new Dto.FileRevision(Guid.NewGuid(), 1) { IterationContainerId = iterationIid, ContainingFolder = folder.Iid };

            file.FileRevision.Add(fileRevision.Iid);
            commonFileStore.File.Add(file.Iid);
            commonFileStore.Folder.Add(folder.Iid);

            var initialList = new List<Dto.Thing> { commonFileStore, folder, file, fileRevision };

            // 1st call of Synchronize, uses incoming DTO's
            await assembler.Synchronize(initialList);

            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(4, Is.EqualTo(assembler.Cache.Count));

            Assert.That(folder.IterationContainerId, Is.Null);
            Assert.That(file.IterationContainerId, Is.Null);
            Assert.That(fileRevision.IterationContainerId, Is.Null);

            //Newly added FileRevision
            var addedFileRevision = new Dto.FileRevision(Guid.NewGuid(), 2) { IterationContainerId = iterationIid, ContainingFolder = folder.Iid };
            file.FileRevision.Add(addedFileRevision.Iid);
            file.RevisionNumber = 2;
            file.IterationContainerId = iterationIid;

            var addFileRevisionList = new List<Dto.Thing> { file, addedFileRevision};

            // 2nd call of Synchronize, uses Cache and incoming DTO's
            await assembler.Synchronize(addFileRevisionList);

            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(5, Is.EqualTo(assembler.Cache.Count));

            Assert.That(file.IterationContainerId, Is.Null);
            Assert.That(addedFileRevision.IterationContainerId, Is.Null);
        }

        [Test]
        public async Task AssertThatIterationIdsForDomainFileStoreRelatedDtosStayFilled()
        {
            var assembler = new Assembler(this.uri, this.messageBus);
            var iterationIid = Guid.NewGuid();
            var domainFileStore = new Dto.DomainFileStore(Guid.NewGuid(), 1);
            var folder = new Dto.Folder(Guid.NewGuid(), 1) { IterationContainerId = iterationIid };
            var file = new Dto.File(Guid.NewGuid(), 1) { IterationContainerId = iterationIid };
            var fileRevision = new Dto.FileRevision(Guid.NewGuid(), 1) { IterationContainerId = iterationIid, ContainingFolder = folder.Iid };

            file.FileRevision.Add(fileRevision.Iid);
            domainFileStore.File.Add(file.Iid);
            domainFileStore.Folder.Add(folder.Iid);

            var initialList = new List<Dto.Thing> { domainFileStore, folder, file, fileRevision };

            // 1st call of Synchronize, uses incoming DTO's
            await assembler.Synchronize(initialList);

            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(4, Is.EqualTo(assembler.Cache.Count));

            Assert.That(iterationIid, Is.EqualTo(folder.IterationContainerId));
            Assert.That(iterationIid, Is.EqualTo(file.IterationContainerId));
            Assert.That(iterationIid, Is.EqualTo(fileRevision.IterationContainerId));

            //Newly added FileRevision
            var addedFileRevision = new Dto.FileRevision(Guid.NewGuid(), 2) { IterationContainerId = iterationIid, ContainingFolder = folder.Iid };
            file.FileRevision.Add(addedFileRevision.Iid);
            file.RevisionNumber = 2;
            file.IterationContainerId = iterationIid;

            var addFileRevisionList = new List<Dto.Thing> { file, addedFileRevision };

            // 2nd call of Synchronize, uses Cache and incoming DTO's
            await assembler.Synchronize(addFileRevisionList);

            Assert.That(assembler.Cache, Is.Not.Empty);
            Assert.That(5, Is.EqualTo(assembler.Cache.Count));

            Assert.That(iterationIid, Is.EqualTo(file.IterationContainerId));
            Assert.That(iterationIid, Is.EqualTo(addedFileRevision.IterationContainerId));
        }

    }
}