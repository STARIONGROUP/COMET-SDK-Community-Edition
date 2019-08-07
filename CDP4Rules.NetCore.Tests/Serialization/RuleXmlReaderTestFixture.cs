// <copyright file="RuleXmlReaderTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Rules.NetCore.Tests.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using CDP4Rules.Serialization;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="RuleXmlReader"/> class.
    /// </summary>
    [TestFixture]
    public class RuleXmlReaderTestFixture
    {
        private RuleXmlReader ruleXmlReader;

        [SetUp]
        public void SetUp()
        {
            this.ruleXmlReader = new RuleXmlReader();
        }

        [Test]
        public void Verify_that_rules_can_be_deserialized_from_resource()
        {
            var rules = this.ruleXmlReader.Deserialize();

            Assert.That(rules, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Verify_that_rules_properties_can_are_deserialized()
        {
            var rules = this.ruleXmlReader.Deserialize();

            var rule = rules.Single(r => r.Id == "MA-0500");

            Assert.That(rule.Description, Is.EqualTo("Checks whether a Thing does not reference a DeprecatableThing where DeprecatableThing.isDeprecated = true"));
            Assert.That(rule.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(rule.Notes, Is.EqualTo("DeprecatableThing where DeprecatableThingisDeprecated = true are ignored"));

        }
    }
}