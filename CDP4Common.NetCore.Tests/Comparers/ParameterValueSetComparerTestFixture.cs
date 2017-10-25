// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using System;

    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterValueSetComparer"/>
    /// </summary>    
    [TestFixture]
    public class ParameterValueSetComparerTestFixture
    {
        private Iteration iteration;

        private Option optiona;

        private Option optionb;

        private ActualFiniteState actualFiniteStatea;

        private ActualFiniteState actualFiniteStateb;

        [SetUp]
        public void SetUp()
        {
            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.optiona = new Option(Guid.NewGuid(), null, null) { Name = "option a", ShortName = "optionb" };
            this.optionb = new Option(Guid.NewGuid(), null, null) { Name = "option b", ShortName = "optionb" };
            this.iteration.Option.Add(this.optionb);
            this.iteration.Option.Add(this.optiona);

            var possibleFiniteStateList = new PossibleFiniteStateList(Guid.NewGuid(), null, null);
            var possibleFiniteStatea = new PossibleFiniteState(Guid.NewGuid(), null, null)
            {
                Name = "state a",
                ShortName = "statea"
            };
            var possibleFiniteStateb = new PossibleFiniteState(Guid.NewGuid(), null, null)
            {
                Name = "state b",
                ShortName = "stateb"
            };
            possibleFiniteStateList.PossibleState.Add(possibleFiniteStateb);
            possibleFiniteStateList.PossibleState.Add(possibleFiniteStatea);
            this.iteration.PossibleFiniteStateList.Add(possibleFiniteStateList);

            var actualFiniteStateList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualFiniteStatea = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualFiniteStatea.PossibleState.Add(possibleFiniteStatea);
            this.actualFiniteStateb = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualFiniteStateb.PossibleState.Add(possibleFiniteStateb);
            actualFiniteStateList.ActualState.Add(this.actualFiniteStateb);
            actualFiniteStateList.ActualState.Add(this.actualFiniteStatea);
            this.iteration.ActualFiniteStateList.Add(actualFiniteStateList);
        }

        [Test]
        public void verifyThatOptionDependentValuesetsComparerCompareReturnsExpectedResults()
        {
            var valueSeta = new ParameterValueSet();
            valueSeta.ActualOption = this.optiona;
            var valueSetb = new ParameterValueSet();
            valueSetb.ActualOption = this.optionb;

            var comparer = new ParameterValueSetComparer();
            var comparisonab = comparer.Compare(valueSeta, valueSetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(valueSetb, valueSeta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(valueSeta, valueSeta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(valueSetb, valueSetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var valueSeta = new ParameterValueSet();
            valueSeta.ActualState = this.actualFiniteStatea;
            var valueSetb = new ParameterValueSet();
            valueSetb.ActualState = this.actualFiniteStateb;

            var comparer = new ParameterValueSetComparer();
            var comparisonab = comparer.Compare(valueSeta, valueSetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(valueSetb, valueSeta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(valueSeta, valueSeta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(valueSetb, valueSetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatOptionDepStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var aa = new ParameterValueSet();
            aa.ActualOption = this.optiona;
            aa.ActualState = this.actualFiniteStatea;

            var ab = new ParameterValueSet();
            ab.ActualOption = this.optiona;
            ab.ActualState = this.actualFiniteStateb;

            var ba = new ParameterValueSet();
            ba.ActualOption = this.optionb;
            ba.ActualState = this.actualFiniteStatea;

            var bb = new ParameterValueSet();
            bb.ActualOption = this.optionb;
            bb.ActualState = this.actualFiniteStateb;

            var comparer = new ParameterValueSetComparer();

            var comparison_aa_ab = comparer.Compare(aa, ab);
            Assert.AreEqual(1, comparison_aa_ab);

            var comparison_aa_bb = comparer.Compare(aa, bb);
            Assert.AreEqual(1, comparison_aa_bb);
        }
    }
}