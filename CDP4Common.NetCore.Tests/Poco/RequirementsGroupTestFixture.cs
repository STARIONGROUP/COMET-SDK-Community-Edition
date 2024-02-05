// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroupTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="RequirementsGroup"/> class
    /// </summary>
    [TestFixture]
    public class RequirementsGroupTestFixture
    {
        [Test]
        public void VerifyThatContainedGroupsReturnsExpectedResult()
        {
            var topGroup = new RequirementsGroup();
            var group_1 = new RequirementsGroup();
            var group_2 = new RequirementsGroup();

            var group_1_1 = new RequirementsGroup();
            var group_1_2 = new RequirementsGroup();

            topGroup.Group.Add(group_1);
            topGroup.Group.Add(group_2);

            group_1.Group.Add(group_1_1);
            group_1.Group.Add(group_1_2);

            var containedGroups = new List<RequirementsGroup>();
            containedGroups.Add(group_1);
            containedGroups.Add(group_2);
            containedGroups.Add(group_1_1);
            containedGroups.Add(group_1_2);

            var actualContainedGroups = topGroup.ContainedGroup().ToList();

            CollectionAssert.AreEquivalent(containedGroups, actualContainedGroups);
        }
    }
}
