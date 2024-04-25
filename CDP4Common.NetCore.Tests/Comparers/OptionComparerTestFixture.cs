// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionComparerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="OptionComparer"/>
    /// </summary>    
    [TestFixture]
    public class OptionComparerTestFixture
    {
        private Iteration iteration;

        private Option optiona;

        private Option optionb;

        [SetUp]
        public void SetUp()
        {
            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.optiona = new Option(Guid.NewGuid(), null, null) { Name = "option a", ShortName = "optionb" };
            this.optionb = new Option(Guid.NewGuid(), null, null) { Name = "option b", ShortName = "optionb" };
            this.iteration.Option.Add(this.optionb);
            this.iteration.Option.Add(this.optiona);
        }

        [Test]
        public void verifyThatOptionDependentValuesetsComparerCompareReturnsExpectedResults()
        {
            var comparer = new OptionComparer();

            Assert.That(comparer.Compare(null, null), Is.EqualTo(0));

            Assert.That(comparer.Compare(null, this.optiona), Is.EqualTo(1));

            Assert.That(comparer.Compare(this.optiona, null), Is.EqualTo(-1));

            var comparisonab = comparer.Compare(this.optiona, this.optionb);
            Assert.That(comparisonab, Is.EqualTo(1));

            var comparisonba = comparer.Compare(this.optionb, this.optiona);
            Assert.That(comparisonba, Is.EqualTo(-1));

            var comparisonaa = comparer.Compare(this.optiona, this.optiona);
            Assert.That(comparisonaa, Is.EqualTo(0));

            var comparisonbb = comparer.Compare(this.optionb, this.optionb);
            Assert.That(comparisonbb, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatOptionsContainedInDifferentIterationsThrowsException()
        {
            var comparer = new OptionComparer();

            var iterationx = new Iteration(Guid.NewGuid(), null, null);
            var optionx = new Option(Guid.NewGuid(), null, null);

            iterationx.Option.Add(optionx);

            var iterationy = new Iteration(Guid.NewGuid(), null, null);
            var optiony = new Option(Guid.NewGuid(), null, null);

            iterationy.Option.Add(optiony);

            Assert.That(() => comparer.Compare(optionx, optiony), Throws.TypeOf<InvalidOperationException>());
        }
    }
}