// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnitTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class PrefixedUnitTestFixture
    {
        private PrefixedUnit prefixedUnit;
        private UnitPrefix unitPrefix;
        private MeasurementUnit measurementUnit;

        [SetUp]
        public void Setup()
        {
            this.prefixedUnit = new PrefixedUnit();

            this.unitPrefix = new UnitPrefix();
            this.unitPrefix.ConversionFactor = "conv";
            this.unitPrefix.Name = "unit";
            this.unitPrefix.ShortName = "u";

            this.measurementUnit = new SimpleUnit();
            this.measurementUnit.Name = "measurement";
            this.measurementUnit.ShortName = "m";
        }

        [Test]
        public void TestGetConversion()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            Assert.AreEqual("conv", this.prefixedUnit.ConversionFactor);
        }

        [Test]
        public void TestGetConversionEmpty()
        {
            Assert.IsEmpty(this.prefixedUnit.ConversionFactor);
        }

        [Test]
        public void TestGetName()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            this.prefixedUnit.ReferenceUnit = this.measurementUnit;
            Assert.AreEqual("unitmeasurement", this.prefixedUnit.Name);
        }

        [Test]
        public void TestGetNameEmpty()
        {
            Assert.IsEmpty(this.prefixedUnit.Name);
        }

        [Test]
        public void TestGetShortName()
        {
            this.prefixedUnit.Prefix = this.unitPrefix;
            this.prefixedUnit.ReferenceUnit = this.measurementUnit;
            Assert.AreEqual("um", this.prefixedUnit.ShortName);
        }

        [Test]
        public void TestGetShortNameEmpty()
        {
            Assert.IsEmpty(this.prefixedUnit.ShortName);
        }
    }
}