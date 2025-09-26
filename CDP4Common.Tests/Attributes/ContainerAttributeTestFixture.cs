﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAttributeTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests
{
    using CDP4Common;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Test fixture for the <see cref="ContainerAttribute"/> class
    /// </summary>
    [TestFixture]
    public class ContainerAttributeTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsProperties()
        {
            var propertyName = "EmailAddress";
            var containerPropertyNameAttribute = new ContainerAttribute(typeof(Person), propertyName);

            Assert.That(containerPropertyNameAttribute.PropertyName, Is.EqualTo(propertyName));
            Assert.That(containerPropertyNameAttribute.ClassType, Is.EqualTo(typeof(Person)));
        }
    }
}
