// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ICDPMessageBus.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Dal
{
    using System;

    using CDP4Common.CommonData;

    using CDP4Dal.Events;

    /// <summary>
    /// Defines the properties and methods of the <see cref="ICDPMessageBus"/> interface
    /// </summary>
    public interface ICDPMessageBus : IDisposable
    {
        /// <summary>
        /// Number of currently active Observables in this instance of the <see cref="ICDPMessageBus"/>;
        /// </summary>
        int ActiveObservableCount { get; }

        /// <summary>
        /// Total number of Calls that have been made to the Listen method
        /// during the lifetime of this instance of <see cref="ICDPMessageBus"/>.
        /// </summary>
        int ListenerCallCount { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ICDPMessageBus"/> is enabled or not
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Listen provides an Observable that will fire whenever a Message is
        /// provided for this object via RegisterMessageSource or SendMessage.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the message to listen to.
        /// </typeparam>
        /// <param name="target">
        /// The target <see cref="object"/> to subscribe to.
        /// </param>
        /// <param name="contract">
        /// A unique string to distinguish messages with
        /// identical types (i.e. "MyCoolViewModel") - if the message type is
        /// only used for one purpose, leave this as null.
        /// </param>
        /// <returns>
        /// An Observable representing the notifications posted to the
        /// message bus.
        /// </returns>
        IObservable<T> Listen<T>(object target = null, string contract = null);

        /// <summary>
        /// Sends a single message using the specified Type and contract.
        /// Consider using RegisterMessageSource instead if you will be sending
        /// messages in response to other changes such as property changes
        /// or events.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the message to send.
        /// </typeparam>
        /// <param name="message">
        /// The actual event to send.
        /// </param>
        /// <param name="target">
        /// The target object that the notification belongs to.
        /// </param>
        /// <param name="contract">
        /// A unique string to distinguish messages with
        /// identical types (i.e. "MyCoolViewModel") - if the message type is
        /// only used for one purpose, leave this as null.
        /// </param>
        void SendMessage<T>(T message, object target = null, string contract = null);

        /// <summary>
        /// Send the necessary messages about a <see cref="Thing"/> being changed. Includes the sending of a message with the embedded type change.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that has changed.
        /// </param>
        /// <param name="eventKind">
        /// The event kind.
        /// </param>
        void SendObjectChangeEvent(Thing thing, EventKind eventKind);

        /// <summary>
        /// Clears all the subcriptions that exist on the Message Bus
        /// </summary>
        void ClearSubscriptions();
    }
}
