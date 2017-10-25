// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterTypeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class ArrayParameterTypeTestFixture
    {
        private ArrayParameterType arrayParameterType;

        [SetUp]
        public void Setup()
        {
            this.arrayParameterType = new ArrayParameterType(Guid.NewGuid(), null, null);
        }

        [Test]
        public void TestGetters()
        {
            Assert.AreEqual(0, this.arrayParameterType.Rank);
            Assert.IsFalse(this.arrayParameterType.HasSingleComponentType);
        }
    }
}