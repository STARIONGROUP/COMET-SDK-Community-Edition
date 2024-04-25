// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeType.cs" company="Starion Group S.A.">
//    Copyright (c) 2024 Starion Group S.A.
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

namespace CDP4ServicesMessaging.Services.Messaging
{
    /// <summary>
    /// The exchange type defines the <see cref="ExchangeType"/>
    /// </summary>
    public enum ExchangeType
    {
        /// <summary>
        /// Default rabbitMQ exchange type
        /// </summary>
        Default,

        /// <summary>
        /// Exchange type used for AMQP direct exchanges.
        /// </summary>
        Direct,

        /// <summary>
        /// Exchange type used for AMQP fanout exchanges. Allows to broadcast messages
        /// </summary>
        Fanout,

        /// <summary>
        /// Exchange type used for AMQP headers exchanges.
        /// </summary>
        Headers,

        /// <summary>
        /// Exchange type used for AMQP topic exchanges.
        /// </summary>
        Topic
    }
}
