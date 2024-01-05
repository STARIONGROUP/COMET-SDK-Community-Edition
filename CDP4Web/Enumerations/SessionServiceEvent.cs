// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionServiceEvent.cs" company="RHEA System S.A.">
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

namespace CDP4Web.Enumerations
{
    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4Web.Services.SessionService;

    /// <summary>
    /// Enumeration used by the <see cref="SessionService"/> to send event on the <see cref="CDPMessageBus"/>
    /// </summary>
    public enum SessionServiceEvent
    {
        /// <summary>
        /// To use when an <see cref="Iteration"/> has been opened
        /// </summary>
        IterationOpened,

        /// <summary>
        /// To use when an <see cref="Iteration"/> has been closed
        /// </summary>
        IterationClosed,

        /// <summary>
        /// To use before refreshing the <see cref="ISession"/>
        /// </summary>
        SessionRefreshing,

        /// <summary>
        /// To use when the <see cref="ISession"/> has been refreshed
        /// </summary>
        SessionRefreshed,

        /// <summary>
        /// To use before reloading the <see cref="ISession"/>
        /// </summary>
        SessionReloading,

        /// <summary>
        /// To use when the <see cref="ISession"/> has been reloaded
        /// </summary>
        SessionReloaded
    }
}
