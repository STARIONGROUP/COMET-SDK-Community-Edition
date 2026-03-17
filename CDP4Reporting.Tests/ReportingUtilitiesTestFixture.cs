// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportingUtilitiesTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Data;

    using CDP4Common.EngineeringModelData;

    using CDP4Reporting.Utilities;

    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ReportingUtilities"/>.
    /// </summary>
    [TestFixture]
    public class ReportingUtilitiesTestFixture
    {
        [Test]
        public void VerifyPrimitiveSequenceIsConvertedToDataTable()
        {
            var table = new DataTable();
            var result = new[] { 1, 2, 3 }.ToDataTable(table, LoadOption.Upsert);

            Assert.Multiple(() =>
            {
                Assert.That(result.Columns.Contains("Value"), Is.True);
                Assert.That(result.Rows.Count, Is.EqualTo(3));
                Assert.That(result.Rows[0]["Value"], Is.EqualTo(1));
            });
        }

        [Test]
        public void VerifyComplexSequenceIsConvertedToDataTable()
        {
            var items = new List<BaseItem>
            {
                new BaseItem { Name = "Base", Count = 1 },
                new DerivedItem { Name = "Derived", Count = 2, Extra = "extra" }
            };

            var table = items.ToDataTable();

            Assert.Multiple(() =>
            {
                Assert.That(table.Columns.Contains(nameof(BaseItem.Name)), Is.True);
                Assert.That(table.Columns.Contains(nameof(BaseItem.Count)), Is.True);
                Assert.That(table.Columns.Contains(nameof(DerivedItem.Extra)), Is.True);
                Assert.That(table.Rows.Count, Is.EqualTo(2));
                Assert.That(table.Rows[1][nameof(DerivedItem.Extra)], Is.EqualTo("extra"));
            });
        }

        private class BaseItem
        {
            public string Name { get; set; }

            public int Count;
        }

        private sealed class DerivedItem : BaseItem
        {
            public string Extra { get; set; }
        }
    }
}
