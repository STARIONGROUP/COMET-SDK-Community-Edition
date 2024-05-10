// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalExportAttributeTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.Composition
{
    using CDP4Dal.Composition;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tess for the <see cref="DalExportAttribute"/>
    /// </summary>
    [TestFixture]
    public class DalExportAttributeTestFixture
    {
        [Test]
        public void VerifyThatThePropertiesAreSet()
        {
            var name = "CDP4";
            var description = "CDP4 Webservices";
            var cdpVersion = "1.1.0";
            var type = DalType.Web;

            var attribute = new DalExportAttribute(name, description, cdpVersion, DalType.Web);
            Assert.That(name, Is.EqualTo(attribute.Name));
            Assert.That(description, Is.EqualTo(attribute.Description));
            Assert.That(cdpVersion, Is.EqualTo(attribute.CDPVersion));
            Assert.That(type, Is.EqualTo(attribute.DalType));
        }
    }
}
