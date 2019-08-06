﻿// <copyright file="AnnotationRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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

using CDP4Common.EngineeringModelData;

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="AnnotationRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class AnnotationRuleCheckerTestFixture
    {
        private AnnotationRuleChecker annotationRuleChecker;

        private SiteDirectory siteDirectory;

        private EngineeringModelSetup engineeringModelSetup;

        [SetUp]
        public void SetUp()
        {
            this.annotationRuleChecker = new AnnotationRuleChecker();

            this.siteDirectory = new SiteDirectory();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.siteDirectory.Model.Add(this.engineeringModelSetup);
        }

        [Test]
        public void Verify_that_CheckWheterTheLanguageCodeExistsInTheSiteDirectory_yields_correct_result_for_SiteDirectory_Contained_Alias()
        {
            var alias = new Alias();
            alias.LanguageCode = "en-GB";

            this.engineeringModelSetup.Alias.Add(alias);

            var result = this.annotationRuleChecker.CheckWheterTheLanguageCodeExistsInTheSiteDirectory(alias);

            Assert.That(result.Id, Is.EqualTo("MA-001"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));

            var naturalLanguage = new NaturalLanguage();
            naturalLanguage.LanguageCode = "en-GB";
            this.siteDirectory.NaturalLanguage.Add(naturalLanguage);

            result = this.annotationRuleChecker.CheckWheterTheLanguageCodeExistsInTheSiteDirectory(alias);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Verify_that_CheckWheterTheLanguageCodeExistsInTheSiteDirectory_yields_correct_result_for_EngineeringModel_Contained_Alias()
        {
            var engineeringModel = new EngineeringModel();
            engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;

            var iteration = new Iteration();
            engineeringModel.Iteration.Add(iteration);

            var elementDefinition = new ElementDefinition();
            iteration.Element.Add(elementDefinition);

            var alias = new Alias {LanguageCode = "en-GB"};
            elementDefinition.Alias.Add(alias);

            var result = this.annotationRuleChecker.CheckWheterTheLanguageCodeExistsInTheSiteDirectory(alias);

            Assert.That(result.Id, Is.EqualTo("MA-001"));
            Assert.That(result.Description, Is.EqualTo($"The Annotation.LanguageCode: {alias.LanguageCode} for Idd: {alias.Iid} does not exist in the SiteDirectory { siteDirectory.Iid}"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));

            var naturalLanguage = new NaturalLanguage();
            naturalLanguage.LanguageCode = "en-GB";
            this.siteDirectory.NaturalLanguage.Add(naturalLanguage);

            result = this.annotationRuleChecker.CheckWheterTheLanguageCodeExistsInTheSiteDirectory(alias);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Verify_that_CheckWeatherTheLanguageCodeIsValid_yields_correct_result()
        {
            var alias = new Alias();
            alias.LanguageCode = "en-GB";

            this.engineeringModelSetup.Alias.Add(alias);

            var result = this.annotationRuleChecker.CheckWeatherTheLanguageCodeIsValid(alias);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Verify_that_RuleCheckerEngine_can_execute_rules()
        {
            var ruleCheckerEngine = new RuleCheckerEngine();

            var alias = new Alias();
            alias.Iid = Guid.NewGuid();
            alias.LanguageCode = "en-GB";
            this.engineeringModelSetup.Alias.Add(alias);

            var result = ruleCheckerEngine.Run(new List<Thing>() { alias }).ToList();

            Assert.That(result, Is.Not.Empty);

            var ruleCheckResult = result.SingleOrDefault(x => x.Id == "MA-001");

            Assert.That(ruleCheckResult.Description, Is.EqualTo($"The Annotation.LanguageCode: en-GB for Idd: {alias.Iid} does not exist in the SiteDirectory { siteDirectory.Iid}"));
            Assert.That(ruleCheckResult.Severity, Is.EqualTo(SeverityKind.Warning));
        }
    }
}