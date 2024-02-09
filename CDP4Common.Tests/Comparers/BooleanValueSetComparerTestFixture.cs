// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanValueSetComparerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BooleanValueSetComparer"/>
    /// </summary>    
    [TestFixture]
    public class BooleanValueSetComparerTestFixture
    {
        private ValueArray<string> valueArrayTrue;
        private ValueArray<string> valueArrayFalse;
        private ValueArray<string> valueArrayNotSet;
        private ValueArray<string> valueArrayLowerTrue;
        private ValueArray<string> valueArrayLowerFalse;
        private ValueArray<string> valueArrayWrongTrue;
        private ValueArray<string> valueArrayWrongFalse;

        private BooleanValueSetComparer booleanValueSetComparer;

        [SetUp]
        public void SetUp()
        {
            this.valueArrayTrue = new ValueArray<string>(new[] { "True"});
            this.valueArrayFalse = new ValueArray<string>(new[] { "False" });
            this.valueArrayLowerTrue = new ValueArray<string>(new[] { "true" });
            this.valueArrayLowerFalse = new ValueArray<string>(new[] { "false" });
            this.valueArrayNotSet = new ValueArray<string>(new [] { "-" });
            this.valueArrayWrongTrue = new ValueArray<string>(new[] { "1" });
            this.valueArrayWrongFalse = new ValueArray<string>(new[] { "0" });

            this.booleanValueSetComparer = new BooleanValueSetComparer();
        }

        [Test]
        public void verify_that_values_are_correct()
        {
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayTrue, this.valueArrayFalse) > 0);
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayTrue, this.valueArrayNotSet) > 0);
            Assert.That(this.booleanValueSetComparer.Compare(this.valueArrayTrue, this.valueArrayLowerTrue), Is.EqualTo(0));
            Assert.That(this.booleanValueSetComparer.Compare(this.valueArrayFalse, this.valueArrayLowerFalse), Is.EqualTo(0));
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayTrue, this.valueArrayWrongTrue) > 0);
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayFalse, this.valueArrayWrongFalse) > 0);

            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayFalse, this.valueArrayTrue) < 0);
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayNotSet, this.valueArrayTrue) < 0);
            Assert.That(this.booleanValueSetComparer.Compare(this.valueArrayLowerTrue, this.valueArrayTrue), Is.EqualTo(0));
            Assert.That(this.booleanValueSetComparer.Compare(this.valueArrayLowerFalse, this.valueArrayFalse), Is.EqualTo(0));
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayWrongTrue, this.valueArrayTrue) < 0);
            Assert.IsTrue(this.booleanValueSetComparer.Compare(this.valueArrayWrongFalse, this.valueArrayFalse) < 0);
        }
    }
}