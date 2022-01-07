// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseVerifier.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// Abstract base class for all Requirement State of Compliance verifiers.
    /// </summary>
    public abstract class BaseVerifier
    {
        /// <summary>
        /// The <see cref="IRequirementVerificationConfiguration"/>
        /// </summary>
        public IRequirementVerificationConfiguration Configuration { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="BaseVerifier"/> class
        /// </summary>
        /// <param name="configuration">The <see cref="IRequirementVerificationConfiguration"/> to be used.</param>
        protected BaseVerifier(IRequirementVerificationConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    }
}
