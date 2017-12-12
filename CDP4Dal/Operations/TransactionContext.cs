// -------------------------------------------------------------------------------------------------
// <copyright file="TransactionContext.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Dal.Operations
{
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose if the <see cref="TransactionContext"/> class is to provide a wrapper around types that can be used
    /// as context in a <see cref="ThingTransaction"/>. An ECSS-E-TM-10-25 data-source only accepts transactions on either
    /// a <see cref="SiteDirectory"/> and an <see cref="Iteration"/>.
    /// </summary>
    public class TransactionContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionContext"/> class.
        /// </summary>
        /// <param name="siteDirectory">
        /// The <see cref="SiteDirectory"/> that is the <see cref="Context"/> of the current <see cref="TransactionContext"/>
        /// </param>
        internal TransactionContext(SiteDirectory siteDirectory)
        {
            this.Context = siteDirectory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionContext"/> class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is the <see cref="Context"/> of the current <see cref="TransactionContext"/>
        /// </param>
        internal TransactionContext(Iteration iteration)
        {
            this.Context = iteration;
        }

        /// <summary>
        /// Gets the <see cref="Thing"/> that represents the context of the current <see cref="TransactionContext"/>
        /// </summary>
        /// <remarks>
        /// The context can only a <see cref="SiteDirectory"/> or <see cref="Iteration"/>
        /// </remarks>
        public Thing Context { get; private set; }

        /// <summary>
        /// Returns the route of the current <see cref="Context"/>
        /// </summary>
        /// <returns>
        /// A string that represents the a route
        /// </returns>
        /// <example>
        /// /SiteDirectory/{iid}
        /// /EngineeringModel/{iid}/iteration/{iid}
        /// </example>
        public string ContextRoute()
        {
            return this.Context.Route;
        }
    }
}
