// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregationAttributeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests
{
    using CDP4Common;

    using NUnit.Framework;

    /// <summary>
    /// Test fixture for the <see cref="UmlInformationAttribute"/> class
    /// </summary>
    [TestFixture]
    public class AggregationAttributeTestFixture
    {
        [Test]
        public void VerifyThatPropertiesAreSetByConstructor()
        {
            var aggregationKind = AggregationKind.Composite;
            var aggregationAttribute = new UmlInformationAttribute(aggregationKind, true, false, false);

            Assert.AreEqual(aggregationKind, aggregationAttribute.Aggregation);
            Assert.IsTrue(aggregationAttribute.IsDerived);
            Assert.IsFalse(aggregationAttribute.IsOrdered);
            Assert.IsFalse(aggregationAttribute.IsNullable);
        }
    }
}
