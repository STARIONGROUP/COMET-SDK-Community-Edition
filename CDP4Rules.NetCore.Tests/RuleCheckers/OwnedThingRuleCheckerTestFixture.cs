// <copyright file="OwnedThingRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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

using System.Linq;

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="OwnedThingRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class OwnedThingRuleCheckerTestFixture
    {
        private OwnedThingRuleChecker ownedThingRuleChecker;

        private DomainOfExpertise domainOfExpertise;

        private Iteration iteration;

        [SetUp]
        public void SetUp()
        {
            this.ownedThingRuleChecker = new OwnedThingRuleChecker();

            var siteDirectory = new SiteDirectory();
            this.domainOfExpertise = new DomainOfExpertise();
            siteDirectory.Domain.Add(this.domainOfExpertise);

            var engineeringModelSetup = new EngineeringModelSetup();
            siteDirectory.Model.Add(engineeringModelSetup);
            engineeringModelSetup.ActiveDomain.Add(this.domainOfExpertise);

            var engineeringModel = new EngineeringModel();
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;
            this.iteration = new Iteration();
            engineeringModel.Iteration.Add(this.iteration);
        }

        [Test]
        public void Verify_that_when_CheckWheterTheLanguageCodeExistsInTheSiteDirectory_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.ownedThingRuleChecker.ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain(null));
        }

        [Test]
        public void Verify_that_when_CheckWheterTheLanguageCodeExistsInTheSiteDirectory_is_called_with_incorrect_thing_exception_thrown()
        {
            var option = new Option();
            Assert.Throws<ArgumentException>(() => this.ownedThingRuleChecker.ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain(option));
        }

        [Test]
        public void Verify_that_when_ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain_is_called_when_domain_is_not_in_activeDomain_result_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            elementDefinition.Owner = new DomainOfExpertise { Iid = Guid.Parse("7f1bacf8-9517-44d1-aead-6cf9c3027db7"), ShortName = "SYS"};
            this.iteration.Element.Add(elementDefinition);

            var result = this.ownedThingRuleChecker.ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain(elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0110"));

            Assert.That(result.Description,
                Is.EqualTo("The Owner 7f1bacf8-9517-44d1-aead-6cf9c3027db7:SYS is not an active Domain of the container Engineering Model"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));

        }

        [Test]
        public void Verify_that_when_ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain_is_called_when_domain_is_in_activeDomain_empty_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            elementDefinition.Owner = this.domainOfExpertise;
            this.iteration.Element.Add(elementDefinition);

            var result = this.ownedThingRuleChecker.ChecksWhetherTheReferencedOwnerDomainOfExpertiseIsIsAnActiveDomain(elementDefinition);
            Assert.That(result, Is.Empty);
        }
    }
}