// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CometTask.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4DalCommon.Protocol.Tasks
{
    using System;

    using CDP4Common.DTO;

    /// <summary>
    /// Represents an operation or task that is the result of a POST request on either the EngineeringModel or SiteDirectory end-points.
    /// The <see cref="CometTask" /> class provides information regarding the state of work that is being done.
    /// </summary>
    /// <remarks>
    /// The <see cref="CometTask" /> is a struct to make sure it is immutable and we receive a copy from the services
    /// and not a reference to an object
    /// </remarks>
    public struct CometTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CometTask" /> struct
        /// </summary>
        public CometTask()
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="CometTask" />
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the request (correlation) token
        /// </summary>
        public string RequestToken { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="Person" /> that started the <see cref="CometTask" />
        /// </summary>
        public Guid Actor { get; set; }

        /// <summary>
        /// Gets or sets the status of the <see cref="CometTask" />
        /// </summary>
        public StatusKind StatusKind { get; set; }

        /// <summary>
        /// Gets the duration in seconds for the <see cref="CometTask" /> to complete
        /// </summary>
        /// <remarks>
        /// A value of -1 is returned when the task is still running or not completed with success
        /// </remarks>
        public readonly int Duration => this.ComputeDuration();

        /// <summary>
        /// Gets or sets the <see cref="DateTime" /> at which the <see cref="CometTask" /> was started
        /// </summary>
        public DateTime? StartedAt { get; set; } = null;

        /// <summary>
        /// Gets or sets the <see cref="DateTime" /> at which the <see cref="CometTask" /> was finished
        /// </summary>
        public DateTime? FinishedAt { get; set; } = null;

        /// <summary>
        /// Gets or sets the TopContainer that the <see cref="CometTask" /> is for
        /// </summary>
        public string TopContainer { get; set; }

        /// <summary>
        /// Gets or sets the revision number that corresponds to the <see cref="CometTask" />
        /// </summary>
        /// <remarks>
        /// if the value is -1, the task has not (yet) completed with success
        /// </remarks>
        public int Revision { get; set; } = -1;

        /// <summary>
        /// Gets or sets the error in case the operation failed
        /// </summary>
        public string Error { get; set; } = null;

        /// <summary>
        /// Computes the duration in seconds for the <see cref="CometTask" /> to complete
        /// </summary>
        /// <returns>The computated duration</returns>
        private readonly int ComputeDuration()
        {
            if (!this.FinishedAt.HasValue || !this.StartedAt.HasValue)
            {
                return -1;
            }

            var timeSpan = this.FinishedAt.Value - this.StartedAt.Value;
            return (int)timeSpan.TotalSeconds;
        }
    }
}
