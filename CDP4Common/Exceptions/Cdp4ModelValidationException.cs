// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4ModelValidationException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;

    /// <summary>
    /// The CDP4 model validation exception.
    /// </summary>
    public class Cdp4ModelValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        public Cdp4ModelValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public Cdp4ModelValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public Cdp4ModelValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
