﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorCategoryColumnTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class DataCollectorCategoryColumnTestFixture
    {
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;

        private Iteration iteration;

        private Option option;

        private Category cat1;
        private Category cat2;
        private Category cat3;
        private Category superCat;
        private Category subCat;

        private DomainOfExpertise domain;

        private ElementDefinition ed1;
        private ElementDefinition ed2;

        private ElementUsage eu;

        private class Row : DataCollectorRow
        {
            [DefinedThingShortName("cat1")]
            public DataCollectorCategory<Row> testCategory1 { get; set; }

            [DefinedThingShortName("cat2")]
            public DataCollectorCategory<Row> testCategory2 { get; set; }
        }

        private class Row2 : DataCollectorRow
        {
            [DefinedThingShortName("superCat")]
            public DataCollectorCategory<Row2> superCategory { get; set; }

            [DefinedThingShortName("subCat")]
            public DataCollectorCategory<Row2> subCategory { get; set; }
        }

        private class Row3 : DataCollectorRow
        {
            [DefinedThingShortName("superCat")]
            public DataCollectorCategory<Row3> superCategory { get; set; }

            public string superCatCategory
            {
                get
                {
                    return this.superCategory.ActualCategory?.Name ?? string.Empty;
                }
            }
        }
        
        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null);

            // Option

            this.option = new Option(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "option1",
                Name = "option1"
            };

            this.iteration.Option.Add(this.option);

            var engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, null);
            var modelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.NewGuid(), this.cache, null);
            var iterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, null);
            var engineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), this.cache, null);

            iterationSetup.Container = engineeringModelSetup;
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;
            engineeringModelSetup.RequiredRdl.Add(modelReferenceDataLibrary);

            this.iteration.IterationSetup = iterationSetup;
            this.iteration.Container = engineeringModel;

            // Categories

            this.cat1 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat1",
                Name = "cat1"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat1);

            this.cache.TryAdd(
                new CacheKey(this.cat1.Iid, null),
                new Lazy<Thing>(() => this.cat1));

            this.cat2 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat2",
                Name = "cat2"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat2);

            this.cache.TryAdd(
                new CacheKey(this.cat2.Iid, null),
                new Lazy<Thing>(() => this.cat2));

            this.cat3 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat3",
                Name = "cat3"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat3);

            this.cache.TryAdd(
                new CacheKey(this.cat3.Iid, null),
                new Lazy<Thing>(() => this.cat3));

            this.superCat = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "superCat",
                Name = "superCat"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.superCat);

            this.cache.TryAdd(
                new CacheKey(this.superCat.Iid, null),
                new Lazy<Thing>(() => this.superCat));

            this.subCat = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "subCat",
                Name = "subCat"
            };

            this.subCat.SuperCategory.Add(this.superCat);

            modelReferenceDataLibrary.DefinedCategory.Add(this.subCat);

            this.cache.TryAdd(
                new CacheKey(this.subCat.Iid, null),
                new Lazy<Thing>(() => this.subCat));

            // Domain of expertise

            this.domain = new DomainOfExpertise(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "domain",
                Name = "domain"
            };

            // Element Definitions

            this.ed1 = new ElementDefinition(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "ed1",
                Name = "element definition 1",
                Owner = this.domain,
                Container = this.iteration
            };

            this.ed2 = new ElementDefinition(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "ed2",
                Name = "element definition 2",
                Owner = this.domain,
                Container = this.iteration
            };

            // Element Usages

            this.eu = new ElementUsage(Guid.NewGuid(), this.cache, null)
            {
                ElementDefinition = this.ed2,
                ShortName = "eu",
                Name = "element usage",
                Owner = this.domain
            };

            // Structure

            this.iteration.TopElement = this.ed1;
            this.ed1.Category.Add(this.cat1);

            this.eu.Category.Add(this.cat2);
            this.ed1.ContainedElement.Add(this.eu);
        }

        [Test]
        public void VerifyThatNodeIdentifiesCategories()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();
            
            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();
            
            Assert.That(node.GetColumns<DataCollectorCategory<Row>>().Count(), Is.EqualTo(2));
        }

        [Test]
        public void VerifyCategoryShortNameInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categories = node.GetColumns<DataCollectorCategory<Row>>().ToList();
            Assert.That(categories.Single(x => x.ShortName == "cat1").ShortName, Is.EqualTo("cat1"));
            Assert.That(categories.Single(x => x.ShortName == "cat2").ShortName, Is.EqualTo("cat2"));
        }

        [Test]
        public void VerifyElementDefinitionCategoryValueInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categories = node.GetColumns<DataCollectorCategory<Row>>().ToList();
            Assert.That(categories.Single(x => x.ShortName == "cat1").Value, Is.EqualTo(true));
            Assert.That(categories.Single(x => x.ShortName == "cat2").Value, Is.EqualTo(false));
        }

        [Test]
        public void VerifyElementUsageCategoryValueInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat2.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categories = node.GetColumns<DataCollectorCategory<Row>>().ToList();
            Assert.That(categories.Single(x => x.ShortName == "cat1").Value, Is.EqualTo(false));
            Assert.That(categories.Single(x => x.ShortName == "cat2").Value, Is.EqualTo(true));
        }

        [Test]
        public void VerifyCategorySuperCategoryInCategoryHierarchy()
        {
            this.ed1.Category.Add(this.superCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.superCat.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            Assert.That(node.GetTable().Columns.Contains(this.superCat.ShortName), Is.True);
            Assert.That(node.GetTable().Columns.Contains(this.subCat.ShortName), Is.False);
        }

        [Test]
        public void VerifyCategorySubCategoryInCategoryHierarchy()
        {
            this.ed1.Category.Add(this.subCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.subCat.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            Assert.That(node.GetTable().Columns.Contains(this.superCat.ShortName), Is.EqualTo(false));
            Assert.That(node.GetTable().Columns.Contains(this.subCat.ShortName), Is.EqualTo(true));
        }

        [Test]
        public void VerifyCategorySubCategoryAsColumn()
        {
            this.ed1.Category.Add(this.subCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row2>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categoryColumns = node.GetColumns<DataCollectorCategory<Row2>>().ToList();
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).Value, Is.EqualTo(true));
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).MainCategory, Is.EqualTo(this.superCat));

            Assert.That(categoryColumns.Single(x => x.ShortName == this.subCat.ShortName).Value, Is.EqualTo(true));
            Assert.That(categoryColumns.Single(x => x.ShortName == this.subCat.ShortName).MainCategory, Is.EqualTo(this.subCat));
        }

        [Test]
        public void VerifyCategorySuperCategoryAsColumn()
        {
            this.ed1.Category.Add(this.superCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row2>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categoryColumns = node.GetColumns<DataCollectorCategory<Row2>>().ToList();
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).Value, Is.EqualTo(true));
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).MainCategory, Is.EqualTo(this.superCat));

            Assert.That(categoryColumns.Single(x => x.ShortName == this.subCat.ShortName).Value, Is.EqualTo(false));
        }

        [Test]
        public void VerifyCategorySuperCategoryActualCategory()
        {
            this.ed1.Category.Add(this.superCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row3>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categoryColumns = node.GetColumns<DataCollectorCategory<Row3>>().ToList();
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).ActualCategory, Is.EqualTo(this.superCat));
        }

        [Test]
        public void VerifyCategorySubCategoryActualCategory()
        {
            this.ed1.Category.Add(this.subCat);

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row3>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var categoryColumns = node.GetColumns<DataCollectorCategory<Row3>>().ToList();
            Assert.That(categoryColumns.Single(x => x.ShortName == this.superCat.ShortName).ActualCategory, Is.EqualTo(this.subCat));
        }
    }
}
