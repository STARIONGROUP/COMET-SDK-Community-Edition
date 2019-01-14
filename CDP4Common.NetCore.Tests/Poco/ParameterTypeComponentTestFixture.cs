#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponentTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
