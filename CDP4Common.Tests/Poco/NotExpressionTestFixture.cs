// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotExpressionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="NotExpression"/> class
    /// </summary>
    [TestFixture]
    public class NotExpressionTestFixture
    {
        private NotExpression notExpression;

        [SetUp]
        public void Setup()
        {
            this.notExpression = new NotExpression();
        }

        [Test]
        public void VerifyThatStringValueReturnsExpectedResult()
        {
            Assert.AreEqual("NOT", this.notExpression.StringValue);
        }
    }
}
