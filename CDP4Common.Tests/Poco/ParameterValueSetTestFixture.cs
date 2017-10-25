// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;
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

        [SetUp]
        public void SetUp()
        {
            var simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null);
            simpleQuantityKind.ShortName = "m";

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            this.elementDefinition.ShortName = "Sat";

            this.parameter = new Parameter(Guid.NewGuid(), null, null);
            this.parameter.ParameterType = simpleQuantityKind;

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
        public void VerifytThatOptionDependenStateDependentParameterValueSetReturnsExpectedModelCode()
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
        public void VerifyThatCloneWithcloneValueArrayReturnsCloneWithNewValueArrays()
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
    }
}
