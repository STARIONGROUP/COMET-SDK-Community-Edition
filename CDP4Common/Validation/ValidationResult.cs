// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationResult.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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

namespace CDP4Common.Validation
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The compound result of <see cref="Parameter"/> value validation that carries the <see cref="ValidationResultKind"/> 
    /// and an optional message.
    /// </summary>
    public struct ValidationResult
    {
        /// <summary>
        /// The actual result of a validation
        /// </summary>
        public ValidationResultKind ResultKind;

        /// <summary>
        /// An optional message to provide more detail regarding the validation result. When the
        /// <see cref="ResultKind"/> is Valid the message is empty
        /// </summary>
        public string Message;

        /// <summary>
        /// Gets a <see cref="ValidationResult"/> with an empty <see cref="Message"/> and a <see cref="ValidationResultKind.Valid"/> resultKind
        /// </summary>
        /// <returns>The <see cref="ValidationResult"/></returns>
        public static ValidationResult ValidResult()
        {
            return new ValidationResult()
            {
                Message = string.Empty,
                ResultKind = ValidationResultKind.Valid
            };
        }
    }
}