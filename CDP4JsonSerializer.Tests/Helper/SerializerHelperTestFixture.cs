#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelperTestFixture.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4JsonSerializer.Tests.Helper
{
    using System;
    using System.Linq;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="SerializerHelper"/> class.
    /// </summary>
    [TestFixture]
    public class SerializerHelperTestFixture
    {
        [Test]
        public void VerifyThatToJsonObjectOfOrderedItemReturnsJObject()
        {
            var uniqueIdentifier = Guid.NewGuid();

            var orderedItem = new OrderedItem();
            orderedItem.K = 1;
            orderedItem.V = uniqueIdentifier;

            var propertyInfo = orderedItem.GetType().GetProperty("M");

            object value = null;
            value = System.Convert.ChangeType(123, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
            propertyInfo.SetValue(orderedItem, value);

            var jObject = SerializerHelper.ToJsonObject(orderedItem);
            Assert.AreEqual(3, jObject.Properties().Count());

            var k = jObject.Property("k");
            Assert.IsNotNull(k);            

            var v = jObject.Property("v");
            Assert.IsNotNull(v);

            var m = jObject.Property("m");
            Assert.IsNotNull(m);
        }

    }
}
