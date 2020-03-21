// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategorizableThingExtensionsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.Tests.Extensions
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CategorizableThingExtensions"/> class
    /// </summary>
    [TestFixture]
    public class CategorizableThingExtensionsTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;

        private SiteReferenceDataLibrary siteRdl_A;
        private SiteReferenceDataLibrary siteRdl_A_A;
        private SiteReferenceDataLibrary siteRdl_A_B;
        private SiteReferenceDataLibrary siteRdl_B;

        private Category productCategory;
        private Category equipmentCategory;
        private Category batteryCategory;
        private Category lithiumBatteryCategory;
        private Category transmitterCategory;
        private Category functionCategory;

        private ElementDefinition elementDefinition;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            var siteDirectory = new SiteDirectory(Guid.NewGuid(), this.cache, this.uri);
            this.siteRdl_A = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            this.siteRdl_A_A = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri) { RequiredRdl = this.siteRdl_A };
            this.siteRdl_A_B = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri) { RequiredRdl = this.siteRdl_A };
            this.siteRdl_B = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var modelRdl = new ModelReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri) { RequiredRdl = this.siteRdl_A_A };
            var engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var engineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), this.cache, this.uri);
            engineeringModelSetup.RequiredRdl.Add(modelRdl);
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;
            engineeringModelSetup.EngineeringModelIid = engineeringModel.Iid;
            siteDirectory.Model.Add(engineeringModelSetup);
            siteDirectory.SiteReferenceDataLibrary.Add(this.siteRdl_A);
            siteDirectory.SiteReferenceDataLibrary.Add(this.siteRdl_A_A);
            siteDirectory.SiteReferenceDataLibrary.Add(this.siteRdl_A_B);
            siteDirectory.SiteReferenceDataLibrary.Add(this.siteRdl_B);
            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            engineeringModel.Iteration.Add(iteration);

            this.productCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "PROD", Name = "Products" };
            this.productCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_A.DefinedCategory.Add(this.productCategory);

            this.equipmentCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "EQT", Name = "Equipments" };
            this.equipmentCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_A.DefinedCategory.Add(this.equipmentCategory);

            this.batteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "BAT", Name = "Batteries" };
            this.batteryCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_A.DefinedCategory.Add(this.batteryCategory);

            this.lithiumBatteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "LITBAT", Name = "Lithium Batteries" };
            this.lithiumBatteryCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_A_A.DefinedCategory.Add(this.lithiumBatteryCategory);

            this.transmitterCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "TX", Name = "Transmitters" };
            this.transmitterCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_A_B.DefinedCategory.Add(this.transmitterCategory);

            this.functionCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "FUNCT", Name = "Functions" };
            this.functionCategory.PermissibleClass.Add(ClassKind.ElementDefinition);
            this.siteRdl_B.DefinedCategory.Add(this.functionCategory);

            this.lithiumBatteryCategory.SuperCategory.Add(this.batteryCategory);
            this.batteryCategory.SuperCategory.Add(this.equipmentCategory);
            this.transmitterCategory.SuperCategory.Add(this.equipmentCategory);
            this.equipmentCategory.SuperCategory.Add(this.productCategory);

            var lazyProductCategory = new Lazy<Thing>(() => this.productCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.productCategory.Iid, null), lazyProductCategory);

            var lazyEquipmentCategory = new Lazy<Thing>(() => this.equipmentCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.equipmentCategory.Iid, null), lazyEquipmentCategory);

            var lazyBatteryCategory = new Lazy<Thing>(() => this.batteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.batteryCategory.Iid, null), lazyBatteryCategory);

            var lazyLithiumBatteryCategory = new Lazy<Thing>(() => this.lithiumBatteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.lithiumBatteryCategory.Iid, null), lazyLithiumBatteryCategory);

            var lazyTransmitterCategory = new Lazy<Thing>(() => this.transmitterCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.transmitterCategory.Iid, null), lazyTransmitterCategory);

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            iteration.Element.Add(this.elementDefinition);
        }

        [Test]
        public void VerifyThatAllCategoriesAreReturned()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            var categories = this.elementDefinition.GetAllCategories();

            CollectionAssert.Contains(categories, this.productCategory);
            CollectionAssert.Contains(categories, this.equipmentCategory);
        }

        [Test]
        public void VerifyThatIfCategorizableThingIsElementUsageTheCategoriesOfTheReferencedElementDefinitionAreReturnedAsWell()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            var elementUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri);
            elementUsage.ElementDefinition = this.elementDefinition;

            var categories = elementUsage.GetAllCategories();

            CollectionAssert.Contains(categories, this.productCategory);
            CollectionAssert.Contains(categories, this.equipmentCategory);
        }

        [Test]
        public void VerifyThatAllCategoryShortNamesAreReturned()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            Assert.AreEqual("PROD EQT", this.elementDefinition.GetAllCategoryShortNames());
        }

        [Test]
        public void VerifyThatIfCategorizableThingIsAMemberOfACategoryTrueIsReturned()
        {
            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            battery.Category.Add(this.batteryCategory);

            Assert.IsTrue(battery.IsMemberOfCategory(this.batteryCategory));
            Assert.IsTrue(battery.IsMemberOfCategory(this.equipmentCategory));
            Assert.IsTrue(battery.IsMemberOfCategory(this.productCategory));
        }

        [Test]
        public void VerifyThatIfCategorizableThingIsANotMemberOfACategoryFalseIsReturned()
        {
            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            battery.Category.Add(this.batteryCategory);

            Assert.IsFalse(battery.IsMemberOfCategory(this.lithiumBatteryCategory));
            Assert.IsFalse(battery.IsMemberOfCategory(this.transmitterCategory));
        }

        [Test]
        public void Verif_that_IsCategoryInChainOfRdls_returns_true_for_DomainOfExpertise()
        {
            var category = new Category();

            var domainOfExpertise = new DomainOfExpertise();

            Assert.That(domainOfExpertise.IsCategoryInChainOfRdls(category), Is.True);
        }

        [Test]
        public void Verif_that_IsCategoryInChainOfRdls_returns_true_for_SiteLogEntry()
        {
            var category = new Category();

            var siteLogEntry = new SiteLogEntry();

            Assert.That(siteLogEntry.IsCategoryInChainOfRdls(category), Is.True);
        }

        [Test]
        public void Verify_that_IsCategoryInChainOfRdls_returns_true_when_category_is_in_same_chain_of_rdls_as_ElementDefinition_and_false_otherwise()
        {
            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.productCategory), Is.True);
            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.equipmentCategory), Is.True);
            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.lithiumBatteryCategory), Is.True);

            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.transmitterCategory), Is.False);

            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.functionCategory), Is.False);
        }

        [Test]
        public void Verify_that_IsCategoryInChainOfRdls_returns_true_when_category_is_in_same_chain_of_rdls_as_ParameterType_and_false_otherwise()
        {
            var parameterType = new TextParameterType(Guid.NewGuid(), this.cache, this.uri);
            this.siteRdl_A_A.ParameterType.Add(parameterType);

            Assert.That(parameterType.IsCategoryInChainOfRdls(this.productCategory), Is.True);
            Assert.That(parameterType.IsCategoryInChainOfRdls(this.equipmentCategory), Is.True);
            Assert.That(parameterType.IsCategoryInChainOfRdls(this.lithiumBatteryCategory), Is.True);

            Assert.That(parameterType.IsCategoryInChainOfRdls(this.transmitterCategory), Is.False);

            Assert.That(this.elementDefinition.IsCategoryInChainOfRdls(this.functionCategory), Is.False);
        }
    }
}
