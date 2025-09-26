// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionComparerTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    [TestFixture]
    internal class ElementDefinitionComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var usage1 = new ElementDefinition { Name = "type1" };
            var usage2 = new ElementDefinition { Name = "type5" };

            var comparer = new ElementDefinitionComparer();
            Assert.That(comparer.Compare(usage1, usage2), Is.EqualTo(-4));
        }
    }
}