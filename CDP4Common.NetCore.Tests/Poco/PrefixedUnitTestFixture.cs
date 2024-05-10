// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnitTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class PrefixedUnitTestFixture
    {
        private PrefixedUnit prefixedUnit;
        private UnitPrefix unitPrefix;
        private MeasurementUnit measurementUnit;

        [SetUp]
        public void Setup()
        {
            this.prefixedUnit = new PrefixedUnit();

            this.unitPrefix = new UnitPrefix();
            this.unitPrefix.ConversionFactor = "conv";
            this.unitPrefix.Name = "unit";
            this.unitPrefix.ShortName = "u";

            this.measurementUnit = new SimpleUnit();
            this.measurementUnit.Name = "measurement";
            this.measurementUnit.ShortName = "m";
        }

        [Test]
        public void TestGetConversion()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            Assert.That(this.prefixedUnit.ConversionFactor, Is.EqualTo("conv"));
        }

        [Test]
        public void TestGetConversionEmpty()
        {
            Assert.That(this.prefixedUnit.ConversionFactor, Is.Empty);
        }

        [Test]
        public void TestGetName()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            this.prefixedUnit.ReferenceUnit = this.measurementUnit;
            Assert.That(this.prefixedUnit.Name, Is.EqualTo("unitmeasurement"));
        }

        [Test]
        public void TestGetNameEmpty()
        {
            Assert.That(this.prefixedUnit.Name, Is.Empty);
        }

        [Test]
        public void TestGetShortName()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            this.prefixedUnit.ReferenceUnit = this.measurementUnit;
            Assert.That(this.prefixedUnit.ShortName, Is.EqualTo("um"));
        }

        [Test]
        public void TestGetShortNameEmpty()
        {
            Assert.That(this.prefixedUnit.ShortName, Is.Empty);
        }
    }
}