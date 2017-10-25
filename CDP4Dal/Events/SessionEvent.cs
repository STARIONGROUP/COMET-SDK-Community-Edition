// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionEvent.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Events
{
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The session status.
    /// </summary>
    public enum SessionStatus
    {
        /// <summary>
        /// Open status 
        /// </summary>
        Open,

        /// <summary>
        /// Closed status 
        /// </summary>
        Closed,

        /// <summary>
        /// A <see cref="SiteReferenceDataLibrary"/> was opened
        /// </summary>
        RdlOpened,

        /// <summary>
        /// A <see cref="SiteReferenceDataLibrary"/> was closed
        /// </summary>
        RdlClosed,

        /// <summary>
        /// An Update is occuring
        /// </summary>
        BeginUpdate,

        /// <summary>
        /// The update is completed
        /// </summary>
        EndUpdate
    }

    /// <summary>
    /// The session event.
    /// </summary>
    public class SessionEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionEvent"/> class.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        /// <param name="status">
        /// The status.
        /// </param>
        public SessionEvent(ISession session, SessionStatus status)
        {
            this.Session = session;
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets the <see cref="Session"/>.
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SessionStatus"/> of the <see cref="Session"/>.
        /// </summary>
        public SessionStatus Status { get; set; }
    }
}
