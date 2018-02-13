#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionEvent.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
