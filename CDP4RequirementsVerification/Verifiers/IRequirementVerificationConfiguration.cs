// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequirementVerificationConfiguration.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Defines that an object implements Requirement Verification Configuration setings and helper methods
    /// </summary>
    public interface IRequirementVerificationConfiguration
    {
        /// <summary>
        /// The <see cref="Option"/> to use during RelationalExpression verification
        /// </summary>
        Option Option { get; set; }

        /// <summary>
        /// Checks if a <see cref="ParameterValueSetBase"/> is eligible for usage during RelationalExpression verification
        /// </summary>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase"/> to check.</param>
        /// <returns>A boolean indicating that usage of the <see cref="ParameterValueSetBase"/> is eligible</returns>
        bool IsValueSetAllowed(ParameterValueSetBase valueSet);
    }
}
