// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequirementStateOfComplianceCalculator.cs" company="RHEA System S.A.">
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

namespace CDP4RequirementsVerification.Calculations
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Specification of the <see cref="IRequirementStateOfComplianceCalculator"/> interface.
    /// </summary>
    public interface IRequirementStateOfComplianceCalculator
    {
        /// <summary>
        /// The method that performs the necessary calculations and and returns the <see cref="RequirementStateOfCompliance"/> based on those calculations
        /// </summary>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase"/> that is used for calculations</param>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> that is used for calculations</param>
        /// <returns><see cref="RequirementStateOfCompliance"/> based on the calculations</returns>
        RequirementStateOfCompliance Calculate(ParameterValueSetBase valueSet, RelationalExpression relationalExpression);
    }
}
