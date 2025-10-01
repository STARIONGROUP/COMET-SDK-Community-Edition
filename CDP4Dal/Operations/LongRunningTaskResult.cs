// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LongRunningTaskResult.cs" company="Starion Group S.A.">
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

namespace CDP4Dal.Operations
{
    using System.Collections.Generic;

    using CDP4Common.DTO;

    using CDP4DalCommon.Protocol.Tasks;

    /// <summary>
    /// Handle the returned data of a possible long running task
    /// </summary>
    public class LongRunningTaskResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongRunningTaskResult" /> class.
        /// </summary>
        /// <param name="things">The collection of <see cref="Thing" /></param>
        public LongRunningTaskResult(IEnumerable<Thing> things)
        {
            this.Things = things;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongRunningTaskResult" /> class.
        /// </summary>
        /// <param name="task">The <see cref="CometTask" /></param>
        public LongRunningTaskResult(CometTask task)
        {
            this.Task = task;
        }

        /// <summary>
        /// Gets the collection of <see cref="Thing" /> that can be retrieved from the response of a long running task if
        /// the task finished before the wait time is reached
        /// </summary>
        public IEnumerable<Thing> Things { get; }

        /// <summary>
        /// Gets the possible <see cref="CometTask" /> that can be retrieved from the response of a long running task if
        /// the task is not finished before the wait time is reached
        /// </summary>
        public CometTask Task { get; }

        /// <summary>
        /// Asserts that lon running task takes more time that the defined wait time and that the wait time has been reached
        /// </summary>
        public bool IsWaitTimeReached => this.Things == null;
    }
}
