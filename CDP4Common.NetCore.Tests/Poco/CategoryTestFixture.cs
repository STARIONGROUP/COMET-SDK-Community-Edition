#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryTestFixture.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Concurrent;    
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;    
    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="Category"/>
    /// </summary>
    [TestFixture]
    public class CategoryTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();
        }

        [Test]
        public void VerifyThatExpectedCategoriesAreReturned()
        {
            var categorya1 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A1"};
            var categorya2 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A2"};
            var categorya11 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A11"};

            categorya11.SuperCategory.Add(categorya1);
            categorya11.SuperCategory.Add(categorya2);

            var categoryb = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B"};
            var category = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "subcat"};

            category.SuperCategory.Add(categorya11);
            category.SuperCategory.Add(categoryb);

            var allSuperCategories = category.AllSuperCategories();

            Assert.AreEqual(4, allSuperCategories.Count());

            var shortnames = allSuperCategories.Aggregate(string.Empty,
                (current, cat) => current + " " + cat.ShortName);

            Assert.AreEqual("A11 A1 A2 B", shortnames.Trim());
        }

        [Test]
        public void VerifyThatExpectedDerivedCategoriesAreReturned()
        {
            var a = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A"};
            var aa = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "AA"};
            var aaa = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "AAA"};
            var aaaa = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "AAAA"};

            aaaa.SuperCategory.Add(aaa);
            aaa.SuperCategory.Add(aa);
            aa.SuperCategory.Add(a);

            var lazyA = new Lazy<Thing>(() => a);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(a.Iid, null), lazyA);
            var lazyAa = new Lazy<Thing>(() => aa);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(aa.Iid, null), lazyAa);
            var lazyAaa = new Lazy<Thing>(() => aaa);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(aaa.Iid, null), lazyAaa);
            var lazyAaaa = new Lazy<Thing>(() => aaaa);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(aaaa.Iid, null), lazyAaaa);

            var b = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B"};
            var bb = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "BB"};
            var bbb = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "BBB"};
            var bbbb = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "BBBB"};

            var lazyB = new Lazy<Thing>(() => b);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(b.Iid, null), lazyB);
            var lazyBb = new Lazy<Thing>(() => bb);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(bb.Iid, null), lazyBb);
            var lazyBbb = new Lazy<Thing>(() => bbb);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(bbb.Iid, null), lazyBbb);
            var lazyBbbb = new Lazy<Thing>(() => bbbb);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(bbbb.Iid, null), lazyBbbb);

            bbbb.SuperCategory.Add(bbb);
            bbb.SuperCategory.Add(bb);
            bb.SuperCategory.Add(b);

            Assert.AreEqual(8, this.cache.Count);

            var derivedCategoriesOfA = a.AllDerivedCategories().ToList();

            Assert.AreEqual(3, derivedCategoriesOfA.Count);

            CollectionAssert.Contains(derivedCategoriesOfA, aa);
            CollectionAssert.Contains(derivedCategoriesOfA, aaa);
            CollectionAssert.Contains(derivedCategoriesOfA, aaaa);
        }

        [Test]
        public void VerifyThatGetRequiredRdlsWorks()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl1_1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);

            var category = new Category(Guid.NewGuid(), this.cache, this.uri);

            srdl1_1.RequiredRdl = srdl1;
            mrdl.RequiredRdl = srdl1_1;
            srdl2.RequiredRdl = srdl1;

            mrdl.DefinedCategory.Add(category);

            Assert.IsTrue(category.RequiredRdls.Contains(mrdl));
            Assert.IsTrue(category.RequiredRdls.Contains(srdl1_1));
            Assert.IsTrue(category.RequiredRdls.Contains(srdl1));

            Assert.IsFalse(category.RequiredRdls.Contains(srdl2));
        }

        [Test]
        public void VerifyThatCategorizedThingsReturnsExpectedElementDefinitions()
        {
            var categorya1 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A1"};
            categorya1.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categorya1.Iid, null), new Lazy<Thing>(() => categorya1));

            var categorya11 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A11"};
            categorya11.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categorya11.Iid, null), new Lazy<Thing>(() => categorya11));

            var categorya111 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A111"};
            categorya111.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categorya111.Iid, null), new Lazy<Thing>(() => categorya111));

            categorya111.SuperCategory.Add(categorya11);
            categorya11.SuperCategory.Add(categorya1);

            var categoryb1 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B1"};
            categoryb1.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categoryb1.Iid, null), new Lazy<Thing>(() => categoryb1));

            var categoryb11 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B11"};
            categoryb11.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categoryb11.Iid, null), new Lazy<Thing>(() => categoryb11));

            var categoryb111 = new Category(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B111"};
            categoryb111.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categoryb111.Iid, null), new Lazy<Thing>(() => categoryb111));

            categoryb111.SuperCategory.Add(categoryb11);
            categoryb11.SuperCategory.Add(categoryb1);

            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(iteration.Iid, null), new Lazy<Thing>(() => iteration));

            var elementDefinitionA = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri) {ShortName = "A"};
            this.cache.TryAdd(new Tuple<Guid, Guid?>(elementDefinitionA.Iid, iteration.Iid), new Lazy<Thing>(() => elementDefinitionA));

            var elementDefinitionB = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri) {ShortName = "B"};
            this.cache.TryAdd(new Tuple<Guid, Guid?>(elementDefinitionB.Iid, iteration.Iid), new Lazy<Thing>(() => elementDefinitionB));

            iteration.Element.Add(elementDefinitionA);
            iteration.Element.Add(elementDefinitionB);

            elementDefinitionA.Category.Add(categorya11);
            elementDefinitionB.Category.Add(categoryb111);

            Assert.Contains(elementDefinitionA, categorya1.CategorizedThings().ToList());
            Assert.Contains(elementDefinitionA, categorya11.CategorizedThings().ToList());

            Assert.Contains(elementDefinitionB, categoryb1.CategorizedThings().ToList());
            Assert.Contains(elementDefinitionB, categoryb11.CategorizedThings().ToList());
            Assert.Contains(elementDefinitionB, categoryb111.CategorizedThings().ToList());
        }

        [Test]
        public void VerifyThatCategorizedThingsReturnsNoneWhenThereAreNoCategorizableThingsInTheCache()
        {
            var categorya1 = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "A1" };
            categorya1.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(categorya1.Iid, null), new Lazy<Thing>(() => categorya1));

            CollectionAssert.IsEmpty(categorya1.CategorizedThings());
        }
    }
}