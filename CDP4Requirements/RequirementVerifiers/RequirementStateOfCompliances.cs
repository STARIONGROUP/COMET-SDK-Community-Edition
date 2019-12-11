// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementStateOfCompliances.cs" company="RHEA System S.A.">
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
    using System;
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Class used for the verification if a <see cref="BooleanExpression"/> is compliant to data in an <see cref="Iteration"/>
    /// It inherits from a <see cref="Dictionary{TKey,TValue}"/> so it links a <see cref="IValueSet"/> to a <see cref="RequirementStateOfCompliance"/>
    /// </summary>
    public class RequirementStateOfCompliances : Dictionary<IValueSet, RequirementStateOfCompliance>
    {
        /// <summary>
        /// Check a list of <see cref="IValueSet"/>s for compliance with a RelationalExpression and add the result to this instance of <see cref="RequirementStateOfCompliances"/>
        /// </summary>
        /// <param name="valueSets">List of <see cref="IValueSet"/>s to be checked and added to this instance of <see cref="RequirementStateOfCompliances"/></param>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> that will be used to verify compliance</param>
        public void VerifyAndAdd(IEnumerable<IValueSet> valueSets, RelationalExpression relationalExpression)
        {
            foreach (var valueSet in valueSets)
            {
                if (!this.ContainsKey(valueSet))
                {
                    switch (relationalExpression.RelationalOperator)
                    {
                        case RelationalOperatorKind.EQ:
                            this.Add(valueSet, relationalExpression.Value.ToString().Equals(valueSet.ActualValue.ToString()) ? RequirementStateOfCompliance.Pass : RequirementStateOfCompliance.Failed);

                            break;

                        case RelationalOperatorKind.GE:
                        case RelationalOperatorKind.GT:
                        case RelationalOperatorKind.LE:
                        case RelationalOperatorKind.LT:

                        case RelationalOperatorKind.NE:
                            this.Add(valueSet, !relationalExpression.Value.ToString().Equals(valueSet.ActualValue.ToString()) ? RequirementStateOfCompliance.Pass : RequirementStateOfCompliance.Failed);

                            break;

                        default: throw new ArgumentOutOfRangeException(nameof(relationalExpression.RelationalOperator), relationalExpression.RelationalOperator, $"Unknown {nameof(relationalExpression.RelationalOperator)}");
                    }
                }
            }
        }
    }
}
