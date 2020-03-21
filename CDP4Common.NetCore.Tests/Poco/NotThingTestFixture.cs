// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotThingTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

            Assert.AreEqual(name, nothing.Name);
            Assert.IsNull(nothing.Container);
            Assert.AreEqual(ClassKind.NotThing, nothing.ClassKind);
        }

        [Test]
        public void VerifyThatResolvePropertiesThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.ResolveProperties(null));
        }

        [Test]
        public void VerifyThatGenericCloneThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.Clone(false));
        }

        [Test]
        public void VerifyThatToDtoThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.ToDto());
        }
    }
}
