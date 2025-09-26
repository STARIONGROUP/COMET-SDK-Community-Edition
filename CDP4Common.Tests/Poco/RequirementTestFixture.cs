﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests.Poco
{
    using System;
    
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    [TestFixture]
    public class RequirementTestFixture
    {
        [Test]
        public void VerifyThatInvalidOperationIsThrownWhenContainerIsNotSet()
        {
            var requirement = new Requirement();
            Assert.That(() => requirement.GroupPath(), Throws.TypeOf<InvalidOperationException>());
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

            Assert.That(requirement.GroupPath(), Is.EqualTo("spec.a.a_a.req"));
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

            Assert.That(requirement.GroupPath(';'), Is.EqualTo("spec;a;a_a;req"));
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.That(requirement.GroupPath(), Is.EqualTo("spec.req"));            
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndNonDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.That(requirement.GroupPath(','), Is.EqualTo("spec,req"));
        }
    }
}
