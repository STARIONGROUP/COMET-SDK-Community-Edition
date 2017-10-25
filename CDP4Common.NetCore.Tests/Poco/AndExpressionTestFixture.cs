// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AndExpressionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="AndExpression"/> class
    /// </summary>
    [TestFixture]
    public class AndExpressionTestFixture
    {
        private AndExpression andExpression;

        [SetUp]
        public void Setup()
        {
            this.andExpression = new AndExpression();
        }

        [Test]
        public void VerifyThatStringValueReturnsExpectedResult()
        {
            Assert.AreEqual("AND", this.andExpression.StringValue);
        }
    }
}
