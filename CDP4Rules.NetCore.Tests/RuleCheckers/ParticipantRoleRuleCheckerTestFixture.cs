// <copyright file="ParticipantRoleRuleCheckerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParticipantRoleRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParticipantRoleRuleCheckerTestFixture
    {
        private ParticipantRoleRuleChecker participantRoleRuleChecker;

        private ParticipantRole participantRole;

        private ParticipantPermission participantPermission;

        [SetUp]
        public void SetUp()
        {
            this.participantRoleRuleChecker = new ParticipantRoleRuleChecker();

            this.participantRole = new ParticipantRole();

            this.participantPermission = new ParticipantPermission
            {
                Iid = Guid.Parse("450ef9fb-fc60-4dab-a203-4340f0181102"),
                ObjectClass = ClassKind.Person
            };

            this.participantRole.ParticipantPermission.Add(this.participantPermission);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.participantRoleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_UnitFactor_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.participantRoleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(alias));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            this.participantPermission.IsDeprecated = true;

            var results = this.participantRoleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.participantRole);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced ParticipantPermission 450ef9fb-fc60-4dab-a203-4340f0181102:Person in ParticipantRole.ParticipantPermission is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.participantRole));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            this.participantPermission.IsDeprecated = false;

            var results = this.participantRoleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.participantRole);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            this.participantRole.IsDeprecated = true;
            this.participantPermission.IsDeprecated = true;

            var results = this.participantRoleRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.participantRole);

            Assert.That(results, Is.Empty);
        }
    }
}