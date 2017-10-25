// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroupTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace CDP4Common.Tests.Poco
{
    using System.Collections.Generic;
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
