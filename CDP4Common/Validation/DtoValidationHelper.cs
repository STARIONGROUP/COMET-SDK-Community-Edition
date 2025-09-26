// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoValidationHelper.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System;
    
    using CDP4Common.DTO;
    using CDP4Common.Exceptions;

    /// <summary>
    /// The validation helper.
    /// </summary>
    /// <typeparam name="T">
    /// Type parameter to bind this generic class
    /// </typeparam>
    public class DtoValidationHelper<T> where T : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoValidationHelper{T}"/> class.
        /// </summary>
        /// <param name="validationPredicate">
        /// The validation predicate.
        /// </param>
        /// <param name="validationError">
        /// The validation error.
        /// </param>
        public DtoValidationHelper(Func<T, bool> validationPredicate, string validationError)
        {
            this.ValidationPredicate = validationPredicate;
            this.ValidationError = validationError;
        }
        
        /// <summary>
        /// Gets the validation predicate.
        /// </summary>
        public Func<T, bool> ValidationPredicate { get; private set; }

        /// <summary>
        /// Gets the validation error text.
        /// </summary>
        public string ValidationError { get; private set; }

        /// <summary>
        /// Run the validation rule, throw a <see cref="Cdp4ModelValidationException"/> if not passed.
        /// </summary>
        /// <param name="thing">
        /// The thing on which to perform the validation.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If the validation rule failed
        /// </exception>
        public void Validate(T thing)
        {
            if (!this.TryValidate(thing))
            {
                throw new Cdp4ModelValidationException(this.ValidationError);
            }
        }

        /// <summary>
        /// Run the validation rule.
        /// </summary>
        /// <param name="thing">
        /// The thing on which to perform the validation.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if validation has passed.
        /// </returns>
        public bool TryValidate(T thing)
        {
            return this.ValidationPredicate(thing);
        }
    }
}