#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer_SystemTextJson.Tests.Helper
{
    using System;

    using CDP4JsonSerializer_SystemTextJson.Helper;
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
            
            Assert.AreEqual("Some text", result);
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnCapitalizeFirstLetter()
        {
           Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(null));

           Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(string.Empty));
        }

        [Test]
        public void VerifyThatFirstLetterIsLowerCased()
        {
            var inputString = "Some text";
            var result = Utils.LowercaseFirstLetter(inputString);

            Assert.AreEqual("some text", result);
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnLowerCased()
        {
            Assert.Throws<ArgumentException>(() => Utils.LowercaseFirstLetter(null));

            Assert.Throws<ArgumentException>(() => Utils.LowercaseFirstLetter(string.Empty));
        }
    }
}
