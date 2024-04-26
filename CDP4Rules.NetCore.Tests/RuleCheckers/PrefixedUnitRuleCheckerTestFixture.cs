// <copyright file="PrefixedUnitRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="PrefixedUnitRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class PrefixedUnitRuleCheckerTestFixture
    {
        private PrefixedUnitRuleChecker prefixedUnitRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private PrefixedUnit prefixedUnit;

        [SetUp]
        public void SetUp()
        {
            this.prefixedUnitRuleChecker = new PrefixedUnitRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();

            this.prefixedUnit = new PrefixedUnit();

            this.siteReferenceDataLibrary.Unit.Add(this.prefixedUnit);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.prefixedUnitRuleChecker.CheckWhetherReferencedUnitPrefixIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_ParameterTypeComponent_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.prefixedUnitRuleChecker.CheckWhetherReferencedUnitPrefixIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_UnitPrefix_is_not_in_chain_of_rdls_result_is_returned()
        {
            var unitPrefix = new UnitPrefix { Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d"), ShortName = "PRE"};
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.UnitPrefix.Add(unitPrefix);

            this.prefixedUnit.Prefix = unitPrefix;

            var result = this.prefixedUnitRuleChecker.CheckWhetherReferencedUnitPrefixIsInChainOfRdls(this.prefixedUnit).First();

            Assert.That(result.Id, Is.EqualTo("MA-0270"));
            Assert.That(result.Description, Is.EqualTo("The referenced UnitPrefix 55e32513-9e45-4a63-8cd4-e84b2f320a8d:PRE of PrefixedUnit.Prefix is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.prefixedUnit));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_UnitPrefix_is_in_chain_of_rdls_no_result_is_returned()
        {
            var unitPrefix = new UnitPrefix { Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d") };
            this.siteReferenceDataLibrary.UnitPrefix.Add(unitPrefix);
            this.prefixedUnit.Prefix = unitPrefix;

            var results = this.prefixedUnitRuleChecker.CheckWhetherReferencedUnitPrefixIsInChainOfRdls(this.prefixedUnit);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var unitPrefix = new UnitPrefix
            {
                Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d"),
                ShortName = "PRE",
                IsDeprecated = true
            };

            this.siteReferenceDataLibrary.UnitPrefix.Add(unitPrefix);
            this.prefixedUnit.Prefix = unitPrefix;

            var result = this.prefixedUnitRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.prefixedUnit).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0500"));
            Assert.That(result.Description, Is.EqualTo("The referenced UnitPrefix 55e32513-9e45-4a63-8cd4-e84b2f320a8d:PRE of PrefixedUnit.Prefix is deprecated"));
            Assert.That(result.Thing, Is.EqualTo(this.prefixedUnit));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var unitPrefix = new UnitPrefix
            {
                Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d"),
                ShortName = "PRE",
                IsDeprecated = false
            };

            this.siteReferenceDataLibrary.UnitPrefix.Add(unitPrefix);
            this.prefixedUnit.Prefix = unitPrefix;

            var results = this.prefixedUnitRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.prefixedUnit);

            Assert.That(results, Is.Empty);
        }
    }
}