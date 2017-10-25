// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrExpressionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="OrExpression"/> class
    /// </summary>
    [TestFixture]
    public class OrExpressionTestFixture
    {
        private OrExpression orExpression;

        [SetUp]
        public void Setup()
        {
            this.orExpression = new OrExpression();
        }

        [Test]
        public void VerifyThatStringValueReturnsExpectedResult()
        {
            Assert.AreEqual("OR", this.orExpression.StringValue);
        }
    }
}
