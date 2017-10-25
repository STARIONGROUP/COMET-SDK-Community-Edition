// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="ParameterBase"/> class
    /// </summary>
    public class ParameterBaseTestFixture
    {
        [Test]
        public void VerifyThatLevelReturnsTheExpectedResuly()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGrouplevel0 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGrouplevel0);

            var parameterGroulevel1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroulevel1);
            parameterGroulevel1.ContainingGroup = parameterGrouplevel0;

            var parameter_0 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_0);

            var parameterlevel1 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameterlevel1);
            parameterlevel1.Group = parameterGrouplevel0;

            var parameterlevel2 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameterlevel2);
            parameterlevel2.Group = parameterGroulevel1;
            
            Assert.AreEqual(0, parameter_0.Level());
            Assert.AreEqual(1, parameterlevel1.Level());
            Assert.AreEqual(2, parameterlevel2.Level());
        }

        [Test]
        public void VerifyThatGetRequiredRdlsWorks()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var parameter = new Parameter(Guid.NewGuid(), null, null);
            var type = new BooleanParameterType(Guid.NewGuid(), null, null);

            mrdl.RequiredRdl = srdl1;
            srdl2.RequiredRdl = srdl1;

            parameter.ParameterType = type;
            mrdl.ParameterType.Add(type);

            Assert.IsTrue(parameter.RequiredRdls.Contains(srdl1));
            Assert.IsTrue(parameter.RequiredRdls.Contains(mrdl));
            Assert.IsFalse(parameter.RequiredRdls.Contains(srdl2));
        }

        [Test]
        public void VerifyThatParameterBaseValueSetWorks()
        {
            var parameter = new Parameter();
            var poverride = new ParameterOverride();
            var subscription = new ParameterSubscription();

            var parameterValueSet = new ParameterValueSet();
            var overrideValueset = new ParameterOverrideValueSet();
            var subscriptionValueset = new ParameterSubscriptionValueSet();

            parameter.ValueSet.Add(parameterValueSet);
            poverride.ValueSet.Add(overrideValueset);
            subscription.ValueSet.Add(subscriptionValueset);

            Assert.AreSame(parameter.ValueSet, parameter.ValueSets);
            Assert.AreSame(poverride.ValueSet, poverride.ValueSets);
            Assert.AreSame(subscription.ValueSet, subscription.ValueSets);
        }
    }
}
