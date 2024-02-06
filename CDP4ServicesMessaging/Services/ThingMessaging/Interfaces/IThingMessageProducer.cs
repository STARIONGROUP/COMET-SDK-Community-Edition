// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IThingMessageProducer.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Services.ThingMessaging.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4ServicesMessaging.Messages;

    /// <summary>
    /// The <see cref="IThingMessageProducer"/> is the interface for the <see cref="ThingMessageProducer"/>
    /// </summary>
    public interface IThingMessageProducer
    {
        /// <summary>
        /// Pushes the specified <paramref name="message"/> in parallel, executing the operation in a fire-and-forget manner to the <see cref="ThingsChangedMessage"/> queue
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/></return>
        /// <exception cref="ArgumentNullException">When the provided <param name="message"></param> is null</exception>
        Task PushParallel(ThingsChangedMessage message, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pushes synchroniously the specified <paramref name="message"/> to the ThingsChangedMessage queue or exchange
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/> to push</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/></return>
        /// <exception cref="ArgumentNullException">When the provided <param name="message"></param> is null</exception>
        Task Push(ThingsChangedMessage message, CancellationToken cancellationToken = default);
    }
}
