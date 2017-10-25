// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeSerializationException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A <see cref="DeSerializationException"/> is thrown the when a deserialization exception is encountered.
    /// </summary>
    [Serializable]
    public class DeSerializationException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeSerializationException"/> class.
        /// </summary>
        public DeSerializationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeSerializationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public DeSerializationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeSerializationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public DeSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeSerializationException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected DeSerializationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
