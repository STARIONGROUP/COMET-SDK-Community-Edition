// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalReadException.cs" company="RHEA System S.A.">
//   Copyright (c) 2015 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A <see cref="DalReadException"/> is thrown the when a during a Read operation the data-source
    /// returns an exception
    /// </summary>
    [Serializable]
    public class DalReadException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DalReadException"/> class.
        /// </summary>
        public DalReadException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalReadException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public DalReadException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalReadException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public DalReadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalReadException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected DalReadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

    }
}
