// <copyright file="ScaleReferenceQuantityValueRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ScaleReferenceQuantityValueRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ScaleReferenceQuantityValueRuleCheckerTestFixture
    {
        private ScaleReferenceQuantityValueRuleChecker scaleReferenceQuantityValueRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private LogarithmicScale logarithmicScale;

        private ScaleReferenceQuantityValue scaleReferenceQuantityValue;

        [SetUp]
        public void SetUp()
        {
            this.scaleReferenceQuantityValueRuleChecker = new ScaleReferenceQuantityValueRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.logarithmicScale = new LogarithmicScale {Iid = Guid.NewGuid()};
            this.scaleReferenceQuantityValue = new ScaleReferenceQuantityValue();

            this.siteReferenceDataLibrary.Scale.Add(this.logarithmicScale);
            this.logarithmicScale.ReferenceQuantityValue.Add(this.scaleReferenceQuantityValue);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.scaleReferenceQuantityValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_ScaleReferenceQuantityValue_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.scaleReferenceQuantityValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);

            this.scaleReferenceQuantityValue.Scale = scale;

            var first = this.scaleReferenceQuantityValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.scaleReferenceQuantityValue).First();
            
            Assert.That(first.Id, Is.EqualTo("MA-0230"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE of ScaleReferenceQuantityValue.Scale is not in the chain of Reference Data Libraries"));
            Assert.That(first.Thing, Is.EqualTo(this.scaleReferenceQuantityValue));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            this.siteReferenceDataLibrary.Scale.Add(scale);

            this.scaleReferenceQuantityValue.Scale = scale;

            var results = this.scaleReferenceQuantityValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.scaleReferenceQuantityValue);

            Assert.That(results, Is.Empty);
        }
    }
}