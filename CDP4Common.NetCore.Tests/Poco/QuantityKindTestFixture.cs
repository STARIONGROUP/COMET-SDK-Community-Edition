// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class QuantityKindTestFixture
    {
        [Test]
        public void TestGetAllPossibleScale()
        {
            var quantityKind = new SimpleQuantityKind();
            quantityKind.PossibleScale.Add(new LogarithmicScale());

            Assert.AreEqual(1, quantityKind.AllPossibleScale.Count);
        }

        [Test]
        public void TestGetAllPossibleScaleSpecialized()
        {
            var quantityKind = new SpecializedQuantityKind();

            var scale = new LogarithmicScale();
            quantityKind.PossibleScale.Add(scale);

            quantityKind.General = new SimpleQuantityKind();
            quantityKind.General.PossibleScale.Add(new RatioScale());
            quantityKind.General.PossibleScale.Add(new CyclicRatioScale());
            quantityKind.General.PossibleScale.Add(scale);

            Assert.AreEqual(3, quantityKind.AllPossibleScale.Count);
        }

        [Test]
        public void TestGetDerivedQuantityDimensionExponent()
        {
            var quantityKind = new SpecializedQuantityKind();
            Assert.Throws<NotSupportedException>(() => { var test = quantityKind.QuantityDimensionExponent; });
        }

        [Test]
        public void TestGetDerivedQuantityDimensionExpression()
        {
            var quantityKind = new SpecializedQuantityKind();
            Assert.Throws<NotSupportedException>(() => { var test = quantityKind.QuantityDimensionExpression; });
        }
    }
}