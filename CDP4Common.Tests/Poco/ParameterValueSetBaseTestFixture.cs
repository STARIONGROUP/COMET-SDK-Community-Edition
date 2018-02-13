#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBaseTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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