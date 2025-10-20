// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorBooleanAndDateTimeParameterTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System;
    using System.Globalization;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class DataCollectorBooleanAndDateTimeParameterTestFixture
    {
        private class TestRow : DataCollectorRow
        {
        }

        private class BooleanParameter : DataCollectorBooleanParameter<TestRow>
        {
        }

        private class DateTimeParameter : DataCollectorDateTimeParameter<TestRow>
        {
        }

        private class StateDependentStringParameter : DataCollectorStateDependentPerRowStringParameter<TestRow>
        {
        }

        [Test]
        public void VerifyThatBooleanValuesAreParsedCorrectly()
        {
            var parameter = new BooleanParameter
            {
                ParameterBase = new Parameter { ParameterType = new BooleanParameterType() }
            };

            Assert.That(parameter.Parse("true"), Is.True);
            Assert.That(parameter.Parse("false"), Is.False);
            Assert.That(parameter.Parse("invalid"), Is.False);
        }

        [Test]
        public void VerifyThatDateTimeValuesAreParsedUsingParameterType()
        {
            var parameter = new DateTimeParameter
            {
                ParameterBase = new Parameter { ParameterType = new DateTimeParameterType() }
            };

            var timestamp = DateTime.UtcNow;
            var roundtrip = timestamp.ToString("o", CultureInfo.InvariantCulture);

            Assert.That(parameter.Parse(roundtrip), Is.EqualTo(DateTime.Parse(roundtrip, null, DateTimeStyles.RoundtripKind)));
            Assert.That(parameter.Parse("not-a-date"), Is.Null);
        }

        [Test]
        public void VerifyThatStateDependentStringParameterReturnsInput()
        {
            var parameter = new StateDependentStringParameter();
            const string expected = "state-value";

            Assert.That(parameter.Parse(expected), Is.EqualTo(expected));
        }
    }
}
