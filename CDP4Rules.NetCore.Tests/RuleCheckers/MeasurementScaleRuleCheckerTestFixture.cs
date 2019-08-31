// <copyright file="MeasurementScaleRuleChecker.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="MeasurementScaleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class MeasurementScaleRuleCheckerTestFixture
    {
        private MeasurementScaleRuleChecker measurementScaleRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private RatioScale ratioScale;

        [SetUp]
        public void SetUp()
        {
            this.measurementScaleRuleChecker = new MeasurementScaleRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.ratioScale = new RatioScale() {Iid = Guid.NewGuid()};

            this.siteReferenceDataLibrary.Scale.Add(this.ratioScale);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.measurementScaleRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_MeasurementScale_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.measurementScaleRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementUnit_is_not_in_chain_of_rdls_result_is_returned()
        {
            var unit = new SimpleUnit { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SIMPLE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Unit.Add(unit);

            this.ratioScale.Unit = unit;

            var first = this.measurementScaleRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(this.ratioScale).First();

            Assert.That(first.Id, Is.EqualTo("MA-0240"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementUnit 1191838a-0f9f-4d2c-8369-cf729d281dee:SIMPLE of MeasurementScale.Unit is not in the chain of Reference Data Libraries"));
            Assert.That(first.Thing, Is.EqualTo(this.ratioScale));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementUnit_is_in_chain_of_rdls_no_result_is_returned()
        {
            var unit = new SimpleUnit { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SIMPLE" };
            this.siteReferenceDataLibrary.Unit.Add(unit);

            this.ratioScale.Unit = unit;

            var results = this.measurementScaleRuleChecker.CheckWhetherReferencedMeasurementUnitIsInChainOfRdls(this.ratioScale);

            Assert.That(results, Is.Empty);
        }
    }
}