// <copyright file="ReferencerRuleRuleChecker.cs" company="Starion Group S.A.">
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
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ReferencerRuleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ReferencerRuleRuleCheckerTestFixture
    {
        private ReferencerRuleRuleChecker referencerRuleRuleChecker;

        private ReferencerRule referencerRule;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        [SetUp]
        public void SetUp()
        {
            this.referencerRuleRuleChecker = new ReferencerRuleRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.referencerRule = new ReferencerRule {Iid = Guid.Parse("85c00539-410b-4208-8ee5-b9ee41f358db"), ShortName = "RULE"};
            this.siteReferenceDataLibrary.Rule.Add(this.referencerRule);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.referencerRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_non_MultiRelationshipRule_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.referencerRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_not_in_chain_of_rdls_Result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();

            var referencingCategory = new Category {Iid = Guid.Parse("a52085b8-6b50-4d76-b699-14b2bb0af59f"), ShortName = "referencing" };
            otherSiteReferenceDataLibrary.DefinedCategory.Add(referencingCategory);

            var referencedCategory = new Category { Iid = Guid.Parse("e0fdb079-2181-409a-ac76-256ccf5ef205"), ShortName = "referenced" };
            otherSiteReferenceDataLibrary.DefinedCategory.Add(referencedCategory);

            this.referencerRule.ReferencingCategory = referencingCategory;
            this.referencerRule.ReferencedCategory.Add(referencedCategory);

            var results = this.referencerRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.referencerRule);

            var first = results.First();

            Assert.That(first.Id, Is.EqualTo("MA-0200"));
            Assert.That(first.Description, Is.EqualTo("The ReferencerRule.RelationshipCategory a52085b8-6b50-4d76-b699-14b2bb0af59f:referencing of 85c00539-410b-4208-8ee5-b9ee41f358db:RULE is not in the chain of Reference Data Libraries"));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(first.Thing, Is.EqualTo(this.referencerRule));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0200"));
            Assert.That(last.Description, Is.EqualTo("The ReferencerRule.ReferencedCategory e0fdb079-2181-409a-ac76-256ccf5ef205:referenced of 85c00539-410b-4208-8ee5-b9ee41f358db:RULE is not in the chain of Reference Data Libraries"));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(last.Thing, Is.EqualTo(this.referencerRule));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_in_chain_of_rdls_no_Result_is_returned()
        {
            var referencingCategory = new Category { Iid = Guid.Parse("a52085b8-6b50-4d76-b699-14b2bb0af59f"), ShortName = "referencing" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(referencingCategory);

            var referencedCategory = new Category { Iid = Guid.Parse("e0fdb079-2181-409a-ac76-256ccf5ef205"), ShortName = "referenced" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(referencedCategory);

            this.referencerRule.ReferencingCategory = referencingCategory;
            this.referencerRule.ReferencedCategory.Add(referencedCategory);

            var results = this.referencerRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.referencerRule);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var referencingCategory = new Category
            {
                Iid = Guid.Parse("a52085b8-6b50-4d76-b699-14b2bb0af59f"),
                ShortName = "referencing",
                IsDeprecated = true
            };
            var referencedCategory = new Category
            {
                Iid = Guid.Parse("e0fdb079-2181-409a-ac76-256ccf5ef205"),
                ShortName = "referenced",
                IsDeprecated = true
            };
            
            this.referencerRule.ReferencingCategory = referencingCategory;
            this.referencerRule.ReferencedCategory.Add(referencedCategory);

            var results = this.referencerRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.referencerRule);

            var first = results.First();

            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced Category a52085b8-6b50-4d76-b699-14b2bb0af59f:referencing of ReferencerRule.ReferencingCategory is deprecated"));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(first.Thing, Is.EqualTo(this.referencerRule));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0500"));
            Assert.That(last.Description, Is.EqualTo("The referenced Category e0fdb079-2181-409a-ac76-256ccf5ef205:referenced in ReferencerRule.ReferencedCategory is deprecated"));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(last.Thing, Is.EqualTo(this.referencerRule));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var referencingCategory = new Category
            {
                Iid = Guid.Parse("a52085b8-6b50-4d76-b699-14b2bb0af59f"),
                ShortName = "referencing",
                IsDeprecated = false
            };
            var referencedCategory = new Category
            {
                Iid = Guid.Parse("e0fdb079-2181-409a-ac76-256ccf5ef205"),
                ShortName = "referenced",
                IsDeprecated = false
            };

            this.referencerRule.ReferencingCategory = referencingCategory;
            this.referencerRule.ReferencedCategory.Add(referencedCategory);

            var results = this.referencerRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.referencerRule);

            Assert.That(results, Is.Empty);
        }
    }
}