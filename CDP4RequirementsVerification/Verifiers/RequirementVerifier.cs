// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementVerifier.cs" company="RHEA System S.A.">
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

namespace CDP4RequirementsVerification.Verifiers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4RequirementsVerification.Events;

    /// <summary>
    /// Class used for the verification if a <see cref="Requirement"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class RequirementVerifier : IHaveRequirementStateOfCompliance
    {
        /// <summary>
        /// The <see cref="Requirement"/> internally used for verification
        /// </summary>
        private readonly Requirement requirement;

        /// <summary>
        /// Backing field for <see cref="RequirementStateOfCompliance"/>
        /// </summary>
        private RequirementStateOfCompliance requirementStateOfCompliance;

        /// <summary>
        /// The list containing all <see cref="ParametricConstraintVerifier"/>s to verify for this <see cref="Requirement"/>
        /// </summary>
        private List<ParametricConstraintVerifier> parametricConstraintVerifiers = new List<ParametricConstraintVerifier>();

        /// <summary>
        /// The current <see cref="CDP4RequirementsVerification.RequirementStateOfCompliance"/>>
        /// </summary>
        public RequirementStateOfCompliance RequirementStateOfCompliance
        {
            get => this.requirementStateOfCompliance;
            private set
            {
                if (this.requirementStateOfCompliance != value)
                {
                    this.requirementStateOfCompliance = value;
                    CDPMessageBus.Current.SendMessage(new RequirementStateOfComplianceChangedEvent(value), this.requirement);
                }
            }
        }

        /// <summary>
        /// Initializes this instance of <see cref="RequirementVerifier"/> 
        /// </summary>
        /// <param name="requirement">The <see cref="Requirement"/> used for verification</param>
        public RequirementVerifier(Requirement requirement)
        {
            this.requirement = requirement;
        }

        /// <summary>
        ///  Entrance methods for verifying if a <see cref="Requirement"/> and its underlying tree of <see cref="BooleanExpression"/>s
        ///  is compliant to data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) in an <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration"></param>
        /// <returns>A <see cref="Task"/> that completes when all (underlying) verifications are completed</returns>
        public async Task<RequirementStateOfCompliance> VerifyRequirements(Iteration iteration)
        {
            this.RequirementStateOfCompliance = RequirementStateOfCompliance.Calculating;
            this.parametricConstraintVerifiers.Clear();

            var tasks = new List<Task<RequirementStateOfCompliance>>();

            foreach (var parametricConstraint in this.requirement.ParametricConstraint)
            {
                var parametricConstraintVerifier = new ParametricConstraintVerifier((ParametricConstraint)parametricConstraint);
                this.parametricConstraintVerifiers.Add(parametricConstraintVerifier);

                tasks.Add(parametricConstraintVerifier.VerifyRequirements(iteration));
            }

            await Task.WhenAll(tasks.ToArray());

            this.CalculateRequirementStateOfCompliance();

            return this.RequirementStateOfCompliance;
        }

        /// <summary>
        /// Calculate the <see cref="RequirementStateOfCompliance"/> for this instance of <see cref="RequirementVerifier"/>
        /// </summary>
        private void CalculateRequirementStateOfCompliance()
        {
            if (!this.parametricConstraintVerifiers.Any())
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Inconclusive;
            }
            else if (this.parametricConstraintVerifiers.All(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Pass))
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Pass;
            }
            else if (this.parametricConstraintVerifiers.All(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Failed))
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Failed;
            }
            else
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Inconclusive;
            }
        }
    }
}
