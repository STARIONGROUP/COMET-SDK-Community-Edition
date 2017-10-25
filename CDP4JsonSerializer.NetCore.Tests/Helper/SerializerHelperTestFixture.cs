// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelperTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Helper
{
    using System;
    using System.Linq;
    using System.Reflection;
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
