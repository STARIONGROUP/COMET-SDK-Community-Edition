// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOperationKindException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;
    using CDP4Dal.DAL;

    /// <summary>
    /// A InvalidOperationKindException is thrown whenever an <see cref="OperationContainer"/> contains
    /// <see cref="Operation"/> that are not supported by the implementation of an <see cref="IDal"/>
    /// </summary>
    public class InvalidOperationKindException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        public InvalidOperationKindException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InvalidOperationKindException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InvalidOperationKindException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
