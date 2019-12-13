// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerVerifier.cs" company="RHEA System S.A.">
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

namespace CDP4Requirements.Verifiers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4Requirements.Events;

    /// <summary>
    /// Class used for the verification if a <see cref="Requirement"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class RequirementsContainerVerifier : IHaveRequirementStateOfCompliance
    {
        /// <summary>
        /// The <see cref="RequirementsContainer"/> internally used for verification
        /// </summary>
        public RequirementsContainer Container { get; }

        /// <summary>
        /// Backing field for <see cref="RequirementStateOfCompliance"/>
        /// </summary>
        private RequirementStateOfCompliance requirementStateOfCompliance;

        /// <summary>
        /// The current <see cref="CDP4Requirements.RequirementStateOfCompliance"/>>
        /// </summary>
        public RequirementStateOfCompliance RequirementStateOfCompliance
        {
            get => this.requirementStateOfCompliance;
            private set
            {
                if (this.requirementStateOfCompliance != value)
                {
                    this.requirementStateOfCompliance = value;
                    CDPMessageBus.Current.SendMessage(new RequirementStateOfComplianceChangedEvent(value), this.Container);
                }
            }
        }

        /// <summary>
        /// Initializes this instance of <see cref="RequirementsContainerVerifier"/> 
        /// </summary>
        /// <param name="container">The container <see cref="Thing"/></param>
        public RequirementsContainerVerifier(RequirementsContainer container)
        {
            this.Container = container;
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
            var tasks = new List<Task<RequirementStateOfCompliance>>();
            var verifiers = new List<IHaveRequirementStateOfCompliance>();

            foreach (var requirementsGroup in this.Container.Group)
            {
                var requirementsContainerVerifier = new RequirementsContainerVerifier(requirementsGroup);
                verifiers.Add(requirementsContainerVerifier);
                tasks.Add(requirementsContainerVerifier.VerifyRequirements(iteration));
            }

            if (this.Container is RequirementsSpecification requirementsSpecification)
            {
                foreach (var requirement in requirementsSpecification.Requirement)
                {
                    var requirementsVerifier = new RequirementVerifier(requirement);
                    verifiers.Add(requirementsVerifier);
                    tasks.Add(requirementsVerifier.VerifyRequirements(iteration));
                }
            }

            await Task.WhenAll(tasks.ToArray());

            return this.RequirementStateOfCompliance =
                verifiers.Any(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Inconclusive)
                    ? RequirementStateOfCompliance.Inconclusive
                    : verifiers.Any(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Failed)
                        ? RequirementStateOfCompliance.Failed
                        : RequirementStateOfCompliance.Pass;
        }
    }
}
