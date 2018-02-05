// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2018 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ElementUsage"/> class.
    /// </summary>
    [TestFixture]
    public class ElementUsageTestFixture
    {
        private string edShortname1;

        private ElementDefinition elementDefinition1;

        private string edShortname2;

        private ElementDefinition elementDefinition2;

        private string euShortname;

        private ElementUsage elementUsage;

        [SetUp]
        public void SetUp()
        {
            this.edShortname1 = "Sat";
            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = this.edShortname1 };

            this.edShortname2 = "Bat";
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null) { ShortName = this.edShortname2 };

            this.euShortname = "bat_1";
            this.elementUsage = new ElementUsage(Guid.NewGuid(), null, null)
                                    {
                                        ShortName = this.euShortname,
                                        ElementDefinition = this.elementDefinition2
                                    };

            this.elementDefinition1.ContainedElement.Add(this.elementUsage);
        }

        [Test]
        public void VerifyThatModelCodeReturnsTheExpectedResult()
        {
            var modelcode = "Sat.bat_1";

            Assert.AreEqual(modelcode, this.elementUsage.ModelCode());
        }

        [Test]
        public void VerifyThatWhenContainmentNotSetAContainmentExceptionIsThrown()
        {
            var elementUsage = new ElementUsage(Guid.NewGuid(), null, null);
            Assert.Throws<ContainmentException>(() => elementUsage.ModelCode());
        }

        [Test]
        public void VerifyThatWhenComponentIndexNotNullArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => this.elementUsage.ModelCode(1));
        }
    }
}
