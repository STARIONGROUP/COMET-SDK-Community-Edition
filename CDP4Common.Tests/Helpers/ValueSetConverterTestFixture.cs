// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueSetConverterTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Tests.Helpers
{
    using System.Globalization;

    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="ValueSetConverter"/> class
    /// </summary>
    [TestFixture]
    public class ValueSetConverterTestFixture
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void VerifyThatValuesAreCalculatedCorrectly(string valueArrayValue, double expectedValue1, double expectedValue2, bool expectedTryParseResult, ParameterType parameterType)
        {
            var culture = new CultureInfo("en-GB")
            {
                NumberFormat =
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = "."
                }
            };

            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            Assert.AreEqual(expectedTryParseResult, ValueSetConverter.TryParseDouble(valueArrayValue, parameterType, out var calculatedValue1));
            Assert.AreEqual(expectedValue1, calculatedValue1);

            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";

            Assert.AreEqual(expectedTryParseResult, ValueSetConverter.TryParseDouble(valueArrayValue, parameterType, out var calculatedValue2));
            Assert.AreEqual(expectedValue2, calculatedValue2);
        }

        private static readonly object[] TestCases =
        {
            new object[] { "11", 11, 11, true, new SimpleQuantityKind()},
            new object[] { "11.11", 11.11, 11.11, true, new SimpleQuantityKind()},
            new object[] { "11.11", 0, 0, false, null},
            new object[] { "11,11", 11.11, 1111, true, new SimpleQuantityKind()},
            new object[] { "-", 0, 0, true, new SimpleQuantityKind()},
            new object[] { "", 0, 0, true, new SimpleQuantityKind()},
            new object[] { " ", 0, 0, true, new SimpleQuantityKind()},
            new object[] { "aa", 0, 0, false, new SimpleQuantityKind() }
        };
    }
}
