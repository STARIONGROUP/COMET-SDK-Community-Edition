// <copyright file="RelationalExpressionRuleCheckerTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="RelationalExpressionRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class RelationalExpressionRuleCheckerTestFixture
    {
        private RelationalExpressionRuleChecker relationalExpressionRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        private RequirementsSpecification requirementsSpecification;

        private Requirement requirement;

        private ParametricConstraint parametricConstraint;

        private RelationalExpression relationalExpression;

        [SetUp]
        public void SetUp()
        {
            this.relationalExpressionRuleChecker = new RelationalExpressionRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration();
            this.requirementsSpecification = new RequirementsSpecification();
            this.requirement = new Requirement();
            this.parametricConstraint = new ParametricConstraint();
            this.relationalExpression = new RelationalExpression() {Iid = Guid.Parse("56d52d2f-fe41-4e35-8723-4fa310c254f3") };
            
            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.Iteration.Add(this.iteration);
            this.iteration.RequirementsSpecification.Add(this.requirementsSpecification);
            this.requirementsSpecification.Requirement.Add(this.requirement);
            this.requirement.ParametricConstraint.Add(this.parametricConstraint);
            this.parametricConstraint.Expression.Add(this.relationalExpression);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.relationalExpressionRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedParameterTypeIsInChainOfRdls_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.relationalExpressionRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(alias));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var otherSiteReferenceDataLibrary = new SiteReferenceDataLibrary();
            var parameterType = new TextParameterType {Iid = Guid.Parse("aaaafb1c-7b33-4602-89c9-85626c28b904"), ShortName = "TEXT"};
            otherSiteReferenceDataLibrary.ParameterType.Add(parameterType);

            this.relationalExpression.ParameterType = parameterType;

            var result = this.relationalExpressionRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.relationalExpression).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0220"));
            Assert.That(result.Description, Is.EqualTo("The referenced ParameterType aaaafb1c-7b33-4602-89c9-85626c28b904:TEXT is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.relationalExpression));
        }

        [Test]
        public void Verify_that_when_ParameterType_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var parameterType = new TextParameterType { Iid = Guid.Parse("aaaafb1c-7b33-4602-89c9-85626c28b904") };
            this.modelReferenceDataLibrary.ParameterType.Add(parameterType);

            this.relationalExpression.ParameterType = parameterType;

            var results = this.relationalExpressionRuleChecker.CheckWhetherReferencedParameterTypeIsInChainOfRdls(this.relationalExpression);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_not_in_chain_of_rdls_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            var otherSiterReferenceDataLibrary = new SiteReferenceDataLibrary();
            otherSiterReferenceDataLibrary.Scale.Add(scale);

            this.relationalExpression.Scale = scale;

            var result = this.relationalExpressionRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.relationalExpression).First();
            
            Assert.That(result.Id, Is.EqualTo("MA-0230"));
            Assert.That(result.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE of RelationalExpression.Scale is not in the chain of Reference Data Libraries"));
            Assert.That(result.Thing, Is.EqualTo(this.relationalExpression));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
        }

        [Test]
        public void Verify_that_when_referenced_MeasurementScale_is_in_chain_of_rdls_no_result_is_returned()
        {
            var scale = new RatioScale { Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"), ShortName = "SCALE" };
            this.modelReferenceDataLibrary.Scale.Add(scale);

            this.relationalExpression.Scale = scale;

            var results = this.relationalExpressionRuleChecker.CheckWhetherReferencedMeasurementScaleInChainOfRdls(this.relationalExpression);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_Deprecated_result_is_returned()
        {
            var scale = new RatioScale
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "SCALE",
                IsDeprecated = true
            };

            var parameterType = new TextParameterType()
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "TEXT",
                IsDeprecated = true
            };

            this.relationalExpression.Scale = scale;
            this.relationalExpression.ParameterType = parameterType;

            var results = this.relationalExpressionRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.relationalExpression);

            var first = results.First();
            Assert.That(first.Id, Is.EqualTo("MA-0500"));
            Assert.That(first.Description, Is.EqualTo("The referenced MeasurementScale 1191838a-0f9f-4d2c-8369-cf729d281dee:SCALE of RelationalExpression.Scale is deprecated"));
            Assert.That(first.Thing, Is.EqualTo(this.relationalExpression));
            Assert.That(first.Severity, Is.EqualTo(SeverityKind.Warning));

            var second = results.ElementAt(1);
            Assert.That(second.Id, Is.EqualTo("MA-0500"));
            Assert.That(second.Description, Is.EqualTo("The referenced ParameterType 1191838a-0f9f-4d2c-8369-cf729d281dee:TEXT of RelationalExpression.ParameterType is deprecated"));
            Assert.That(second.Thing, Is.EqualTo(this.relationalExpression));
            Assert.That(second.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_referenced_DeprecatableThing_Is_not_Deprecated_no_result_is_returned()
        {
            var scale = new RatioScale
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "SCALE",
                IsDeprecated = false
            };

            var parameterType = new TextParameterType()
            {
                Iid = Guid.Parse("1191838a-0f9f-4d2c-8369-cf729d281dee"),
                ShortName = "TEXT",
                IsDeprecated = false
            };

            this.relationalExpression.Scale = scale;
            this.relationalExpression.ParameterType = parameterType;

            var results = this.relationalExpressionRuleChecker.ChecksWhetherAReferencedDeprecatableThingIsDeprecated(this.relationalExpression);

            Assert.That(results, Is.Empty);
        }
    }
}