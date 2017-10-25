// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayParserTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Types
{
    using CDP4Common.Types;
    using NUnit.Framework;

    [TestFixture]
    internal class ValueArrayParserTestFixture
    {
        private string error;
        private ValueArray<int> result;

        [SetUp]
        public void Setup()
        {
            this.error = string.Empty;
            result = null;
        }

        [Test]
        public void VerifyThatStringToValueArrayIntWorks()
        {
            var stringArray = "{1;2;3}";
            Assert.IsTrue(stringArray.TryParseToIntValueArray(out result, out error));

            Assert.AreEqual(1, this.result[0]);
            Assert.AreEqual(2, this.result[1]);
            Assert.AreEqual(3, this.result[2]);
        }

        [Test]
        public void VerifyThatStringToValueArrayIntWorks2()
        {
            var stringArray = "{1}";
            Assert.IsTrue(stringArray.TryParseToIntValueArray(out result, out error));

            Assert.AreEqual(1, this.result[0]);
        }

        [Test]
        public void VerifyThatExceptionThrown1()
        {
            var stringArray = "";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }

        [Test]
        public void VerifyThatExceptionThrown2()
        {
            var stringArray = "1";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }

        [Test]
        public void VerifyThatExceptionThrown3()
        {
            var stringArray = "{1,2}";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }
    }
}