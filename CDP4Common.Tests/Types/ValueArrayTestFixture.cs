// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Types
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ValueArray{T}"/> class
    /// </summary>
    [TestFixture]
    public class ValueArrayTestFixture
    {
        [Test]
        public void VerifyThatValueArrayToStringWorks()
        {
            var array = new ValueArray<float>(new List<float> {1, 2, 3, 4.1f});
            var s = array.ToString();

            Assert.AreEqual("{1; 2; 3; 4.1}", s);
        }

        [Test]
        public void VerifyThatValueArrayToStringWorksWithStrings()
        {
            var array = new ValueArray<string>(new List<string> { "abc", "def", "3", "4.1" });
            var s = array.ToString();

            Assert.AreEqual("{\"abc\"; \"def\"; \"3\"; \"4.1\"}", s);
        }

        [Test]
        public void VerifyThatEmptyArrayReturnsEmptyString()
        {
            var array = new ValueArray<string>(new List<string>());

            Assert.AreEqual(string.Empty, array.ToString());
        }
    }
}
