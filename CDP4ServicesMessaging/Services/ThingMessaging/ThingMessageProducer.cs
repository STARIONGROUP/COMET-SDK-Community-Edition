// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageProducer.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Services.ThingMessaging
{
    using System.Threading.Tasks;
    using System.Threading;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Services.Messaging;
    using CDP4ServicesMessaging.Services.ThingMessaging.Interfaces;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using CDP4ServicesMessaging.Serializers.Json;

    /// <summary>
    /// The <see cref="ThingMessageProducer"/> provides producers for <see cref="ThingsChangedMessage"/>.
    /// </summary>
    public class ThingMessageProducer : MessageClientService, IThingMessageProducer
    {
        /// <summary>
        /// Initializes a new <see cref="MessageClientBaseService"/>
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        /// <param name="logger">The <see cref="ILogger"/></param>
        /// <param name="serializer">The <see cref="ICdp4MessageSerializer"/></param>
        public ThingMessageProducer(IConfiguration configuration, ILogger<MessageClientService> logger, ICdp4MessageSerializer serializer) : base(configuration, logger, serializer)
        {
        }

        /// <summary>
        /// Pushes the specified <paramref name="message"/> in parallel, executing the operation in a fire-and-forget manner to the <see cref="ThingsChangedMessage"/> queue
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/></return>
        public Task PushParallel(ThingsChangedMessage message, CancellationToken cancellationToken = default)
        {
            return this.PushParallel(nameof(ThingsChangedMessage), message, ExchangeType.Fanout, cancellationToken);
        }
        
        /// <summary>
        /// Pushes synchroniously the specified <paramref name="message"/> to the ThingsChangedMessage queue or exchange
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/> to push</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        public async Task Push(ThingsChangedMessage message, CancellationToken cancellationToken = default)
        {
            await this.Push(nameof(ThingsChangedMessage), message, ExchangeType.Fanout, cancellationToken);
        }
    }
}
