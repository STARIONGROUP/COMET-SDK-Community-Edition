#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementTestFixture.cs" company="RHEA System S.A.">
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
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    public class RequirementTestFixture
    {
        [Test]
        public void VerifyThatInvalidOperationIsThrownWhenContainerIsNotSet()
        {
            var requirement = new Requirement();
            Assert.Throws<InvalidOperationException>(() => requirement.GroupPath());
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenGroupedAndDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };
            requirementsSpecification.Requirement.Add(requirement);
            
            var requirementsGroupA = new RequirementsGroup() {ShortName = "a"};
            var requirementsGroupAA = new RequirementsGroup() { ShortName = "a_a" };

            requirementsGroupA.Group.Add(requirementsGroupAA);
            requirementsSpecification.Group.Add(requirementsGroupA);

            requirement.Group = requirementsGroupAA;

            Assert.AreEqual("spec.a.a_a.req", requirement.GroupPath());
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenGroupedAndNonDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };
            requirementsSpecification.Requirement.Add(requirement);

            var requirementsGroupA = new RequirementsGroup() { ShortName = "a" };
            var requirementsGroupAA = new RequirementsGroup() { ShortName = "a_a" };

            requirementsGroupA.Group.Add(requirementsGroupAA);
            requirementsSpecification.Group.Add(requirementsGroupA);

            requirement.Group = requirementsGroupAA;

            Assert.AreEqual("spec;a;a_a;req", requirement.GroupPath(';'));
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.AreEqual("spec.req", requirement.GroupPath());            
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndNonDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.AreEqual("spec,req", requirement.GroupPath(','));
        }
    }
}
