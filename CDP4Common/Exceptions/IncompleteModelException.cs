// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IncompleteModelException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Exceptions
{
    using System;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.Runtime.Serialization;
#endif
    using CDP4Common.CommonData;

    /// <summary>
    /// An <see cref="IncompleteModelException"/> is thrown when the containment tree of any <see cref="Thing"/> is walked, either
    /// up or down and the model is incomplete.
    /// </summary>
    public class IncompleteModelException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncompleteModelException"/> class.
        /// </summary>
        public IncompleteModelException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncompleteModelException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public IncompleteModelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncompleteModelException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public IncompleteModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
        /// <summary>
        /// Initializes a new instance of the <see cref="IncompleteModelException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected IncompleteModelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
