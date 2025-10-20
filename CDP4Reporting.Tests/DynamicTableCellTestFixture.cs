// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicTableCellTestFixture.cs" company="Starion Group S.A.">
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
    using CDP4Reporting.DynamicTableChecker;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="DynamicTableCell"/>.
    /// </summary>
    [TestFixture]
    public class DynamicTableCellTestFixture
    {
        [Test]
        public void VerifyConstructorInitializesExpression()
        {
            var cell = new DynamicTableCell("=Fields.Name");

            Assert.Multiple(() =>
            {
                Assert.That(cell.Expression, Is.EqualTo("=Fields.Name"));
                Assert.That(cell.ForeColorExpression, Is.Null);
                Assert.That(cell.BackColorExpression, Is.Null);
            });
        }

        [Test]
        public void VerifyExpressionsAreMutable()
        {
            var cell = new DynamicTableCell("=Fields.Value")
            {
                ForeColorExpression = "=Iif(Value > 0, 'Green', 'Red')",
                BackColorExpression = "=Parameters.Background"
            };

            Assert.Multiple(() =>
            {
                Assert.That(cell.ForeColorExpression, Is.EqualTo("=Iif(Value > 0, 'Green', 'Red')"));
                Assert.That(cell.BackColorExpression, Is.EqualTo("=Parameters.Background"));
            });
        }
    }
}
