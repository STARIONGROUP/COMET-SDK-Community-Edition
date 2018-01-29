// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoValidationHelper.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Validation
{
    using System;
    using System.Collections.Generic;

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
