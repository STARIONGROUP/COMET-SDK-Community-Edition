// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportingParametersTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using CDP4Reporting.DataCollection;
    using CDP4Reporting.Parameters;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ReportingParameters"/>.
    /// </summary>
    [TestFixture]
    public class ReportingParametersTestFixture
    {
        [Test]
        public void VerifyFilterStringConcatenation()
        {
            var reportingParameters = new TestReportingParameters();
            var parameters = new List<IReportingParameter>
            {
                new ReportingParameter("First", typeof(string), null, "[Field1] = 1"),
                new ReportingParameter("Second", typeof(string), null, "[Field2] = 2"),
                new ReportingParameter("Third", typeof(string), null, " ")
            };

            var filter = reportingParameters.CreateFilterString(parameters);

            Assert.That(filter, Is.EqualTo("([Field1] = 1) Or ([Field2] = 2)"));
        }

        [Test]
        public void VerifyFilterStringIsEmptyWhenNoFiltersSpecified()
        {
            var reportingParameters = new TestReportingParameters();
            var parameters = new List<IReportingParameter>
            {
                new ReportingParameter("First", typeof(string), null)
            };

            var filter = reportingParameters.CreateFilterString(parameters);

            Assert.That(filter, Is.Empty);
        }

        private sealed class TestReportingParameters : ReportingParameters
        {
            public override IEnumerable<IReportingParameter> CreateParameters(object dataSource, IDataCollector dataCollector)
            {
                throw new NotSupportedException();
            }
        }
    }
}
