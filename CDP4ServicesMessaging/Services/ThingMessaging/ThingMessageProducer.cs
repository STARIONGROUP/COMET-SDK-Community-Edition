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
    using System;
    using System.Threading.Tasks;
    using System.Threading;

    using CDP4Common.MetaInfo;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Services.Messaging;
    using CDP4ServicesMessaging.Services.ThingMessaging.Interfaces;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using CDP4ServicesMessaging.Serializers.Json;

    /// <summary>
    /// The <see cref="ThingMessageProducer"/> provides consumers for <see cref="ThingsChangedMessage"/>.
    /// </summary>
    public class ThingMessageProducer : MessageClientService, IThingMessageProducer
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
        /// <param name="serializer">The <see cref="ICdp4MessageSerializer"/></param>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/></param>
        public ThingMessageProducer(IConfiguration configuration, ILogger<MessageClientService> logger, ICdp4MessageSerializer serializer, IMetaDataProvider metaDataProvider) : base(configuration, logger, serializer)
        {
            this.metaDataProvider = metaDataProvider;
        }

        /// <summary>
        /// Pushes the specified <paramref name="message"/> in parallel, executing the operation in a fire-and-forget manner to the <see cref="ThingsChangedMessage"/> queue
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/></return>
        public Task PushParallel(ThingsChangedMessage message, CancellationToken cancellationToken = default)
        {
            this.InitializeSerializer(message.ModelVersion);
            return this.PushParallel(nameof(ThingsChangedMessage), message, ExchangeType.Fanout, cancellationToken);
        }
        
        /// <summary>
        /// Pushes synchroniously the specified <paramref name="message"/> to the ThingsChangedMessage queue or exchange
        /// </summary>
        /// <param name="message">The <see cref="ThingsChangedMessage"/> to push</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        public async Task Push(ThingsChangedMessage message, CancellationToken cancellationToken = default)
        {
            this.InitializeSerializer(message.ModelVersion);
            await this.Push(nameof(ThingsChangedMessage), message, ExchangeType.Fanout, cancellationToken);
        }

        /// <summary>
        /// Initialize the serializer
        /// </summary>
        /// <param name="modelVersion">The supported <see cref="Version"/></param>
        private void InitializeSerializer(Version modelVersion)
        {
            if (this.Serializer is ICdp4MessageSerializer serializer)
            {
                serializer.Initialize(this.metaDataProvider, modelVersion);
            }
        }
    }
}
