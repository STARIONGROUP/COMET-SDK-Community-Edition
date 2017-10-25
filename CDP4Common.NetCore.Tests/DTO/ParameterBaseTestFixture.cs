// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseTestFixture.cs" company="RHEA Systen S.A.">
//   Copyright (c) 2017 RHEA Systen S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.DTO
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO ;
    using NUnit.Framework;

    [TestFixture]
    public class ParameterBaseTestFixture
    {
        private List<Guid> valuesets;

        [SetUp]
        public void SetUp()
        {
            this.valuesets = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };            
        }

        [Test]
        public void VerifyThatParameterReturnsValueSets()
        {
            var parameter = new Parameter(Guid.NewGuid(), 1);
            parameter.ValueSet.AddRange(this.valuesets);

            CollectionAssert.AreEqual(this.valuesets, parameter.ValueSets);
        }

        [Test]
        public void VerifyThatParameterOverrideReturnsValueSets()
        {
            var parameterOverride = new ParameterOverride(Guid.NewGuid(), 1);
            parameterOverride.ValueSet.AddRange(this.valuesets);

            CollectionAssert.AreEqual(this.valuesets, parameterOverride.ValueSets);
        }

        [Test]
        public void VerifyThatParameterSubscriptionReturnsValueSets()
        {
            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(), 1);
            parameterSubscription.ValueSet.AddRange(this.valuesets);

            CollectionAssert.AreEqual(this.valuesets, parameterSubscription.ValueSets);
        }
    }
}
