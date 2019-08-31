// <copyright file="MultiRelationshipRuleRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="MultiRelationshipRuleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class MultiRelationshipRuleRuleCheckerTestFixture
    {
        private MultiRelationshipRuleRuleChecker multiRelationshipRuleRuleChecker;

        private MultiRelationshipRule multiRelationshipRule;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        [SetUp]
        public void SetUp()
        {
            this.multiRelationshipRule = new MultiRelationshipRule{Iid = Guid.Parse("3b9f431a-7a7c-4763-9818-7e3154c70910"), ShortName = "MULTIRULE"};
            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.siteReferenceDataLibrary.Rule.Add(this.multiRelationshipRule);

            this.multiRelationshipRuleRuleChecker = new MultiRelationshipRuleRuleChecker();
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.multiRelationshipRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_non_MultiRelationshipRule_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.multiRelationshipRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_not_in_chain_of_rdls_Result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();

            var relationshipCategory = new Category {Iid = Guid.Parse("4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd"), ShortName = "MULTIRELS"};
            otherSiteReferenceDataLibrary.DefinedCategory.Add(relationshipCategory);

            var relatedCategory = new Category { Iid = Guid.Parse("7ddec22b-694d-43db-a5ba-122d10b8efaf"), ShortName = "RELATED" };
            otherSiteReferenceDataLibrary.DefinedCategory.Add(relatedCategory);

            this.multiRelationshipRule.RelationshipCategory = relationshipCategory;
            this.multiRelationshipRule.RelatedCategory.Add(relatedCategory);

            var results = this.multiRelationshipRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.multiRelationshipRule);

            var first = results.First();

            Assert.That(first.Id, Is.EqualTo("MA-0200"));
            Assert.That(first.Description, Is.EqualTo("The MultiRelationshipRule.RelationshipCategory 4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd:MULTIRELS of 3b9f431a-7a7c-4763-9818-7e3154c70910:MULTIRULE is not in the chain of Reference Data Libraries"));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(first.Thing, Is.EqualTo(this.multiRelationshipRule));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0200"));
            Assert.That(last.Description, Is.EqualTo("The MultiRelationshipRule.RelatedCategory 7ddec22b-694d-43db-a5ba-122d10b8efaf:RELATED of 3b9f431a-7a7c-4763-9818-7e3154c70910:MULTIRULE is not in the chain of Reference Data Libraries"));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(last.Thing, Is.EqualTo(this.multiRelationshipRule));
        }

        [Test]
        public void Verify_that_when_referenced_Category_is_in_chain_of_rdls_no_Result_is_returned()
        {
            var relationshipCategory = new Category { Iid = Guid.Parse("4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd"), ShortName = "MULTIRELS" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relationshipCategory);

            var relatedCategory = new Category { Iid = Guid.Parse("7ddec22b-694d-43db-a5ba-122d10b8efaf"), ShortName = "RELATED" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relatedCategory);

            this.multiRelationshipRule.RelationshipCategory = relationshipCategory;
            this.multiRelationshipRule.RelatedCategory.Add(relatedCategory);

            var results = this.multiRelationshipRuleRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(this.multiRelationshipRule);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var relationshipCategory = new Category
            {
                Iid = Guid.Parse("4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd"),
                ShortName = "MULTIRELS",
                IsDeprecated = true
            };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relationshipCategory);

            var relatedCategory = new Category
            {
                Iid = Guid.Parse("7ddec22b-694d-43db-a5ba-122d10b8efaf"),
                ShortName = "RELATED",
                IsDeprecated = true
            };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relatedCategory);

            this.multiRelationshipRule.RelationshipCategory = relationshipCategory;
            this.multiRelationshipRule.RelatedCategory.Add(relatedCategory);

            var results = this.multiRelationshipRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.multiRelationshipRule);
            
            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced Category 4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd:MULTIRELS of MultiRelationshipRule.RelationshipCategory is deprecated"));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(first.Thing, Is.EqualTo(this.multiRelationshipRule));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0500"));
            Assert.That(last.Description, Is.EqualTo("The referenced Category 7ddec22b-694d-43db-a5ba-122d10b8efaf:RELATED of MultiRelationshipRule.RelatedCategory is deprecated"));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(last.Thing, Is.EqualTo(this.multiRelationshipRule));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var relationshipCategory = new Category { Iid = Guid.Parse("4086ae01-4ee5-4c3a-89f9-bdf9b86d96dd"), ShortName = "MULTIRELS" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relationshipCategory);

            var relatedCategory = new Category { Iid = Guid.Parse("7ddec22b-694d-43db-a5ba-122d10b8efaf"), ShortName = "RELATED" };
            this.siteReferenceDataLibrary.DefinedCategory.Add(relatedCategory);

            this.multiRelationshipRule.RelationshipCategory = relationshipCategory;
            this.multiRelationshipRule.RelatedCategory.Add(relatedCategory);

            var results = this.multiRelationshipRuleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.multiRelationshipRule);

            Assert.That(results, Is.Empty);
        }
    }
}