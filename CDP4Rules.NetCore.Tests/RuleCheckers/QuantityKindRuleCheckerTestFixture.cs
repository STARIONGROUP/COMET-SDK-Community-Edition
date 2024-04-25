// <copyright file="QuantityKindRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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

        [Test]
        public void Verify_that_when_the_DefaultScale_is_not_in_the_PossibleScales_a_result_is_returned()
        {
            var ratioScale_1 = new RatioScale { Iid = Guid.Parse("9fd6eb4f-5fb8-469f-8798-20bf4dd84e95"), ShortName = "scale_1" };
            var ratioScale_2 = new RatioScale { Iid = Guid.Parse("eed266d7-3ce5-4117-8ca4-2db316ec9cc6"), ShortName = "scale_2" };
            var ratioScale_3 = new RatioScale { Iid = Guid.Parse("918abf39-87af-4305-91e8-28c17ab274b2"), ShortName = "scale_3" };

            var sqk = new SimpleQuantityKind();
            sqk.PossibleScale.Add(ratioScale_1);
            sqk.PossibleScale.Add(ratioScale_2);

            sqk.DefaultScale = ratioScale_3;

            var result = this.quantityKindRuleChecker.ChecksWhetherReferencedDefaultScaleIsInTheCollectionOfPossibleScales(sqk).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0750"));
            Assert.That(result.Description, Is.EqualTo("The QuantityKind.DefaultScale 918abf39-87af-4305-91e8-28c17ab274b2:scale_3 is not in the list of QuantityKind.PossibleScale"));
            Assert.That(result.Thing, Is.EqualTo(sqk));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }
        [Test]
        public void Verify_that_when_the_DefaultScale_is_in_the_PossibleScales_no_result_is_returned()
        {
            var ratioScale_1 = new RatioScale { Iid = Guid.Parse("9fd6eb4f-5fb8-469f-8798-20bf4dd84e95"), ShortName = "scale_1" };
            var ratioScale_2 = new RatioScale { Iid = Guid.Parse("eed266d7-3ce5-4117-8ca4-2db316ec9cc6"), ShortName = "scale_2" };
            var ratioScale_3 = new RatioScale { Iid = Guid.Parse("918abf39-87af-4305-91e8-28c17ab274b2"), ShortName = "scale_3" };

            var sqk = new SimpleQuantityKind();
            sqk.PossibleScale.Add(ratioScale_1);
            sqk.PossibleScale.Add(ratioScale_2);
            sqk.PossibleScale.Add(ratioScale_3);

            sqk.DefaultScale = ratioScale_3;

            var results = this.quantityKindRuleChecker.ChecksWhetherReferencedDefaultScaleIsInTheCollectionOfPossibleScales(sqk);

            Assert.That(results, Is.Empty);
        }

    }
}