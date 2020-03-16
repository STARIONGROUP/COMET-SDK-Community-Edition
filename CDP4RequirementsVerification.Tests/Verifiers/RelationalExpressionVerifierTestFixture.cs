// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpressionVerifierTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4RequirementsVerification.Events;
    using CDP4RequirementsVerification.Tests.Builders;
    using CDP4RequirementsVerification.Verifiers;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="RelationalExpressionVerifier"/> class.
    /// </summary>
    [TestFixture]
    public class RelationalExpressionVerifierTestFixture
    {
        private RelationalExpressionVerifier relationalExpressionVerifier;

        private RelationalExpression relationalExpression;

        private Iteration iteration;

        private ElementDefinition elementDefinition;

        [SetUp]
        public void SetUp()
        {
            this.relationalExpression =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue("10")
                    .Build();

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

            this.relationalExpressionVerifier = new RelationalExpressionVerifier(this.relationalExpression);
        }

        [TearDown]
        public void TearDown()
        {
            CDPMessageBus.Current.ClearSubscriptions();
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
            var messageBusWasCalled = false;
            var requirementStateOfCompliance = RequirementStateOfCompliance.Unknown;

            CDPMessageBus.Current.Listen<RequirementStateOfComplianceChangedEvent>(this.relationalExpression).Subscribe(x =>
            {
                messageBusWasCalled = true;
                requirementStateOfCompliance = x.RequirementStateOfCompliance;
            });

            await this.relationalExpressionVerifier.VerifyRequirementStateOfCompliance(new Dictionary<BooleanExpression, IBooleanExpressionVerifier>(), this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.relationalExpressionVerifier.RequirementStateOfCompliance);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, requirementStateOfCompliance);
            Assert.IsTrue(messageBusWasCalled);
        }

        [Test]
        public async Task Verify_that_state_of_compliances_are_properly_calculated_without_messagebus_calls()
        {
            var messageBusWasCalled = false;
            var requirementStateOfCompliance = RequirementStateOfCompliance.Unknown;

            CDPMessageBus.Current.Listen<RequirementStateOfComplianceChangedEvent>(this.relationalExpression).Subscribe(x =>
            {
                messageBusWasCalled = true;
                requirementStateOfCompliance = x.RequirementStateOfCompliance;
            });

            var binaryRelationships = this.relationalExpression.Relationships.OfType<BinaryRelationship>();

            await this.relationalExpressionVerifier.VerifyRequirementStateOfCompliance(binaryRelationships, this.iteration);

            Assert.AreEqual(RequirementStateOfCompliance.Unknown, requirementStateOfCompliance);
            Assert.IsFalse(messageBusWasCalled);
            Assert.AreEqual(RequirementStateOfCompliance.Pass, this.relationalExpressionVerifier.RequirementStateOfCompliance);
        }
    }
}
