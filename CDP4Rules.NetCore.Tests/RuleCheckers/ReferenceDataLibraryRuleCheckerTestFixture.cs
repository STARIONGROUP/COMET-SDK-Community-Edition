// <copyright file="ReferenceDataLibraryRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ReferenceDataLibraryRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ReferenceDataLibraryRuleCheckerTestFixture
    {
        private ReferenceDataLibraryRuleChecker referenceDataLibraryRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private SiteReferenceDataLibrary siteReferenceDataLibrary;

        [SetUp]
        public void SetUp()
        {
            this.referenceDataLibraryRuleChecker = new ReferenceDataLibraryRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();

            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary
            {
                Iid = Guid.Parse("9de8bb06-e696-42a4-9cb5-ac9ca2f1ff43"),
                ShortName = "GENERIC"
            };

            this.modelReferenceDataLibrary.RequiredRdl = this.siteReferenceDataLibrary;
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.referenceDataLibraryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.referenceDataLibraryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(alias));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            this.siteReferenceDataLibrary.IsDeprecated = true;

            var results = this.referenceDataLibraryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.modelReferenceDataLibrary);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced SiteReferenceDataLibrary 9de8bb06-e696-42a4-9cb5-ac9ca2f1ff43:GENERIC of ReferenceDataLibrary.RequiredRdl is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.modelReferenceDataLibrary));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            this.siteReferenceDataLibrary.IsDeprecated = false;

            var results = this.referenceDataLibraryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.modelReferenceDataLibrary);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_DeprecatableThing_Is_Deprecated_no_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary
            {
                Iid = Guid.Parse("ac3027f4-0dcc-4be6-ae45-03e2656670b4"),
                ShortName = "OTHER",
                IsDeprecated = true
            };

            this.siteReferenceDataLibrary.IsDeprecated = true;
            this.siteReferenceDataLibrary.RequiredRdl = otherSiteReferenceDataLibrary;

            var results = this.referenceDataLibraryRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.siteReferenceDataLibrary);

            Assert.That(results, Is.Empty);
        }
    }
}