// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainmentException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.Runtime.Serialization;
#endif
    using CDP4Common.CommonData;

    /// <summary>
    /// A <see cref="ContainmentException"/> is thrown the when Container of a <see cref="Thing"/> is not set and it is 
    /// requested in an operation.
    /// </summary>
    public class ContainmentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainmentException"/> class.
        /// </summary>
        public ContainmentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainmentException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public ContainmentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainmentException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public ContainmentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainmentException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected ContainmentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
