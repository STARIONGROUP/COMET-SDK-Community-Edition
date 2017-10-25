// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlInformationAttributeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Attributes
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="UmlInformationAttribute"/> class.
    /// </summary>
    [TestFixture]
    public class UmlInformationAttributeTestFixture
    {
        [Test]
        public void Verify_That_Properties_Are_Set()
        {
            var aggregationKind = AggregationKind.None;
            var isDerived = true;
            var isOrdered = true;
            var isNullable = true;
            var isPersistent = true;

            var umlInformationAttribute = new UmlInformationAttribute(aggregationKind, isDerived, isOrdered, isNullable, isPersistent);

            Assert.AreEqual(aggregationKind, umlInformationAttribute.Aggregation);
            Assert.AreEqual(isDerived, umlInformationAttribute.IsDerived);
            Assert.AreEqual(isOrdered, umlInformationAttribute.IsOrdered);
            Assert.AreEqual(isNullable, umlInformationAttribute.IsNullable);
            Assert.AreEqual(isPersistent, umlInformationAttribute.IsPersistent);
        }
    }
}
