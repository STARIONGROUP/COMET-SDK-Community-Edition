// <copyright file="ConstantRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ConstantRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ConstantRuleCheckerTestFixture
    {
        private ConstantRuleChecker constantRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private Constant constant;

        [SetUp]
        public void SetUp()
        {
            this.constantRuleChecker = new ConstantRuleChecker();

            this.constant = new Constant();
            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.siteReferenceDataLibrary.Constant.Add(this.constant);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.constantRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_BinaryRelationship_exception_is_thrown()
        {
            var alias = new Alias();

            Assert.Throws<ArgumentException>(() => this.constantRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_not_in_chain_of_rdls_result_is_returned()
        {
            var parameterType = new TextParameterType();
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.ParameterType.Add(parameterType);

            this.constant.ParameterType = parameterType;

            var result = this.constantRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.constant).First();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.constant));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_ParameterType_is_in_chain_of_rdls_no_result_is_returned()
        {
            var parameterType = new TextParameterType();
            this.siteReferenceDataLibrary.ParameterType.Add(parameterType);
            this.constant.ParameterType = parameterType;

            var results = this.constantRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.constant);

            Assert.That(results, Is.Empty);
        }
    }
}