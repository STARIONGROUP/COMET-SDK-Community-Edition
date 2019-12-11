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

namespace CDP4Requirements.RequirementVerifiers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Class used for the verification if a <see cref="ParametricConstraint"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    public class ParametricConstraintVerifier
    {
        /// <summary>
        /// Dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s
        /// </summary>
        public Dictionary<BooleanExpression, IBooleanExpressionVerifier> BooleanExpressionVerifiers { get; } = new Dictionary<BooleanExpression, IBooleanExpressionVerifier>();

        /// <summary>
        ///  Entrance methods for verifying if a <see cref="ParametricConstraint"/> and its underlying tree of <see cref="BooleanExpression"/>s
        ///  is compliant to data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) in an <see cref="Iteration"/>
        /// </summary>
        /// <param name="parametricConstraint"></param>
        /// <param name="iteration"></param>
        /// <returns>A <see cref="Task"/> that completes when all (underlying) verifications are completed</returns>
        public async Task VerifyRequirements(ParametricConstraint parametricConstraint, Iteration iteration)
        {
            this.CreateBooleanExpressionVerifiers(parametricConstraint);
            var tasks = new List<Task<RequirementStateOfCompliance>>();

            foreach (var entry in this.BooleanExpressionVerifiers)
            {
                tasks.Add(entry.Value.VerifyRequirementStateOfCompliance(this.BooleanExpressionVerifiers, iteration));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        /// <summary>
        /// Clear and (re)fill the list of <see cref="BooleanExpression"/>s and their matching <see cref="BooleanExpressionVerifier{T}"/>s.
        /// </summary>
        /// <param name="parametricConstraint">the <see cref="ParametricConstraint"/> that contains the underlying <see cref="BooleanExpression"/>s</param>
        private void CreateBooleanExpressionVerifiers(ParametricConstraint parametricConstraint)
        {
            this.BooleanExpressionVerifiers.Clear();

            foreach (var booleanExpression in parametricConstraint.Expression)
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
