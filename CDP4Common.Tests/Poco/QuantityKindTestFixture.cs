// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4Common.Tests.Poco
{
    using System;

    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class QuantityKindTestFixture
    {
        [Test]
        public void TestGetAllPossibleScale()
        {
            var quantityKind = new SimpleQuantityKind();
            quantityKind.PossibleScale.Add(new LogarithmicScale());

            Assert.That(quantityKind.AllPossibleScale.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestGetAllPossibleScaleSpecialized()
        {
            var quantityKind = new SpecializedQuantityKind();

            var scale = new LogarithmicScale();
            quantityKind.PossibleScale.Add(scale);

            quantityKind.General = new SimpleQuantityKind();
            quantityKind.General.PossibleScale.Add(new RatioScale());
            quantityKind.General.PossibleScale.Add(new CyclicRatioScale());
            quantityKind.General.PossibleScale.Add(scale);

            Assert.That(quantityKind.AllPossibleScale.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestGetDerivedQuantityDimensionExponent()
        {
            var quantityKind = new SpecializedQuantityKind();
            Assert.Throws<NotSupportedException>(() => { var test = quantityKind.QuantityDimensionExponent; });
        }

        [Test]
        public void TestGetDerivedQuantityDimensionExpression()
        {
            var quantityKind = new SpecializedQuantityKind();
            Assert.Throws<NotSupportedException>(() => { var test = quantityKind.QuantityDimensionExpression; });
        }
    }
}