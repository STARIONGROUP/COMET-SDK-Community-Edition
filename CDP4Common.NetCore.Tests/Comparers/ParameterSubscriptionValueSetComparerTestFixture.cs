#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetComparerTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Comparers
{
    using System;
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterSubscriptionValueSetComparer"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterSubscriptionValueSetComparerTestFixture
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
            var parametervalueseta = new ParameterValueSet();
            parametervalueseta.ActualOption = this.optiona;
            var parametervaluesetb = new ParameterValueSet();
            parametervaluesetb.ActualOption = this.optionb;

            var subscriptioinvalueseta = new ParameterSubscriptionValueSet();
            subscriptioinvalueseta.SubscribedValueSet = parametervalueseta;

            var subscriptioinvaluesetb = new ParameterSubscriptionValueSet();
            subscriptioinvaluesetb.SubscribedValueSet = parametervaluesetb;

            var comparer = new ParameterSubscriptionValueSetComparer();
            var comparisonab = comparer.Compare(subscriptioinvalueseta, subscriptioinvaluesetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(subscriptioinvaluesetb, subscriptioinvalueseta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(subscriptioinvalueseta, subscriptioinvalueseta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(subscriptioinvaluesetb, subscriptioinvaluesetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parametervalueseta = new ParameterValueSet();
            parametervalueseta.ActualState = this.actualFiniteStatea;
            var parametervaluesetb = new ParameterValueSet();
            parametervaluesetb.ActualState = this.actualFiniteStateb;

            var subscriptionValueseta = new ParameterSubscriptionValueSet();
            subscriptionValueseta.SubscribedValueSet = parametervalueseta;

            var subscriptionValuesetb = new ParameterSubscriptionValueSet();
            subscriptionValuesetb.SubscribedValueSet = parametervaluesetb;

            var comparer = new ParameterSubscriptionValueSetComparer();
            var comparisonab = comparer.Compare(subscriptionValueseta, subscriptionValuesetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(subscriptionValuesetb, subscriptionValueseta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(subscriptionValueseta, subscriptionValueseta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(subscriptionValuesetb, subscriptionValuesetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatOptionDepStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parametervaluesetaa = new ParameterValueSet();
            parametervaluesetaa.ActualOption = this.optiona;
            parametervaluesetaa.ActualState = this.actualFiniteStatea;

            var aa = new ParameterSubscriptionValueSet();
            aa.SubscribedValueSet = parametervaluesetaa;

            var parametervaluesetab = new ParameterValueSet();
            parametervaluesetab.ActualOption = this.optiona;
            parametervaluesetab.ActualState = this.actualFiniteStateb;

            var ab = new ParameterSubscriptionValueSet();
            ab.SubscribedValueSet = parametervaluesetab;

            var parametervaluesetbb = new ParameterValueSet();
            parametervaluesetbb.ActualOption = this.optionb;
            parametervaluesetbb.ActualState = this.actualFiniteStateb;

            var bb = new ParameterSubscriptionValueSet();
            bb.SubscribedValueSet = parametervaluesetbb;

            var parametervaluesetba = new ParameterValueSet();
            parametervaluesetba.ActualOption = this.optionb;
            parametervaluesetba.ActualState = this.actualFiniteStatea;

            var ba = new ParameterSubscriptionValueSet();
            ba.SubscribedValueSet = parametervaluesetba;

            var comparer = new ParameterSubscriptionValueSetComparer();

            var comparison_aa_ab = comparer.Compare(aa, ab);
            Assert.AreEqual(1, comparison_aa_ab);

            var comparison_aa_bb = comparer.Compare(aa, bb);
            Assert.AreEqual(1, comparison_aa_bb);

            var comparison_ab_ab = comparer.Compare(ab, ab);
            Assert.AreEqual(0, comparison_ab_ab);
        }
    }
}
