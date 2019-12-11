// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpressionVerifier.cs" company="RHEA System S.A.">
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

namespace CDP4Requirements.RequirementVerifiers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Class used for the verification if a <see cref="RelationalExpression"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class RelationalExpressionVerifier : BooleanExpressionVerifier<RelationalExpression>
    {
        /// <summary>
        /// object used to lock the verification process to ensure that a verification is done only once.
        /// </summary>
        private object locker = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpressionVerifier"/> class.
        /// </summary>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> that is verified.</param>
        public RelationalExpressionVerifier(RelationalExpression relationalExpression)
        {
            this.Expression = relationalExpression;
        }

        /// <summary>
        /// A list containing all the <see cref="RequirementStateOfCompliances"/>s that were found when verifying <see cref="Iteration"/> data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>)
        /// </summary>
        public RequirementStateOfCompliances RequirementStateOfCompliances { get; } = new RequirementStateOfCompliances();

        /// <summary>
        /// Verify a <see cref="RelationalExpression"/> with respect to a <see cref="Requirement"/> using data from a given <see cref="Iteration"/> 
        /// </summary>
        /// <param name="booleanExpressionVerifiers">A dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s</param>
        /// <param name="iteration">The <see cref="Iteration"/> that contains the data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) used for verification</param>
        /// <returns><see cref="Task"/> that returns the calculated <see cref="RequirementStateOfCompliance"/> for this class' <see cref="BooleanExpressionVerifier{T}.Expression"/> property</returns>
        public override async Task<RequirementStateOfCompliance> VerifyRequirementStateOfCompliance(IDictionary<BooleanExpression, IBooleanExpressionVerifier> booleanExpressionVerifiers, Iteration iteration)
        {
            if (this.RequirementStateOfCompliance != RequirementStateOfCompliance.Unknown)
            {
                return this.RequirementStateOfCompliance;
            }

            lock (this.locker)
            {
                if (this.RequirementStateOfCompliance != RequirementStateOfCompliance.Unknown)
                {
                    return this.RequirementStateOfCompliance;
                }

                foreach (var binaryRelation in this.Expression.QueryRelationships.OfType<BinaryRelationship>().Where(x => x.Source is ParameterOrOverrideBase && x.Target is RelationalExpression))
                {
                    if (binaryRelation.Target is RelationalExpression expression)
                    {
                        var relationParameter = binaryRelation.Source as Parameter;

                        var elementDefinitionParameters =
                            iteration.Element.SelectMany(x => x.Parameter)
                                .Where(x => x == relationParameter)
                                .ToList();

                        if (relationParameter != null && elementDefinitionParameters.Any())
                        {
                            foreach (var parameter in elementDefinitionParameters)
                            {
                                this.RequirementStateOfCompliances.VerifyAndAdd(parameter.ValueSet, expression);
                            }
                        }

                        var relationParameterOverride = binaryRelation.Source as ParameterOverride;

                        var elementUsageParameterOverrides = iteration.Element.SelectMany(x => x.ContainedElement)
                            .SelectMany(x => x.ParameterOverride)
                            .Where(x => x == relationParameterOverride)
                            .ToList();

                        if (relationParameterOverride != null && elementUsageParameterOverrides.Any())
                        {
                            foreach (var parameterOverride in elementUsageParameterOverrides)
                            {
                                this.RequirementStateOfCompliances.VerifyAndAdd(parameterOverride.ValueSet, expression);
                            }
                        }
                    }
                }

                this.CalculateRequirementStateOfCompliance();
            }

            return this.RequirementStateOfCompliance;
        }

        /// <summary>
        /// Calculate the <see cref="RequirementStateOfCompliance"/> for this instance of <see cref="RelationalExpression"/>
        /// </summary>
        private void CalculateRequirementStateOfCompliance()
        {
            if (!this.RequirementStateOfCompliances.Any())
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Inconclusive;
            }
            else if (this.RequirementStateOfCompliances.All(x => x.Value == RequirementStateOfCompliance.Pass))
            {
                this.RequirementStateOfCompliance = RequirementStateOfCompliance.Pass;
            }
            else if (this.RequirementStateOfCompliances.All(x => x.Value == RequirementStateOfCompliance.Failed))
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
