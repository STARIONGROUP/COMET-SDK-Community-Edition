// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalWriteException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;

    /// <summary>
    /// A <see cref="DalWriteException"/> is thrown the when a during a Write operation the data-source
    /// returns an exception
    /// </summary>
    public class DalWriteException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        public DalWriteException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public DalWriteException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public DalWriteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
