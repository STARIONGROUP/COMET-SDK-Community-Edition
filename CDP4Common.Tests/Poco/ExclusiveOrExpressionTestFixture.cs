// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExclusiveOrExpressionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ExclusiveOrExpression"/> class
    /// </summary>
    [TestFixture]
    public class ExclusiveOrExpressionTestFixture
    {
        private ExclusiveOrExpression exclusiveOrExpression;

        [SetUp]
        public void Setup()
        {
            this.exclusiveOrExpression = new ExclusiveOrExpression();
        }

        [Test]
        public void VerifyThatStringValueReturnsExpectedResult()
        {
            Assert.AreEqual("XOR", this.exclusiveOrExpression.StringValue);
        }
    }
}
