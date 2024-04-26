// <copyright file="DomainOfExpertiseGroupRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DomainOfExpertiseGroupRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class DomainOfExpertiseGroupRuleCheckerTestFixture
    {
        private DomainOfExpertiseGroupRuleChecker domainOfExpertiseGroupRuleChecker;

        private DomainOfExpertiseGroup domainOfExpertiseGroup;

        [SetUp]
        public void SetUp()
        {
            this.domainOfExpertiseGroupRuleChecker = new DomainOfExpertiseGroupRuleChecker();

            this.domainOfExpertiseGroup = new DomainOfExpertiseGroup();
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = true
            };
            this.domainOfExpertiseGroup.Domain.Add(domainOfExpertise);

            var result = this.domainOfExpertiseGroupRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.domainOfExpertiseGroup).Single();
            Assert.That(result.Id, Is.EqualTo("MA-0500"));
            Assert.That(result.Description, Is.EqualTo("The referenced DomainOfExpertise 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SYS in DomainOfExpertiseGroup.Domain is deprecated"));
            Assert.That(result.Thing, Is.EqualTo(domainOfExpertiseGroup));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = false
            };
            this.domainOfExpertiseGroup.Domain.Add(domainOfExpertise);

            var results = this.domainOfExpertiseGroupRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.domainOfExpertiseGroup);
            Assert.That(results, Is.Empty);            
        }
    }
}