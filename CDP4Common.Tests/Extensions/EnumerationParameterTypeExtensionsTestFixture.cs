// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationParameterTypeExtensionsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Common.Tests.Extensions
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.Exceptions;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="EnumerationParameterTypeExtensions"/> class
    /// </summary>
    [TestFixture]
    public class EnumerationParameterTypeExtensionsTestFixture
    {
        private EnumerationParameterType enumerationParameterType;
        private EnumerationValueDefinition enumerationValueDefinition1;
        private EnumerationValueDefinition enumerationValueDefinition2;
        private EnumerationValueDefinition enumerationValueDefinition3;

        [SetUp]
        public void SetUp()
        {
            this.enumerationParameterType = new EnumerationParameterType(Guid.NewGuid(), null, null);
            this.enumerationValueDefinition1 = new EnumerationValueDefinition(Guid.NewGuid(), null, null) {Name = "Value 1", ShortName = "val1"};
            this.enumerationValueDefinition2 = new EnumerationValueDefinition(Guid.NewGuid(), null, null) { Name = "Value 2", ShortName = "val2" };
            this.enumerationValueDefinition3 = new EnumerationValueDefinition(Guid.NewGuid(), null, null) { Name = "Value 3", ShortName = "val3" };

            this.enumerationParameterType.ValueDefinition.Add(this.enumerationValueDefinition1);
            this.enumerationParameterType.ValueDefinition.Add(this.enumerationValueDefinition2);
            this.enumerationParameterType.ValueDefinition.Add(this.enumerationValueDefinition3);
        }

        [Test]
        public void VerifyExpressionStringsAtThingLevel()
        {
            Assert.That(this.enumerationParameterType.ResolveNames("-"), Is.EquivalentTo(new List<string> { "-" }));
            Assert.That(this.enumerationParameterType.ResolveNames("val1"), Is.EquivalentTo(new List<string> { "Value 1" }));
            Assert.That(this.enumerationParameterType.ResolveNames("val1|val2"), Is.EquivalentTo(new List<string> { "Value 1", "Value 2" }));
            Assert.That(this.enumerationParameterType.ResolveNames("val1|val3"), Is.EquivalentTo(new List<string> { "Value 1", "Value 3" }));
            Assert.That(() => this.enumerationParameterType.ResolveNames("val1|val4"), Throws.TypeOf<Cdp4ModelValidationException>());
        }
    }
}
