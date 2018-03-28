#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
#endregion

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using NUnit.Framework;
    using CDP4Common.Exceptions;

    /// <summary>
    /// Suite of tests for the <see cref="Parameter"/> class
    /// </summary>
    [TestFixture]
    public class ParameterTestFixture
    {
        private string edShortname;

        private ElementDefinition elementDefinition;

        private string scalarParameterTypeShortname;

        private ScalarParameterType scalarParameterType;

        private Parameter scalarParameter;

        private string compoundParameterTypeShortname;

        private CompoundParameterType compoundParameterType;
        private DomainOfExpertise domain;
        private Parameter compoundParameter;
        private Iteration iteration;
        private Option option1;
        private Option option2;
        private PossibleFiniteStateList possibleList;
        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;
        private ActualFiniteStateList actualList;
        private ActualFiniteState actualState1;
        private ActualFiniteState actualState2;
        private ParameterTypeComponent component;

        [SetUp]
        public void SetUp()
        {
            this.domain = new DomainOfExpertise(Guid.NewGuid(), null, null) { Name = "domain", ShortName = "d" };
            this.scalarParameterTypeShortname = "m";

            var simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null) { ShortName = this.scalarParameterTypeShortname };
            this.scalarParameterType = simpleQuantityKind;

            this.edShortname = "Sat";
            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null) { Owner = this.domain , ShortName = this.edShortname };

            this.scalarParameter = new Parameter(Guid.NewGuid(), null, null) { Owner = this.domain }; 
            this.scalarParameter.ParameterType = this.scalarParameterType;
            this.elementDefinition.Parameter.Add(this.scalarParameter);

            this.compoundParameterTypeShortname = "coord";
            this.compoundParameterType = new CompoundParameterType(Guid.NewGuid(), null, null);
            this.compoundParameterType.ShortName = this.compoundParameterTypeShortname;
            this.component = new ParameterTypeComponent(Guid.NewGuid(), null, null) { ParameterType = this.scalarParameterType };
            this.component.ShortName = this.scalarParameterType.ShortName;
            this.compoundParameterType.Component.Add(this.component);

            this.compoundParameter = new Parameter(Guid.NewGuid(), null, null) { Owner = this.domain, ParameterType = this.compoundParameterType };
            this.elementDefinition.Parameter.Add(this.compoundParameter);

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
            this.iteration.Element.Add(this.elementDefinition);
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForScalar()
        {
            var modelcode = "Sat.m";
            Assert.AreEqual(modelcode, this.scalarParameter.ModelCode());
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForCompoundComponent1()
        {
            var modelcode = "Sat.coord.1_8";
            this.component.ShortName = "{{1 -*/;%&@ 8<>}";

            Assert.AreEqual(modelcode, this.compoundParameter.ModelCode(0));
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForCompoundComponent2()
        {
            var modelcode = "Sat.coord.1_8";
            this.component.ShortName = "1_8";

            Assert.AreEqual(modelcode, this.compoundParameter.ModelCode(0));
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForCompoundComponent3()
        {
            var modelcode = "Sat.coord.1_8";
            this.component.ShortName = "{1;8";

            Assert.AreEqual(modelcode, this.compoundParameter.ModelCode(0));
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForCompoundComponent4()
        {
            var modelcode = "Sat.coord.";
            this.component.ShortName = "  ";

            Assert.AreEqual(modelcode, this.compoundParameter.ModelCode(0));
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResultForCompound()
        {
            var modelcode = "Sat.coord";
            Assert.AreEqual(modelcode, this.compoundParameter.ModelCode());
        }

        [Test]
        public void VerifyThatExpectedExceptionIsThrownWhenComponentIndexIsSuppliedForScalarParameterType()
        {
            Assert.Throws<ArgumentException>(() => this.scalarParameter.ModelCode(1));
        }

        [Test]
        public void VerifyThatWhenContainmentNotSetAContainmentExceptionIsThrown()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            Assert.Throws<ContainmentException>(() => parameter.ModelCode());
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet()
        {
            // no option, no state
            this.scalarParameter.ValidatePoco();
            Assert.IsNotEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet2()
        {
            // option/State dependent
            this.scalarParameter.IsOptionDependent = true;
            this.scalarParameter.StateDependence = this.actualList;

            this.scalarParameter.ValidatePoco();
            Assert.IsNotEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet3()
        {
            // option dependent
            this.scalarParameter.IsOptionDependent = true;

            this.scalarParameter.ValidatePoco();
            Assert.IsNotEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet4()
        {
            // State dependent
            this.scalarParameter.StateDependence = this.actualList;

            this.scalarParameter.ValidatePoco();
            Assert.IsNotEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterWithEmptyArrayValueSetHasError()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), null, null);
            this.scalarParameter.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.scalarParameter.ValidatePoco();

            Assert.IsNotEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasNoError()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), null, null);
            var data = new List<string> {"-"};
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.scalarParameter.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.scalarParameter.ValidatePoco();

            Assert.IsEmpty(this.scalarParameter.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterCanBePublishedReturnsExpectedResult()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), null, null);
            var data = new List<string> { "-" };
            valueset.ValueSwitch = ParameterSwitchKind.MANUAL;
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.scalarParameter.ValueSet.Add(valueset);
            
            Assert.IsFalse(this.scalarParameter.CanBePublished);

            var updatedData = new List<string> { "1" };
            valueset.Manual = new ValueArray<string>(updatedData);

            Assert.IsTrue(this.scalarParameter.CanBePublished);
        }

        [Test]
        public void VerifyThatWhenParameterIsNotPublishableGetToBePublishedReturnsFalse()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), null, null);
            var data = new List<string> { "-" };            
            valueset.ValueSwitch = ParameterSwitchKind.MANUAL;
            valueset.Manual = new ValueArray<string>(data);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.scalarParameter.ValueSet.Add(valueset);

            this.scalarParameter.ToBePublished = true;

            Assert.IsFalse(this.scalarParameter.ToBePublished);
        }

        [Test]
        public void VerifyThatWhenParameterIsPublishableGetToBePublishedReturnsTrue()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), null, null);
            var data = new List<string> { "-" };
            var manualData = new List<string> { "1" };
            valueset.ValueSwitch = ParameterSwitchKind.MANUAL;
            valueset.Manual = new ValueArray<string>(manualData);
            valueset.Computed = new ValueArray<string>(data);
            valueset.Reference = new ValueArray<string>(data);
            valueset.Published = new ValueArray<string>(data);
            valueset.Formula = new ValueArray<string>(data);

            this.scalarParameter.ValueSet.Add(valueset);

            Assert.IsFalse(this.scalarParameter.ToBePublished);

            this.scalarParameter.ToBePublished = true;

            Assert.IsTrue(this.scalarParameter.ToBePublished);
        }
    }
}
