// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRuleTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="BinaryRelationshipRule"/> class
    /// </summary>
    [TestFixture]
    public class BinaryRelationshipRuleTestFixture
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
            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri);
            
            Assert.That(() => rule.Verify(null), Throws.ArgumentNullException);
        }

        [Test]
        public void VerifyThatIfTheIterationContainsNoBinaryRelationShipsAnEmptyResultIsReturned()
        {
            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri);

            var multiRelationship = new MultiRelationship(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Relationship.Add(multiRelationship);

            var violations = rule.Verify(this.iteration);
            
            Assert.That(violations, Is.Empty);
        }

        [Test]
        public void VerifyThatIfRelationshipRuleDoesNotHaveRelationshipCategorySetThatNoViolationsAreReturned()
        {
            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri);
            var binaryRelationShip = new BinaryRelationship(Guid.NewGuid(), this.cache, this.uri);
            this.iteration.Relationship.Add(binaryRelationShip);

            var violations = rule.Verify(this.iteration);

            Assert.That(violations, Is.Empty);
        }

        [Test]
        public void VerifyThatIfSourceOrTargetIsNotCategorizableViolationIsCreated()
        {
            var relationshipCategory = new Category(Guid.NewGuid(), this.cache, this.uri)
                                           {
                                               ShortName = "link",
                                               Name = "a link"
                                           };

            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri)
                            {
                                ShortName = "BinRule",
                                Name = "Binary Relationship Rule",
                                RelationshipCategory = relationshipCategory
                            };

            var sourceAlias = new Alias(Guid.NewGuid(), this.cache, this.uri);
            var targetAlias = new Alias(Guid.NewGuid(), this.cache, this.uri);
            var binaryRelationship = new BinaryRelationship(Guid.NewGuid(), this.cache, this.uri)
                            {
                                Source = sourceAlias,
                                Target = targetAlias
                            };
            binaryRelationship.Category.Add(relationshipCategory);

            this.iteration.Relationship.Add(binaryRelationship);

            var violations = rule.Verify(this.iteration);
            
            Assert.That(violations, Is.Not.Empty);

            var sourceViolation = violations.Single(x => x.ViolatingThing.Contains(binaryRelationship.Iid) && x.Description.Contains("The Source"));
            
            Assert.That(sourceViolation, Is.Not.Null);

            var targetViolation = violations.Single(x => x.ViolatingThing.Contains(binaryRelationship.Iid) && x.Description.Contains("The Target"));
            
            Assert.That(targetViolation, Is.Not.Null);
        }

        [Test]
        public void VerifyThatIfRuleIsViolatedViolationsAreReturned()
        {
            var relationshipCategory = new Category(Guid.NewGuid(), this.cache, this.uri)
                    {
                        ShortName = "link",
                        Name = "a link"
                    };

            var sourceAndTargetCategory = new Category(Guid.NewGuid(), this.cache, this.uri);
            sourceAndTargetCategory.ShortName = "SOURCEANDTARGET";
            
            var lazySourceAndTargetCategory = new Lazy<Thing>(() => sourceAndTargetCategory);
            this.cache.TryAdd(new CDP4Common.Types.CacheKey(sourceAndTargetCategory.Iid, null), lazySourceAndTargetCategory);

            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri)
                           {
                               ShortName = "BinRule",
                               Name = "Binary Relationship Rule",
                               RelationshipCategory = relationshipCategory
                           };

            rule.SourceCategory = sourceAndTargetCategory;
            rule.TargetCategory = sourceAndTargetCategory;
            
            var elementDefinitionBattery1 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinitionBattery2 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            var binaryRelationship = new BinaryRelationship(Guid.NewGuid(), this.cache, this.uri)
                            {
                                Source = elementDefinitionBattery1,
                                Target = elementDefinitionBattery2
                            };

            binaryRelationship.Category.Add(relationshipCategory);
            this.iteration.Relationship.Add(binaryRelationship);

            var violations = rule.Verify(this.iteration);

            Assert.That(violations, Is.Not.Empty);

            var sourceViolation = violations.Single(x => x.ViolatingThing.Contains(binaryRelationship.Iid) && x.Description.Contains("The Source"));
            
            Assert.That(sourceViolation, Is.Not.Null);

            Assert.That(sourceViolation.ViolatingThing.Contains(elementDefinitionBattery1.Iid), Is.True);

            var targetViolation = violations.Single(x => x.ViolatingThing.Contains(binaryRelationship.Iid) && x.Description.Contains("The Target"));
            
            Assert.That(targetViolation, Is.Not.Null);

            Assert.That(targetViolation.ViolatingThing.Contains(elementDefinitionBattery2.Iid), Is.True);
        }

        [Test]
        public void VerifyThatGetRequiredRdlsReturnsExpectedResults()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl1_1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);

            var rule = new BinaryRelationshipRule(Guid.NewGuid(), this.cache, this.uri);
            
            srdl1_1.RequiredRdl = srdl1;
            mrdl.RequiredRdl = srdl1_1;
            srdl2.RequiredRdl = srdl1;

            mrdl.Rule.Add(rule);

            var requiredRdls = rule.RequiredRdls.ToList();

            Assert.That(requiredRdls.Contains(mrdl), Is.True);

            Assert.That(requiredRdls.Contains(srdl1_1), Is.True);

            Assert.That(requiredRdls.Contains(srdl1), Is.True);

            Assert.That(requiredRdls.Contains(srdl2), Is.False);
        }
    }
}
