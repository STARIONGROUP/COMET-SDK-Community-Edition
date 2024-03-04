// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CometTaskEvent.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Dal.Events
{
    using System.Collections.Generic;

    using CDP4DalCommon.Tasks;

    /// <summary>
    /// Event related to <see cref="CometTask" />
    /// </summary>
    public class CometTaskEvent
    {
        /// <summary>
        /// Initialize a new <see cref="CometTaskEvent" />
        /// </summary>
        /// <param name="session">The <see cref="ISession" /> that read <see cref="CometTask" /></param>
        /// <param name="cometTask">The newly read <see cref="CometTask" /></param>
        public CometTaskEvent(ISession session, CometTask cometTask) : this(session, new List<CometTask> { cometTask })
        {
        }

        /// <summary>
        /// Initialize a new <see cref="CometTaskEvent" />
        /// </summary>
        /// <param name="session">The <see cref="ISession" /> that read <see cref="CometTask" />s</param>
        /// <param name="cometTasks">A collection of read <see cref="CometTask" /></param>
        public CometTaskEvent(ISession session, IEnumerable<CometTask> cometTasks)
        {
            this.CometTasks = new List<CometTask>(cometTasks);
            this.Session = session;
        }

        /// <summary>
        /// The collection of related <see cref="CometTask" />
        /// </summary>
        public IReadOnlyCollection<CometTask> CometTasks { get; }

        /// <summary>
        /// Gets the <see cref="ISession" /> that read <see cref="CometTask" />
        /// </summary>
        public ISession Session { get; }
    }
}
