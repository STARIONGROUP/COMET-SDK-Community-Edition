// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BackgroundThingsMessageProducer.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesMessaging.Services.BackgroundMessageProducers
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Services.ThingMessaging.Interfaces;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The <see cref="BackgroundThingsMessageProducer"/> wraps the <see cref="IThingMessageProducer"/> as a <see cref="BackgroundService"/>
    /// </summary>
    public class BackgroundThingsMessageProducer : BackgroundService, IBackgroundThingsMessageProducer
    {
        /// <summary>
        /// The <see cref="ILogger{T}" />
        /// </summary>
        private readonly ILogger<BackgroundThingsMessageProducer> logger;

        /// <summary>
        /// The <see cref="IConfiguration"/>
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The <see cref="IThingMessageProducer" />
        /// </summary>
        private readonly IThingMessageProducer messageProducer;

        /// <summary>
        /// The <see cref="ConcurrentStack{T}" />
        /// </summary>
        private readonly ConcurrentQueue<ThingsChangedMessage> messagesToProcess = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundThingsMessageProducer" /> class.
        /// </summary>
        /// <param name="messageProducer">The message queue client service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        public BackgroundThingsMessageProducer(IThingMessageProducer messageProducer, ILogger<BackgroundThingsMessageProducer> logger, IConfiguration configuration)
        {
            this.messageProducer = messageProducer;
            this.logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// Dequeues and processes messages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DequeueAsync(CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation("BackgroundThingsMessageProducer service is stopping.");

            while (this.messagesToProcess.TryDequeue(out var message))
            {
                await this.ProcessMessageAsync(message, cancellationToken);
            }

            await this.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Enqueues messages to be processed.
        /// </summary>
        /// <param name="message">The message to enqueue.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task EnqueueAsync(ThingsChangedMessage message)
        {
            this.messagesToProcess.Enqueue(message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous Start operation.</returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            if (this.configuration.GetValue<bool>("MessageBroker:IsEnabled", true))
            {
                return base.StartAsync(cancellationToken);
            }

            this.logger.LogDebug("BackgroundThingMessageProducer is disabled no thing message will be sent.");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Executes the background service logic.
        /// </summary>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation($"{nameof(BackgroundThingsMessageProducer)} background service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await this.ProcessMessageQueueAsync(stoppingToken);
                }
                catch (OperationCanceledException exception)
                {
                    this.logger.LogError(exception, "Processing message got canceled.");
                }
                catch (Exception exception)
                {
                    this.logger.LogError(exception, "Error in BackgroundThingsMessageProducer background service.");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
            
            this.logger.LogInformation("BackgroundThingsMessageProducer service is stopping.");
        }

        /// <summary>
        /// Indexes things asynchronously.
        /// </summary>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ProcessMessageQueueAsync(CancellationToken stoppingToken)
        {
            if (this.messagesToProcess.TryDequeue(out var messageInfo))
            {
                await this.ProcessMessageAsync(messageInfo, stoppingToken);
            }
        }

        /// <summary>
        /// Processes a message asynchronously.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ProcessMessageAsync(ThingsChangedMessage message, CancellationToken stoppingToken)
        {
            try
            {
                await this.messageProducer.PushParallel(message, stoppingToken);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "Error processing message type {name}.", nameof(ThingsChangedMessage));
            }
        }
    }
}
