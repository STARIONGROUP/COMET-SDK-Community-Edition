// <copyright file="ParameterTypeRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterTypeRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterTypeRuleCheckerTestFixture
    {
        private ParameterTypeRuleChecker parameterTypeRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private TextParameterType parameterType_1;

        private TextParameterType parameterType_2;

        private TextParameterType parameterType_3;

        [SetUp]
        public void SetUp()
        {
            this.parameterTypeRuleChecker = new ParameterTypeRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.parameterType_1 = new TextParameterType { Iid = Guid.Parse("d501f2e8-896f-4027-b0e4-c0fe6b8507b5") };
            this.parameterType_2 = new TextParameterType { Iid = Guid.Parse("6fb0c4a0-fd3f-444e-9efb-dad00f08cf2f") };
            this.parameterType_3 = new TextParameterType { Iid = Guid.Parse("9bf61f1e-65ea-4dc1-9199-41cda57aba4e") };

            this.siteReferenceDataLibrary.ParameterType.Add(this.parameterType_1);
            this.siteReferenceDataLibrary.ParameterType.Add(this.parameterType_2);
            this.siteReferenceDataLibrary.ParameterType.Add(this.parameterType_3);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.parameterTypeRuleChecker.CheckWhetherTheParameterTypeShortNameIsUniqueInTheContainerRdl(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_ParameterType_exception_is_thrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.parameterTypeRuleChecker.CheckWhetherTheParameterTypeShortNameIsUniqueInTheContainerRdl(alias));
        }

        [Test]
        public void Verify_that_when_A_ParameterType_Shortname_is_not_unique_in_the_containing_RDL_a_result_is_returned()
        {
            this.parameterType_1.ShortName = "TEXT";
            this.parameterType_2.ShortName = "TEXT";
            this.parameterType_3.ShortName = "OTHERTEXT";

            var result = this.parameterTypeRuleChecker.CheckWhetherTheParameterTypeShortNameIsUniqueInTheContainerRdl(this.parameterType_1).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0700"));
            Assert.That(result.Description, Is.EqualTo("The ParameterType does not have a unique ShortNames in the container Reference Data Library - 6fb0c4a0-fd3f-444e-9efb-dad00f08cf2f:TEXT"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterType_1));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_A_ParameterType_Symbol_is_not_unique_in_the_containing_RDL_a_result_is_returned()
        {
            this.parameterType_1.Symbol = "TEXT";
            this.parameterType_2.Symbol = "TEXT";
            this.parameterType_3.Symbol = "OTHERTEXT";

            var result = this.parameterTypeRuleChecker.CheckWhetherTheParameterTypeSymbolIsUniqueInTheContainerRdl(this.parameterType_1).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0710"));
            Assert.That(result.Description, Is.EqualTo("The ParameterType does not have a unique Symbols in the container Reference Data Library - 6fb0c4a0-fd3f-444e-9efb-dad00f08cf2f:TEXT"));
            Assert.That(result.Thing, Is.EqualTo(this.parameterType_1));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }
    }
}