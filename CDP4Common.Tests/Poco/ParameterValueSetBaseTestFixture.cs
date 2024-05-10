// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBaseTestFixture.cs" company="Starion Group S.A.">
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

    using CDP4Common.Exceptions;
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
            Assert.That(this.parameterValueSetBase.ActualValue, Is.EqualTo(this.parameterValueSetBase.Computed));

            this.parameterValueSetBase.ValueSwitch = ParameterSwitchKind.REFERENCE;
            Assert.That(this.parameterValueSetBase.ActualValue, Is.EqualTo(this.parameterValueSetBase.Reference));

            this.parameterValueSetBase.ValueSwitch = ParameterSwitchKind.MANUAL;
            Assert.That(this.parameterValueSetBase.ActualValue, Is.EqualTo(this.parameterValueSetBase.Manual));
        }

        [Test]
        public void TestGetOwner1()
        {
            var container = new Parameter();
            container.Owner = new DomainOfExpertise();

            container.ValueSet.Add(this.parameterValueSetBase as ParameterValueSet);

            Assert.That(ReferenceEquals(container.Owner, this.parameterValueSetBase.Owner), Is.True);
        }

        [Test]
        public void TestGetOwner2()
        {
            var container = new ParameterOverride();
            container.Owner = new DomainOfExpertise();
            this.parameterValueSetBase = new ParameterOverrideValueSet();

            container.ValueSet.Add(this.parameterValueSetBase as ParameterOverrideValueSet);

            Assert.That(ReferenceEquals(container.Owner, this.parameterValueSetBase.Owner), Is.True);
        }

        [Test]
        public void TestGetOwnerThrowsEx()
        {
            Assert.Throws<ContainmentException>(() =>
            {
                Console.WriteLine(this.parameterValueSetBase.Owner);    
            });
        }
    }
}