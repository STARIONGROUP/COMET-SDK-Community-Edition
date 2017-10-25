// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponentTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterTypeComponent"/> class
    /// </summary>
    [TestFixture]
    public class ParameterTypeComponentTestFixture
    {
        [Test]
        public void VerifyThatTheIndexOfAComponentReturnsTheExpectedResult()
        {
            var compoundParameterType = new CompoundParameterType(Guid.NewGuid(), null, null);

            var component0 = new ParameterTypeComponent(Guid.NewGuid(), null, null);
            var component1 = new ParameterTypeComponent(Guid.NewGuid(), null, null);
            var component2 = new ParameterTypeComponent(Guid.NewGuid(), null, null);
            var componentnocontainer = new ParameterTypeComponent(Guid.NewGuid(), null, null);

            compoundParameterType.Component.Add(component0);
            compoundParameterType.Component.Add(component1);
            compoundParameterType.Component.Add(component2);

            Assert.AreEqual(0, component0.Index);
            Assert.AreEqual(1, component1.Index);
            Assert.AreEqual(2, component2.Index);
            Assert.AreEqual(-1, componentnocontainer.Index);
        }
    }
}
