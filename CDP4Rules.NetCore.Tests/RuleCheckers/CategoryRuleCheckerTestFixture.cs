// <copyright file="CategoryRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Rules.RuleCheckers
{
    using System;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CategoryRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class CategoryRuleCheckerTestFixture
    {
        private CategoryRuleChecker categoryRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;
        private Category category_1;
        private Category category_2;
        private Category category_3;

        [SetUp]
        public void SetUp()
        {
            this.categoryRuleChecker = new CategoryRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();

            this.category_1 = new Category { Iid = Guid.Parse("da4d1677-3f02-4272-965e-7a21f6b14b60") };
            this.category_2 = new Category { Iid = Guid.Parse("f3813784-8420-452f-9f85-2c82756a4fa3") };
            this.category_3 = new Category { Iid = Guid.Parse("82b811af-5e67-4304-9dd7-cb7b9d8a5a07") };

            this.siteReferenceDataLibrary.DefinedCategory.Add(this.category_1);
            this.siteReferenceDataLibrary.DefinedCategory.Add(this.category_2);
            this.siteReferenceDataLibrary.DefinedCategory.Add(this.category_3);
        }

        [Test]
        public void Verify_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.categoryRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_when_CheckWhetherReferencedCategoryIsInChainOfRdls_is_called_with_non_Category_exception_is_thrown()
        {
            var alias = new Alias();

            Assert.Throws<ArgumentException>(() => this.categoryRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_category_is_not_in_chain_of_rdl_result_is_returned()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var category = new Category { Iid = Guid.Parse("6766cbf6-0bea-4e9d-8c86-91c5b71ae1bd"), ShortName = "CAT" };
            siteReferenceDataLibrary.DefinedCategory.Add(category);

            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var superCategory = new Category { Iid = Guid.Parse("c24a3bd3-99a8-4b18-a2f0-a7eae3f02f76"), ShortName = "SUPERCAT" };
            otherSiteReferenceDataLibrary.DefinedCategory.Add(superCategory);

            category.SuperCategory.Add(superCategory);

            var result = this.categoryRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(category).First();

            Assert.That(result.Id, Is.EqualTo("MA-0200"));
            Assert.That(result.Thing, Is.EqualTo(category));
            Assert.That(result.Description, Is.EqualTo("The superCategory c24a3bd3-99a8-4b18-a2f0-a7eae3f02f76:SUPERCAT of 6766cbf6-0bea-4e9d-8c86-91c5b71ae1bd:CAT is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_categories_are_in_the_chain_of_Rdls_no_result_is_returned()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            
            var category = new Category { Iid = Guid.Parse("6766cbf6-0bea-4e9d-8c86-91c5b71ae1bd"), ShortName = "CAT" };
            siteReferenceDataLibrary.DefinedCategory.Add(category);
            
            var superCategory = new Category { Iid = Guid.Parse("c24a3bd3-99a8-4b18-a2f0-a7eae3f02f76"), ShortName = "SUPERCAT" };
            siteReferenceDataLibrary.DefinedCategory.Add(superCategory);

            category.SuperCategory.Add(superCategory);

            var results = this.categoryRuleChecker.CheckWhetherReferencedCategoryIsInChainOfRdls(category);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_A_Category_ShortName_is_not_unique_in_the_containing_RDL_a_result_is_returned()
        {
            this.category_1.ShortName = "CAT";
            this.category_2.ShortName = "CAT";
            this.category_3.ShortName = "CAT3";

            var result = this.categoryRuleChecker.CheckWhetherTheCategoryShortNameIsUniqueInTheContainerRdl(this.category_1).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0720"));
            Assert.That(result.Description, Is.EqualTo("The Category does not have a unique ShortNames in the container Reference Data Library - f3813784-8420-452f-9f85-2c82756a4fa3:CAT"));
            Assert.That(result.Thing, Is.EqualTo(this.category_1));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_A_Category_Name_is_not_unique_in_the_containing_RDL_a_result_is_returned()
        {
            this.category_1.Name = "CAT";
            this.category_2.Name = "CAT";
            this.category_3.Name = "CAT3";

            var result = this.categoryRuleChecker.CheckWhetherTheCategoryNameIsUniqueInTheContainerRdl(this.category_1).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0730"));
            Assert.That(result.Description, Is.EqualTo("The Category does not have a unique Names in the container Reference Data Library - f3813784-8420-452f-9f85-2c82756a4fa3:CAT"));
            Assert.That(result.Thing, Is.EqualTo(this.category_1));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }
    }
}