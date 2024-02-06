#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRuleTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="MultiRelationshipRule"/>
    /// </summary>
    [TestFixture]
    public class MultiRelationshipRuleTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        private Iteration iteration;

        private Category productCategory;
        private Category equipmentCategory;
        private Category batteryCategory;
        private Category lithiumBatteryCategory;

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
            this.productCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "PROD", Name = "Product" };
            this.equipmentCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "EQT", Name = "Equipment" };
            this.batteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "BAT", Name = "Battery" };
            this.lithiumBatteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "LITBAT", Name = "Lithium Battery" };

            this.lithiumBatteryCategory.SuperCategory.Add(this.batteryCategory);
            this.batteryCategory.SuperCategory.Add(this.equipmentCategory);
            this.equipmentCategory.SuperCategory.Add(this.productCategory);

            var lazyProductCategory = new Lazy<Thing>(() => this.productCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.productCategory.Iid, null), lazyProductCategory);

            var lazyEquipmentCategory = new Lazy<Thing>(() => this.equipmentCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.equipmentCategory.Iid, null), lazyEquipmentCategory);

            var lazyBatteryCategory = new Lazy<Thing>(() => this.batteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.batteryCategory.Iid, null), lazyBatteryCategory);

            var lazyLithiumBatteryCategory = new Lazy<Thing>(() => this.lithiumBatteryCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(this.lithiumBatteryCategory.Iid, null), lazyLithiumBatteryCategory);
        }

        [Test]
        public void VerifyThatNullIterationThrowsArgumentException()
        {
            var rule = new MultiRelationshipRule(Guid.NewGuid(), this.cache, this.uri);
            
            Assert.That(() => rule.Verify(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatIfNoMultiRelationshipsAreContainedByIterationNoViolationsAreReturned()
        {
            var rule = new MultiRelationshipRule(Guid.NewGuid(), this.cache, this.uri);
            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfRelationshipCategoryIsNullNoViolationsAreReturned()
        {
            var rule = new MultiRelationshipRule();
            rule.RelationshipCategory = null;

            var binaryRelationship = new BinaryRelationship(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Relationship.Add(binaryRelationship);

            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfRelationshipIsNotMemberOfCategoryNoViolationIsReturned()
        {
            var rule = new MultiRelationshipRule();
            rule.RelationshipCategory = this.equipmentCategory;

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Relationship.Add(multiRelationship);

            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfRelationshipViolatesRuleViolationIsReturned()
        {
            var rule = new MultiRelationshipRule(Guid.NewGuid(), this.cache, this.uri)
                           {
                               RelationshipCategory = this.lithiumBatteryCategory
                           };
            rule.RelatedCategory.Add(this.lithiumBatteryCategory);

            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
                              {
                                  ShortName = "BAT",
                                  Name = "Battery"
                              };
            battery.Category.Add(this.batteryCategory);
            this.iteration.Element.Add(battery);

            var lithiumBattery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "LITBAT",
                Name = "Lithium Battery"
            };
            lithiumBattery.Category.Add(this.lithiumBatteryCategory);
            this.iteration.Element.Add(lithiumBattery);

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            multiRelationship.Category.Add(this.lithiumBatteryCategory);
            multiRelationship.RelatedThing.Add(battery);
            multiRelationship.RelatedThing.Add(lithiumBattery);
            this.iteration.Relationship.Add(multiRelationship);

            var violations = rule.Verify(this.iteration);
            var violation = violations.Single();

            CollectionAssert.Contains(violation.ViolatingThing, multiRelationship.Iid);
        }

        [Test]
        public void VerifyThatIfNonCategorizableThingsAreRelatedViolationsAreReturned()
        {
            var rule = new MultiRelationshipRule(Guid.NewGuid(), this.cache, this.uri)
                           {
                               RelationshipCategory = this.lithiumBatteryCategory
                           };
            rule.RelatedCategory.Add(this.lithiumBatteryCategory);

            var alias = new Alias(Guid.NewGuid(), this.cache, this.uri);
            var definition = new Definition(Guid.NewGuid(), this.cache, this.uri);

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            multiRelationship.Category.Add(this.lithiumBatteryCategory);

            multiRelationship.RelatedThing.Add(alias);
            multiRelationship.RelatedThing.Add(definition);
            this.iteration.Relationship.Add(multiRelationship);
            
            var violations = rule.Verify(this.iteration);
            
            Assert.AreEqual(2, violations.Count());

            var aliasViolation = violations.Single(v => v.ViolatingThing.Contains(alias.Iid));
            Assert.IsTrue(aliasViolation.Description.Contains("is not a CategorizableThing"));

            var definitionViolation = violations.Single(v => v.ViolatingThing.Contains(definition.Iid));
            Assert.IsTrue(definitionViolation.Description.Contains("is not a CategorizableThing"));
        }

        [Test]
        public void VerifyThatIfRuleIsNotViolatedNoViolationsAreReturned()
        {
            var rule = new MultiRelationshipRule(Guid.NewGuid(), this.cache, this.uri)
            {
                RelationshipCategory = this.productCategory
            };
            rule.RelatedCategory.Add(this.productCategory);

            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            battery.Category.Add(this.batteryCategory);
            this.iteration.Element.Add(battery);

            var cell = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            cell.Category.Add(this.equipmentCategory);
            this.iteration.Element.Add(cell);

            var cellElementUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri);
            cellElementUsage.ElementDefinition = cell;
            battery.ContainedElement.Add(cellElementUsage);

            var pcdu = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            pcdu.Category.Add(this.equipmentCategory);
            this.iteration.Element.Add(pcdu);

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            multiRelationship.Category.Add(this.productCategory);
            this.iteration.Relationship.Add(multiRelationship);

            multiRelationship.RelatedThing.Add(battery);
            multiRelationship.RelatedThing.Add(cellElementUsage);
            multiRelationship.RelatedThing.Add(pcdu);

            var violations = rule.Verify(this.iteration);

            CollectionAssert.IsEmpty(violations);
        }
    }
}