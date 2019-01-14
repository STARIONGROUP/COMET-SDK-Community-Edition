#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterOverrideValueSetTestFixture
    {
        private ElementDefinition elementDefinition1;
        private ElementDefinition elementDefinition2;
        private ElementUsage elementUsage;
        private Parameter scalarParameter;        
        
        [SetUp]
        public void SetUp()
        {
            var scalarParameterType = new SimpleQuantityKind() { ShortName = "l", Name = "length"};
            var compoundParameterType = new CompoundParameterType() { ShortName = "coord", Name = "cartesian coordinate" };
            var component = new ParameterTypeComponent() { ShortName = "x" };
            component.ParameterType = scalarParameterType;
            compoundParameterType.Component.Add(component);

            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = "Sat" };
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = "Bat" };
            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null)
            {
                ShortName = "battery_1",
                ElementDefinition = this.elementDefinition2
            };
            this.elementDefinition1.ContainedElement.Add(this.elementUsage);

            this.scalarParameter = new Parameter { ParameterType = scalarParameterType };
            var scalarParameterValueSet = new ParameterValueSet();
            this.scalarParameter.ValueSet.Add(scalarParameterValueSet);

            this.elementDefinition2.Parameter.Add(this.scalarParameter);
        }

        [Test]
        public void TestGets()
        {
            var thing = new ParameterOverrideValueSet(Guid.NewGuid(), null, null);
            var parameterValueSet = new ParameterValueSet(Guid.NewGuid(), null, null);
            parameterValueSet.ActualOption = new Option(Guid.NewGuid(), null, null);
            parameterValueSet.ActualState = new ActualFiniteState(Guid.NewGuid(), null, null);
            thing.ParameterValueSet = parameterValueSet;

            Assert.IsTrue(ReferenceEquals(parameterValueSet.ActualState, thing.ActualState));
            Assert.IsTrue(ReferenceEquals(parameterValueSet.ActualOption, thing.ActualOption));
        }

        [Test]
        public void VerifyThatParameterOverrideValueSetReturnsExpectedModelCode()
        {
            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = this.scalarParameter;
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ParameterValueSet = this.scalarParameter.ValueSet.Single();

            Assert.AreEqual("Sat.battery_1.l", parameterOverrideValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatOptionDependentParameterOverrideValueSetReturnsExpectedModelCode()
        {
            var option = new Option();
            option.ShortName = "option_1";

            var parameterValueSet = this.scalarParameter.ValueSet.Single();
            parameterValueSet.ActualOption = option;

            this.scalarParameter.IsOptionDependent = true;
            
            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = this.scalarParameter;
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ParameterValueSet = parameterValueSet;

            Assert.AreEqual(@"Sat.battery_1.l\option_1", parameterOverrideValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatStateDependentParameterOverrideValueSetReturnsExpectedModelCode()
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

            this.scalarParameter.StateDependence = actualFiniteStateList;
            var parameterValueSet = this.scalarParameter.ValueSet.Single();
            parameterValueSet.ActualState = actualFiniteState;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = this.scalarParameter;
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();
            parameterOverrideValueSet.ParameterValueSet = parameterValueSet;
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ParameterValueSet = parameterValueSet;

            Assert.AreEqual(@"Sat.battery_1.l\SM", parameterOverrideValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatOptionAndStateDependentParameterOverrideValueSetReturnsExpectedModelCode()
        {
            var option = new Option();
            option.ShortName = "option_1";

            var possibleFiniteStateList = new PossibleFiniteStateList();
            var possibleFiniteState = new PossibleFiniteState();
            possibleFiniteState.ShortName = "SM";
            possibleFiniteStateList.PossibleState.Add(possibleFiniteState);

            var actualFiniteStateList = new ActualFiniteStateList();
            actualFiniteStateList.PossibleFiniteStateList.Add(possibleFiniteStateList);
            var actualFiniteState = new ActualFiniteState();
            actualFiniteState.PossibleState.Add(possibleFiniteState);
            actualFiniteStateList.ActualState.Add(actualFiniteState);

            this.scalarParameter.IsOptionDependent = true;

            this.scalarParameter.StateDependence = actualFiniteStateList;
            var parameterValueSet = this.scalarParameter.ValueSet.Single();
            parameterValueSet.ActualState = actualFiniteState;
            parameterValueSet.ActualOption = option;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = this.scalarParameter;
            this.elementUsage.ParameterOverride.Add(parameterOverride);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();
            parameterOverrideValueSet.ParameterValueSet = parameterValueSet;
            parameterOverride.ValueSet.Add(parameterOverrideValueSet);

            parameterOverrideValueSet.ParameterValueSet = parameterValueSet;

            Assert.AreEqual(@"Sat.battery_1.l\option_1\SM", parameterOverrideValueSet.ModelCode(0));
        }

        [Test]
        public void VerifyThatCloneWithCloneValueArrayReturnsCloneWithNewValueArrays()
        {
            var parameterOverrideValueSet = new ParameterOverrideValueSet();

            var manualValue = "manual";
            var newManualValue = "new manual";

            var referenceValue = "reference";
            var newReferenceValue = "new referennce";

            var computedValue = "computed";
            var newComputedValue = "new computedValue";

            var manualValueArray = new ValueArray<string>(new List<string> { manualValue });
            var referenceValueArray = new ValueArray<string>(new List<string> { referenceValue });
            var computedValueArray = new ValueArray<string>(new List<string> { computedValue });

            parameterOverrideValueSet.Manual = manualValueArray;
            parameterOverrideValueSet.Reference = referenceValueArray;
            parameterOverrideValueSet.Computed = computedValueArray;

            Assert.AreEqual(manualValue, parameterOverrideValueSet.Manual[0]);
            Assert.AreEqual(referenceValue, parameterOverrideValueSet.Reference[0]);
            Assert.AreEqual(computedValue, parameterOverrideValueSet.Computed[0]);

            var clone = parameterOverrideValueSet.Clone(false);
            clone.Manual[0] = newManualValue;
            clone.Reference[0] = newReferenceValue;
            clone.Computed[0] = newComputedValue;

            Assert.AreEqual(newManualValue, clone.Manual[0]);
            Assert.AreEqual(manualValue, parameterOverrideValueSet.Manual[0]);

            Assert.AreEqual(newReferenceValue, clone.Reference[0]);
            Assert.AreEqual(referenceValue, parameterOverrideValueSet.Reference[0]);

            Assert.AreEqual(newComputedValue, clone.Computed[0]);
            Assert.AreEqual(computedValue, parameterOverrideValueSet.Computed[0]);
        }
    }
}