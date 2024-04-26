// <copyright file="ParticipantRuleCheckerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParticipantRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParticipantRuleCheckerTestFixture
    {
        private ParticipantRuleChecker participantRuleChecker;

        private Participant participant;

        [SetUp]
        public void SetUp()
        {
            this.participantRuleChecker = new ParticipantRuleChecker();

            this.participant = new Participant();
        }

        [Test]
        public void Verify_that_when_ChecksWhetherAReferencedDeprecatableThingIsDeprecated_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.participantRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(null));
        }

        [Test]
        public void Verify_that_when_ChecksWhetherAReferencedDeprecatableThingIsDeprecated_is_called_with_incorrect_thing_exception_thrown()
        {
            var elementDefinition = new ElementDefinition();
            Assert.Throws<ArgumentException>(() => this.participantRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(elementDefinition));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = true
            };

            var person = new Person
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "JD",
                IsDeprecated = true
            };

            var participantRole = new ParticipantRole
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "OBS",
                IsDeprecated = true
            };

            this.participant.Domain.Add(domainOfExpertise);
            this.participant.SelectedDomain = domainOfExpertise;
            this.participant.Person = person;
            this.participant.Role = participantRole;

            var results = this.participantRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.participant);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced DomainOfExpertise 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SYS in Participant.Domain is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.participant));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var second = results.ElementAt(1);
            Assert.That(second.Id, Is.EqualTo("MA-0500"));
            Assert.That(second.Description, Is.EqualTo("The referenced DomainOfExpertise 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SYS of Participant.SelectedDomain is deprecated"));
            Assert.That(second.Thing, Is.EqualTo(this.participant));
            Assert.That(second.Severity, Is.EqualTo(SeverityKind.Warning));

            var third = results.ElementAt(2);
            Assert.That(third.Id, Is.EqualTo("MA-0500"));
            Assert.That(third.Description, Is.EqualTo("The referenced Person 7f1bacf8-9517-44d1-aead-6cf9c3027db7:JD of Participant.Person is deprecated"));
            Assert.That(third.Thing, Is.EqualTo(this.participant));
            Assert.That(third.Severity, Is.EqualTo(SeverityKind.Warning));

            var fourth = results.ElementAt(3);
            Assert.That(fourth.Id, Is.EqualTo("MA-0500"));
            Assert.That(fourth.Description, Is.EqualTo("The referenced ParticipantRole 7f1bacf8-9517-44d1-aead-6cf9c3027db7:OBS of Participant.Role is deprecated"));
            Assert.That(fourth.Thing, Is.EqualTo(this.participant));
            Assert.That(fourth.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = false
            };

            var person = new Person
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "JD",
                IsDeprecated = false
            };

            var participantRole = new ParticipantRole
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "OBS",
                IsDeprecated = false
            };

            this.participant.Domain.Add(domainOfExpertise);
            this.participant.SelectedDomain = domainOfExpertise;
            this.participant.Person = person;
            this.participant.Role = participantRole;

            var results = this.participantRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.participant);
            Assert.That(results, Is.Empty);
        }
    }
}