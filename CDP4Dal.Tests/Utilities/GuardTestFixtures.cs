// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardTestFixtures.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using NUnit.Framework;

    using Guard = CDP4Dal.Utilities.Guard;

[TestFixture]
    public class GuardTestFixtures
    {
        private static readonly int[] NotEmptyArray = { 1, 2, 3 };

        [Test]
        public void VerifyThrowsIfNull()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => Guard.ThrowIfNull((string)null, "something"), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNull((Thing)null, "something"), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNull("A value", "something"), Throws.Nothing);
            });
        }

        [Test]
        public void VerifyThrowIfNotValidForTransaction()
        {
            var elementDefinition = new ElementDefinition()
            {
                Iid = Guid.NewGuid()
            };

            Assert.Multiple(() =>
            {
                Assert.That(() => Guard.ThrowIfNotValidForTransaction(null), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNotValidForTransaction(elementDefinition), Throws.Nothing);
                Assert.That(() => Guard.ThrowIfNotValidForTransaction(elementDefinition.Clone(false)), Throws.Exception);
            });

            elementDefinition.Cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>
            {
                [elementDefinition.CacheKey] = new Lazy<Thing>(() => elementDefinition)
            };

            Assert.Multiple(() =>
            {
                Assert.That(() => Guard.ThrowIfNotValidForTransaction(elementDefinition), Throws.Exception);
                Assert.That(() => Guard.ThrowIfNotValidForTransaction(elementDefinition.Clone(false)), Throws.Nothing);
            });
        }

        [Test]
        public void VerifyThrowIfNotAClone()
        {
            var elementDefinition = new ElementDefinition()
            {
                Iid = Guid.NewGuid()
            };

            Assert.Multiple(() =>
            {
                Assert.That(() => Guard.ThrowIfNotAClone(null), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNotAClone(elementDefinition), Throws.Exception);
                Assert.That(() => Guard.ThrowIfNotAClone(elementDefinition.Clone(false)), Throws.Nothing);
            });
        }

        [Test]
        public void VerifyThrowIfNullOrEmpty()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => Guard.ThrowIfNullOrEmpty((string)null, "something"), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNullOrEmpty("", "something"), Throws.Exception);
                Assert.That(() => Guard.ThrowIfNullOrEmpty((IEnumerable<int>)null, "something"), Throws.ArgumentNullException);
                Assert.That(() => Guard.ThrowIfNullOrEmpty(Enumerable.Empty<int>(), "something"), Throws.Exception);
                Assert.That(() => Guard.ThrowIfNullOrEmpty("a", "something"), Throws.Nothing);
                Assert.That(() => Guard.ThrowIfNullOrEmpty(NotEmptyArray, "something"), Throws.Nothing);
            });
        }
    }
}
