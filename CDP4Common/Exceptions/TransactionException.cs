// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionException.cs" company="RHEA System S.A.">
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
    using CDP4Common.Operations;

    /// <summary>
    /// A <see cref="TransactionException"/> is thrown by the <see cref="ThingTransaction"/> whenever the transaction is in an
    /// inconsistent state.
    /// </summary>
    public class TransactionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionException"/> class.
        /// </summary>
        public TransactionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public TransactionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public TransactionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected TransactionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
