// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceNotFoundException.cs" company="RHEA System S.A.">
//   Copyright (c) 2015 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;

    /// <summary>
    /// A <see cref="InstanceNotFoundException"/> is thrown the when a <see cref="Thing"/> cannot be found.
    /// </summary>
    public class InstanceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        public InstanceNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InstanceNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InstanceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
