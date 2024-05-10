// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorDoubleParameterTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System.Globalization;
    using System.Linq;

    using CDP4Common.Helpers;
    using CDP4Common.Types;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class DataCollectorDoubleParameterTestFixture
    {
        private DataCollectorParameterTestFixture dataCollectorParameterTestFixture;

        private class Row : DataCollectorRow
        {
            [DefinedThingShortName("type1", "TypeOne")]
            public DataCollectorDoubleParameter<Row> parameter1 { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            this.dataCollectorParameterTestFixture = new DataCollectorParameterTestFixture();
            this.dataCollectorParameterTestFixture.SetUp();
        }

        [Test]
        public void VerifyThatCorrectColumnNameIsUsed()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.dataCollectorParameterTestFixture.iteration, this.dataCollectorParameterTestFixture.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.dataCollectorParameterTestFixture.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            Assert.That(node.GetColumns<DataCollectorDoubleParameter<Row>>().Count(), Is.EqualTo(1));
            Assert.That(node.GetTable().Columns.Contains("TypeOne"), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void VerifyThatValuesAreCalculatedCorrectly(string valueArrayValue, double expectedValue1, double expectedValue2)
        {
            this.dataCollectorParameterTestFixture.ed1.Parameter.First().ValueSet.First().Published =  new ValueArray<string>(new [] { valueArrayValue });

            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.dataCollectorParameterTestFixture.iteration, this.dataCollectorParameterTestFixture.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.dataCollectorParameterTestFixture.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var culture = new CultureInfo("en-GB")
            {
                NumberFormat =
                {
                    NumberDecimalSeparator = ",", 
                    NumberGroupSeparator = "."
                }
            };

            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            Assert.That(node.GetColumns<DataCollectorDoubleParameter<Row>>().Count(), Is.EqualTo(1));

            Assert.That((double)node.GetTable().Rows[0]["TypeOne"], Is.EqualTo(expectedValue1));

            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";

            Assert.That((double)node.GetTable().Rows[0]["TypeOne"], Is.EqualTo(expectedValue2));
        }

        static object[] TestCases =
        {
            new object[] { "11", 11, 11},
            new object[] { "11.11", 11.11, 11.11},
            new object[] { "11,11", 11.11, 1111},
            new object[] { "-", 0, 0},
            new object[] { "", 0, 0},
            new object[] { " ", 0, 0},
            new object[] { "aa", 0, 0 }
        };
    }
}
