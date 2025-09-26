﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AndExpressionVerifier.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4RequirementsVerification.Verifiers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    /// <summary>
    /// Class used for the verification if a <see cref="AndExpression"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class AndExpressionVerifier : BooleanExpressionVerifier<AndExpression>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AndExpressionVerifier"/> class.
        /// </summary>
        /// <param name="andExpression">The <see cref="AndExpression"/> that is verified.</param>
        /// <param name="configuration">The <see cref="IRequirementVerificationConfiguration"/></param>
        /// <param name="messageBus">The <see cref="ICDPMessageBus"/></param>
        public AndExpressionVerifier(AndExpression andExpression, IRequirementVerificationConfiguration configuration, ICDPMessageBus messageBus) : base(configuration, messageBus)
        {
            this.Expression = andExpression;
        }

        /// <summary>
        /// Verify a <see cref="AndExpression"/> with respect to a <see cref="Requirement"/> using data from a given <see cref="Iteration"/> 
        /// </summary>
        /// <param name="booleanExpressionVerifiers">A dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s</param>
        /// <param name="iteration">The <see cref="Iteration"/> that contains the data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) used for verification</param>
        /// <returns><see cref="Task"/> that returns the calculated <see cref="RequirementStateOfCompliance"/> for this class' <see cref="BooleanExpressionVerifier{T}.Expression"/> property</returns>
        public override async Task<RequirementStateOfCompliance> VerifyRequirementStateOfCompliance(IDictionary<BooleanExpression, IBooleanExpressionVerifier> booleanExpressionVerifiers, Iteration iteration)
        {
            this.RequirementStateOfCompliance = RequirementStateOfCompliance.Calculating;

            if (!this.Expression?.Term?.Any() ?? true)
            {
                return this.RequirementStateOfCompliance = RequirementStateOfCompliance.Inconclusive;
            }

            var requirementStateOfCompliances = new List<RequirementStateOfCompliance>();

            foreach (var expression in this.Expression.Term)
            {
                var expressionVerifier = booleanExpressionVerifiers[expression];
                requirementStateOfCompliances.Add(await expressionVerifier.VerifyRequirementStateOfCompliance(booleanExpressionVerifiers, iteration));
            }

            return this.RequirementStateOfCompliance = 
                requirementStateOfCompliances.Any(x => x == RequirementStateOfCompliance.Inconclusive)
                    ? RequirementStateOfCompliance.Inconclusive
                    : requirementStateOfCompliances.Any(x => x == RequirementStateOfCompliance.Failed)
                        ? RequirementStateOfCompliance.Failed
                        : RequirementStateOfCompliance.Pass;
        }
    }
}