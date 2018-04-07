#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterValueSet"/> class
    /// </summary>
    [TestFixture]
    public class ParameterValueSetTestFixture
    {
        private ElementDefinition elementDefinition;

        private Parameter parameter;

        private ParameterValueSet parameterValueSet;

        private SimpleQuantityKind simpleQuantityKind;

        [SetUp]
        public void SetUp()
        {
            this.simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null);
            this.simpleQuantityKind.ShortName = "m";

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            this.elementDefinition.ShortName = "Sat";

            this.parameter = new Parameter(Guid.NewGuid(), null, null);
            this.parameter.ParameterType = this.simpleQuantityKind;

            this.elementDefinition.Parameter.Add((this.parameter));

            this.parameterValueSet = new ParameterValueSet();
            this.parameterValueSet.Iid = Guid.NewGuid();

            this.parameter.ValueSet.Add(this.parameterValueSet);
        }

        [Test]
        public void VerifyThatParameterValueSetReturnsExpectedModelCode()
        {
            Assert.AreEqual("Sat.m", this.parameterValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatOptionDependentParameterValueSetReturnsExpectedModelCode()
        {
            var option = new Option(Guid.NewGuid(), null, null);
            option.ShortName = "option_1";

            this.parameter.IsOptionDependent = true;
            this.parameterValueSet.ActualOption = option;

            Assert.AreEqual(@"Sat.m\option_1", this.parameterValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatStateDependentParameterValueSetReturnsExpectedModelCode()
        {
            var possibleFiniteStateList = new PossibleFiniteStateList();
            var possibleFiniteState = new PossibleFiniteState();
            possibleFiniteState.ShortName = "SM";
            possibleFiniteStateList.PossibleState.Add(possibleFiniteState);

            var actualFiniteStateList = new ActualFiniteStateList();
            actualFiniteStateList.PossibleFiniteStateList.Add(possibleFiniteStateList);
            var actualFiniteState = new ActualFiniteState();
            actualFiniteState.PossibleState.Add(possibleFiniteState);
            actualFiniteStateList.ActualState.Add(actualFiniteState);

            this.parameter.StateDependence = actualFiniteStateList;
            this.parameterValueSet.ActualState = actualFiniteState;

            Assert.AreEqual(@"Sat.m\SM", this.parameterValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatOptionDependentStateDependentParameterValueSetReturnsExpectedModelCode()
        {
            var option = new Option(Guid.NewGuid(), null, null);
            option.ShortName = "option_1";

            this.parameter.IsOptionDependent = true;
            this.parameterValueSet.ActualOption = option;

            var possibleFiniteStateList = new PossibleFiniteStateList();
            var possibleFiniteState = new PossibleFiniteState();
            possibleFiniteState.ShortName = "SM";
            possibleFiniteStateList.PossibleState.Add(possibleFiniteState);

            var actualFiniteStateList = new ActualFiniteStateList();
            actualFiniteStateList.PossibleFiniteStateList.Add(possibleFiniteStateList);
            var actualFiniteState = new ActualFiniteState();
            actualFiniteState.PossibleState.Add(possibleFiniteState);
            actualFiniteStateList.ActualState.Add(actualFiniteState);

            this.parameter.StateDependence = actualFiniteStateList;
            this.parameterValueSet.ActualState = actualFiniteState;

            Assert.AreEqual(@"Sat.m\option_1\SM", this.parameterValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatCloneWithCloneValueArrayReturnsCloneWithNewValueArrays()
        {
            var manualValue = "manual";
            var newManualValue = "new manual";

            var referenceValue = "reference";
            var newReferenceValue = "new referennce";

            var computedValue = "computed";
            var newComputedValue = "new computedValue";

            var manualValueArray = new ValueArray<string>(new List<string> { manualValue });
            var referenceValueArray = new ValueArray<string>(new List<string> { referenceValue });
            var computedValueArray = new ValueArray<string>(new List<string> { computedValue });

            this.parameterValueSet.Manual = manualValueArray;
            this.parameterValueSet.Reference = referenceValueArray;
            this.parameterValueSet.Computed = computedValueArray;

            Assert.AreEqual(manualValue, this.parameterValueSet.Manual[0]);
            Assert.AreEqual(referenceValue, this.parameterValueSet.Reference[0]);
            Assert.AreEqual(computedValue, this.parameterValueSet.Computed[0]);

            var clone = this.parameterValueSet.Clone(false);
            clone.Manual[0] = newManualValue;
            clone.Reference[0] = newReferenceValue;
            clone.Computed[0] = newComputedValue;

            Assert.AreEqual(newManualValue, clone.Manual[0]);
            Assert.AreEqual(manualValue, this.parameterValueSet.Manual[0]);

            Assert.AreEqual(newReferenceValue, clone.Reference[0]);
            Assert.AreEqual(referenceValue, this.parameterValueSet.Reference[0]);

            Assert.AreEqual(newComputedValue, clone.Computed[0]);
            Assert.AreEqual(computedValue, this.parameterValueSet.Computed[0]);
        }

        [Test]
        public void Verify_that_when_container_not_set_ModelCode_throws_exception()
        {
            var parameterValueSet = new ParameterValueSet(Guid.NewGuid(), null, null);
            Assert.Throws<ContainmentException>(() => parameterValueSet.ModelCode(0));
        }

        [Test]
        public void Verify_that_QueryParameterType_returns_expected_result()
        {
            var parameterType = this.parameterValueSet.QueryParameterType();
            Assert.AreEqual(this.simpleQuantityKind, parameterType);
        }

        [Test]
        public void Verify_that_when_container_not_set_QueryParameterType_throws_Exception()
        {
            var parameterValueSet = new ParameterValueSet(Guid.NewGuid(), null, null);
            Assert.Throws<ContainmentException>(() => parameterValueSet.QueryParameterType());
        }
    }
}
