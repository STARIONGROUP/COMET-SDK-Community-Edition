// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorDoubleParameterTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System;
    using System.Linq;

    using CDP4Common.Helpers;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class DataCollectorStateDependentRowDoubleParameterTestFixture
    {
        private DataCollectorParameterTestFixture dataCollectorParameterTestFixture;

        private class Row : DataCollectorRow
        {
            [DefinedThingShortName("type4", "TypeFour")]
            public DataCollectorStateDependentPerRowDoubleParameter<Row> parameter4 { get; set; }
        }

        private class NoActualStateRow : DataCollectorRow
        {
            [DefinedThingShortName("type1", "typeOne")]
            public DataCollectorStateDependentPerRowDoubleParameter<NoActualStateRow> parameter1 { get; set; }
        }

        private class ErrorRow : DataCollectorRow
        {
            [DefinedThingShortName("type1", "typeOne")]
            public DataCollectorStateDependentPerRowDoubleParameter<ErrorRow> parameter1 { get; set; }

            [DefinedThingShortName("type4", "TypeFour")]
            public DataCollectorStateDependentPerRowStringParameter<ErrorRow> parameter4 { get; set; }
        }

        private class CorrectRow : DataCollectorRow
        {
            [DefinedThingShortName("type1", "typeOne")]
            public DataCollectorStateDependentPerRowStringParameter<CorrectRow> parameter1 { get; set; }

            [DefinedThingShortName("type4", "TypeFour")]
            public DataCollectorStateDependentPerRowStringParameter<CorrectRow> parameter4 { get; set; }
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

            Assert.That(node.GetColumns<DataCollectorStateDependentPerRowDoubleParameter<Row>>().Count(), Is.EqualTo(1));
            Assert.That(node.GetTable().Columns.Contains("ParameterName"), Is.True);
            Assert.That(node.GetTable().Columns.Contains("ParameterState"), Is.True);
            Assert.That(node.GetTable().Columns.Contains("ParameterValue"), Is.True);

            Assert.That(node.GetTable().Rows.Count, Is.EqualTo(2));
        }

        [Test]
        public void VerifyThatParametersWithoutStateDependenciesWork()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.dataCollectorParameterTestFixture.iteration, this.dataCollectorParameterTestFixture.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<NoActualStateRow>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.dataCollectorParameterTestFixture.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            Assert.That(node.GetColumns<DataCollectorStateDependentPerRowDoubleParameter<NoActualStateRow>>().Count(), Is.EqualTo(1));

            Assert.That(node.GetTable().Columns.Contains("ParameterName"), Is.True);
            Assert.That(node.GetTable().Columns.Contains("ParameterState"), Is.True);
            Assert.That(node.GetTable().Columns.Contains("ParameterValue"), Is.True);

            Assert.That(node.GetTable().Rows.Count, Is.EqualTo(1));

            Assert.That(node.GetTable().Rows[0]["ParameterName"], Is.EqualTo("typeOne"));
            Assert.That(node.GetTable().Rows[0]["ParameterState"], Is.EqualTo(DBNull.Value));
            Assert.That(node.GetTable().Rows[0]["ParameterValue"], Is.EqualTo(11D));
        }

        [Test]
        public void VerifyThatMultipleParametersOfSameTypeAreAllowed()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.dataCollectorParameterTestFixture.iteration, this.dataCollectorParameterTestFixture.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<CorrectRow>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.dataCollectorParameterTestFixture.option).ToList();

            Assert.DoesNotThrow(() => dataSource.CreateNodes(hierarchy, nestedElementTree));
        }

        [Test]
        public void VerifyThatMultipleParametersOfDifferentTypesAreNotAllowed()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.dataCollectorParameterTestFixture.iteration, this.dataCollectorParameterTestFixture.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<ErrorRow>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.dataCollectorParameterTestFixture.option).ToList();

            Assert.Throws<InvalidOperationException>(() => dataSource.CreateNodes(hierarchy, nestedElementTree));
        }
    }
}
