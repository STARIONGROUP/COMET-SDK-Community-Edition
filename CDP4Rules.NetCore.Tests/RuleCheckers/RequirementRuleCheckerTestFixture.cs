// <copyright file="RequirementRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="RequirementRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class RequirementRuleCheckerTestFixture
    {
        private RequirementRuleChecker requirementRuleChecker;

        private RequirementsSpecification requirementsSpecification;

        private Requirement requirement_1;

        private Requirement requirement_2;

        private Requirement requirement_3;

        [SetUp]
        public void SetUp()
        {
            this.requirementRuleChecker = new RequirementRuleChecker();

            this.requirementsSpecification = new RequirementsSpecification();
            this.requirement_1 = new Requirement { Iid = Guid.Parse("0816f4b2-7715-47be-88c1-514530bca0c2") };
            this.requirement_2 = new Requirement { Iid = Guid.Parse("998f7f11-0153-4331-b7ee-33e36b278d3a") };
            this.requirement_3 = new Requirement { Iid = Guid.Parse("ca3a7e32-4862-42c9-8435-b4f7dbdfac83") };

            this.requirementsSpecification.Requirement.Add(this.requirement_1);
            this.requirementsSpecification.Requirement.Add(this.requirement_2);
            this.requirementsSpecification.Requirement.Add(this.requirement_3);
        }

        [Test]
        public void Verify_when_Check_is_called_with_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.requirementRuleChecker.CheckWhetherTheRequirementShortNameIsUniqueInContainerRequirementsSpecification(null));
        }

        [Test]
        public void Verify_when_Check_is_called_with_non_Category_exception_is_thrown()
        {
            var alias = new Alias();

            Assert.Throws<ArgumentException>(() => this.requirementRuleChecker.CheckWhetherTheRequirementShortNameIsUniqueInContainerRequirementsSpecification(alias));
        }

        [Test]
        public void Verify_that_when_requirement_ShortNames_are_not_unique_within_RequirementsSpecification_result_is_returned()
        {
            this.requirement_1.ShortName = "REQ-1";
            this.requirement_2.ShortName = "REQ-1";
            this.requirement_3.ShortName = "REQ-3";

            var result = this.requirementRuleChecker.CheckWhetherTheRequirementShortNameIsUniqueInContainerRequirementsSpecification(this.requirement_1).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0800"));
            Assert.That(result.Thing, Is.EqualTo(requirement_1));
            Assert.That(result.Description, Is.EqualTo("The Requirement.ShortName is not unique within the container RequirementsSpecification: 998f7f11-0153-4331-b7ee-33e36b278d3a:REQ-1"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_requirement_ShortNames_are_unique_within_RequirementsSpecification_no_result_is_returned()
        {
            this.requirement_1.ShortName = "REQ-1";
            this.requirement_2.ShortName = "REQ-2";
            this.requirement_3.ShortName = "REQ-3";

            var results = this.requirementRuleChecker.CheckWhetherTheRequirementShortNameIsUniqueInContainerRequirementsSpecification(this.requirement_1);

            Assert.That(results, Is.Empty);
        }
    }
}