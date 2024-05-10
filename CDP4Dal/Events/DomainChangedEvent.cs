// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainChangedEvent.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Dal.Events
{
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The session event.
    /// </summary>
    public class DomainChangedEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainChangedEvent"/> class.
        /// </summary>
        /// <param name="iteration">
        /// The session.
        /// </param>
        /// <param name="domain">
        /// The status.
        /// </param>
        public DomainChangedEvent(Iteration iteration, DomainOfExpertise domain)
        {
            this.Iteration = iteration;
            this.SelectedDomain = domain;
        }

        /// <summary>
        /// Gets or sets the <see cref="Iteration"/>.
        /// </summary>
        public Iteration Iteration { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SessionStatus"/> of the <see cref="Iteration"/>.
        /// </summary>
        public DomainOfExpertise SelectedDomain { get; set; }
    }
}
