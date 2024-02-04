// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET SDK Community Edition
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Helper
{
    using CDP4JsonSerializer.Helper;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Utils"/> class
    /// </summary>
    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void VerifyThatFirstLetterIsCapitalized()
        {
            var inputString = "some text";
            var result = Utils.CapitalizeFirstLetter(inputString);

            Assert.That(result, Is.EqualTo("Some text"));
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnCapitalizeFirstLetter()
        {
            Assert.That(() => Utils.CapitalizeFirstLetter(null), Throws.ArgumentException);

            Assert.That(() => Utils.CapitalizeFirstLetter(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void VerifyThatFirstLetterIsLowerCased()
        {
            var inputString = "Some text";
            var result = Utils.LowercaseFirstLetter(inputString);

            Assert.That(result, Is.EqualTo("some text"));
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnLowerCased()
        {
            Assert.That(() => Utils.LowercaseFirstLetter(null), Throws.ArgumentException);

            Assert.That(() => Utils.LowercaseFirstLetter(string.Empty), Throws.ArgumentException);
        }
    }
}
