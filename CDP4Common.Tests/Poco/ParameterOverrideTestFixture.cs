﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideTestFixture.cs" company="Starion Group S.A.">
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

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterOverrideTestFixture
    {
        private ElementDefinition elementDefinition1;
        private ElementDefinition elementDefinition2;
        private ElementUsage elementUsage;
        private ParameterOverride parameterOverride;
        private Parameter parameter;

        private DomainOfExpertise domain;
        private Iteration iteration;
        private Option option1;
        private Option option2;
        private PossibleFiniteStateList possibleList;
        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;
        private ActualFiniteStateList actualList;
        private ActualFiniteState actualState1;
        private ActualFiniteState actualState2;

        [SetUp]
        public void Setup()
        {
            this.domain = new DomainOfExpertise(Guid.NewGuid(), null, null) { Name = "domain", ShortName = "d" };
            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { Owner = this.domain, ShortName = "Sat" };
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null) { Owner = this.domain, ShortName = "Bat" };

            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null)
            {
                ShortName = "battery_1",
                ElementDefinition = this.elementDefinition2
            };

            this.elementDefinition1.ContainedElement.Add(this.elementUsage);

            this.parameterOverride = new ParameterOverride(Guid.NewGuid(), null, null) { Owner = this.domain };
            this.parameter = new Parameter(Guid.NewGuid(), null, null) { Owner = this.domain };
            this.parameter.ParameterType = new BooleanParameterType(Guid.NewGuid(), null, null) { ShortName = "bool" };
            this.parameter.IsOptionDependent = true;
            this.parameter.Scale = new LogarithmicScale(Guid.NewGuid(), null, null);
            this.parameter.StateDependence = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.parameter.Group = new ParameterGroup(Guid.NewGuid(), null, null);

            this.parameterOverride.Parameter = this.parameter;

            this.elementDefinition2.Parameter.Add(this.parameter);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.option1 = new Option(Guid.NewGuid(), null, null) { Name = "option1", ShortName = "o1" };
            this.option2 = new Option(Guid.NewGuid(), null, null) { Name = "option2", ShortName = "o2" };

            this.possibleList = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "possible list", ShortName = "pl" };
            this.possibleState1 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "ps1", ShortName = "ps1" };
            this.possibleState2 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "ps2", ShortName = "ps2" };
            this.possibleList.PossibleState.Add(this.possibleState1);
            this.possibleList.PossibleState.Add(this.possibleState2);

            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList);
            this.actualState1 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualState1.PossibleState.Add(this.possibleState1);
            this.actualState2 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualState2.PossibleState.Add(this.possibleState2);
            this.actualList.ActualState.Add(this.actualState1);
            this.actualList.ActualState.Add(this.actualState2);

            this.iteration.Option.Add(this.option1);
            this.iteration.Option.Add(this.option2);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList);
            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.Element.Add(this.elementDefinition1);
            this.iteration.Element.Add(this.elementDefinition2);

            this.elementUsage.ParameterOverride.Add(this.parameterOverride);
        }

        [Test]
        public void TestGets()
        {
            Assert.That(ReferenceEquals(this.parameter.ParameterType, this.parameterOverride.ParameterType), Is.True);
            Assert.That(this.parameterOverride.IsOptionDependent, Is.EqualTo(this.parameter.IsOptionDependent));
            Assert.That(ReferenceEquals(this.parameter.Scale, this.parameterOverride.Scale), Is.True);
            Assert.That(ReferenceEquals(this.parameter.StateDependence, this.parameterOverride.StateDependence), Is.True);
            Assert.That(ReferenceEquals(this.parameter.Group, this.parameterOverride.Group), Is.True);
        }

        [Test]
        public void VerifyThatScalarParameterOverrideReturnsExpectedModelCode()
        {
            var parameterOverride = new ParameterOverride { Parameter = this.parameter };
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            Assert.That( parameterOverride.ModelCode(), Is.EqualTo("Sat.battery_1.bool"));
        }

        [Test]
        public void VerifyThatCompoundParameterOverrideReturnsExpectedModelCode()
        {
            var simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null) { ShortName = "l" };

            var compoundParameterType = new CompoundParameterType(Guid.NewGuid(), null, null);
            compoundParameterType.ShortName = "coord";
            var component = new ParameterTypeComponent(Guid.NewGuid(), null, null) { ParameterType = simpleQuantityKind };
            component.ShortName = "x";
            compoundParameterType.Component.Add(component);

            this.parameter.ParameterType = compoundParameterType;

            var parameterOverride = new ParameterOverride { Parameter = this.parameter };

            this.elementUsage.ParameterOverride.Add(parameterOverride);

            Assert.That(parameterOverride.ModelCode(0), Is.EqualTo("Sat.battery_1.coord.x"));
        }

        [Test]
        public void VerifyThatCompoundParameterOverrideReturnsExpectedModelCodeNoComponent()
        {
            var simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null) { ShortName = "l" };

            var compoundParameterType = new CompoundParameterType(Guid.NewGuid(), null, null);
            compoundParameterType.ShortName = "coord";
            var component = new ParameterTypeComponent(Guid.NewGuid(), null, null) { ParameterType = simpleQuantityKind };
            component.ShortName = "x";
            compoundParameterType.Component.Add(component);

            this.parameter.ParameterType = compoundParameterType;

            var parameterOverride = new ParameterOverride { Parameter = this.parameter };

            this.elementUsage.ParameterOverride.Add(parameterOverride);

            Assert.That(parameterOverride.ModelCode(), Is.EqualTo("Sat.battery_1.coord"));
        }

        [Test]
        public void VerifyThatExpectedExceptionIsThrownWhenComponentIndexIsSuppliedForScalarParameterType()
        {
            var parameterOverride = new ParameterOverride { Parameter = this.parameter };
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            Assert.That(() => parameterOverride.ModelCode(1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void VerifyThatWhenContainmentNotSetAContainmentExceptionIsThrown()
        {
            var parameterOverride = new ParameterOverride { Parameter = this.parameter };
            Assert.That(() => parameterOverride.ModelCode(), Throws.TypeOf<ContainmentException>());
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet()
        {
            // no option, no state
            this.parameterOverride.ValidatePoco();
            Assert.That(this.parameterOverride.ValidationErrors, Is.Not.Empty);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet2()
        {
            // option/State dependent
            this.parameter.IsOptionDependent = true;
            this.parameter.StateDependence = this.actualList;

            this.parameterOverride.ValidatePoco();
            Assert.That(this.parameterOverride.ValidationErrors, Is.Not.Empty);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet3()
        {
            // option dependent
            this.parameter.IsOptionDependent = true;

            this.parameterOverride.ValidatePoco();
            Assert.That(this.parameterOverride.ValidationErrors, Is.Not.Empty);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet4()
        {
            // State dependent
            this.parameter.StateDependence = this.actualList;

            this.parameterOverride.ValidatePoco();
            Assert.That(this.parameterOverride.ValidationErrors, Is.Not.Empty);
        }

        [Test]
        public void VerifyThatParameterWithEmptyArrayValueSetHasError()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterOverrideValueSet(Guid.NewGuid(), null, null) { ParameterValueSet = valuesetoverriden };
            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = null;

            this.parameterOverride.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.parameterOverride.ValidatePoco();

            Assert.That(this.parameterOverride.ValidationErrors, Is.Not.Empty);
        }

        [Test]
        public void VerifyThatParameterHasNoError()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterOverrideValueSet(Guid.NewGuid(), null, null) { ParameterValueSet = valuesetoverriden };
            var data = new List<string> { "-" };
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = null;

            this.parameterOverride.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.parameterOverride.ValidatePoco();

            Assert.That(this.parameterOverride.ValidationErrors, Is.Empty);
        }

        [Test]
        public void VerifyThatCanBePublishedReturnsExpectedResult()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterOverrideValueSet(Guid.NewGuid(), null, null) { ParameterValueSet = valuesetoverriden };
            var data = new List<string> { "-" };
            valueset.ValueSwitch = ParameterSwitchKind.MANUAL;
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.parameterOverride.ValueSet.Add(valueset);

            Assert.That(this.parameterOverride.CanBePublished, Is.False);

            var updatedData = new List<string> { "1" };
            valueset.Manual = new ValueArray<string>(updatedData);

            Assert.That(this.parameterOverride.CanBePublished, Is.True);
        }

        [Test]
        public void VerifyThatToBePublishedReturnsExpectedResult()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterOverrideValueSet(Guid.NewGuid(), null, null) { ParameterValueSet = valuesetoverriden };
            var data = new List<string> { "-" };
            valueset.ValueSwitch = ParameterSwitchKind.MANUAL;
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.parameterOverride.ValueSet.Add(valueset);

            Assert.That(this.parameterOverride.ToBePublished, Is.False);

            this.parameterOverride.ToBePublished = true;

            Assert.That(this.parameterOverride.ToBePublished, Is.False);

            var updatedData = new List<string> { "1" };
            valueset.Manual = new ValueArray<string>(updatedData);

            Assert.That(this.parameterOverride.ToBePublished, Is.True);
        }

        [Test]
        public void Verify_that_Manual_Value_can_be_reset()
        {
            var defaultValueArray = new ValueArray<string>(new List<string> { "-" });

            var parameterOverrideValueSet = new ParameterOverrideValueSet(Guid.NewGuid(), null, null);
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ResetManual();
            Assert.That(parameterOverrideValueSet.Manual, Is.EqualTo(defaultValueArray));

            parameterOverrideValueSet.ResetManual();
            Assert.That(parameterOverrideValueSet.Manual, Is.EqualTo(defaultValueArray));
        }

        [Test]
        public void Verify_that_Computed_Value_can_be_reset()
        {
            var defaultValueArray = new ValueArray<string>(new List<string> { "-" });

            var parameterOverrideValueSet = new ParameterOverrideValueSet(Guid.NewGuid(), null, null);
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ResetComputed();
            Assert.That(parameterOverrideValueSet.Computed, Is.EqualTo(defaultValueArray));

            parameterOverrideValueSet.ResetComputed();
            Assert.That(parameterOverrideValueSet.Computed, Is.EqualTo(defaultValueArray));
        }

        [Test]
        public void Verify_that_Formula_Value_can_be_reset()
        {
            var defaultValueArray = new ValueArray<string>(new List<string> { "-" });

            var parameterOverrideValueSet = new ParameterOverrideValueSet(Guid.NewGuid(), null, null);
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ResetFormula();
            Assert.That(parameterOverrideValueSet.Formula, Is.EqualTo(defaultValueArray));

            parameterOverrideValueSet.ResetFormula();
            Assert.That(parameterOverrideValueSet.Formula, Is.EqualTo(defaultValueArray));
        }

        [Test]
        public void Verify_that_Reference_Value_can_be_reset()
        {
            var defaultValueArray = new ValueArray<string>(new List<string> { "-" });

            var parameterOverrideValueSet = new ParameterOverrideValueSet(Guid.NewGuid(), null, null);
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ResetReference();
            Assert.That(parameterOverrideValueSet.Reference, Is.EqualTo(defaultValueArray));

            parameterOverrideValueSet.ResetReference();
            Assert.That(parameterOverrideValueSet.Reference, Is.EqualTo(defaultValueArray));
        }
    }
}