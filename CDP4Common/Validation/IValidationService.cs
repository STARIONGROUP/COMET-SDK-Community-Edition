// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationService.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Common.Validation
{
    using System.Collections.Generic;

    using CDP4Common.CommonData;

    /// <summary>
    /// The purpose of the <see cref="IValidationService" /> is to check and report on the validity of a field in a form
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Gets the validation map provides the mapping between field names and <see cref="ValidationService.ValidationRule" />s.
        /// </summary>
        Dictionary<string, ValidationService.ValidationRule> ValidationMap { get; }

        /// <summary>
        /// Validate a property of a <see cref="Thing" />
        /// </summary>
        /// <param name="propertyName">the name of the property to validate</param>
        /// <param name="value">the value to validate</param>
        /// <returns>
        /// The <see cref="string" /> with the error text, or null if there is no validation error
        /// (either because there is no rule for the given property or because the given value is correct)
        /// </returns>
        string ValidateProperty(string propertyName, object value);
    }
}
