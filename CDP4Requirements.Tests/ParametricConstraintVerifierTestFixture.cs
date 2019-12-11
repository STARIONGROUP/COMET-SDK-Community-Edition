// <copyright file="ParametricConstraintVerifierTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Requirements.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Requirements.RequirementVerifiers;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParametricConstraintVerifier"/> class.
    /// </summary>
    [TestFixture]
    public class ParametricConstraintVerifierTestFixture
    {
        private ParametricConstraintVerifier parametricConstraintVerifier;

        private ParametricConstraint parametricConstraint;

        private OrExpression orExpression;

        private AndExpression andExpression;

        private ExclusiveOrExpression exclusiveOrExpression;

        private NotExpression notExpression;

        private RelationalExpression relationalExpression1;

        private RelationalExpression relationalExpression2;

        private RelationalExpression relationalExpression3;

        private RelationalExpression relationalExpression4;

        private Iteration iteration;

        private ParameterValueSet parameterValueSet;

        private ParameterOverrideValueSet parameterOverrideValueSet;

        private readonly string okValue = "OK";

        private readonly string notOkValue = "NOK";
        private Option option1;
        private Option option2;
        private ElementDefinition elementDefinition;

        [SetUp]
        public void SetUp()
        {
            this.parametricConstraint = new ParametricConstraint(Guid.NewGuid(), null, null);
            this.orExpression = new OrExpression(Guid.NewGuid(), null, null);
            this.andExpression = new AndExpression(Guid.NewGuid(), null, null);
            this.exclusiveOrExpression = new ExclusiveOrExpression(Guid.NewGuid(), null, null);
            this.notExpression = new NotExpression(Guid.NewGuid(), null, null);

            this.relationalExpression1 = new RelationalExpression(Guid.NewGuid(), null, null);
            this.relationalExpression1.Value = new ValueArray<string>(new[] { this.okValue });

            this.relationalExpression2 = new RelationalExpression(Guid.NewGuid(), null, null);
            this.relationalExpression2.Value = new ValueArray<string>(new[] { this.okValue });

            this.relationalExpression3 = new RelationalExpression(Guid.NewGuid(), null, null);
            this.relationalExpression3.Value = new ValueArray<string>(new[] { this.okValue });

            this.relationalExpression4 = new RelationalExpression(Guid.NewGuid(), null, null);
            this.relationalExpression4.Value = new ValueArray<string>(new[] { this.okValue });

            this.orExpression.Term.Add(this.relationalExpression1);
            this.orExpression.Term.Add(this.relationalExpression2);
            this.andExpression.Term.Add(this.relationalExpression3);
            this.andExpression.Term.Add(this.relationalExpression4);
            this.exclusiveOrExpression.Term.Add(this.relationalExpression3);
            this.exclusiveOrExpression.Term.Add(this.relationalExpression4);

            this.parametricConstraint.Expression.Add(this.andExpression);
            this.parametricConstraint.Expression.Add(this.orExpression);
            this.parametricConstraint.Expression.Add(this.exclusiveOrExpression);
            this.parametricConstraint.Expression.Add(this.notExpression);
            this.parametricConstraint.Expression.Add(this.relationalExpression1);
            this.parametricConstraint.Expression.Add(this.relationalExpression2);
            this.parametricConstraint.Expression.Add(this.relationalExpression3);
            this.parametricConstraint.Expression.Add(this.relationalExpression4);

            this.parametricConstraintVerifier = new ParametricConstraintVerifier();

            this.iteration = new Iteration(Guid.NewGuid(), null, null);

            this.option1 = new Option();
            this.option2 = new Option();
            this.iteration.Option.Add(this.option1);
            this.iteration.Option.Add(this.option2);

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            var elementUsage = new ElementUsage(Guid.NewGuid(), null, null);
            elementUsage.ElementDefinition = this.elementDefinition;
            this.elementDefinition.ContainedElement.Add(elementUsage);

            var parameter = this.CreateParameter(this.option1);
            this.iteration.Element.Add(this.elementDefinition);

            var parameterOverride = new ParameterOverride(Guid.NewGuid(), null, null);
            parameterOverride.Parameter = parameter;
            this.parameterOverrideValueSet = new ParameterOverrideValueSet { ValueSwitch = ParameterSwitchKind.MANUAL, Manual = new ValueArray<string>(new[] { this.okValue }) };
            parameterOverride.ValueSet.Add(this.parameterOverrideValueSet);
            elementUsage.ParameterOverride.Add(parameterOverride);

            this.RegisterBinaryRelationShip(parameter, this.relationalExpression1);
            this.RegisterBinaryRelationShip(parameterOverride, this.relationalExpression2);
        }

        private Parameter CreateParameter(Option option1)
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            var parameterType = new SimpleQuantityKind(Guid.NewGuid(), null, null);

            parameter.ParameterType = parameterType;
            this.parameterValueSet = new ParameterValueSet { ActualOption = option1, ValueSwitch = ParameterSwitchKind.MANUAL, Manual = new ValueArray<string>(new[] { this.okValue }) };
            parameter.ValueSet.Add(this.parameterValueSet);
            this.elementDefinition.Parameter.Add(parameter);

            return parameter;
        }

        private void RegisterBinaryRelationShip(ParameterOrOverrideBase parameter, RelationalExpression expression)
        {
            var relationShip = new BinaryRelationship(Guid.NewGuid(), null, null);
            relationShip.Source = parameter;
            relationShip.Target = expression;

            expression.Relationships.Add(relationShip);
            relationShip.Source.Relationships.Add(relationShip);
            relationShip.Target.Relationships.Add(relationShip);

            this.iteration.Relationship.Add(relationShip);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_match()
        {
            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_do_not_match()
        {
            this.parameterValueSet.Manual = new ValueArray<string>(new[] { this.notOkValue });
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { this.notOkValue });

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_notExpression_is_used_on_a_orExpression_that_is_compliant()
        {
            this.notExpression.Term = this.orExpression;
            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_notExpression_is_used_on_a_orExpression_that_is_not_compliant()
        {
            this.notExpression.Term = this.orExpression;
            this.parameterValueSet.Manual = new ValueArray<string>(new[] { this.notOkValue });
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { this.notOkValue });

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_orExpression_is_partially_compliant()
        {
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { this.notOkValue });

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_compliant()
        {
            var parameter1 = this.CreateParameter(this.option1);
            var parameter2 = this.CreateParameter(this.option1);

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_not_compliant()
        {
            var parameter1 = this.CreateParameter(this.option1);
            var parameter2 = this.CreateParameter(this.option1);
            parameter1.ValueSet.First().Manual = new ValueArray<string>(new[] { this.notOkValue });
            parameter2.ValueSet.First().Manual = new ValueArray<string>(new[] { this.notOkValue });

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_partially_compliant()
        {
            var parameter1 = this.CreateParameter(this.option1);
            var parameter2 = this.CreateParameter(this.option1);
            parameter1.ValueSet.First().Manual = new ValueArray<string>(new[] { this.notOkValue });

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.parametricConstraintVerifier.VerifyRequirements(this.parametricConstraint, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Failed, this.parametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance);
        }
    }
}
