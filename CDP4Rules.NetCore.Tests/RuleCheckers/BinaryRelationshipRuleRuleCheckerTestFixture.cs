// <copyright file="BinaryRelationshipRuleRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BinaryRelationshipRuleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class BinaryRelationshipRuleRuleCheckerTestFixture
    {
        private BinaryRelationshipRuleRuleChecker binaryRelationshipRuleRuleChecker;

        private BinaryRelationshipRule binaryRelationshipRule;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        [SetUp]
        public void SetUp()
        {
            this.binaryRelationshipRuleRuleChecker = new BinaryRelationshipRuleRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.binaryRelationshipRule = new BinaryRelationshipRule {Iid = Guid.Parse("426f4e96-dcfd-4589-bce0-856bea40495b"), ShortName = "BINRULE" };
            this.modelReferenceDataLibrary.Rule.Add(this.binaryRelationshipRule);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoriesAreInChainOfRdls_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.binaryRelationshipRuleRuleChecker.CheckWhetherReferencedCategoriesAreInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoriesAreInChainOfRdls_is_called_with_incorrect_thing_exception_thrown()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => this.binaryRelationshipRuleRuleChecker.CheckWhetherReferencedCategoriesAreInChainOfRdls(elementDefinition));
        }

        [Test]
        public void Verify_that_when_RelationshipCategory_is_not_in_chain_of_rdl_result_is_returned()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            
            var category = new Category {Iid = Guid.Parse("e269cbd4-5b70-41ef-87ff-ceefc662a4fb"), ShortName = "CAT"};
            siteReferenceDataLibrary.DefinedCategory.Add(category);
            var sourceCategory = new Category{Iid = Guid.Parse("5d16ca08-e01d-409e-ab38-049c11a1f1fb"), ShortName = "SOURCE"};
            this.modelReferenceDataLibrary.DefinedCategory.Add(sourceCategory);
            var targetCategory = new Category {Iid = Guid.Parse("7dc45a22-3862-42a6-ae1e-1bc853c4dc94"), ShortName = "TARGET"};
            this.modelReferenceDataLibrary.DefinedCategory.Add(targetCategory);

            this.binaryRelationshipRule.RelationshipCategory = category;
            this.binaryRelationshipRule.SourceCategory = sourceCategory;
            this.binaryRelationshipRule.TargetCategory = targetCategory;

            var result = this.binaryRelationshipRuleRuleChecker.CheckWhetherReferencedCategoriesAreInChainOfRdls(this.binaryRelationshipRule).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The BinaryRelationshipRule.RelationshipCategory e269cbd4-5b70-41ef-87ff-ceefc662a4fb:CAT of 426f4e96-dcfd-4589-bce0-856bea40495b:BINRULE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationshipRule));
        }

        [Test]
        public void Verify_that_when_SourceCategory_is_not_in_chain_of_rdl_result_is_returned()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();

            var category = new Category { Iid = Guid.Parse("e269cbd4-5b70-41ef-87ff-ceefc662a4fb"), ShortName = "CAT" };
            this.modelReferenceDataLibrary.DefinedCategory.Add(category);
            var sourceCategory = new Category { Iid = Guid.Parse("5d16ca08-e01d-409e-ab38-049c11a1f1fb"), ShortName = "SOURCE" };
            siteReferenceDataLibrary.DefinedCategory.Add(sourceCategory);
            var targetCategory = new Category { Iid = Guid.Parse("7dc45a22-3862-42a6-ae1e-1bc853c4dc94"), ShortName = "TARGET" };
            this.modelReferenceDataLibrary.DefinedCategory.Add(targetCategory);

            this.binaryRelationshipRule.RelationshipCategory = category;
            this.binaryRelationshipRule.SourceCategory = sourceCategory;
            this.binaryRelationshipRule.TargetCategory = targetCategory;

            var result = this.binaryRelationshipRuleRuleChecker.CheckWhetherReferencedCategoriesAreInChainOfRdls(this.binaryRelationshipRule).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The BinaryRelationshipRule.SourceCategory 5d16ca08-e01d-409e-ab38-049c11a1f1fb:SOURCE of 426f4e96-dcfd-4589-bce0-856bea40495b:BINRULE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationshipRule));
        }

        [Test]
        public void Verify_that_when_TargetCategory_is_not_in_chain_of_rdl_result_is_returned()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();

            var category = new Category { Iid = Guid.Parse("e269cbd4-5b70-41ef-87ff-ceefc662a4fb"), ShortName = "CAT" };
            this.modelReferenceDataLibrary.DefinedCategory.Add(category);
            var sourceCategory = new Category { Iid = Guid.Parse("5d16ca08-e01d-409e-ab38-049c11a1f1fb"), ShortName = "SOURCE" };
            this.modelReferenceDataLibrary.DefinedCategory.Add(sourceCategory);
            var targetCategory = new Category { Iid = Guid.Parse("7dc45a22-3862-42a6-ae1e-1bc853c4dc94"), ShortName = "TARGET" };
            siteReferenceDataLibrary.DefinedCategory.Add(targetCategory);

            this.binaryRelationshipRule.RelationshipCategory = category;
            this.binaryRelationshipRule.SourceCategory = sourceCategory;
            this.binaryRelationshipRule.TargetCategory = targetCategory;

            var result = this.binaryRelationshipRuleRuleChecker.CheckWhetherReferencedCategoriesAreInChainOfRdls(this.binaryRelationshipRule).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The BinaryRelationshipRule.TargetCategory 7dc45a22-3862-42a6-ae1e-1bc853c4dc94:TARGET of 426f4e96-dcfd-4589-bce0-856bea40495b:BINRULE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationshipRule));
        }
    }
}