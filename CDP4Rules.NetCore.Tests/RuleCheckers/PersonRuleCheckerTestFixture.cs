// <copyright file="PersonRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="PersonRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class PersonRuleCheckerTestFixture
    {
        private PersonRuleChecker personRuleChecker;

        private Person person;

        [SetUp]
        public void SetUp()
        {
            this.personRuleChecker = new PersonRuleChecker();

            this.person = new Person();
        }

        [Test]
        public void Verify_that_when_ChecksWhetherAReferencedDeprecatableThingIsDeprecated_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.personRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(null));
        }

        [Test]
        public void Verify_that_when_ChecksWhetherAReferencedDeprecatableThingIsDeprecated_is_called_with_incorrect_thing_exception_thrown()
        {
            var elementDefinition = new ElementDefinition();
            Assert.Throws<ArgumentException>(() => this.personRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(elementDefinition));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var organization = new Organization
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "Starion",
                IsDeprecated = true
            };

            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = true
            };

            var personRole = new PersonRole()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "OBS",
                IsDeprecated = true
            };

            this.person.Organization = organization;
            this.person.DefaultDomain = domainOfExpertise;
            this.person.Role = personRole;

            var results = this.personRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.person);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced Organization 7f1bacf8-9517-44d1-aead-6cf9c3027db7:Starion of Person.Organization is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.person));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var second = results.ElementAt(1);
            Assert.That(second.Id, Is.EqualTo("MA-0500"));
            Assert.That(second.Description, Is.EqualTo("The referenced DomainOfExpertise 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SYS of Person.DefaultDomain is deprecated"));
            Assert.That(second.Thing, Is.EqualTo(this.person));
            Assert.That(second.Severity, Is.EqualTo(SeverityKind.Warning));

            var third = results.ElementAt(2);
            Assert.That(third.Id, Is.EqualTo("MA-0500"));
            Assert.That(third.Description, Is.EqualTo("The referenced PersonRole 7f1bacf8-9517-44d1-aead-6cf9c3027db7:OBS of Person.Role is deprecated"));
            Assert.That(third.Thing, Is.EqualTo(this.person));
            Assert.That(third.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var organization = new Organization()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "Starion",
                IsDeprecated = false
            };

            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = false
            };

            var personRole = new PersonRole()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "OBS",
                IsDeprecated = false
            };

            this.person.Organization = organization;
            this.person.DefaultDomain = domainOfExpertise;
            this.person.Role = personRole;

            var results = this.personRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.person);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var organization = new Organization
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "Starion",
                IsDeprecated = true
            };

            var domainOfExpertise = new DomainOfExpertise
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "SYS",
                IsDeprecated = true
            };

            var personRole = new PersonRole()
            {
                Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"),
                ShortName = "OBS",
                IsDeprecated = true
            };

            this.person.Organization = organization;
            this.person.DefaultDomain = domainOfExpertise;
            this.person.Role = personRole;
            this.person.IsDeprecated = true;

            var results = this.personRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.person);

            Assert.That(results, Is.Empty);
        }
    }
}