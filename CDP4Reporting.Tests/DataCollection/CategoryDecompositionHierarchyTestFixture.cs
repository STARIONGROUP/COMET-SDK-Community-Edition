// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryHierarchyTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    using CDP4Reporting.DataCollection;

    [TestFixture]
    public class CategoryDecompositionHierarchyTestFixture
    {
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;

        private Iteration iteration;

        private Category cat1;
        private Category cat2;
        private Category cat3;
        private Category cat4;

        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null);

            var engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, null);
            var modelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.NewGuid(), this.cache, null);

            engineeringModel.EngineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), this.cache, null);
            engineeringModel.EngineeringModelSetup.RequiredRdl.Add(modelReferenceDataLibrary);
            
            this.iteration.Container = engineeringModel;

            this.cat1 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat1",
                Name = "cat1"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat1);
            this.cache.TryAdd(new CacheKey(this.cat1.Iid, null), new Lazy<Thing>(() => this.cat1));

            this.cat2 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat2",
                Name = "cat2"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat2);
            this.cache.TryAdd(new CacheKey(this.cat2.Iid, null), new Lazy<Thing>(() => this.cat2));

            this.cat3 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat3",
                Name = "cat3"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat3);
            this.cache.TryAdd(new CacheKey(this.cat3.Iid, null), new Lazy<Thing>(() => this.cat3));

            this.cat4 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat4",
                Name = "cat4"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat4);
            this.cache.TryAdd(new CacheKey(this.cat4.Iid, null), new Lazy<Thing>(() => this.cat4));
        }

        [Test]
        public void VerifyThatBuilderThrowsOnUnkownCategory()
        {
            Assert.Throws<NotSupportedException>(() =>
                new CategoryDecompositionHierarchy.Builder(this.iteration, "unknown_cat"));
        }

        [Test]
        public void VerifyThatBuilderBuids()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            Assert.That(hierarchy, Is.InstanceOf<CategoryDecompositionHierarchy>());
        }

        [Test]
        public void VerifyThatExceptionThrowsWhenEmptyTopLevel()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                .Builder(this.iteration);

            Assert.Throws<InvalidOperationException>(() => hierarchy.Build());
        }

        [Test]
        public void VerifyThatCategoryHierarchyIsCorrect()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .AddLevel(this.cat2.ShortName)
                .AddLevel(this.cat3.ShortName)
                .AddLevel(this.cat4.ShortName, "cat4FieldName")
                .Build();

            Assert.That(hierarchy.Category, Is.EqualTo(this.cat1));

            hierarchy = hierarchy.Child;
            Assert.That(hierarchy.Category, Is.EqualTo(this.cat2));

            hierarchy = hierarchy.Child;
            Assert.That(hierarchy.Category, Is.EqualTo(this.cat3));

            hierarchy = hierarchy.Child;
            Assert.That(hierarchy.Category, Is.EqualTo(this.cat4));

            Assert.That(hierarchy.Child, Is.Null);
        }
    }
}
