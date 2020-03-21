// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.Tests.Types
{
    using System.Collections.Generic;

    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ValueArray{T}"/> class
    /// </summary>
    [TestFixture]
    public class ValueArrayTestFixture
    {
        [Test]
        public void VerifyThatValueArrayToStringWorks()
        {
            var array = new ValueArray<float>(new List<float> {1, 2, 3, 4.1f});
            var s = array.ToString();

            Assert.AreEqual("{1; 2; 3; 4.1}", s);
        }

        [Test]
        public void VerifyThatValueArrayToStringWorksWithStrings()
        {
            var array = new ValueArray<string>(new List<string> { "abc", "def", "3", "4.1" });
            var s = array.ToString();

            Assert.AreEqual("{\"abc\"; \"def\"; \"3\"; \"4.1\"}", s);
        }

        [Test]
        public void VerifyThatEmptyArrayReturnsEmptyString()
        {
            var array = new ValueArray<string>(new List<string>());

            Assert.AreEqual(string.Empty, array.ToString());
        }
    }
}
