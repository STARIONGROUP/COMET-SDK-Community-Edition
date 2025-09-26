// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterSubscriptionValueSetTestFixture
    {
        private BooleanParameterType booleanParameterType;

        private ElementDefinition elementDefinition1;
        private ElementDefinition elementDefinition2;
        private ElementUsage elementUsage;
        private ParameterOverride parameterOverride;
        private Parameter parameter;

        private ParameterSubscriptionValueSet parameterSubscriptionValueSet;
        private ParameterValueSetBase parameterValueSetBase;
        private ParameterSubscription parameterSubscription;

        [SetUp]
        public void Setup()
        {
            this.booleanParameterType = new BooleanParameterType(Guid.NewGuid(), null, null) { ShortName = "bool" };

            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = "Sat" };
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = "Bat" };
            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null)
            {
                ShortName = "battery_1",
                ElementDefinition = this.elementDefinition2
            };
            this.elementDefinition1.ContainedElement.Add(this.elementUsage);
            this.parameter = new Parameter(Guid.NewGuid(), null, null);
            this.parameter.ParameterType = this.booleanParameterType;
            this.elementDefinition2.Parameter.Add(this.parameter);
            this.parameterOverride = new ParameterOverride(Guid.NewGuid(), null, null);
            this.parameterOverride.Parameter = this.parameter;

            this.parameterSubscriptionValueSet = new ParameterSubscriptionValueSet();
            this.parameterValueSetBase = new ParameterValueSet();
            this.parameterValueSetBase.Published = new ValueArray<string>(new List<string> { "computed" });
            this.parameterValueSetBase.Computed = new ValueArray<string>(new List<string> { "computed" });
            this.parameterValueSetBase.Reference = new ValueArray<string>(new List<string> { "ref" });
            this.parameterValueSetBase.ActualState = new ActualFiniteState();
            this.parameterValueSetBase.ActualOption = new Option();

            this.parameterSubscriptionValueSet.SubscribedValueSet = this.parameterValueSetBase;
            this.parameterSubscriptionValueSet.Manual = new ValueArray<string>(new List<string> { "manual" });

            this.parameterSubscription = new ParameterSubscription();
            this.parameterSubscription.ValueSet.Add(this.parameterSubscriptionValueSet);
            this.parameterSubscription.Owner = new DomainOfExpertise();
        }

        [Test]
        public void TestGetComputed()
        {
            Assert.That(ReferenceEquals(this.parameterValueSetBase.Published, this.parameterSubscriptionValueSet.Computed), Is.True);
        }

        [Test]
        public void TestGetReference()
        {
            Assert.That(this.parameterSubscriptionValueSet.Reference[0], Is.EqualTo("ref"));
        }

        [Test]
        public void TestGetActualValue()
        {
            this.parameterSubscriptionValueSet.ValueSwitch = ParameterSwitchKind.COMPUTED;
            Assert.That(this.parameterSubscriptionValueSet.ActualValue[0], Is.EqualTo("computed"));

            this.parameterSubscriptionValueSet.ValueSwitch = ParameterSwitchKind.REFERENCE;
            Assert.That(this.parameterSubscriptionValueSet.ActualValue[0], Is.EqualTo("ref"));

            this.parameterSubscriptionValueSet.ValueSwitch = ParameterSwitchKind.MANUAL;
            Assert.That(this.parameterSubscriptionValueSet.ActualValue[0], Is.EqualTo("manual"));
        }

        [Test]
        public void TestGetActualState()
        {
            Assert.That(ReferenceEquals(this.parameterValueSetBase.ActualState, this.parameterSubscriptionValueSet.ActualState), Is.True);
        }

        [Test]
        public void TestGetActualOption()
        {
            Assert.That(ReferenceEquals(this.parameterValueSetBase.ActualOption, this.parameterSubscriptionValueSet.ActualOption), Is.True);
        }

        [Test]
        public void TestGetOwner()
        {
            Assert.That(ReferenceEquals(this.parameterSubscription.Owner, this.parameterSubscriptionValueSet.Owner), Is.True);
        }

        [Test]
        public void TestGetOwnerThrowsException()
        {
            this.parameterSubscriptionValueSet = new ParameterSubscriptionValueSet();

            Assert.That(() =>
            {
                Console.WriteLine(this.parameterSubscriptionValueSet.Owner);
            }, Throws.TypeOf<ContainmentException>());
        }

        [Test]
        public void VerifyThatParameterSubscriptionModelCodeReturnsExpectedResult()
        {
            var parameterValueSet = new ParameterValueSet();
            this.parameter.ValueSet.Add(parameterValueSet);

            var subscription = new ParameterSubscription();
            var subscriptionValueSet = new ParameterSubscriptionValueSet();
            subscription.ValueSet.Add(subscriptionValueSet);

            subscriptionValueSet.SubscribedValueSet = parameterValueSet;

            this.parameter.ParameterSubscription.Add(subscription);

            Assert.That(subscriptionValueSet.ModelCode(0), Is.EqualTo(@"Bat.bool"));
        }

        [Test]
        public void VerifyThatParameterOverrideSubscriptionModelCodeReturnsExpectedResult()
        {
            var parameterOverride = new ParameterOverride();
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverride.Parameter = this.parameter;

            var subscription = new ParameterSubscription();
            var subscriptionValueSet = new ParameterSubscriptionValueSet();
            subscription.ValueSet.Add(subscriptionValueSet);

            subscriptionValueSet.SubscribedValueSet = parameterOverrideValueSet;

            parameterOverride.ParameterSubscription.Add(subscription);

            Assert.That(subscriptionValueSet.ModelCode(0), Is.EqualTo(@"Sat.battery_1.bool"));
        }

        [Test]
        public void VerifyThatCloneWithCloneValueArrayReturnsCloneWithNewValueArrays()
        {
            var manualValue = "manual";
            var newManualValue = "new manual";

            var manualValueArray = new ValueArray<string>(new List<string> { manualValue });

            this.parameterSubscriptionValueSet.Manual = manualValueArray;

            Assert.That(this.parameterSubscriptionValueSet.Manual[0], Is.EqualTo(manualValue));

            var clone = this.parameterSubscriptionValueSet.Clone(false);
            clone.Manual[0] = newManualValue;

            Assert.That(clone.Manual[0], Is.EqualTo(newManualValue));
            Assert.That(this.parameterSubscriptionValueSet.Manual[0], Is.EqualTo(manualValue));
        }

        [Test]
        public void Verify_that_Validate_poco_returns_errors_when_size_of_valuearray_is_incorrect()
        {
            var component_1 = new ParameterTypeComponent(Guid.NewGuid(), null, null);
            component_1.ParameterType = this.booleanParameterType;

            var component_2 = new ParameterTypeComponent(Guid.NewGuid(), null, null);
            component_2.ParameterType = this.booleanParameterType;

            var compoundParameterType = new CompoundParameterType(Guid.NewGuid(), null, null);
            compoundParameterType.Component.Add(component_1);
            compoundParameterType.Component.Add(component_2);

            var parameter = new Parameter(Guid.NewGuid(), null, null) { ParameterType = compoundParameterType };

            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(), null, null);
            var parameterSubscriptionValueSet = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null);
            parameterSubscriptionValueSet.Manual = new ValueArray<string>(new List<string> { "true", "false" });

            parameterSubscriptionValueSet.SubscribedValueSet = new ParameterValueSet(Guid.NewGuid(), null, null);

            parameterSubscription.ValueSet.Add(parameterSubscriptionValueSet);

            parameter.ParameterSubscription.Add(parameterSubscription);

            parameterSubscriptionValueSet.ValidatePoco();

            var errors = parameterSubscriptionValueSet.ValidationErrors;

            Assert.That(errors.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Verify_that_Manual_value_can_be_reset()
        {
            var defaultValueArray = new ValueArray<string>(new List<string> { "-" });

            var p = new Parameter(Guid.NewGuid(), null, null);
            p.ParameterType = this.booleanParameterType;

            var ps = new ParameterSubscription(Guid.NewGuid(), null, null);
            var psvs = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null);
            ps.ValueSet.Add(psvs);
            p.ParameterSubscription.Add(ps);

            psvs.ResetManual();
            Assert.That(psvs.Manual, Is.EqualTo(defaultValueArray));

            psvs.ResetManual();
            Assert.That(psvs.Manual, Is.EqualTo(defaultValueArray));
        }

        [Test]
        public void Verify_that_ResetComputed_throws_exception()
        {
            var psvs = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null);
            Assert.That(() => psvs.ResetComputed(), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void Verify_that_ResetReference_throws_exception()
        {
            var psvs = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null);
            Assert.That(() => psvs.ResetReference(), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void Verify_that_ResetFormula_throws_exception()
        {
            var psvs = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null);
            Assert.That(() => psvs.ResetFormula(), Throws.TypeOf<NotSupportedException>());
        }
    }
}