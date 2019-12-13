// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintVerifier.cs" company="RHEA System S.A.">
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

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4Requirements.Events;
    using CDP4Requirements.ExtensionMethods;

    /// <summary>
    /// Class used for the verification if a <see cref="ParametricConstraint"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class ParametricConstraintVerifier : IBooleanExpressionVerifier
    {
        /// <summary>
        /// The <see cref="ParametricConstraint"/> internally used for verification
        /// </summary>
        private ParametricConstraint parametricConstraint;

        /// <summary>
        /// Backing field for <see cref="RequirementStateOfCompliance"/>
        /// </summary>
        private RequirementStateOfCompliance requirementStateOfCompliance;

        /// <summary>
        /// Dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s
        /// </summary>
        public Dictionary<BooleanExpression, IBooleanExpressionVerifier> BooleanExpressionVerifiers { get; } = new Dictionary<BooleanExpression, IBooleanExpressionVerifier>();

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
                    CDPMessageBus.Current.SendMessage(new RequirementStateOfComplianceChangedEvent(value), this.parametricConstraint);
                }
            }
        }

        /// <summary>
        /// Initializes this instance of <see cref="ParametricConstraintVerifier"/>
        /// </summary>
        /// <param name="parametricConstraint">The <see cref="ParametricConstraint"/> that is used for verification</param>
        public ParametricConstraintVerifier(ParametricConstraint parametricConstraint)
        {
            this.parametricConstraint = parametricConstraint;
        }

        /// <summary>
        ///  Entrance methods for verifying if a <see cref="ParametricConstraint"/> and its underlying tree of <see cref="BooleanExpression"/>s
        ///  is compliant to data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) in an <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration"></param>
        /// <returns>A <see cref="Task"/> that completes when all (underlying) verifications are completed</returns>
        public async Task<RequirementStateOfCompliance> VerifyRequirements(Iteration iteration)
        {
            this.RequirementStateOfCompliance = RequirementStateOfCompliance.Calculating;

            this.CreateBooleanExpressionVerifiers();
            return await this.VerifyRequirementStateOfCompliance(this.BooleanExpressionVerifiers, iteration);
        }

        /// <summary>
        /// Verify a <see cref="BooleanExpression"/> with respect to a <see cref="Requirement"/> using data from a given <see cref="Iteration"/> 
        /// </summary>
        /// <param name="booleanExpressionVerifiers">A dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s</param>
        /// <param name="iteration">The <see cref="Iteration"/> that contains the data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) used for verification</param>
        /// <returns><see cref="Task"/> that returns the calculated <see cref="CDP4Requirements.RequirementStateOfCompliance"/> for this class</returns>
        public async Task<RequirementStateOfCompliance> VerifyRequirementStateOfCompliance(IDictionary<BooleanExpression, IBooleanExpressionVerifier> booleanExpressionVerifiers, Iteration iteration)
        {
            var tasks = new List<Task<RequirementStateOfCompliance>>();

            foreach (var entry in this.BooleanExpressionVerifiers)
            {
                tasks.Add(entry.Value.VerifyRequirementStateOfCompliance(this.BooleanExpressionVerifiers, iteration));
            }

            await Task.WhenAll(tasks.ToArray());

            var topLevelBooleanExpressions = this.parametricConstraint.Expression.GetTopLevelExpressions();
            var topLevelBooleanExpressionVerifiers = 
                this.BooleanExpressionVerifiers
                .Where(x => topLevelBooleanExpressions.Contains(x.Key))
                .Select(x => x.Value)
                .ToList();

            return this.RequirementStateOfCompliance =
                topLevelBooleanExpressionVerifiers.Any(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Inconclusive)
                    ? RequirementStateOfCompliance.Inconclusive
                    : topLevelBooleanExpressionVerifiers.Any(x => x.RequirementStateOfCompliance == RequirementStateOfCompliance.Failed)
                        ? RequirementStateOfCompliance.Failed
                        : RequirementStateOfCompliance.Pass;
        }

        /// <summary>
        /// Clear and (re)fill the list of <see cref="BooleanExpression"/>s and their matching <see cref="BooleanExpressionVerifier{T}"/>s.
        /// </summary>
        private void CreateBooleanExpressionVerifiers()
        {
            this.BooleanExpressionVerifiers.Clear();

            foreach (var booleanExpression in this.parametricConstraint.Expression)
            {
                this.BooleanExpressionVerifiers.Add(booleanExpression, this.GetBooleanExpressionVerifier(booleanExpression));
            }
        }

        /// <summary>
        /// Return a <see cref="IBooleanExpressionVerifier"/> that can deal with a <see cref="BooleanExpression"/> 
        /// </summary>
        /// <param name="booleanExpression">The <see cref="BooleanExpression"/> where the matching <see cref="IBooleanExpressionVerifier"/> needs te be created for</param>
        /// <returns><see cref="IBooleanExpressionVerifier"/> that matches the <see cref="BooleanExpression"/> parameter, or Null if one cannot be found</returns>
        private IBooleanExpressionVerifier GetBooleanExpressionVerifier(BooleanExpression booleanExpression)
        {
            if (booleanExpression is NotExpression notExpression)
            {
                return new NotExpressionVerifier(notExpression);
            }

            if (booleanExpression is AndExpression andExpression)
            {
                return new AndExpressionVerifier(andExpression);
            }

            if (booleanExpression is OrExpression orExpression)
            {
                return new OrExpressionVerifier(orExpression);
            }

            if (booleanExpression is ExclusiveOrExpression exclusiveOrExpression)
            {
                return new ExclusiveOrExpressionVerifier(exclusiveOrExpression);
            }

            if (booleanExpression is RelationalExpression relationalExpression)
            {
                return new RelationalExpressionVerifier(relationalExpression);
            }

            return null;
        }
    }
}
