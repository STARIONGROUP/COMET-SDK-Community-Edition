// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindValueSetComparerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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
    using System.Globalization;
    using System.Threading;

    using CDP4Common.Comparers;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="QuantityKindValueSetComparer"/>
    /// </summary>    
    [TestFixture]
    public class QuantityKindValueSetComparerTestFixture
    {
        private ValueArray<string> valueArray1;
        private ValueArray<string> valueArray2;
        private ValueArray<string> valueArrayNull;
        private ValueArray<string> valueArrayNegative;
        private ValueArray<string> valueArray01Invariant;
        private ValueArray<string> valueArray01;
        private ValueArray<string> valueArray02Invariant;
        private ValueArray<string> valueArray02;

        private QuantityKindValueSetComparer quantityKindValueSetComparer;
        private CultureInfo restoreCulture;

        [SetUp]
        public void SetUp()
        {
            this.restoreCulture = Thread.CurrentThread.CurrentCulture;

            var newCulture = new CultureInfo("en-US") { NumberFormat = { NumberDecimalSeparator = ",", NumberGroupSeparator = "." } };
            Thread.CurrentThread.CurrentCulture = newCulture;

            this.valueArray1 = new ValueArray<string>(new[] { "1"});
            this.valueArray2 = new ValueArray<string>(new[] { "2" });
            this.valueArrayNull = new ValueArray<string>(new string[] { null });
            this.valueArrayNegative = new ValueArray<string>(new string[] { "-1" });

            this.valueArray01 = new ValueArray<string>(new[] { "0,1" });
            this.valueArray01Invariant = new ValueArray<string>(new[] { "0.1" });

            this.valueArray02 = new ValueArray<string>(new[] { "0,2" });
            this.valueArray02Invariant = new ValueArray<string>(new[] { "0.2" });

            quantityKindValueSetComparer = new QuantityKindValueSetComparer();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.CurrentThread.CurrentCulture = this.restoreCulture;
        }

        [Test]
        public void verify_that_value_equals()
        {
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArray2), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray2, this.valueArray1), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, new ValueArray<string>(this.valueArray1)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArrayNull), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArrayNull, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArrayNull, new ValueArray<string>(this.valueArrayNull)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArrayNegative), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArrayNegative, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArrayNegative, new ValueArray<string>(this.valueArrayNegative)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArray01), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01, new ValueArray<string>(this.valueArray01)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArray01Invariant), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01Invariant, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01Invariant, new ValueArray<string>(this.valueArray01Invariant)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArray02), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02, new ValueArray<string>(this.valueArray02)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray1, this.valueArray02Invariant), Is.EqualTo(1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02Invariant, this.valueArray1), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02Invariant, new ValueArray<string>(this.valueArray02Invariant)), Is.EqualTo(0));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01Invariant, this.valueArray02Invariant), Is.EqualTo(-1    ));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02Invariant, this.valueArray01Invariant), Is.EqualTo(1));

            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray01, this.valueArray02), Is.EqualTo(-1));
            Assert.That(this.quantityKindValueSetComparer.Compare(this.valueArray02, this.valueArray01), Is.EqualTo(1));
        }
    }
}