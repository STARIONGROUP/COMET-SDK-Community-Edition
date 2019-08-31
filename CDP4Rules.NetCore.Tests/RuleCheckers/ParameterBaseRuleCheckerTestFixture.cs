// <copyright file="ParameterBaseRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ParameterBaseRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterBaseRuleCheckerTestFixture
    {
        private ParameterBaseRuleChecker parameterBaseRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private ElementDefinition elementDefinition;

        private Parameter parameter;

        [SetUp]
        public void SetUp()
        {
            this.parameterBaseRuleChecker = new ParameterBaseRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.elementDefinition = new ElementDefinition();
            this.parameter = new Parameter();
            
            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.Element.Add(this.elementDefinition);
            this.elementDefinition.Parameter.Add(this.parameter);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.parameterBaseRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.parameterBaseRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var parameterType = new TextParameterType {Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "TEXT"};
            otherSiteReferenceDataLibrary.ParameterType.Add(parameterType);

            this.parameter.ParameterType = parameterType;

            var result = this.parameterBaseRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameter).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType 3c44c0e3-d2de-43f9-9636-8235984dc4bf:TEXT is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.parameter));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var parameterType = new TextParameterType { Iid = Guid.Parse("3c44c0e3-d2de-43f9-9636-8235984dc4bf"), ShortName = "TEXT" };
            this.modelReferenceDataLibrary.ParameterType.Add(parameterType);

            this.parameter.ParameterType = parameterType;

            var results = this.parameterBaseRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.parameter);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("833f1e3e-0b2e-49ca-b1b0-ef6d627210d0"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);

            this.parameter.Scale = scale;

            var result = this.parameterBaseRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.parameter).First();

            Assert.That(result.Id, Is.EqualTo("MA-0230"));
            Assert.That(result.Description, Is.EqualTo("The referenced MeasurementScale 833f1e3e-0b2e-49ca-b1b0-ef6d627210d0:SCALE is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.parameter));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale();
            this.modelReferenceDataLibrary.Scale.Add(scale);
            this.parameter.Scale = scale;

            var results = this.parameterBaseRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.parameter);

            Assert.That(results, Is.Empty);
        }
    }
}