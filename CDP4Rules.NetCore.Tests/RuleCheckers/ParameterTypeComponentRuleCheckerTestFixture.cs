// <copyright file="ParameterTypeComponentRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="ParameterTypeComponentRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterTypeComponentRuleCheckerTestFixture
    {
        private ParameterTypeComponentRuleChecker parameterTypeComponentRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private CompoundParameterType compoundParameterType;

        private ParameterTypeComponent parameterTypeComponent;

        [SetUp]
        public void SetUp()
        {
            this.parameterTypeComponentRuleChecker = new ParameterTypeComponentRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.compoundParameterType = new CompoundParameterType {Iid = Guid.Parse("f3d7df0f-a82b-4fa6-a4b3-9978f55c7e4e") };
            this.parameterTypeComponent = new ParameterTypeComponent();

            this.siteReferenceDataLibrary.ParameterType.Add(this.compoundParameterType);
            this.compoundParameterType.Component.Add(this.parameterTypeComponent);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.parameterTypeComponentRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_ParameterTypeComponent_exception_is_thrown()
        {
            var alias = new Alias();

            Assert.Throws<ArgumentException>(() => this.parameterTypeComponentRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_not_in_chain_of_rdls_result_is_returned()
        {
            var parameterType = new TextParameterType {Iid = Guid.Parse("55e32513-9e45-4a63-8cd4-e84b2f320a8d") };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.ParameterType.Add(parameterType);

            this.parameterTypeComponent.ParameterType = parameterType;

            var result = this.parameterTypeComponentRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameterTypeComponent).First();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_in_chain_of_rdls_no_result_is_returned()
        {
            var parameterType = new TextParameterType();
            this.siteReferenceDataLibrary.ParameterType.Add(parameterType);
            this.parameterTypeComponent.ParameterType = parameterType;

            var results = this.parameterTypeComponentRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameterTypeComponent);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("833f1e3e-0b2e-49ca-b1b0-ef6d627210d0"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);
            this.parameterTypeComponent.Scale = scale;

            var result = this.parameterTypeComponentRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.parameterTypeComponent).First();

            Assert.That(result.Id, Is.EqualTo("MA-0230"));
            Assert.That(result.Description, Is.EqualTo("The referenced MeasurementScale 833f1e3e-0b2e-49ca-b1b0-ef6d627210d0:SCALE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("833f1e3e-0b2e-49ca-b1b0-ef6d627210d0"), ShortName = "SCALE" };
            this.siteReferenceDataLibrary.Scale.Add(scale);
            this.parameterTypeComponent.Scale = scale;

            var results = this.parameterTypeComponentRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.parameterTypeComponent);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var scale = new RatioScale()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "RATIO",
                IsDeprecated = true
            };

            var parameterType = new TextParameterType()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "TEXT",
                IsDeprecated = true
            };

            this.parameterTypeComponent.Scale = scale;
            this.parameterTypeComponent.ParameterType = parameterType;

            var results = this.parameterTypeComponentRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.parameterTypeComponent);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 7f1bacf8-9517-44d1-aead-6cf9c3027db7:RATIO of ParameterTypeComponent.Scale is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var second = results.ElementAt(1);
            Assert.That(second.Id, Is.EqualTo("MA-0500"));
            Assert.That(second.Description, Is.EqualTo("The referenced ParameterType 7f1bacf8-9517-44d1-aead-6cf9c3027db7:TEXT of ParameterTypeComponent.ParameterType is deprecated"));
            Assert.That(second.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(second.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var scale = new RatioScale()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "RATIO",
                IsDeprecated = false
            };

            var parameterType = new TextParameterType()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "TEXT",
                IsDeprecated = false
            };

            this.parameterTypeComponent.Scale = scale;
            this.parameterTypeComponent.ParameterType = parameterType;

            var results = this.parameterTypeComponentRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.parameterTypeComponent);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var scale = new RatioScale()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "RATIO",
                IsDeprecated = true
            };

            var parameterType = new TextParameterType()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "TEXT",
                IsDeprecated = true
            };

            this.parameterTypeComponent.Scale = scale;
            this.parameterTypeComponent.ParameterType = parameterType;
            this.compoundParameterType.IsDeprecated = true;

            var results = this.parameterTypeComponentRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.parameterTypeComponent);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_The_ParameterTypeComponent_has_a_valid_scale()
        {
            var scale = new RatioScale();
            var textParameterType = new TextParameterType();
            var simpleQuantityKind = new SimpleQuantityKind();

            this.parameterTypeComponent.Scale = scale;
            this.parameterTypeComponent.ParameterType = textParameterType;

            var result = this.parameterTypeComponentRuleChecker.ChecksWhetherTheParameterTypeComponentHasAValidScale(this.parameterTypeComponent).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0740"));
            Assert.That(result.Description, Is.EqualTo("When the referenced ParameterType is a not QuantityKind, the ParameterTypeComponent.Scale must be null"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));

            this.parameterTypeComponent.Scale = null;
            this.parameterTypeComponent.ParameterType = simpleQuantityKind;

            result = this.parameterTypeComponentRuleChecker.ChecksWhetherTheParameterTypeComponentHasAValidScale(this.parameterTypeComponent).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0740"));
            Assert.That(result.Description, Is.EqualTo("When the referenced ParameterType is a QuantityKind, the ParameterTypeComponent.Scale may not be null"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterTypeComponent));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }
    }
}