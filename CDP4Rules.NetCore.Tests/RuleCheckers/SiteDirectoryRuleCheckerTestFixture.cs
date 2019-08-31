// <copyright file="SiteDirectoryRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="SiteDirectoryRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class SiteDirectoryRuleCheckerTestFixture
    {
        private SiteDirectoryRuleChecker siteDirectoryRuleChecker;

        private SiteDirectory siteDirectory;

        private PersonRole personRole;

        private ParticipantRole participantRole;

        [SetUp]
        public void SetUp()
        {
            this.siteDirectoryRuleChecker = new SiteDirectoryRuleChecker();

            this.siteDirectory = new SiteDirectory();
            this.personRole = new PersonRole
            {
                Iid = Guid.Parse("c9e4beec-1b97-4c33-aaea-b8468610af3e"),
                ShortName = "TL"
            };
            this.participantRole = new ParticipantRole
            {
                Iid = Guid.Parse("3e9d77bd-3cc4-4b21-af99-fafd2f4cf64a"),
                ShortName = "DE"
            };

            this.siteDirectory.PersonRole.Add(this.personRole);
            this.siteDirectory.ParticipantRole.Add(this.participantRole);
            this.siteDirectory.DefaultPersonRole = this.personRole;
            this.siteDirectory.DefaultParticipantRole = this.participantRole;
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.siteDirectoryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_UnitFactor_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.siteDirectoryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(alias));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            this.personRole.IsDeprecated = true;
            this.participantRole.IsDeprecated = true;

            var results = this.siteDirectoryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.siteDirectory);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced PersonRole c9e4beec-1b97-4c33-aaea-b8468610af3e:TL of SiteDirectory.DefaultPersonRole is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.siteDirectory));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0500"));
            Assert.That(last.Description, Is.EqualTo("The referenced ParticipantRole 3e9d77bd-3cc4-4b21-af99-fafd2f4cf64a:DE of SiteDirectory.DefaultParticipantRole is deprecated"));
            Assert.That(last.Thing, Is.EqualTo(this.siteDirectory));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            this.personRole.IsDeprecated = false;
            this.participantRole.IsDeprecated = false;

            var results = this.siteDirectoryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.siteDirectory);

            Assert.That(results, Is.Empty);
        }
    }
}