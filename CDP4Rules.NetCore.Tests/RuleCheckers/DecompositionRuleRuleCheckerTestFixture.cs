// <copyright file="DecompositionRuleRuleCheckerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    /// Suite of tests for the <see cref="DecompositionRuleRuleChecker"/> class
    /// </summary>
    [TestFixture]
    public class DecompositionRuleRuleCheckerTestFixture
    {
        private DecompositionRuleRuleChecker decompositionRuleRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private DecompositionRule decompositionRule;

        [SetUp]
        public void SetUp()
        {
            this.decompositionRuleRuleChecker = new DecompositionRuleRuleChecker();

            this.decompositionRule = new DecompositionRule
            {
                Iid = Guid.Parse("93db34a8-251d-40aa-bd68-1e38574f585a"),
                ShortName = "DECOMPRULE"
            };

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.siteReferenceDataLibrary.Rule.Add(this.decompositionRule);
        }

        [Test]
        public void Verify_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.decompositionRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_non_Category_exception_is_thrown()
        {
            var alias = new Alias();

            Assert.Throws<ArgumentException>(() => this.decompositionRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_categories_are_not_in_chain_of_Rdl_results_are_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var systemCategory = new Category {Iid = Guid.Parse("f6985d6b-9ad6-40a2-814b-c99dc6b39b2b"), ShortName = "SYS"};
            var elementCategory = new Category { Iid = Guid.Parse("e13cf5d0-473a-47d7-835a-83b237924483"), ShortName = "ELE" };

            otherSiteReferenceDataLibrary.DefinedCategory.Add(systemCategory);
            otherSiteReferenceDataLibrary.DefinedCategory.Add(elementCategory);

            this.decompositionRule.ContainingCategory = systemCategory;
            this.decompositionRule.ContainedCategory.Add(elementCategory);

            var results = this.decompositionRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.decompositionRule);

            Assert.That(results.Count(), Is.EqualTo(2));

            var first = results.First();

            Assert.That(first.Id, Is.EqualTo("MA-0200"));
            Assert.That(first.Thing, Is.EqualTo(this.decompositionRule));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(first.Description, Is.EqualTo("The ContainingCategory f6985d6b-9ad6-40a2-814b-c99dc6b39b2b:SYS of 93db34a8-251d-40aa-bd68-1e38574f585a:DECOMPRULE is not in the chain of Reference Data Libraries"));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0200"));
            Assert.That(last.Thing, Is.EqualTo(this.decompositionRule));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(last.Description, Is.EqualTo("The ContainedCategory e13cf5d0-473a-47d7-835a-83b237924483:ELE of 93db34a8-251d-40aa-bd68-1e38574f585a:DECOMPRULE is not in the chain of Reference Data Libraries"));
        }
    }
}