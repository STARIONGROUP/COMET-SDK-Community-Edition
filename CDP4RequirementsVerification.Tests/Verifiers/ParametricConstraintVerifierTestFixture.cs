// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintVerifierTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4RequirementsVerification.Tests.Verifiers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using CDP4Dal;

    using CDP4RequirementsVerification.Tests.Builders;
    using CDP4RequirementsVerification.Verifiers;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParametricConstraintVerifier"/> class.
    /// </summary>
    [TestFixture]
    public class ParametricConstraintVerifierTestFixture
    {
        private ParametricConstraintVerifier nullConfigurationParametricConstraintVerifier;

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

        private Parameter parameter;

        private ParameterOverrideValueSet parameterOverrideValueSet;

        private const string OkValue = "10";

        private const string NotOkValue = "11";

        private Option option1;

        private Option option2;

        private ElementDefinition elementDefinition1;
        private ElementDefinition elementDefinition2;
        private ParametricConstraintVerifier option1ConfigurationParametricConstraintVerifier;
        private ParametricConstraintVerifier option2ConfigurationParametricConstraintVerifier;
        private CDPMessageBus messageBus;

        [SetUp]
        public void SetUp()
        {
            this.messageBus = new CDPMessageBus();

            this.parametricConstraint = new ParametricConstraint(Guid.NewGuid(), null, null);
            this.orExpression = new OrExpression(Guid.NewGuid(), null, null);
            this.andExpression = new AndExpression(Guid.NewGuid(), null, null);
            this.exclusiveOrExpression = new ExclusiveOrExpression(Guid.NewGuid(), null, null);
            this.notExpression = new NotExpression(Guid.NewGuid(), null, null);

            this.relationalExpression1 =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue(OkValue)
                    .Build();

            this.relationalExpression2 =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue(OkValue)
                    .Build();

            this.relationalExpression3 =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue(OkValue)
                    .Build();

            this.relationalExpression4 =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue(OkValue)
                    .Build();

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

            this.iteration = new Iteration(Guid.NewGuid(), null, null);

            this.option1 = new Option(Guid.NewGuid(), null, null);
            this.option2 = new Option(Guid.NewGuid(), null, null);
            this.iteration.Option.Add(this.option1);
            this.iteration.Option.Add(this.option2);

            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null);
            this.elementDefinition2 = new ElementDefinition(Guid.NewGuid(), null, null);

            var elementUsage = new ElementUsage(Guid.NewGuid(), null, null) { ElementDefinition = this.elementDefinition2 };
            this.elementDefinition1.ContainedElement.Add(elementUsage);

            this.iteration.Element.Add(this.elementDefinition1);
            this.iteration.TopElement = this.elementDefinition1;

            this.parameter =
                new ParameterBuilder()
                    .WithOptions(this.option1)
                    .WithSimpleQuantityKindParameterType()
                    .WithValues(OkValue)
                    .AddToElementDefinition(this.elementDefinition1)
                    .Build();

            var parameterOverride = new ParameterOverride(Guid.NewGuid(), null, null) { Parameter = this.parameter };
            this.parameterOverrideValueSet = new ParameterOverrideValueSet { ValueSwitch = ParameterSwitchKind.MANUAL, Manual = new ValueArray<string>(new[] { OkValue }), Formula = new ValueArray<string>(new[] { "-" })};
            this.parameterOverrideValueSet.ParameterValueSet = this.parameter.ValueSet.First();

            parameterOverride.ValueSet.Add(this.parameterOverrideValueSet);
            elementUsage.ParameterOverride.Add(parameterOverride);

            this.RegisterBinaryRelationShip(this.parameter, this.relationalExpression1);
            this.RegisterBinaryRelationShip(parameterOverride, this.relationalExpression2);

            this.nullConfigurationParametricConstraintVerifier = new ParametricConstraintVerifier(this.parametricConstraint, null, this.messageBus);
            this.option1ConfigurationParametricConstraintVerifier = new ParametricConstraintVerifier(this.parametricConstraint, new RequirementVerificationConfiguration { Option = this.option1 }, this.messageBus);
            this.option2ConfigurationParametricConstraintVerifier = new ParametricConstraintVerifier(this.parametricConstraint, new RequirementVerificationConfiguration { Option = this.option2 }, this.messageBus);
        }

        private void RegisterBinaryRelationShip(ParameterOrOverrideBase parameter, RelationalExpression expression)
        {
            var relationShip = new BinaryRelationship(Guid.NewGuid(), null, null)
            {
                Source = parameter,
                Target = expression
            };

            expression.Relationships.Add(relationShip);
            relationShip.Source.Relationships.Add(relationShip);
            relationShip.Target.Relationships.Add(relationShip);

            this.iteration.Relationship.Add(relationShip);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_match()
        {
            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_do_not_match()
        {
            this.parameter.ValueSet[0].Manual = new ValueArray<string>(new[] { NotOkValue });
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { NotOkValue });

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_notExpression_is_used_on_a_orExpression_that_is_compliant()
        {
            this.notExpression.Term = this.orExpression;
            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_notExpression_is_used_on_a_orExpression_that_is_not_compliant()
        {
            this.notExpression.Term = this.orExpression;
            this.parameter.ValueSet[0].Manual = new ValueArray<string>(new[] { NotOkValue });
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { NotOkValue });

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_a_orExpression_is_partially_compliant()
        {
            this.parameterOverrideValueSet.Manual = new ValueArray<string>(new[] { NotOkValue });

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_compliant()
        {
            var parameter1 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(OkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            var parameter2 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(OkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_not_compliant()
        {
            var parameter1 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(NotOkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            var parameter2 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(NotOkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_partially_compliant()
        {
            var parameter1 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(NotOkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            var parameter2 = new ParameterBuilder()
                .WithOptions(this.option1)
                .WithSimpleQuantityKindParameterType()
                .WithValue(OkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.nullConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.nullConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.nullConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_partially_compliant_for_option1()
        {
            var parameter1 = new ParameterBuilder()
                .WithOptions(this.option1, this.option2)
                .WithSimpleQuantityKindParameterType()
                .WithValues(NotOkValue, OkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            var parameter2 = new ParameterBuilder()
                .WithOptions(this.option1, this.option2)
                .WithSimpleQuantityKindParameterType()
                .WithValues(OkValue, NotOkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.option1ConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.option1ConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.option1ConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.option1ConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.option1ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_set_when_valuesets_are_partially_compliant_for_option2()
        {
            var parameter1 = new ParameterBuilder()
                .WithOptions(this.option1, this.option2)
                .WithSimpleQuantityKindParameterType()
                .WithValues(OkValue, NotOkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            var parameter2 = new ParameterBuilder()
                .WithOptions(this.option1, this.option2)
                .WithSimpleQuantityKindParameterType()
                .WithValues(NotOkValue, OkValue)
                .AddToElementDefinition(this.elementDefinition1)
                .Build();

            this.RegisterBinaryRelationShip(parameter1, this.relationalExpression3);
            this.RegisterBinaryRelationShip(parameter2, this.relationalExpression4);

            this.notExpression.Term = this.andExpression;

            await this.option2ConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.option2ConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression1].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression2].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.orExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));

            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression3].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.relationalExpression4].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.andExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.exclusiveOrExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Pass));

            this.notExpression.Term = this.exclusiveOrExpression;
            await this.option2ConfigurationParametricConstraintVerifier.VerifyRequirements(this.iteration);

            Assert.That(this.option2ConfigurationParametricConstraintVerifier.RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Inconclusive));
            Assert.That(this.option2ConfigurationParametricConstraintVerifier.BooleanExpressionVerifiers[this.notExpression].RequirementStateOfCompliance, Is.EqualTo(RequirementStateOfCompliance.Failed));
        }
    }
}
