// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRuleTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DecompositionRule"/> class
    /// </summary>
    [TestFixture]
    public class DecompositionRuleTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        private Iteration iteration;

        private Category systemCategory;
        private Category productCategory;
        private Category equipmentCategory;
        private Category batteryCategory;
        private Category lithiumBatteryCategory;

        private Category functionCategory;
        private Category powerStorageCategory;
        private Category electricalPowerStorageCategory;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            this.CreateCategories();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
        }

        /// <summary>
        /// instantiate categories
        /// </summary>
        private void CreateCategories()
        {
            this.systemCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "SYS", Name = "System" };
            this.productCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "PROD", Name = "Product" };
            this.equipmentCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "EQT", Name = "Equipment" };
            this.batteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "BAT", Name = "Battery" };
            this.lithiumBatteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "LITBAT", Name = "Lithium Battery" };

            this.functionCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "FUNC", Name = "Function" };
            this.powerStorageCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "POWSTORE", Name = "Power Storage" };
            this.electricalPowerStorageCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "ELECPOWSTORE", Name = "Electrical Power Storage" };

            this.lithiumBatteryCategory.SuperCategory.Add(this.batteryCategory);
            this.batteryCategory.SuperCategory.Add(this.equipmentCategory);
            this.equipmentCategory.SuperCategory.Add(this.productCategory);

            this.electricalPowerStorageCategory.SuperCategory.Add(this.powerStorageCategory);
            this.powerStorageCategory.SuperCategory.Add(this.functionCategory);
            this.functionCategory.SuperCategory.Add(this.systemCategory);

            var lazyProductCategory = new Lazy<Thing>(() => this.productCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.productCategory.Iid, null), lazyProductCategory);

            var lazyEquipmentCategory = new Lazy<Thing>(() => this.equipmentCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.equipmentCategory.Iid, null), lazyEquipmentCategory);

            var lazyBatteryCategory = new Lazy<Thing>(() => this.batteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.batteryCategory.Iid, null), lazyBatteryCategory);

            var lazyLithiumBatteryCategory = new Lazy<Thing>(() => this.lithiumBatteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.lithiumBatteryCategory.Iid, null), lazyLithiumBatteryCategory);

            var lazyFunctionCategory = new Lazy<Thing>(() => this.functionCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.functionCategory.Iid, null), lazyFunctionCategory);

            var lazyPowerStorageCategory = new Lazy<Thing>(() => this.powerStorageCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.powerStorageCategory.Iid, null), lazyPowerStorageCategory);

            var lazyElectricalPowerStorageCategory = new Lazy<Thing>(() => this.electricalPowerStorageCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.electricalPowerStorageCategory.Iid, null), lazyElectricalPowerStorageCategory);
        }

        [Test]
        public void VerifyThatNullIterationThrowsArgumentException()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);
            Assert.That(() => rule.Verify(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatIfTheIterationContainsNoBinaryRelationShipsAnEmptyResultIsReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Relationship.Add(multiRelationship);

            var violations = rule.Verify(this.iteration);
            CollectionAssert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfThereAreNoElementDefinitionsContainedByAnITerationAnEmptyResultIsReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);

            CollectionAssert.IsEmpty(this.iteration.Element);

            var violations = rule.Verify(this.iteration);

            CollectionAssert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfRuleIsViolatedExpectedViolationsAreReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri)
                           {
                               ContainingCategory = this.systemCategory
                           };
            rule.ContainedCategory.Add(this.functionCategory);
            rule.ContainedCategory.Add(this.productCategory);

            var spaceMissionElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
                                        {
                                            Name = "Space Mission",
                                            ShortName = "SpaceMission"
                                        };
            spaceMissionElementDefinition.Category.Add(this.systemCategory);

            var satelliteElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
                                                 {
                                                     Name = "satellite",
                                                     ShortName = "SAT"
                                                 };
            satelliteElementDefinition.Category.Add(this.systemCategory);

            var satelliteElementUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
                                            {
                                                ElementDefinition = satelliteElementDefinition
                                            };
            spaceMissionElementDefinition.ContainedElement.Add(satelliteElementUsage);

            this.iteration.Element.Add(spaceMissionElementDefinition);
            this.iteration.Element.Add(satelliteElementDefinition);

            var violations = rule.Verify(this.iteration);

            var violation = violations.SingleOrDefault();

            Assert.IsNotNull(violation);

            Assert.IsTrue(violation.Description.Contains("of an incorrect type"));

            CollectionAssert.Contains(violation.ViolatingThing, spaceMissionElementDefinition.Iid);
            CollectionAssert.Contains(violation.ViolatingThing, satelliteElementUsage.Iid);
        }

        [Test]
        public void VerifyThatIfDecompositionIsSatisfiedButMinContainedNotViolationIsReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);
            rule.ContainingCategory = this.systemCategory;
            rule.ContainedCategory.Add(this.productCategory);
            rule.MinContained = 2;

            var satelliteElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                Name = "satellite",
                ShortName = "SAT"
            };
            satelliteElementDefinition.Category.Add(this.systemCategory);
            this.iteration.Element.Add(satelliteElementDefinition);

            var batteryElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
                                               {
                                                   Name = "Battery",
                                                   ShortName = "BAT"
                                               };
            batteryElementDefinition.Category.Add(this.productCategory);
            this.iteration.Element.Add(batteryElementDefinition);

            var batteryUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri) { Name = "battery 1", ShortName = "bat_1" };
            batteryUsage.ElementDefinition = batteryElementDefinition;

            satelliteElementDefinition.ContainedElement.Add(batteryUsage);

            var violations = rule.Verify(this.iteration);
            Assert.AreEqual(1, violations.Count());

            var violation = violations.Single();

            Assert.IsTrue(violation.Description.Contains("does not contain the minimum of 2"));
        }

        [Test]
        public void VerifyThatIfDecompositionIsSatisfiedButMaxContainedNotViolationIsReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);
            rule.ContainingCategory = this.systemCategory;
            rule.ContainedCategory.Add(this.productCategory);
            rule.MinContained = 1;
            rule.MaxContained = 2;

            var satelliteElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                Name = "satellite",
                ShortName = "SAT"
            };
            satelliteElementDefinition.Category.Add(this.systemCategory);
            this.iteration.Element.Add(satelliteElementDefinition);

            var batteryElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                Name = "Battery",
                ShortName = "BAT"
            };
            batteryElementDefinition.Category.Add(this.productCategory);
            this.iteration.Element.Add(batteryElementDefinition);

            var batteryUsage1 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri) { Name = "battery 1", ShortName = "bat_1" };
            batteryUsage1.ElementDefinition = batteryElementDefinition;
            satelliteElementDefinition.ContainedElement.Add(batteryUsage1);

            var batteryUsage2 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri) { Name = "battery 2", ShortName = "bat_2" };
            batteryUsage2.ElementDefinition = batteryElementDefinition;
            satelliteElementDefinition.ContainedElement.Add(batteryUsage2);

            var batteryUsage3 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri) { Name = "battery 3", ShortName = "bat_3" };
            batteryUsage3.ElementDefinition = batteryElementDefinition;
            satelliteElementDefinition.ContainedElement.Add(batteryUsage3);

            var violations = rule.Verify(this.iteration);
            Assert.AreEqual(1, violations.Count());

            var violation = violations.Single();

            Assert.IsTrue(violation.Description.Contains("contains more Element Usages than the maximum of 2"));
        }

        [Test]
        public void VerifyThatIfNoDecompositionRuleIsViolatedNoViolationsAreReturned()
        {
            var rule = new DecompositionRule(Guid.NewGuid(), this.cache, this.uri);
            rule.ContainingCategory = this.systemCategory;
            rule.ContainedCategory.Add(this.functionCategory);
            rule.MinContained = 1;
            rule.MaxContained = 2;

            var satellite = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            satellite.Category.Add(this.systemCategory);
            this.iteration.Element.Add(satellite);

            var electricalStorage = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            electricalStorage.Category.Add(this.electricalPowerStorageCategory);
            this.iteration.Element.Add(electricalStorage);

            var elementUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri);
            elementUsage.ElementDefinition = electricalStorage;
            satellite.ContainedElement.Add(elementUsage);

            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }
    }
}
