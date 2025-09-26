// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests.Poco
{
    using System;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ElementUsage"/> class.
    /// </summary>
    [TestFixture]
    public class ElementUsageTestFixture
    {
        private string edShortname1;

        private ElementDefinition elementDefinition1;

        private string edShortname2;

        private ElementDefinition elementDefinition2;

        private string euShortname;

        private ElementUsage elementUsage;

        [SetUp]
        public void SetUp()
        {
            this.edShortname1 = "Sat";
            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = this.edShortname1 };

            this.edShortname2 = "Bat";
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = this.edShortname2 };

            this.euShortname = "bat_1";
            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null)
                                    {
                                        ShortName = this.euShortname,
                                        ElementDefinition = this.elementDefinition2
                                    };

            this.elementDefinition1.ContainedElement.Add(this.elementUsage);
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResult()
        {
            var modelcode = "Sat.bat_1";

            Assert.That(this.elementUsage.ModelCode(), Is.EqualTo(modelcode));
        }

        [Test]
        public void VerifyThatWhenContainmentNotSetAContainmentExceptionIsThrown()
        {
            var elementUsage = new ElementUsage(Guid.NewGuid(), null, null);
            Assert.That(() => elementUsage.ModelCode(), Throws.TypeOf<ContainmentException>());
        }

        [Test]
        public void VerifyThatWhenComponentIndexNotNullArgumentExceptionIsThrown()
        {
            Assert.That(() => this.elementUsage.ModelCode(1), Throws.TypeOf<ArgumentException>());
        }
    }
}
