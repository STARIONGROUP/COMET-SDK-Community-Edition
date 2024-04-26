// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementStateOfComplianceCalculator.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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

namespace CDP4RequirementsVerification.Calculations
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Implementation of the <see cref="IRequirementStateOfComplianceCalculator"/> interface that is used for the calculation of a <see cref="RequirementStateOfCompliance"/>
    /// </summary>
    public class RequirementStateOfComplianceCalculator : IRequirementStateOfComplianceCalculator
    {
        /// <summary>
        /// The method that performs the necessary calculations and and returns the <see cref="RequirementStateOfCompliance"/> based on those calculations
        /// </summary>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase"/> that is used for calculations</param>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> that is used for calculations</param>
        /// <returns><see cref="RequirementStateOfCompliance"/> based on the calculations</returns>
        public RequirementStateOfCompliance Calculate(ParameterValueSetBase valueSet, RelationalExpression relationalExpression)
        {
            var comparer = this.GetValueSetComparer(relationalExpression);

            switch (relationalExpression.RelationalOperator)
            {
                case RelationalOperatorKind.EQ:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) == 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                case RelationalOperatorKind.GE:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) >= 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                case RelationalOperatorKind.GT:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) > 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                case RelationalOperatorKind.LE:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) <= 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                case RelationalOperatorKind.LT:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) < 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                case RelationalOperatorKind.NE:
                    return comparer.Compare(valueSet.ActualValue, relationalExpression.Value) != 0
                        ? RequirementStateOfCompliance.Pass
                        : RequirementStateOfCompliance.Failed;

                default: throw new ArgumentOutOfRangeException(nameof(relationalExpression.RelationalOperator), relationalExpression.RelationalOperator, $"Unknown {nameof(relationalExpression.RelationalOperator)}");
            }
        }

        /// <summary>
        /// Gets the ValueSet comparer for this kind of <see cref="ParameterType"/>
        /// </summary>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/></param>
        /// <returns>The <see cref="IComparer{ValueArray{String}}"/></returns>
        private IComparer<ValueArray<string>> GetValueSetComparer(RelationalExpression relationalExpression)
        {
            IComparer<ValueArray<string>> comparer;

            switch (relationalExpression.ParameterType.ClassKind)
            {
                case ClassKind.SpecializedQuantityKind:
                    comparer = new QuantityKindValueSetComparer();

                    break;

                case ClassKind.SimpleQuantityKind:
                    comparer = new QuantityKindValueSetComparer();

                    break;

                case ClassKind.DerivedQuantityKind:
                    comparer = new QuantityKindValueSetComparer();

                    break;

                case ClassKind.BooleanParameterType:
                    comparer = new BooleanValueSetComparer();

                    break;

                case ClassKind.EnumerationParameterType:
                    comparer = new EnumerationValueSetComparer();

                    break;

                case ClassKind.DateParameterType:
                    comparer = new DateTimeValueSetComparer();

                    break;

                case ClassKind.DateTimeParameterType:
                    comparer = new DateTimeValueSetComparer();

                    break;

                case ClassKind.TimeOfDayParameterType:
                    comparer = new DateTimeValueSetComparer();

                    break;

                case ClassKind.TextParameterType:
                    comparer = new StringValueSetComparer();

                    break;

                default:
                    comparer = new StringValueSetComparer();

                    break;
            }

            return comparer;
        }
    }
}
