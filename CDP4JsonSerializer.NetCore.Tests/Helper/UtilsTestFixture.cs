// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Helper
{
    using System;

    using CDP4JsonSerializer.Helper;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Utils"/> class
    /// </summary>
    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void VerifyThatFirstLetterIsCapitalized()
        {
            var inputString = "some text";
            var result = Utils.CapitalizeFirstLetter(inputString);
            
            Assert.AreEqual("Some text", result);
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnCapitalizeFirstLetter()
        {
           Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(null));

           Assert.Throws<ArgumentException>(() => Utils.CapitalizeFirstLetter(string.Empty));
        }

        [Test]
        public void VerifyThatFirstLetterIsLowerCased()
        {
            var inputString = "Some text";
            var result = Utils.LowercaseFirstLetter(inputString);

            Assert.AreEqual("some text", result);
        }

        [Test]
        public void VerifyThatArgumentExceptionIsThrownOnLowerCased()
        {
            Assert.Throws<ArgumentException>(() => Utils.LowercaseFirstLetter(null));

            Assert.Throws<ArgumentException>(() => Utils.LowercaseFirstLetter(string.Empty));
        }
    }
}
