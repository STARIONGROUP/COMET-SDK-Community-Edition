// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportingParameterTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Reporting.Tests
{
    using System;
    using CDP4Reporting.Parameters;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ReportingParameter"/>.
    /// </summary>
    [TestFixture]
    public class ReportingParameterTestFixture
    {
        [Test]
        public void VerifyParameterNameAndForceDefaultValue()
        {
            var parameter = new ReportingParameter("Total Mass", typeof(int), 5, "[Mass] > 0");

            Assert.Multiple(() =>
            {
                Assert.That(parameter.Name, Is.EqualTo("Total Mass"));
                Assert.That(parameter.ParameterName, Is.EqualTo("dyn_Total_Mass"));
                Assert.That(parameter.Type, Is.EqualTo(typeof(int)));
                Assert.That(parameter.DefaultValue, Is.EqualTo(5));
                Assert.That(parameter.FilterExpression, Is.EqualTo("[Mass] > 0"));
                Assert.That(parameter.ForceDefaultValue, Is.True);
            });
        }

        [Test]
        public void VerifyLookupValuesCanBeAddedFluently()
        {
            var parameter = new ReportingParameter("Status", typeof(string), "Open");

            var returned = parameter.AddLookupValue(1, "Open").AddLookupValue(2, "Closed");

            Assert.Multiple(() =>
            {
                Assert.That(returned, Is.SameAs(parameter));
                Assert.That(parameter.LookUpValues, Has.Count.EqualTo(2));
                Assert.That(parameter.LookUpValues[1], Is.EqualTo("Open"));
                Assert.That(parameter.LookUpValues[2], Is.EqualTo("Closed"));
            });
        }
    }
}
