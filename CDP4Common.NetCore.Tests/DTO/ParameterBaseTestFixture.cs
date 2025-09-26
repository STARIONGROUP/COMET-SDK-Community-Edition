// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Tests.DTO
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;

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

            Assert.That(parameter.ValueSets, Is.EqualTo(this.valuesets) );
        }

        [Test]
        public void VerifyThatParameterOverrideReturnsValueSets()
        {
            var parameterOverride = new ParameterOverride(Guid.NewGuid(), 1);
            parameterOverride.ValueSet.AddRange(this.valuesets);

            Assert.That(parameterOverride.ValueSets, Is.EqualTo(this.valuesets));
        }

        [Test]
        public void VerifyThatParameterSubscriptionReturnsValueSets()
        {
            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(), 1);
            parameterSubscription.ValueSet.AddRange(this.valuesets);

            Assert.That(parameterSubscription.ValueSets, Is.EqualTo(this.valuesets));
        }
    }
}
