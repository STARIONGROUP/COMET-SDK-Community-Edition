// ----------------------------------------------------------------------------
// <copyright file="IRequirementVerification.cs" company="RHEA System S.A.">
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
// ----------------------------------------------------------------------------

namespace CDP4RequirementsVerification
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// State of compliance for a <see cref="ParametricConstraint"/> or a <see cref="BooleanExpression"/>
    /// </summary>
    public enum RequirementStateOfCompliance
    {
        /// <summary>
        /// No verification ran yet
        /// </summary>
        Unknown,

        /// <summary>
        /// Verification process was started
        /// </summary>
        Calculating,

        /// <summary>
        /// Cannot verify because of some reason
        /// </summary>
        Inconclusive,

        /// <summary>
        /// All conditions are passed
        /// </summary>
        Pass,

        /// <summary>
        /// At least one condition does not pass
        /// </summary>
        Failed
    }
}
