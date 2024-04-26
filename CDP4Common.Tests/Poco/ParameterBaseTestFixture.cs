// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
        public void VerifyThatLevelReturnsTheExpectedResult()
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
            
            Assert.That(parameter_0.Level(), Is.EqualTo(0));
            Assert.That(parameterlevel1.Level(), Is.EqualTo(1));
            Assert.That(parameterlevel2.Level(), Is.EqualTo(2));
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
