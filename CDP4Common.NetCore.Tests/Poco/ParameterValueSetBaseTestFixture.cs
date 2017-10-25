// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBaseTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class ParameterValueSetBaseTestFixture
    {
        private ParameterValueSetBase parameterValueSetBase;

        [SetUp]
        public void Setup()
        {
            this.parameterValueSetBase = new ParameterValueSet();
        }

        [Test]
        public void TestGetActualValue()
        {
            this.parameterValueSetBase.ValueSwitch = ParameterSwitchKind.COMPUTED;
            Assert.AreEqual(this.parameterValueSetBase.Computed, this.parameterValueSetBase.ActualValue);

            this.parameterValueSetBase.ValueSwitch = ParameterSwitchKind.REFERENCE;
            Assert.AreEqual(this.parameterValueSetBase.Reference, this.parameterValueSetBase.ActualValue);

            this.parameterValueSetBase.ValueSwitch = ParameterSwitchKind.MANUAL;
            Assert.AreEqual(this.parameterValueSetBase.Manual, this.parameterValueSetBase.ActualValue);
        }

        [Test]
        public void TestGetOwner1()
        {
            var container = new Parameter();
            container.Owner = new DomainOfExpertise();

            container.ValueSet.Add(this.parameterValueSetBase as ParameterValueSet);

            Assert.IsTrue(ReferenceEquals(container.Owner, this.parameterValueSetBase.Owner));
        }

        [Test]
        public void TestGetOwner2()
        {
            var container = new ParameterOverride();
            container.Owner = new DomainOfExpertise();
            this.parameterValueSetBase = new ParameterOverrideValueSet();

            container.ValueSet.Add(this.parameterValueSetBase as ParameterOverrideValueSet);

            Assert.IsTrue(ReferenceEquals(container.Owner, this.parameterValueSetBase.Owner));
        }

        [Test]
        public void TestGetOwnerThrowsEx()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(this.parameterValueSetBase.Owner);    
            });
        }
    }
}