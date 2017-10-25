// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class ParameterTypeTestFixture
    {
        [Test]
        public void TestGetNumberOfValue()
        {
            var type = new BooleanParameterType();
            Assert.AreEqual(1, type.NumberOfValues);
        }
    }
}