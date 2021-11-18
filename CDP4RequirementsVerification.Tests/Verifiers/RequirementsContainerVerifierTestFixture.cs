// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerVerifierTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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
namespace CDP4RequirementsVerification.Tests.Verifiers
{
    using System;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    using CDP4RequirementsVerification.Tests.Builders;
    using CDP4RequirementsVerification.Verifiers;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="RequirementsContainerVerifier"/> class.
    /// </summary>
    [TestFixture]
    public class RequirementsContainerVerifierTestFixture
    {
        private RequirementsContainerVerifier requirementsContainerVerifier;

        private RequirementsSpecification requirementsSpecification;

        private RequirementsGroup requirementsGroup1;

        private RequirementsGroup requirementsGroup2;

        private Requirement requirement1;

        private ParametricConstraint parametricConstraint;

        private RelationalExpression relationalExpression;

        private Iteration iteration;
        private ElementDefinition elementDefinition;
        private RequirementsContainerVerifier requirementsGroupVerifier1;
        private RequirementsContainerVerifier requirementsGroupVerifier2;

        [SetUp]
        public void SetUp()
        {
            this.parametricConstraint = new ParametricConstraint(Guid.NewGuid(), null, null);

            this.relationalExpression =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue("10")
                    .Build();

            this.parametricConstraint.Expression.Add(this.relationalExpression);

            this.requirement1 = new Requirement(Guid.NewGuid(), null, null);

            this.requirement1.ParametricConstraint.Add(this.parametricConstraint);

            this.requirementsSpecification = new RequirementsSpecification(Guid.NewGuid(), null, null);
            this.requirementsSpecification.Requirement.Add(this.requirement1);

            this.requirementsGroup1 = new RequirementsGroup(Guid.NewGuid(), null, null);
            this.requirementsGroup2 = new RequirementsGroup(Guid.NewGuid(), null, null);

            this.requirementsSpecification.Group.Add(this.requirementsGroup1);
            this.requirementsGroup1.Group.Add(this.requirementsGroup2);

            this.requirement1.Group = this.requirementsGroup1;

            this.requirementsContainerVerifier = new RequirementsContainerVerifier(this.requirementsSpecification);

            this.requirementsGroupVerifier1 = new RequirementsContainerVerifier(this.requirementsGroup1);
            this.requirementsGroupVerifier2 = new RequirementsContainerVerifier(this.requirementsGroup2);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            var elementUsage = new ElementUsage(Guid.NewGuid(), null, null) { ElementDefinition = this.elementDefinition };
            this.elementDefinition.ContainedElement.Add(elementUsage);

            var parameter =
                new ParameterBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue("10")
                    .AddToElementDefinition(this.elementDefinition)
                    .Build();

            this.iteration.Element.Add(this.elementDefinition);

            this.RegisterBinaryRelationShip(parameter, this.relationalExpression);
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
        public async Task Verify_that_state_of_compliances_are_properly_calculated()
        {
            await this.requirementsContainerVerifier.VerifyRequirements(this.iteration);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.requirementsContainerVerifier.RequirementStateOfCompliance);

            await this.requirementsGroupVerifier1.VerifyRequirements(this.iteration);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.requirementsGroupVerifier1.RequirementStateOfCompliance);

            await this.requirementsGroupVerifier2.VerifyRequirements(this.iteration);
            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.requirementsGroupVerifier2.RequirementStateOfCompliance);

            this.requirementsGroup1.Group.Clear(); // no more inconclusive sub groups.

            await this.requirementsContainerVerifier.VerifyRequirements(this.iteration);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.requirementsContainerVerifier.RequirementStateOfCompliance);

            await this.requirementsGroupVerifier1.VerifyRequirements(this.iteration);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.requirementsGroupVerifier1.RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_calculated_when_requirement_is_deprecated()
        {
            this.requirement1.IsDeprecated = true;
            await this.requirementsContainerVerifier.VerifyRequirements(this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.requirementsContainerVerifier.RequirementStateOfCompliance);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_calculated_when_no_requirements_are_present()
        {
            this.requirementsSpecification.Requirement.Clear();
            await this.requirementsContainerVerifier.VerifyRequirements(this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Inconclusive, this.requirementsContainerVerifier.RequirementStateOfCompliance);
        }
    }
}
