// <copyright file="UserRuleVerificationRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="UserRuleVerificationRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class UserRuleVerificationRuleCheckerTestFixture
    {
        private UserRuleVerificationRuleChecker userRuleVerificationRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private RuleVerificationList ruleVerificationList;

        private UserRuleVerification userRuleVerification;

        [SetUp]
        public void SetUp()
        {
            this.userRuleVerificationRuleChecker = new UserRuleVerificationRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.ruleVerificationList = new RuleVerificationList();
            this.userRuleVerification = new UserRuleVerification();

            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.RuleVerificationList.Add(this.ruleVerificationList);
            this.ruleVerificationList.RuleVerification.Add(this.userRuleVerification);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.userRuleVerificationRuleChecker.CheckWhetherReferencedRuleIsInChainOfRlds(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.userRuleVerificationRuleChecker.CheckWhetherReferencedRuleIsInChainOfRlds(alias));
        }

        [Test]
        public void Verify_that_when_Rule_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var rule = new DecompositionRule { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "RULE" };
            otherSiteReferenceDataLibrary.Rule.Add(rule);

            this.userRuleVerification.Rule = rule;

            var result = this.userRuleVerificationRuleChecker.CheckWhetherReferencedRuleIsInChainOfRlds(this.userRuleVerification).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0250"));
            Assert.That(result.Description, Is.EqualTo("The referenced Rule 3c44c0e3-d2de-43f9-9636-8235984dc4bf:RULE of UserRuleVerification.Rule is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.userRuleVerification));
        }

        [Test]
        public void Verify_that_when_Rule_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var rule = new DecompositionRule { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "RULE" };
            this.modelReferenceDataLibrary.Rule.Add(rule);

            this.userRuleVerification.Rule = rule;

            var results = this.userRuleVerificationRuleChecker.CheckWhetherReferencedRuleIsInChainOfRlds(this.userRuleVerification);

            Assert.That(results, Is.Empty);
        }
    }
}