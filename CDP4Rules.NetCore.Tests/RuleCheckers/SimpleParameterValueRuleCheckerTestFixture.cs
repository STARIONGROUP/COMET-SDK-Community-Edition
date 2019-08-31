// <copyright file="SimpleParameterValueRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="SimpleParameterValueRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class SimpleParameterValueRuleCheckerTestFixture
    {
        private SimpleParameterValueRuleChecker simpleParameterValueRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private RequirementsSpecification requirementsSpecification;

        private Requirement requirement;

        private SimpleParameterValue simpleParameterValue;

        [SetUp]
        public void SetUp()
        {
            this.simpleParameterValueRuleChecker = new SimpleParameterValueRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.requirementsSpecification = new RequirementsSpecification();
            this.requirement = new Requirement();
            this.simpleParameterValue = new SimpleParameterValue();
            
            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.RequirementsSpecification.Add(this.requirementsSpecification);
            this.requirementsSpecification.Requirement.Add(this.requirement);
            this.requirement.ParameterValue.Add(this.simpleParameterValue);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.simpleParameterValueRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.simpleParameterValueRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var parameterType = new TextParameterType { Iid = Guid.Parse("aaaafb1c-7b33-4602-89c9-85626c28b904"), ShortName = "TEXT" };
            otherSiteReferenceDataLibrary.ParameterType.Add(parameterType);

            this.simpleParameterValue.ParameterType = parameterType;

            var result = this.simpleParameterValueRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.simpleParameterValue).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType aaaafb1c-7b33-4602-89c9-85626c28b904:TEXT is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.simpleParameterValue));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var parameterType = new TextParameterType { Iid = Guid.Parse("aaaafb1c-7b33-4602-89c9-85626c28b904") };
            this.modelReferenceDataLibrary.ParameterType.Add(parameterType);

            this.simpleParameterValue.ParameterType = parameterType;

            var results = this.simpleParameterValueRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.simpleParameterValue);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);

            this.simpleParameterValue.Scale = scale;

            var first = this.simpleParameterValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.simpleParameterValue).First();

            Assert.That(first.Id, Is.EqualTo("MA-0230"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE of SimpleParameterValue.Scale is not in the chain of Reference Data Libraries"));
            Assert.That(first.Thing, Is.EqualTo(this.simpleParameterValue));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Error));

        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            this.modelReferenceDataLibrary.Scale.Add(scale);

            this.simpleParameterValue.Scale = scale;

            var results = this.simpleParameterValueRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.simpleParameterValue);

            Assert.That(results, Is.Empty);
        }
    }
}