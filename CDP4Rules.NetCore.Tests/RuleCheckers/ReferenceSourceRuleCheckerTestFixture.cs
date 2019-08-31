// <copyright file="ReferenceSourceRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ReferenceSourceRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ReferenceSourceRuleCheckerTestFixture
    {
        private ReferenceSourceRuleChecker referenceSourceRuleChecker;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        private ReferenceSource referenceSource;

        [SetUp]
        public void SetUp()
        {
            this.referenceSourceRuleChecker = new ReferenceSourceRuleChecker();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.referenceSource = new ReferenceSource { Iid = Guid.Parse("27fc9848-a2cd-4ecd-a4d0-dae1f87cb659"), ShortName = "SOURCE" };
            this.siteReferenceDataLibrary.ReferenceSource.Add(this.referenceSource);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedReferenceSourceIsInChainOfRdls_is_called_with_null_thing_exception_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.referenceSourceRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedReferenceSourceIsInChainOfRdls_is_called_with_incorrect_thing_exception_thrown()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => this.referenceSourceRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(elementDefinition));
        }

        [Test]
        public void Verify_that_when_ReferenceSource_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var referencedReferenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "REFERENCED-SOURCE" };
            otherSiteReferenceDataLibrary.ReferenceSource.Add(referencedReferenceSource);

            this.referenceSource.PublishedIn = referencedReferenceSource;

            var result = this.referenceSourceRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.referenceSource).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0260"));
            Assert.That(result.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:REFERENCED-SOURCE of ReferenceSource.PublishedIn is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.referenceSource));
        }

        [Test]
        public void Verify_that_when_ReferenceSource_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var referencedReferenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "REFERENCED-SOURCE" };
            this.siteReferenceDataLibrary.ReferenceSource.Add(referencedReferenceSource);

            this.referenceSource.PublishedIn = referencedReferenceSource;

            var results = this.referenceSourceRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.referenceSource);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var organization = new Organization
            {
                Iid = Guid.Parse("9f4daf6a-09e2-4ed5-a8be-79a0765654ca"),
                ShortName = "RHEA",
                IsDeprecated = true
            };

            var referencedReferenceSource = new ReferenceSource
            {
                Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"),
                ShortName = "REFERENCED-SOURCE",
                IsDeprecated = true
            };

            this.referenceSource.Publisher = organization;
            this.referenceSource.PublishedIn = referencedReferenceSource;
            
            var results = this.referenceSourceRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.referenceSource);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced Organization 9f4daf6a-09e2-4ed5-a8be-79a0765654ca:RHEA of ReferenceSource.Publisher is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.referenceSource));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var last = results.Last();
            Assert.That(last.Id, Is.EqualTo("MA-0500"));
            Assert.That(last.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:REFERENCED-SOURCE of ReferenceSource.PublishedIn is deprecated"));
            Assert.That(last.Thing, Is.EqualTo(this.referenceSource));
            Assert.That(last.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var organization = new Organization
            {
                Iid = Guid.Parse("9f4daf6a-09e2-4ed5-a8be-79a0765654ca"),
                ShortName = "RHEA",
                IsDeprecated = false
            };

            var referencedReferenceSource = new ReferenceSource
            {
                Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"),
                ShortName = "REFERENCED-SOURCE",
                IsDeprecated = false
            };

            this.referenceSource.Publisher = organization;
            this.referenceSource.PublishedIn = referencedReferenceSource;

            var results = this.referenceSourceRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.referenceSource);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var organization = new Organization
            {
                Iid = Guid.Parse("9f4daf6a-09e2-4ed5-a8be-79a0765654ca"),
                ShortName = "RHEA",
                IsDeprecated = true
            };

            var referencedReferenceSource = new ReferenceSource
            {
                Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"),
                ShortName = "REFERENCED-SOURCE",
                IsDeprecated = true
            };

            this.referenceSource.Publisher = organization;
            this.referenceSource.PublishedIn = referencedReferenceSource;
            this.referenceSource.IsDeprecated = true;

            var results = this.referenceSourceRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.referenceSource);

            Assert.That(results, Is.Empty);
        }
    }
}