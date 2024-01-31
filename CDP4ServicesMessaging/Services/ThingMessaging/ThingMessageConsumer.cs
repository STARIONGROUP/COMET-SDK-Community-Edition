// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageConsumer.cs" company="RHEA System S.A.">
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
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.MetaInfo;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Serializers.Json;
    using CDP4ServicesMessaging.Services.Messaging;
    using CDP4ServicesMessaging.Services.ThingMessaging.Interfaces;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The <see cref="ThingMessageConsumer"/> provides consumers for <see cref="ThingsChangedMessage"/>.
    /// </summary>
    public class ThingMessageConsumer : MessageClientService, IThingMessageConsumer
    {
        /// <summary>
        /// The <see cref="IMetaDataProvider"/>
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// Initializes a new <see cref="MessageClientBaseService"/>
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        /// <param name="logger">The <see cref="ILogger"/></param>
        /// <param name="serializer">The <see cref="IMessageSerializer"/></param>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/></param>
        public ThingMessageConsumer(IConfiguration configuration, ILogger<MessageClientService> logger, ICdp4MessageSerializer serializer, IMetaDataProvider metaDataProvider) : base(configuration, logger, serializer)
        {
            this.metaDataProvider = metaDataProvider;
        }

        /// <summary>
        /// Listens and emmits <see cref="ThingsChangedMessage"/> message
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <returns>An awaitable of <see cref="IObservable{T}"/> of <see cref="ThingsChangedMessage"/></returns>
        public async Task<IObservable<ThingsChangedMessage>> Listen(CancellationToken cancellationToken = default)
        {
            return await this.Listen<ThingsChangedMessage>(nameof(ThingsChangedMessage), ExchangeType.Fanout, cancellationToken);
        }

        /// <summary>
        /// Adds a listener to the specified queue
        /// </summary>
        /// <param name="onReceive">An <see cref="Action"/> that takes the received <see cref="ThingsChangedMessage"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/> of <see cref="IDisposable"/></return>
        public async Task<IDisposable> AddListener(Action<ThingsChangedMessage> onReceive, CancellationToken cancellationToken = default)
        {
            return await this.AddListener(nameof(ThingsChangedMessage), (_, m) =>
            {
                var thingsChangedMessage = this.Serializer.Deserialize<ThingsChangedMessage>(m.Body);
                onReceive(thingsChangedMessage);
            }, ExchangeType.Fanout, cancellationToken);
        }
    }
}
