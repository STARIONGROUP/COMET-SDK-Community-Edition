// <copyright file="QuantityKindRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="QuantityKindRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class QuantityKindRuleCheckerTestFixture
    {
        private QuantityKindRuleChecker quantityKindRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private SimpleQuantityKind simpleQuantityKind;

        [SetUp]
        public void SetUp()
        {
            this.quantityKindRuleChecker = new QuantityKindRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.simpleQuantityKind = new SimpleQuantityKind();
            
            this.siteReferenceDataLibrary.ParameterType.Add(this.simpleQuantityKind);
            
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.quantityKindRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_QuantityKind_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.quantityKindRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);

            this.simpleQuantityKind.PossibleScale.Add(scale);
            this.simpleQuantityKind.DefaultScale = scale;

            var first = this.quantityKindRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.simpleQuantityKind).First();
            var last = this.quantityKindRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.simpleQuantityKind).Last();

            Assert.That(first.Id, Is.EqualTo("MA-0230"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE in QuantityKind.PossibleScale is not in the chain of Reference Data Libraries"));
            Assert.That(first.Thing, Is.EqualTo(this.simpleQuantityKind));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));

            Assert.That(last.Id, Is.EqualTo("MA-0230"));
            Assert.That(last.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE in QuantityKind.DefaultScale is not in the chain of Reference Data Libraries"));
            Assert.That(last.Thing, Is.EqualTo(this.simpleQuantityKind));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            this.siteReferenceDataLibrary.Scale.Add(scale);

            this.simpleQuantityKind.PossibleScale.Add(scale);
            this.simpleQuantityKind.DefaultScale = scale;

            var results = this.quantityKindRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.simpleQuantityKind);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var scale = new RatioScale
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "SCALE",
                IsDeprecated = true
            };
            
            this.simpleQuantityKind.PossibleScale.Add(scale);
            this.simpleQuantityKind.DefaultScale = scale;

            var results = this.quantityKindRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.simpleQuantityKind);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE in QuantityKind.PossibleScale is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.simpleQuantityKind));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var second = results.ElementAt(1);
            Assert.That(second.Id, Is.EqualTo("MA-0500"));
            Assert.That(second.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE of QuantityKind.DefaultScale is deprecated"));
            Assert.That(second.Thing, Is.EqualTo(this.simpleQuantityKind));
            Assert.That(second.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var scale = new RatioScale
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "SCALE",
                IsDeprecated = false
            };

            this.simpleQuantityKind.PossibleScale.Add(scale);
            this.simpleQuantityKind.DefaultScale = scale;

            var results = this.quantityKindRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.simpleQuantityKind);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var scale = new RatioScale
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "SCALE",
                IsDeprecated = true
            };

            this.simpleQuantityKind.PossibleScale.Add(scale);
            this.simpleQuantityKind.DefaultScale = scale;
            this.simpleQuantityKind.IsDeprecated = true;

            var results = this.quantityKindRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.simpleQuantityKind);

            Assert.That(results, Is.Empty);
        }
    }
}