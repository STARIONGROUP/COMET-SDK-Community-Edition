// <copyright file="ParameterizedCategoryRuleRuleCheckerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterizedCategoryRuleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterizedCategoryRuleRuleCheckerTestFixture
    {
        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private ParameterizedCategoryRule parameterizedCategoryRule;

        private ParameterizedCategoryRuleRuleChecker parameterizedCategoryRuleRuleChecker;

        [SetUp]
        public void SetUp()
        {
            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.parameterizedCategoryRule = new ParameterizedCategoryRule{Iid = Guid.Parse("27fc9848-a2cd-4ecd-a4d0-dae1f87cb659"), ShortName = "RULE"};
            this.siteReferenceDataLibrary.Rule.Add(this.parameterizedCategoryRule);

            this.parameterizedCategoryRuleRuleChecker = new ParameterizedCategoryRuleRuleChecker();
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoriesAreInChainOfRdls_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoriesAreInChainOfRdls_is_called_with_incorrect_thing_exception_thrown()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(elementDefinition));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_not_in_chain_of_rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var category = new Category {Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"), ShortName = "PROD"};
            otherSiteReferenceDataLibrary.DefinedCategory.Add(category);

            this.parameterizedCategoryRule.Category = category;

            var results = this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.parameterizedCategoryRule);
            var result = results.First();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The ParameterizedCategoryRule.Category df9031c7-85f2-4728-b303-146835e97fc3:PROD of 27fc9848-a2cd-4ecd-a4d0-dae1f87cb659:RULE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.parameterizedCategoryRule));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_in_chain_of_rdls_no_result_is_returned()
        {
            var category = new Category { Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"), ShortName = "PROD" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(category);
            this.parameterizedCategoryRule.Category = category;

            var results = this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.parameterizedCategoryRule);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_nukll_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_non_ParameterizedCategoryRule_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_not_in_chain_of_rdl_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var parameterType = new TextParameterType { Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"), ShortName = "TEXT" };
            otherSiteReferenceDataLibrary.ParameterType.Add(parameterType);

            this.parameterizedCategoryRule.ParameterType.Add(parameterType);

            var result = this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameterizedCategoryRule).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType df9031c7-85f2-4728-b303-146835e97fc3:TEXT is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.parameterizedCategoryRule));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_in_chain_of_rdl_no_result_is_returned()
        {
            var parameterType = new TextParameterType { Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"), ShortName = "TEXT" };
            this.siteReferenceDataLibrary.ParameterType.Add(parameterType);

            this.parameterizedCategoryRule.ParameterType.Add(parameterType);

            var results = this.parameterizedCategoryRuleRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameterizedCategoryRule);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var category = new Category
            {
                Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"),
                ShortName = "PROD",
                IsDeprecated = true
            };
            this.parameterizedCategoryRule.Category = category;

            var parameterType = new TextParameterType
            {
                Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"),
                ShortName = "TEXT",
                IsDeprecated = true
            };
            this.parameterizedCategoryRule.ParameterType.Add(parameterType);

            var results = this.parameterizedCategoryRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.parameterizedCategoryRule);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced Category df9031c7-85f2-4728-b303-146835e97fc3:PROD of ParameterizedCategoryRule.Category is deprecated"));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(first.Thing, Is.EqualTo(this.parameterizedCategoryRule));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0500"));
            Assert.That(last.Description, Is.EqualTo("The referenced ParameterType df9031c7-85f2-4728-b303-146835e97fc3:TEXT in ParameterizedCategoryRule.ParameterType is deprecated"));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(last.Thing, Is.EqualTo(this.parameterizedCategoryRule));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var category = new Category
            {
                Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"),
                ShortName = "PROD",
                IsDeprecated = false
            };
            this.parameterizedCategoryRule.Category = category;

            var parameterType = new TextParameterType
            {
                Iid = Guid.Parse("df9031c7-85f2-4728-b303-146835e97fc3"),
                ShortName = "TEXT",
                IsDeprecated = false
            };
            this.parameterizedCategoryRule.ParameterType.Add(parameterType);

            var results = this.parameterizedCategoryRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.parameterizedCategoryRule);

            Assert.That(results, Is.Empty);
        }
    }
}