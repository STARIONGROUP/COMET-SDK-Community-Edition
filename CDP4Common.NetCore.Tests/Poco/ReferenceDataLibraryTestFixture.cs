// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibraryTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class ReferenceDataLibraryTestFixture
    {
        private ModelReferenceDataLibrary mRdl;
        private SiteReferenceDataLibrary sRdl1;
        private SiteReferenceDataLibrary sRdl11;
        private SiteReferenceDataLibrary sRdl2;

        [SetUp]
        public void SetUp()
        {
            this.mRdl = new ModelReferenceDataLibrary();
            this.sRdl1 = new SiteReferenceDataLibrary();
            this.sRdl11 = new SiteReferenceDataLibrary();
            this.sRdl2 = new SiteReferenceDataLibrary();

            this.mRdl.RequiredRdl = this.sRdl11;
            this.sRdl11.RequiredRdl = this.sRdl1;
        }

        [Test]
        public void VerifyThatGetRequiresRdlWorks()
        {
            int i = 0;
            foreach (var rdl in mRdl.GetRequiredRdls())
            {
                i++;
            }

            Assert.AreEqual(2, i);

            i = 0;
            foreach (var rdl in sRdl2.GetRequiredRdls())
            {
                i++;
            }

            Assert.AreEqual(0, i);
        }

        [Test]
        public void Verify_that_RequiredRdls_returns_expected_result()
        {
            var expectedRls = new List<ReferenceDataLibrary>()
            {
                this.sRdl1,
                this.sRdl11
            };

            Assert.That(expectedRls, Is.EquivalentTo(this.mRdl.RequiredRdls));
        }

        [Test]
        public void Verify_that_AggregatedRdls_Returns_expected_result()
        {
            var expectedRls = new List<ReferenceDataLibrary>()
            {
                this.mRdl,
                this.sRdl1,
                this.sRdl11
            };
            
            var rdls = this.mRdl.AggregatedReferenceDataLibrary;

            Assert.That(rdls, Is.EquivalentTo(expectedRls));
        }

        [Test]
        public void Verify_that_QueryCategoriesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_category = new Category(Guid.NewGuid(), null, null);
            var sRdl1_category = new Category(Guid.NewGuid(), null, null);
            var sRdl11_category = new Category(Guid.NewGuid(), null, null);

            this.mRdl.DefinedCategory.Add(mRdl_category);
            this.sRdl1.DefinedCategory.Add(sRdl1_category);
            this.sRdl11.DefinedCategory.Add(sRdl11_category);
            
            Assert.That(new List<Category>{ mRdl_category, sRdl1_category, sRdl11_category}, Is.EquivalentTo(this.mRdl.QueryCategoriesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryParameterTypesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_TextParameterType = new TextParameterType(Guid.NewGuid(), null, null);
            var sRdl1_TextParameterType = new TextParameterType(Guid.NewGuid(), null, null);
            var sRdl11_TextParameterType = new TextParameterType(Guid.NewGuid(), null, null);

            this.mRdl.ParameterType.Add(mRdl_TextParameterType);
            this.sRdl1.ParameterType.Add(sRdl1_TextParameterType);
            this.sRdl11.ParameterType.Add(sRdl11_TextParameterType);
            
            Assert.That(new List<ParameterType>{mRdl_TextParameterType, sRdl1_TextParameterType, sRdl11_TextParameterType}, Is.EquivalentTo(this.mRdl.QueryParameterTypesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryMeasurementScalesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_RatioScale = new RatioScale(Guid.NewGuid(), null, null);
            var sRdl1_RatioScale = new RatioScale(Guid.NewGuid(), null, null);
            var sRdl11_RatioScale = new RatioScale(Guid.NewGuid(), null, null);

            this.mRdl.Scale.Add(mRdl_RatioScale);
            this.sRdl1.Scale.Add(sRdl1_RatioScale);
            this.sRdl11.Scale.Add(sRdl11_RatioScale);
            
            Assert.That(new List<MeasurementScale>{mRdl_RatioScale, sRdl1_RatioScale, sRdl11_RatioScale}, Is.EquivalentTo(this.mRdl.QueryMeasurementScalesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryUnitPrefixesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_UnitPrefix = new UnitPrefix(Guid.NewGuid(), null, null);
            var sRdl1_UnitPrefix = new UnitPrefix(Guid.NewGuid(), null, null);
            var sRdl11_UnitPrefix = new UnitPrefix(Guid.NewGuid(), null, null);

            this.mRdl.UnitPrefix.Add(mRdl_UnitPrefix);
            this.sRdl1.UnitPrefix.Add(sRdl1_UnitPrefix);
            this.sRdl11.UnitPrefix.Add(sRdl11_UnitPrefix);
            
            Assert.That(new List<UnitPrefix>{mRdl_UnitPrefix, sRdl1_UnitPrefix, sRdl11_UnitPrefix}, Is.EquivalentTo(this.mRdl.QueryUnitPrefixesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryMeasurementUnitsFromChainOfRdls_returns_expected_result()
        {
            var mRdl_MeasurementUnit = new SimpleUnit(Guid.NewGuid(), null, null);
            var sRdl1_MeasurementUnit = new SimpleUnit(Guid.NewGuid(), null, null);
            var sRdl11_MeasurementUnit = new SimpleUnit(Guid.NewGuid(), null, null);

            this.mRdl.Unit.Add(mRdl_MeasurementUnit);
            this.sRdl1.Unit.Add(sRdl1_MeasurementUnit);
            this.sRdl11.Unit.Add(sRdl11_MeasurementUnit);
            
            Assert.That(new List<MeasurementUnit>{mRdl_MeasurementUnit, sRdl1_MeasurementUnit, sRdl11_MeasurementUnit}, Is.EquivalentTo(this.mRdl.QueryMeasurementUnitsFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryFileTypesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_FileType = new FileType(Guid.NewGuid(), null, null);
            var sRdl1_FileType = new FileType(Guid.NewGuid(), null, null);
            var sRdl11_FileType = new FileType(Guid.NewGuid(), null, null);

            this.mRdl.FileType.Add(mRdl_FileType);
            this.sRdl1.FileType.Add(sRdl1_FileType);
            this.sRdl11.FileType.Add(sRdl11_FileType);
            
            Assert.That(new List<FileType>{mRdl_FileType, sRdl1_FileType, sRdl11_FileType}, Is.EquivalentTo(this.mRdl.QueryFileTypesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryGlossariesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_Glossary = new Glossary(Guid.NewGuid(), null, null);
            var sRdl1_Glossary = new Glossary(Guid.NewGuid(), null, null);
            var sRdl11_Glossary = new Glossary(Guid.NewGuid(), null, null);

            this.mRdl.Glossary.Add(mRdl_Glossary);
            this.sRdl1.Glossary.Add(sRdl1_Glossary);
            this.sRdl11.Glossary.Add(sRdl11_Glossary);
            
            Assert.That(new List<Glossary>{mRdl_Glossary, sRdl1_Glossary, sRdl11_Glossary}, Is.EquivalentTo(this.mRdl.QueryGlossariesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryReferenceSourcesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_ReferenceSource = new ReferenceSource(Guid.NewGuid(), null, null);
            var sRdl1_ReferenceSource = new ReferenceSource(Guid.NewGuid(), null, null);
            var sRdl11_ReferenceSource = new ReferenceSource(Guid.NewGuid(), null, null);

            this.mRdl.ReferenceSource.Add(mRdl_ReferenceSource);
            this.sRdl1.ReferenceSource.Add(sRdl1_ReferenceSource);
            this.sRdl11.ReferenceSource.Add(sRdl11_ReferenceSource);
            
            Assert.That(new List<ReferenceSource>{mRdl_ReferenceSource, sRdl1_ReferenceSource, sRdl11_ReferenceSource}, Is.EquivalentTo(this.mRdl.QueryReferenceSourcesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryRulesFromChainOfRdls_returns_expected_result()
        {
            var mRdl_Rule = new BinaryRelationshipRule(Guid.NewGuid(), null, null);
            var sRdl1_Rule = new BinaryRelationshipRule(Guid.NewGuid(), null, null);
            var sRdl11_Rule = new BinaryRelationshipRule(Guid.NewGuid(), null, null);

            this.mRdl.Rule.Add(mRdl_Rule);
            this.sRdl1.Rule.Add(sRdl1_Rule);
            this.sRdl11.Rule.Add(sRdl11_Rule);
            
            Assert.That(new List<Rule>{mRdl_Rule, sRdl1_Rule, sRdl11_Rule}, Is.EquivalentTo(this.mRdl.QueryRulesFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_QueryConstantsFromChainOfRdls_returns_expected_result()
        {
            var mRdl_Constant = new Constant(Guid.NewGuid(), null, null);
            var sRdl1_Constant = new Constant(Guid.NewGuid(), null, null);
            var sRdl11_Constant = new Constant(Guid.NewGuid(), null, null);

            this.mRdl.Constant.Add(mRdl_Constant);
            this.sRdl1.Constant.Add(sRdl1_Constant);
            this.sRdl11.Constant.Add(sRdl11_Constant);
            
            Assert.That(new List<Constant>{mRdl_Constant, sRdl1_Constant, sRdl11_Constant}, Is.EquivalentTo(this.mRdl.QueryConstantsFromChainOfRdls()));
        }

        [Test]
        public void Verify_that_IsCategoryInChainOfRdls_returns_expected_result()
        {
            var category = new Category();
            Assert.That(this.mRdl.IsCategoryInChainOfRdls(category), Is.False);

            this.sRdl1.DefinedCategory.Add(category);
            Assert.That(this.mRdl.IsCategoryInChainOfRdls(category), Is.True);
        }

        [Test]
        public void Verify_that_IsFileTypeInChainOfRdls_returns_expected_result()
        {
            var fileType = new FileType();
            Assert.That(this.mRdl.IsFileTypeInChainOfRdls(fileType), Is.False);

            this.sRdl1.FileType.Add(fileType);
            Assert.That(this.mRdl.IsFileTypeInChainOfRdls(fileType), Is.True);
        }

        [Test]
        public void Verify_that_IsParameterTypeInChainOfRdls_returns_expected_result()
        {
            var parameterType = new TextParameterType();
            Assert.That(this.mRdl.IsParameterTypeInChainOfRdls(parameterType), Is.False);

            this.sRdl1.ParameterType.Add(parameterType);
            Assert.That(this.mRdl.IsParameterTypeInChainOfRdls(parameterType), Is.True);
        }

        [Test]
        public void Verify_that_IsMeasurementScaleInChainOfRdls_returns_expected_result()
        {
            var ratioScale = new RatioScale();
            Assert.That(this.mRdl.IsMeasurementScaleInChainOfRdls(ratioScale), Is.False);

            this.sRdl1.Scale.Add(ratioScale);
            Assert.That(this.mRdl.IsMeasurementScaleInChainOfRdls(ratioScale), Is.True);
        }

        [Test]
        public void Verify_that_IsMeasurementUnitInChainOfRdls_returns_expected_result()
        {
            var simpleUnit = new SimpleUnit();
            Assert.That(this.mRdl.IsMeasurementUnitInChainOfRdls(simpleUnit), Is.False);

            this.sRdl1.Unit.Add(simpleUnit);
            Assert.That(this.mRdl.IsMeasurementUnitInChainOfRdls(simpleUnit), Is.True);
        }

        [Test]
        public void Verify_that_IsRuleInChainOfRdls_returns_expected_result()
        {
            var decompositionRule = new DecompositionRule();
            Assert.That(this.mRdl.IsRuleInChainOfRdls(decompositionRule), Is.False);

            this.sRdl1.Rule.Add(decompositionRule);
            Assert.That(this.mRdl.IsRuleInChainOfRdls(decompositionRule), Is.True);
        }

        [Test]
        public void Verify_that_IsReferenceSourceInChainOfRdls_returns_expected_result()
        {
            var referenceSource = new ReferenceSource();
            Assert.That(this.mRdl.IsReferenceSourceInChainOfRdls(referenceSource), Is.False);

            this.sRdl1.ReferenceSource.Add(referenceSource);
            Assert.That(this.mRdl.IsReferenceSourceInChainOfRdls(referenceSource), Is.True);
        }

        [Test]
        public void Verify_that_IsUnitPrefixInChainOfRdls_returns_expected_result()
        {
            var unitPrefix = new UnitPrefix();
            Assert.That(this.mRdl.IsUnitPrefixInChainOfRdls(unitPrefix), Is.False);

            this.sRdl1.UnitPrefix.Add(unitPrefix);
            Assert.That(this.mRdl.IsUnitPrefixInChainOfRdls(unitPrefix), Is.True);
        }
    }
}