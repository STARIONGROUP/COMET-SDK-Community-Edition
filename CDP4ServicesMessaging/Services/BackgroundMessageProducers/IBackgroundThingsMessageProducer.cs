// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IBackgroundMessagePublisher.cs" company="RHEA System S.A.">
//    Copyright (c) 2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Antoine Théate, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesMessaging.Services.BackgroundMessageProducers
{
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4ServicesMessaging.Messages;

    /// <summary>
    /// The <see cref="IBackgroundThingsMessageProducer"/> is the interface definition for the <see cref="BackgroundThingsMessageProducer"/>
    /// </summary>
    public interface IBackgroundThingsMessageProducer
    {
        /// <summary>
        /// Dequeues and processes messages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DequeueAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Enqueues messages to be processed.
        /// </summary>
        /// <param name="message">The message to enqueue.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task EnqueueAsync(ThingsChangedMessage message);
    }
}
