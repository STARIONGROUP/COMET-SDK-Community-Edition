// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheKeyTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4Common.Tests.Types
{
    using System;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CacheKey"/> class
    /// </summary>
    [TestFixture]
    public class CacheKeyTestFixture
    {
        private CacheKey cachekey_1;

        private CacheKey cachekey_2;

        private Guid guid_1;

        private Guid guid_2;

        [SetUp]
        public void SetUp()
        {
            this.guid_1 = Guid.NewGuid();
            this.guid_2 = Guid.NewGuid();
        }

        [Test]
        public void Verify_that_equals_returns_expected_result()
        {
            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_1, null);
            Assert.IsTrue(cachekey_1.Equals(cachekey_2));

            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_2, null);
            Assert.IsFalse(cachekey_1.Equals(cachekey_2));

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_1, this.guid_2);
            Assert.IsTrue(cachekey_1.Equals(cachekey_2));

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_2, this.guid_1);
            Assert.IsFalse(cachekey_1.Equals(cachekey_2));

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_1, null);
            Assert.IsFalse(cachekey_1.Equals(cachekey_2));

            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_1, this.guid_2);
            Assert.IsFalse(cachekey_1.Equals(cachekey_2));
        }

        [Test]
        public void Verify_that_equality_returns_expected_result()
        {
            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_1, null);
            
            Assert.IsTrue(cachekey_1 == cachekey_2);
            Assert.IsFalse(cachekey_1 != cachekey_2);


            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_2, null);
            Assert.IsFalse(cachekey_1 == cachekey_2);
            Assert.IsTrue(cachekey_1 != cachekey_2);

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_1, this.guid_2);
            Assert.IsTrue(cachekey_1 == cachekey_2);
            Assert.IsFalse(cachekey_1 != cachekey_2);

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_2, this.guid_1);
            Assert.IsFalse(cachekey_1 == cachekey_2);
            Assert.IsTrue(cachekey_1 != cachekey_2);

            this.cachekey_1 = new CacheKey(this.guid_1, this.guid_2);
            this.cachekey_2 = new CacheKey(this.guid_1, null);
            Assert.IsFalse(cachekey_1 == cachekey_2);
            Assert.IsTrue(cachekey_1 != cachekey_2);

            this.cachekey_1 = new CacheKey(this.guid_1, null);
            this.cachekey_2 = new CacheKey(this.guid_1, this.guid_2);
            Assert.IsFalse(cachekey_1 == cachekey_2);
            Assert.IsTrue(cachekey_1 != cachekey_2);
        }
        
        [Test]
        public void Verify_that_GetHashCode_returns_same_value_as_expected()
        {
            this.cachekey_1 = new CacheKey(this.guid_1, null);
            
            Assert.AreEqual(this.cachekey_1.GetHashCode(), this.cachekey_1.GetHashCode());
        }
    }
}