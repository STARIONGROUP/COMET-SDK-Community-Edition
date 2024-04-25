// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetComparerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Common.Tests.Comparers
{
    using System;

    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterOverrideValueSetComparer"/> class
    /// </summary>
    [TestFixture]
    public class ParameterOverrideValueSetComparerTestFixture
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
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSeta = new ParameterValueSet();
            var parameterValueSetb = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSeta);
            parameter.ValueSet.Add(parameterValueSetb);

            parameterValueSeta.ActualOption = this.optiona;
            parameterValueSetb.ActualOption = this.optionb;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;
            
            var parameterOverrideValueSeta = new ParameterOverrideValueSet();
            parameterOverrideValueSeta.ParameterValueSet = parameterValueSeta;

            var optiondepaparametervaluesetb = new ParameterOverrideValueSet();
            optiondepaparametervaluesetb.ParameterValueSet = parameterValueSetb;

            var comparer = new ParameterOverrideValueSetComparer();
            var comparisonab = comparer.Compare(parameterOverrideValueSeta, optiondepaparametervaluesetb);
            Assert.That(comparisonab, Is.EqualTo(1));

            var comparisonba = comparer.Compare(optiondepaparametervaluesetb, parameterOverrideValueSeta);
            Assert.That(comparisonba, Is.EqualTo(-1));

            var comparisonaa = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSeta);
            Assert.That(comparisonaa, Is.EqualTo(0));

            var comparisonbb = comparer.Compare(optiondepaparametervaluesetb, optiondepaparametervaluesetb);
            Assert.That(comparisonbb, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSeta = new ParameterValueSet();
            var parameterValueSetb = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSeta);
            parameter.ValueSet.Add(parameterValueSetb);

            parameterValueSeta.ActualState = this.actualFiniteStatea;
            parameterValueSetb.ActualState = this.actualFiniteStateb;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;

            var parameterOverrideValueSeta = new ParameterOverrideValueSet();
            parameterOverrideValueSeta.ParameterValueSet = parameterValueSeta;

            var parameterOverrideValueSetb = new ParameterOverrideValueSet();
            parameterOverrideValueSetb.ParameterValueSet = parameterValueSetb;

            var comparer = new ParameterOverrideValueSetComparer();
            var comparisonab = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSetb);
            Assert.That(comparisonab, Is.EqualTo(1));

            var comparisonba = comparer.Compare(parameterOverrideValueSetb, parameterOverrideValueSeta);
            Assert.That(comparisonba, Is.EqualTo(-1));

            var comparisonaa = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSeta);
            Assert.That(comparisonaa, Is.EqualTo(0));

            var comparisonbb = comparer.Compare(parameterOverrideValueSetb, parameterOverrideValueSetb);
            Assert.That(comparisonbb, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatOptionDepStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSetaa = new ParameterValueSet();
            var parameterValueSetab = new ParameterValueSet();
            var parameterValueSetbb = new ParameterValueSet();
            var parameterValueSetba = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSetaa);
            parameter.ValueSet.Add(parameterValueSetab);
            parameter.ValueSet.Add(parameterValueSetbb);
            parameter.ValueSet.Add(parameterValueSetba);

            parameterValueSetaa.ActualOption = this.optiona;
            parameterValueSetaa.ActualState = this.actualFiniteStatea;

            parameterValueSetab.ActualOption = this.optiona;
            parameterValueSetab.ActualState = this.actualFiniteStateb;

            parameterValueSetbb.ActualOption = this.optionb;
            parameterValueSetbb.ActualState = this.actualFiniteStateb;

            parameterValueSetba.ActualOption = this.optionb;
            parameterValueSetba.ActualState = this.actualFiniteStatea;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;

            var aa = new ParameterOverrideValueSet();
            aa.ParameterValueSet = parameterValueSetaa;

            var ab = new ParameterOverrideValueSet();
            ab.ParameterValueSet = parameterValueSetab;

            var bb = new ParameterOverrideValueSet();
            bb.ParameterValueSet = parameterValueSetbb;

            var ba = new ParameterOverrideValueSet();
            ba.ParameterValueSet = parameterValueSetba;

            var comparer = new ParameterOverrideValueSetComparer();

            var comparison_aa_ab = comparer.Compare(aa, ab);
            Assert.That(comparison_aa_ab, Is.EqualTo(1));

            var comparison_aa_bb = comparer.Compare(aa, ab);
            Assert.That(comparison_aa_bb, Is.EqualTo(1));
        }
    }
}