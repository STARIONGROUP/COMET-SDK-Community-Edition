// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationKindExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Operations
{
    using CDP4Common.DTO;

    using CDP4DalCommon.Protocol.Operations;

    /// <summary>
    /// Utils class to provide OperationKind Extensions to CDP4Dal
    /// </summary>
    public static class OperationKindExtensions
    {
        /// <summary>
        /// Assert whether an <see cref="OperationKind"/> is a copy operation
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation</returns>
        public static bool IsCopyOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.Copy ||
                   operationKind == OperationKind.CopyDefaultValuesChangeOwner ||
                   operationKind == OperationKind.CopyKeepValues ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
        }

        /// <summary>
        /// Assert whether an <see cref="OperationKind"/> is a copy operation that changes the owner of a <see cref="IOwnedThing"/>
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation that changes the owner</returns>
        public static bool IsCopyChangeOwnerOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.CopyDefaultValuesChangeOwner ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
        }

        /// <summary>
        /// Assert whether an <see cref="OperationKind"/> is a copy operation that keeps the original values of a <see cref="ParameterBase"/>
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation that keeps the original values of a <see cref="ParameterBase"/></returns>
        public static bool IsCopyKeepOriginalValuesOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.CopyKeepValues ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
        }
    }
}
