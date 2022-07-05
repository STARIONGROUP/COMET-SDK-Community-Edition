// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItem.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary
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

namespace CDP4Common.Tests.Helpers
{
    using System;
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
        [TestCaseSource(nameof(TryParseDoubleTestCases))]
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

        [Test]
        [TestCaseSource(nameof(ValueSetConverterTestCases))]
        public void VerifyThatValueSetValuesAreCalculatedCorrectly(object value, string expectedValue1, string expectedValue2, ParameterType parameterType)
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

            Assert.AreEqual(expectedValue1, value.ToValueSetString(parameterType));

            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";

            Assert.AreEqual(expectedValue2, value.ToValueSetString(parameterType));
        }

        private static readonly object[] TryParseDoubleTestCases =
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

        private static readonly object[] ValueSetConverterTestCases =
        {
            new object[] { "AAA", "AAA", "AAA", new TextParameterType()},
            new object[] { "11.11", "11.11", "11.11", new SimpleQuantityKind()},
            new object[] { "11,11", "11.11", "11,11", new SimpleQuantityKind()},
            new object[] { "-", "-", "-", new SimpleQuantityKind()},
            new object[] { "", "-", "-", new SimpleQuantityKind()},
            new object[] { " ", "-", "-", new SimpleQuantityKind()},
            new object[] { true, "true", "true", new BooleanParameterType()},
            new object[] { false, "false", "false", new BooleanParameterType()},
            new object[] { "True", "true", "true", new BooleanParameterType()},
            new object[] { "False", "false", "false", new BooleanParameterType()},
            new object[] { "True", "True", "True", new TextParameterType()},
            new object[] { "False", "False", "False", new TextParameterType()},
            new object[] { null, string.Empty, string.Empty, new TextParameterType()},
            new object[] { "true", "true", "true", new TextParameterType()},
            new object[] { "false", "false", "false", new TextParameterType()},
            new object[] { "0000001", "0000001", "0000001", new TextParameterType()},
            new object[] { "000.000,000", "000.000,000", "000.000,000", new TextParameterType()},
            new object[] { 11.11F, "11.11", "11.11", new SimpleQuantityKind()},
            new object[] { 11.11D, "11.11", "11.11", new SimpleQuantityKind()},
            new object[] { 11.11F, "11,11", "11.11", new TextParameterType()},
            new object[] { 11.11D, "11,11", "11.11", new TextParameterType()},
            new object[] { true, "True", "True", new TextParameterType()},
            new object[] { false, "False", "False", new TextParameterType()},

            new object[] { new EnumerationValueDefinition() {ShortName = "enumValue"}, "enumValue", "enumValue", new EnumerationParameterType()},
            new object[] { "SomeValue", "SomeValue", "SomeValue", new EnumerationParameterType()},
            new object[]
            {
                new []
                {
                    new EnumerationValueDefinition {ShortName = "enumValue1"},
                    new EnumerationValueDefinition {ShortName = "enumValue2"}
                }, 
                $"enumValue1{Constants.PaddedMultiEnumSeparator}enumValue2", $"enumValue1{Constants.PaddedMultiEnumSeparator}enumValue2", new EnumerationParameterType()
            },
            new object[] { DateTime.ParseExact("2020-09-23T12:11:30", "yyyy-MM-ddTHH:mm:ss", null), "2020-09-23T12:11:30", "2020-09-23T12:11:30", new DateTimeParameterType()},
            new object[] { DateTime.ParseExact("2020-09-23T12:11:30", "yyyy-MM-ddTHH:mm:ss", null), "2020-09-23", "2020-09-23", new DateParameterType()},
            new object[] { DateTime.ParseExact("2020-09-23T12:11:30", "yyyy-MM-ddTHH:mm:ss", null), "12:11:30", "12:11:30", new TimeOfDayParameterType()},
        };
    }
}
