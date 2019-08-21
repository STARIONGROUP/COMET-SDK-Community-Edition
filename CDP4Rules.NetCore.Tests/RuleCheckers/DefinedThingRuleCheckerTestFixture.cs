// <copyright file="DefinedThingRuleChecker.cs" company="RHEA System S.A.">
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
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DefinedThingRuleChecker"/> class
    /// </summary>
    [TestFixture]
    public class DefinedThingRuleCheckerTestFixture
    {
        private DefinedThingRuleChecker definedThingRuleChecker;

        private Requirement requirement;

        [SetUp]
        public void SetUp()
        {
            this.definedThingRuleChecker = new DefinedThingRuleChecker();

            this.requirement = new Requirement();
        }

        [Test]
        public void Verify_that_when_CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage_is_called_whith_null_parameter_an_exception_is_throw()
        {
            Assert.Throws<ArgumentNullException>(() => this.definedThingRuleChecker.CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage_is_called_whith_non_defined_Thing_an_exception_is_throw()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.definedThingRuleChecker.CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage(alias));
        }

        [Test]
        public void Verify_that_when_a_DefinedThing_contains_non_unique_NaturalLanguageDefinitions_a_result_is_returned()
        {
            var english_def_1 = new CDP4Common.CommonData.Definition { Iid = Guid.Parse("e9a80cab-680b-4b2c-98bb-47de59e49e25"), LanguageCode = "en-GB"};

            var english_def_2 = new CDP4Common.CommonData.Definition { Iid = Guid.Parse("19f45e4c-7c54-4653-9ccc-13580413768b"), LanguageCode = "en-GB" };

            var french_def_1 = new CDP4Common.CommonData.Definition { Iid = Guid.Parse("bb71b34e-cabd-424a-9318-81553338012e"), LanguageCode = "fr" };

            this.requirement.Definition.Add(english_def_1);
            this.requirement.Definition.Add(english_def_2);
            this.requirement.Definition.Add(french_def_1);

            var result = this.definedThingRuleChecker.CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage(requirement).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0400"));
            Assert.That(result.Description, Is.EqualTo("The DefinedThing contains Definitions with non-unique language codes: e9a80cab-680b-4b2c-98bb-47de59e49e25,19f45e4c-7c54-4653-9ccc-13580413768b; with LanguageCodes: en-GB,en-GB"));
            Assert.That(result.Thing, Is.EqualTo(this.requirement));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_a_DefinedThing_contains_language_unique_NaturalLanguageDefinitions_null_is_returned()
        {
            var english_def_1 = new CDP4Common.CommonData.Definition { Iid = Guid.Parse("e9a80cab-680b-4b2c-98bb-47de59e49e25"), LanguageCode = "en-GB" };

            var french_def_1 = new CDP4Common.CommonData.Definition { Iid = Guid.Parse("bb71b34e-cabd-424a-9318-81553338012e"), LanguageCode = "fr" };

            this.requirement.Definition.Add(english_def_1);
            this.requirement.Definition.Add(french_def_1);

            var result = this.definedThingRuleChecker.CheckWhetherADefinedThingHasAtMostOneDefinitionPerNaturalLanguage(requirement);

            Assert.That(result, Is.Empty);
        }
    }
}