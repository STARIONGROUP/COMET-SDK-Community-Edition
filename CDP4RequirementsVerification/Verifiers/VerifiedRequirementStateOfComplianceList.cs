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

namespace CDP4RequirementsVerification.Verifiers
{
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;

    using CDP4RequirementsVerification.Calculations;

    /// <summary>
    /// Class used for the verification if a <see cref="RelationalExpression"/> is compliant to data in an <see cref="Iteration"/>
    /// It inherits from a <see cref="Dictionary{ParameterValueSetBase,RequirementStateOfCompliance}"/> so it links a <see cref="ParameterValueSetBase"/> to a <see cref="RequirementStateOfCompliance"/>
    /// </summary>
    public class VerifiedRequirementStateOfComplianceList : Dictionary<ParameterValueSetBase, RequirementStateOfCompliance>
    {
        private readonly IRequirementStateOfComplianceCalculator requirementStateOfComplianceCalculator;

        /// <summary>
        /// Initializes an instance of <see cref="VerifiedRequirementStateOfComplianceList"/>
        /// </summary>
        /// <param name="requirementStateOfComplianceCalculator">Implementation of <see cref="IRequirementStateOfComplianceCalculator"/> that will be used to calculate the <see cref="RequirementStateOfCompliance"/></param>
        public VerifiedRequirementStateOfComplianceList(IRequirementStateOfComplianceCalculator requirementStateOfComplianceCalculator)
        {
            this.requirementStateOfComplianceCalculator = requirementStateOfComplianceCalculator;
        }

        /// <summary>
        /// Check a list of <see cref="ParameterValueSetBase"/>s for compliance with a RelationalExpression and add the result to this instance of <see cref="VerifiedRequirementStateOfComplianceList"/>
        /// </summary>
        /// <param name="valueSets">List of <see cref="ParameterValueSetBase"/>s to be checked and added to this instance of <see cref="VerifiedRequirementStateOfComplianceList"/></param>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> that will be used to verify compliance</param>
        public void VerifyAndAdd(IEnumerable<ParameterValueSetBase> valueSets, RelationalExpression relationalExpression)
        {
            foreach (var valueSet in valueSets)
            {
                if (!this.ContainsKey(valueSet))
                {
                    this.Add(valueSet, this.requirementStateOfComplianceCalculator.Calculate(valueSet, relationalExpression));
                }
            }
        }
    }
}
