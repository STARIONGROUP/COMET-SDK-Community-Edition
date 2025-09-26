﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotThingTestFixture.cs" company="Starion Group S.A.">
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
    using System;

    using CDP4Common.CommonData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="NotThing"/> class
    /// </summary>
    [TestFixture]
    public class NotThingTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsProperties()
        {
            var name = "nothing";

            var nothing = new NotThing(name);

            Assert.That(nothing.Name, Is.EqualTo(name));
            Assert.That(nothing.Container, Is.Null);
            Assert.That(nothing.ClassKind, Is.EqualTo(ClassKind.NotThing));
        }

        [Test]
        public void VerifyThatResolvePropertiesThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.That(() => nothing.ResolveProperties(null), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void VerifyThatGenericCloneThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.That(() => nothing.Clone(false), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void VerifyThatToDtoThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.That(() => nothing.ToDto(), Throws.TypeOf<NotSupportedException>());
        }
    }
}
