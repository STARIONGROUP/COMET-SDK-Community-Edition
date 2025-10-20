// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanValueSetComparerAdditionalTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Additional coverage tests for <see cref="BooleanValueSetComparer"/>.
    /// </summary>
    [TestFixture]
    public class BooleanValueSetComparerAdditionalTestFixture
    {
        [Test]
        public void VerifyThatStringComparisonIsUsedWhenConversionFails()
        {
            var left = new ValueArray<string>(new[] { "maybe" });
            var right = new ValueArray<string>(new[] { "certain" });
            var comparer = new BooleanValueSetComparer();

            var result = comparer.Compare(left, right);

            var expected = string.CompareOrdinal(left.ToString().ToLower(), right.ToString().ToLower());
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatFailedConversionResetsBooleanList()
        {
            var comparer = new BooleanValueSetComparer();
            var valueArray = new ValueArray<string>(new[] { "true", "value", "false" });

            var success = comparer.TryConvertStringValueArrayToBooleanList(valueArray, out var booleanList);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(booleanList, Is.Empty);
            });
        }
    }
}
