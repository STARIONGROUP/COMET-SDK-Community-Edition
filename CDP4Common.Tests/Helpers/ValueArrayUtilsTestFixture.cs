// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayUtilsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Common.Tests.Helpers
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.Helpers;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="ValueArrayUtils"/> class
    /// </summary>
    [TestFixture]
    public class ValueArrayUtilsTestFixture
    {
        [Test]
        public void Verify_that_when_size_smaller_than_one_ArgumentOutOfRangeException_is_trown()
        {
            var size = 0;
            Assert.That(() => ValueArrayUtils.CreateDefaultValueArray(size), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Verify_that_when_ValueArray_is_created_the_correct_amount_of_slots_are_created()
        {
            var size = 3;
            var result = ValueArrayUtils.CreateDefaultValueArray(size);

            Assert.That(result.Count, Is.EqualTo(size));
        }

        [Test]
        public void VerifyThatContainsSameValuesWorks()
        {
            var valueArray1 = new ValueArray<string>(new List<string>() { "1", "ABC", "Test" });
            var valueArray2 = new ValueArray<string>(new List<string>() { "1", "ABC", "Test" });
            var valueArray3 = new ValueArray<string>(new List<string>() { "1", "ABC" });
            var valueArray4 = new ValueArray<string>(new List<string>() { "1", "ABCa", "Test" });
            var valueArray5 = new ValueArray<string>(new List<string>() { "1.0", "ABC", "Test" });

            Assert.Multiple(() =>
            {
                Assert.That(valueArray1.ContainsSameValues(valueArray2), Is.True);
                Assert.That(valueArray1.ContainsSameValues(valueArray3), Is.False);
                Assert.That(valueArray1.ContainsSameValues(valueArray4), Is.False);
                Assert.That(valueArray1.ContainsSameValues(valueArray5), Is.False);
            });
        }
    }
}
