#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
#endregion

namespace CDP4Common
{
    /// <summary>
    /// Enumeration that specifies at what level in the containment hierarchy an instance is located.
    /// </summary>
    public enum ContainerLevelKind
    {
        /// <summary>
        /// Assertion that the level cannot be set, this is applicable for Abstract classes
        /// </summary>
        Invalid,

        /// <summary>
        /// Assertion that it is not yet determined where the instance is located in the containment hierarchy.
        /// </summary>
        Inconclusive,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="SiteDirectoryData.SiteDirectory"/>
        /// </summary>
        SiteDirectory,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="EngineeringModelData.EngineeringModel"/>.
        /// </summary>
        /// <remarks>
        /// This exlcudes containment by <see cref="EngineeringModelData.Iteration"/>
        /// </remarks>
        EngineeringModel,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="EngineeringModelData.Iteration"/>.
        /// </summary>
        /// <remarks>
        /// This exlcudes containment by <see cref="EngineeringModelData.Iteration"/>
        /// </remarks>
        Iteration
    }
}
