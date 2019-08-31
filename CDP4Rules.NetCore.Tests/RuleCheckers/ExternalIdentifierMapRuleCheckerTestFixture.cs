// <copyright file="ExternalIdentifierMapRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ExternalIdentifierMapRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ExternalIdentifierMapRuleCheckerTestFixture
    {
        private ExternalIdentifierMapRuleChecker externalIdentifierMapRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private ExternalIdentifierMap externalIdentifierMap;

        [SetUp]
        public void SetUp()
        {
            this.externalIdentifierMapRuleChecker = new ExternalIdentifierMapRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.externalIdentifierMap = new ExternalIdentifierMap();

            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.ExternalIdentifierMap.Add(this.externalIdentifierMap);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.externalIdentifierMapRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.externalIdentifierMapRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_ReferenceSource_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            otherSiteReferenceDataLibrary.ReferenceSource.Add(referenceSource);

            this.externalIdentifierMap.ExternalFormat = referenceSource;

            var result = this.externalIdentifierMapRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.externalIdentifierMap).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0260"));
            Assert.That(result.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:SOURCE of ExternalIdentifierMap.ExternalFormat is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.externalIdentifierMap));
        }

        [Test]
        public void Verify_that_when_ReferenceSource_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            this.modelReferenceDataLibrary.ReferenceSource.Add(referenceSource);

            this.externalIdentifierMap.ExternalFormat = referenceSource;

            var results = this.externalIdentifierMapRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.externalIdentifierMap);

            Assert.That(results, Is.Empty);
        }
    }
}