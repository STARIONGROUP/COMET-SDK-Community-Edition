// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlInformationAttributeTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Attributes
{
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="UmlInformationAttribute"/> class.
    /// </summary>
    [TestFixture]
    public class UmlInformationAttributeTestFixture
    {
        [Test]
        public void Verify_That_Properties_Are_Set()
        {
            var aggregationKind = AggregationKind.None;
            var isDerived = true;
            var isOrdered = true;
            var isNullable = true;
            var isPersistent = true;

            var umlInformationAttribute = new UmlInformationAttribute(aggregationKind, isDerived, isOrdered, isNullable, isPersistent);

            Assert.That(umlInformationAttribute.Aggregation, Is.EqualTo(aggregationKind));
            Assert.That(umlInformationAttribute.IsDerived, Is.EqualTo(isDerived));
            Assert.That(umlInformationAttribute.IsOrdered, Is.EqualTo(isOrdered));
            Assert.That(umlInformationAttribute.IsNullable, Is.EqualTo(isNullable));
            Assert.That(umlInformationAttribute.IsPersistent, Is.EqualTo(isPersistent));
        }
    }
}
