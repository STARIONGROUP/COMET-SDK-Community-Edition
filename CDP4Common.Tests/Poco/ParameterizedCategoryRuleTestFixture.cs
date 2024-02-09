// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizedCategoryRuleTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ParameterizedCategoryRule"/> class
    /// </summary>
    [TestFixture]
    public class ParameterizedCategoryRuleTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        private Iteration iteration;

        private Category productCategory;
        private Category equipmentCategory;
        private Category batteryCategory;
        private Category lithiumBatteryCategory;

        private TextParameterType textParameterType;
        private SimpleQuantityKind simpleQuantityKind;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            this.CreateCategories();

            this.textParameterType = new TextParameterType(Guid.NewGuid(), this.cache, this.uri) { ShortName = "TXT" };
            this.simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), this.cache, this.uri) {ShortName = "SIMPLE" };

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
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri);
            
            Assert.That(() => rule.Verify(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatIfCategoryNotSetOnRuleInvalidOperationIsThrown()
        {
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri);
            Assert.That(() => rule.Verify(this.iteration), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatIfNoElementDefinitionsAreContainedByIterationNoViolationIsReturned()
        {
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri)
            {
                Category = this.productCategory
            };
            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfNoParameterTypesSpecifiedNoViolationIsReturned()
        {
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri)
                        {
                            Category = this.productCategory
                        };

            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                Name = "Battery",
                ShortName = "BAT"
            };
            elementDefinition.Category.Add(this.batteryCategory);
            this.iteration.Element.Add(elementDefinition);

            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }

        [Test]
        public void VerifyThatIfElementDefinitionIsCategprizedAndParametersAreMissionAViolationIsReturned()
        {
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri)
                           {
                               Category = this.productCategory
                           };
            rule.ParameterType.Add(this.textParameterType);
            rule.ParameterType.Add(this.simpleQuantityKind);

            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
                                        {
                                            Name = "Battery",
                                            ShortName = "BAT"
                                        };
            elementDefinition.Category.Add(this.batteryCategory);
            this.iteration.Element.Add(elementDefinition);

            var violations = rule.Verify(this.iteration);

            Assert.IsNotEmpty(violations);

            var violation = violations.Single();
            violation.ViolatingThing.Contains(elementDefinition.Iid);

            Assert.IsTrue(violation.Description.Contains("does not contain parameters that reference the following parameter types"));
        }

        [Test]
        public void VerifyThatIfElementDefinitionContainsCorrectParametersNoViolationIsReturned()
        {
            var rule = new ParameterizedCategoryRule(Guid.NewGuid(), this.cache, this.uri)
            {
                Category = this.productCategory
            };
            rule.ParameterType.Add(this.textParameterType);
            rule.ParameterType.Add(this.simpleQuantityKind);

            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                Name = "Battery",
                ShortName = "BAT"
            };

            var textParameter = new Parameter(Guid.NewGuid(), this.cache, this.uri);
            textParameter.ParameterType = this.textParameterType;
            var simpleParameter = new Parameter(Guid.NewGuid(), this.cache, this.uri);
            simpleParameter.ParameterType = simpleQuantityKind;

            elementDefinition.Parameter.Add(textParameter);
            elementDefinition.Parameter.Add(simpleParameter);

            elementDefinition.Category.Add(this.batteryCategory);
            this.iteration.Element.Add(elementDefinition);

            var violations = rule.Verify(this.iteration);

            Assert.IsEmpty(violations);
        }
    }
}
