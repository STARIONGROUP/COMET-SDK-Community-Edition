// <copyright file="CitationRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CitationRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class CitationRuleCheckerTestFixture
    {
        private CitationRuleChecker citationRuleChecker;

        private SiteDirectory siteDirectory;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private ElementDefinition elementDefinition;

        private Definition definition;

        private Citation citation;

        [SetUp]
        public void SetUp()
        {
            this.citationRuleChecker = new CitationRuleChecker();

            this.siteDirectory = new SiteDirectory();
            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.elementDefinition = new ElementDefinition();
            this.definition = new Definition();
            this.citation = new Citation();
            
            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.Element.Add(this.elementDefinition);
            this.elementDefinition.Definition.Add(this.definition);
            this.definition.Citation.Add(this.citation);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedRuleIsInChainOfRlds_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_Container_is_EngineeringModel_and_ReferenceSource_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            otherSiteReferenceDataLibrary.ReferenceSource.Add(referenceSource);

            this.citation.Source = referenceSource;

            var result = this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.citation).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0260"));
            Assert.That(result.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:SOURCE of Citation.Source is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.citation));
        }

        [Test]
        public void Verify_that_when_Container_is_EngineeringModel_and_ReferenceSource_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            this.modelReferenceDataLibrary.ReferenceSource.Add(referenceSource);

            this.citation.Source = referenceSource;

            var results = this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(this.citation);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_Container_is_ReferenceDataLibrary_and_ReferenceSource_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            this.siteDirectory.SiteReferenceDataLibrary.Add(otherSiteReferenceDataLibrary);
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            otherSiteReferenceDataLibrary.ReferenceSource.Add(referenceSource);

            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var category = new Category();
            var categoryDefinition = new Definition();
            var categoryCitation = new Citation();
            categoryCitation.Source = referenceSource;

            this.siteDirectory.SiteReferenceDataLibrary.Add(siteReferenceDataLibrary);
            siteReferenceDataLibrary.DefinedCategory.Add(category);
            category.Definition.Add(categoryDefinition);
            categoryDefinition.Citation.Add(categoryCitation);

            var result = this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(categoryCitation).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0260"));
            Assert.That(result.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:SOURCE of Citation.Source is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(categoryCitation));
        }

        [Test]
        public void Verify_that_when_Container_is_ReferenceDataLibrary_and_ReferenceSource_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var referenceSource = new ReferenceSource { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "SOURCE" };
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var category = new Category();
            var categoryDefinition = new Definition();
            var categoryCitation = new Citation();
            categoryCitation.Source = referenceSource;

            this.siteDirectory.SiteReferenceDataLibrary.Add(siteReferenceDataLibrary);
            siteReferenceDataLibrary.DefinedCategory.Add(category);
            siteReferenceDataLibrary.ReferenceSource.Add(referenceSource);
            category.Definition.Add(categoryDefinition);
            categoryDefinition.Citation.Add(categoryCitation);

            var results = this.citationRuleChecker.CheckWhetherReferencedReferenceSourceIsInChainOfRdls(categoryCitation);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var referenceSource = new ReferenceSource
            { 
                Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), 
                ShortName = "SOURCE",
                IsDeprecated = true
            };

            this.citation.Source = referenceSource;
            
            var results = this.citationRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.citation);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced ReferenceSource 3c44c0e3-d2de-43f9-9636-8235984dc4bf:SOURCE of Citation.Source is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.citation));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var referenceSource = new ReferenceSource
            {
                Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"),
                ShortName = "SOURCE",
                IsDeprecated = false
            };

            this.citation.Source = referenceSource;

            var results = this.citationRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.citation);

            Assert.That(results, Is.Empty);
        }
    }
}