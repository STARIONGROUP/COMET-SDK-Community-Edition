// <copyright file="ShortNamedThingCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="ShortNamedThingChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ShortNamedThingCheckerTestFixture
    {
        private ShortNamedThingChecker shortNamedThingChecker;
        
        [SetUp]
        public void SetUp()
        {
            this.shortNamedThingChecker = new ShortNamedThingChecker();
        }

        [Test]
        public void
            Verify_that_when_CheckWhetherTheShortNameIsAValidShortName_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(null));
        }

        [Test]
        public void
            Verify_that_when_CheckWheterTheLanguageCodeExistsInTheSiteDirectory_is_called_with_incorrect_thing_exception_thrown()
        {
            var hyperLink = new HyperLink();
            Assert.Throws<ArgumentException>(() => this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(hyperLink));
        }

        [Test]
        public void Verify_that_when_an_ElementBase_has_an_invalid_shortname_a_result_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            elementDefinition.ShortName = "123Xa -";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0010"));
            Assert.That(result.Thing, Is.EqualTo(elementDefinition));
            Assert.That(result.Description, Is.EqualTo("The ShortName: 123Xa - is invalid. The ShortName must start with a letter and not contain any spaces or non alphanumeric characters."));
        }

        [Test]
        public void Verify_that_when_an_ElementBase_has_an_valid_shortname_empty_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            elementDefinition.ShortName = "BAT";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(elementDefinition);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_when_a_RequirementsContainer_has_an_invalid_shortname_a_result_is_returned()
        {
            var requirementsSpecification = new RequirementsSpecification();
            requirementsSpecification.ShortName = "123 we";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(requirementsSpecification).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0010"));
            Assert.That(result.Thing, Is.EqualTo(requirementsSpecification));
            Assert.That(result.Description, Is.EqualTo("The ShortName: 123 we is invalid. The ShortName must start with a letter and not contain any spaces or non alphanumeric characters."));
        }

        [Test]
        public void Verify_that_when_a_RequirementsContainer_has_an_valid_shortname_null_is_returned()
        {
            var requirementsSpecification = new RequirementsSpecification();
            requirementsSpecification.ShortName = "MRD";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(requirementsSpecification);

            Assert.That(result, Is.Empty);
        }
        
        [Test]
        public void Verify_that_when_a_IShortNamedThing_has_an_invalid_shortname_a_result_is_returned()
        {
            var requirement = new Requirement();
            requirement.ShortName = "contains a space";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(requirement).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0010"));
            Assert.That(result.Thing, Is.EqualTo(requirement));
            Assert.That(result.Description, Is.EqualTo("The ShortName: contains a space is invalid. A shortName should not contain any whitespace"));
        }

        [Test]
        public void Verify_that_when_a_IShortNamedThing_has_an_valid_shortname_null_is_returned()
        {
            var requirement = new Requirement();
            requirement.ShortName = "MR-010";

            var result = this.shortNamedThingChecker.CheckWhetherTheShortNameIsAValidShortName(requirement);

            Assert.That(result, Is.Empty);
        }
    }
}