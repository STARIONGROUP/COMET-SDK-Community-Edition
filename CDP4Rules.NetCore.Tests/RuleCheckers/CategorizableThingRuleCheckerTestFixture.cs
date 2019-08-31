// <copyright file="CategorizableThingRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="CategorizableThingRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class CategorizableThingRuleCheckerTestFixture
    {
        private CategorizableThingRuleChecker categorizableThingRuleChecker;
        
        [SetUp]
        public void SetUp()
        {
            this.categorizableThingRuleChecker = new CategorizableThingRuleChecker();
        }

        [Test]
        public void Verify_that_when_CheckWhetherThereAreNoDuplicateCategoriesAreDefined_is_called_with_null_thing_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherThereAreNoDuplicateCategoriesAreDefined_is_called_with_non_categorizable_thing_exception_is_thrown()
        {
            var unit = new SimpleUnit();

            Assert.Throws<ArgumentException>(() => this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(unit));
        }

        [Test]
        public void Verify_that_whenCheckWhetherThereAreNoDuplicateCategoriesAreDefined_is_called_when_CategorizableThing_is_member_of_same_category_mroe_than_one_result_is_Returned()
        {
            var lithiumBatteries = new Category{ Iid = Guid.Parse("e89f7639-9583-4656-905c-d8908b569a82"), ShortName = "LITHIUM_BAT" };

            var elementDefinition = new ElementDefinition();
            elementDefinition.Category.Add(lithiumBatteries);
            elementDefinition.Category.Add(lithiumBatteries);

            Assert.That(elementDefinition.Category.Count, Is.EqualTo(2));

            var result = this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0300"));
            Assert.That(result.Description, 
                Is.EqualTo("The CategorizableThing is a member of the following Categories: e89f7639-9583-4656-905c-d8908b569a82; with shortNames: LITHIUM_BAT more than once"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));

            elementDefinition.Category.Clear();

            var batteries = new Category { Iid = Guid.Parse("5a16b679-a703-48a7-9994-6a7aa355395a"), ShortName = "BAT" };
            var products = new Category { Iid = Guid.Parse("09be61c4-b74e-4b97-8ff6-6e82ef93ec93"), ShortName = "PROD" };

            lithiumBatteries.SuperCategory.Add(batteries);
            batteries.SuperCategory.Add(products);

            elementDefinition.Category.Add(lithiumBatteries);
            elementDefinition.Category.Add(products);

            result = this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(elementDefinition).Single();
            Assert.That(result.Id, Is.EqualTo("MA-0300"));
            Assert.That(result.Description,
                Is.EqualTo("The CategorizableThing is a member of the following Categories: e89f7639-9583-4656-905c-d8908b569a82,09be61c4-b74e-4b97-8ff6-6e82ef93ec93; with shortNames: LITHIUM_BAT,PROD more than once"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_CategorizableThing_is_not_a_member_of_duplicate_categories_empyt_list_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            var result = this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(elementDefinition);
            Assert.That(result, Is.Empty);

            var batteries = new Category();
            elementDefinition.Category.Add(batteries);
            result = this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(elementDefinition);
            Assert.That(result, Is.Empty);

            var lithiums = new Category();
            elementDefinition.Category.Add(lithiums);
            result = this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(elementDefinition);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_when_ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory_is_called_with_null_thing_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.categorizableThingRuleChecker.ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(null));
        }

        [Test]
        public void Verify_that_when_ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory_is_called_with_non_categorizable_thing_exception_is_thrown()
        {
            var unit = new SimpleUnit();

            Assert.Throws<ArgumentException>(() => this.categorizableThingRuleChecker.ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(unit));
        }

        [Test]
        public void Verify_that_when_a_CategorizableThing_is_a_member_of_an_abstract_error_a_result_is_returned()
        {
            var product = new Category {Iid = Guid.Parse("dacef175-37e2-45ab-bd56-df0ff0c66714"), ShortName = "PROD", IsAbstract = true};

            var elementDefinition = new ElementDefinition();
            elementDefinition.Category.Add(product);

            var result = this.categorizableThingRuleChecker.ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0310"));
            Assert.That(result.Description,
                Is.EqualTo("The CategorizableThing is a member of the following abstract Categories: dacef175-37e2-45ab-bd56-df0ff0c66714; with shortNames: PROD"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_a_CategorizableThing_is_a_not_member_of_an_abstract_error_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            var result = this.categorizableThingRuleChecker.ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(elementDefinition);
            Assert.That(result, Is.Empty);

            var product = new Category { Iid = Guid.Parse("dacef175-37e2-45ab-bd56-df0ff0c66714"), ShortName = "PROD" };
            elementDefinition.Category.Add(product);
            result = this.categorizableThingRuleChecker.ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(elementDefinition);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_null_excption_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.categorizableThingRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_non_ICategorizableThing_excption_is_thrown()
        {
            var siteDirectory = new SiteDirectory();
            Assert.Throws<ArgumentException>(() => this.categorizableThingRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(siteDirectory));
        }

        [Test]
        public void Verify_that_when_a_ICategorizableThing_is_a_member_of_a_Category_that_is_not_in_the_chain_of_rdl_a_result_is_returned()
        {
            var siteReferenceDataLibrary_1 = new SiteReferenceDataLibrary();
            var category = new Category() { Iid = Guid.Parse("0b8f399c-a1b2-4993-abc3-31f2ad880936"), ShortName = "CAT" };
            siteReferenceDataLibrary_1.DefinedCategory.Add(category);

            var siteReferenceDataLibrary_2 = new SiteReferenceDataLibrary();
            var fileType = new FileType{Iid = Guid.Parse("b050b1f4-6f4d-4ee8-993b-6d3ae67bb2f0"), ShortName = "FT"};
            siteReferenceDataLibrary_2.FileType.Add(fileType);

            fileType.Category.Add(category);

            var result = this.categorizableThingRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(fileType).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The ICategorizableThing is a member of Categories that are not in the chain of Reference Data Libraries: 0b8f399c-a1b2-4993-abc3-31f2ad880936:CAT"));
            Assert.That(result.Thing, Is.EqualTo(fileType));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));

            var modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            var engineeringModel = new EngineeringModel();
            var engineeringModelSetup = new EngineeringModelSetup();
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;
            engineeringModelSetup.RequiredRdl.Add(modelReferenceDataLibrary);

            var iteration = new Iteration();
            engineeringModel.Iteration.Add(iteration);
            var elementDefinition = new ElementDefinition();
            iteration.Element.Add(elementDefinition);

            elementDefinition.Category.Add(category);

            result = this.categorizableThingRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(elementDefinition).Single();
            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Description, Is.EqualTo("The ICategorizableThing is a member of Categories that are not in the chain of Reference Data Libraries: 0b8f399c-a1b2-4993-abc3-31f2ad880936:CAT"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            var requirement = new Requirement();
            var category = new Category
            {
                Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d"),
                ShortName = "DEPRECATED",
                IsDeprecated = true
            };

            elementDefinition.Category.Add(category);
            var result = this.categorizableThingRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(elementDefinition).Single();
            Assert.That(result.Id, Is.EqualTo("MA-0500"));
            Assert.That(result.Description, Is.EqualTo("The referenced Category 55e32513-9e45-4a63-8cd4-e84b2f320a8d:DEPRECATED of ICategorizableThing.Category is deprecated"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));

            requirement.Category.Add(category);
            result = this.categorizableThingRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(requirement).Single();
            Assert.That(result.Id, Is.EqualTo("MA-0500"));
            Assert.That(result.Description, Is.EqualTo("The referenced Category 55e32513-9e45-4a63-8cd4-e84b2f320a8d:DEPRECATED of ICategorizableThing.Category is deprecated"));
            Assert.That(result.Thing, Is.EqualTo(requirement));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            var requirement = new Requirement();
            var category = new Category
            {
                Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d"),
                ShortName = "NOTDEPRECATED",
                IsDeprecated = false
            };

            elementDefinition.Category.Add(category);
            var results = this.categorizableThingRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(elementDefinition);
            Assert.That(results, Is.Empty);

            requirement.Category.Add(category);
            results = this.categorizableThingRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(requirement);
            Assert.That(results, Is.Empty);
        }
    }
}