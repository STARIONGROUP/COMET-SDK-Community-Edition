// <copyright file="UnitFactorRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="UnitFactorRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class UnitFactorRuleCheckerTestFixture
    {
        private UnitFactorRuleChecker unitFactorRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private DerivedUnit derivedUnit;

        private UnitFactor unitFactor;

        [SetUp]
        public void SetUp()
        {
            this.unitFactorRuleChecker = new UnitFactorRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.derivedUnit = new DerivedUnit();
            this.unitFactor = new UnitFactor();

            this.siteReferenceDataLibrary.Unit.Add(this.derivedUnit);
            this.derivedUnit.UnitFactor.Add(this.unitFactor);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.unitFactorRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_UnitFactor_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.unitFactorRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementUnit_is_not_in_chain_of_rdls_result_is_returned()
        {
            var unit = new SimpleUnit { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SIMPLE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Unit.Add(unit);

            this.unitFactor.Unit = unit;

            var first = this.unitFactorRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(this.unitFactor).First();

            Assert.That(first.Id, Is.EqualTo("MA-0240"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementUnit 1191838a-0f9f-4d2c-8369-cf729d281dee:SIMPLE of UnitFactor.Unit is not in the chain of Reference Data Libraries"));
            Assert.That(first.Thing, Is.EqualTo(this.unitFactor));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementUnit_is_in_chain_of_rdls_no_result_is_returned()
        {
            var unit = new SimpleUnit { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SIMPLE" };
            this.siteReferenceDataLibrary.Unit.Add(unit);

            this.unitFactor.Unit = unit;

            var results = this.unitFactorRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(this.unitFactor);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var unit = new SimpleUnit()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SIMPLE",
                IsDeprecated = true
            };

            this.unitFactor.Unit = unit;

            var results = this.unitFactorRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.unitFactor);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementUnit 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SIMPLE of UnitFactor.Unit is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.unitFactor));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var unit = new SimpleUnit()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SIMPLE",
                IsDeprecated = false
            };

            this.unitFactor.Unit = unit;

            var results = this.unitFactorRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.unitFactor);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var unit = new SimpleUnit()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SIMPLE",
                IsDeprecated = true
            };

            this.unitFactor.Unit = unit;
            this.derivedUnit.IsDeprecated = true;

            var results = this.unitFactorRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.unitFactor);

            Assert.That(results, Is.Empty);
        }
    }
}