// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.Runtime.Serialization;
#endif
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// A <see cref="NestedElementTreeException"/> is thrown when a problem occurs while
    /// generating the <see cref="NestedElement"/> Tree
    /// </summary>
    public class NestedElementTreeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        public NestedElementTreeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public NestedElementTreeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public NestedElementTreeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected NestedElementTreeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
