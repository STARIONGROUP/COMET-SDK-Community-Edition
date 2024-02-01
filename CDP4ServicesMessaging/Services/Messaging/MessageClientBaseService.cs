// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageClientBaseService.cs" company="RHEA System S.A.">
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

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo($"{nameof(CDP4ServicesMessaging)}.Tests")]

namespace CDP4ServicesMessaging.Services.Messaging
{
    using System;
    using System.Threading;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;

    using RabbitMQ.Client;

    using CDP4ServicesMessaging.Services.Messaging.Interfaces;

    using Polly;

    using System.Threading.Tasks;

    /// <summary>
    /// The <see cref="MessageClientBaseService"/> is the base RabbitMQ client
    /// </summary>
    public abstract class MessageClientBaseService : IMessageQueueClientBaseService
    {
        /// <summary>
        /// Gets or sets the <see cref="ILogger"/> 
        /// </summary>
        public ILogger<MessageClientBaseService> Logger { get; }

        /// <summary>
        /// The <see cref="IConnectionFactory"/> for this client
        /// </summary>
        internal IConnectionFactory ConnectionFactory { get; set; }
        
        /// <summary>
        /// The number of times the connection process can be attempted
        /// </summary>
        private int maxConnectionRetryAttempts = 4;

        /// <summary>
        /// The time span in seconds between connection attempts.
        /// </summary>
        private int timeSpanBetweenAttempts = 1;
        
        /// <summary>
        /// The <see cref="IConfiguration"/>
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The <see cref="IConnection"/>
        /// </summary>
        private IConnection connection;

        /// <summary>
        /// The per thread <see cref="IModel"/>
        /// </summary>
        private readonly ThreadLocal<IModel> threadLocalChannel = new ();

        /// <summary>
        /// Initializes a new <see cref="MessageClientBaseService"/>
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        /// <param name="logger">The <see cref="ILogger"/></param>
        protected MessageClientBaseService(IConfiguration configuration, ILogger<MessageClientBaseService> logger)
        {
            this.Logger = logger;
            this.configuration = configuration;
            this.InitializeConnectionFactory();
        }

        /// <summary>
        /// Initializes the <see cref="ConnectionFactory"/> based on the specified <paramref name="configurationSectionName"/>.
        /// This overrides the connection factory initialized in <see cref="MessageClientBaseService(IConfiguration, ILogger{MessageClientBaseService})"/>.
        /// </summary>
        /// <param name="configurationSectionName">The configuration section name, default value is "MessageBroker".</param>
        public void InitializeConnectionFactory(string configurationSectionName = "MessageBroker")
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = this.configuration[$"{configurationSectionName}:HostName"] ?? "localhost",
                Port = this.GetIntConfig($"{configurationSectionName}:Port", 5672),
            };

            this.maxConnectionRetryAttempts = this.GetIntConfig($"{configurationSectionName}:MaxConnectionRetryAttempts", 4);
            this.timeSpanBetweenAttempts = this.GetIntConfig($"{configurationSectionName}:TimeSpanBetweenAttempts", 1);

            this.ConnectionFactory = connectionFactory;
        }

        /// <summary>
        /// Retrieves an integer configuration value from the application's configuration settings based on the specified key.
        /// If the configuration value is not present or cannot be parsed as an integer, the default value is returned.
        /// </summary>
        /// <param name="configKey">The key for the desired configuration value.</param>
        /// <param name="defaultValue">The default value to be returned if the configuration value is not present or cannot be parsed as an integer.</param>
        /// <returns>
        /// The integer configuration value associated with the specified key, or the default value if the key is not found or the value cannot be parsed as an integer.
        /// </returns>
        private int GetIntConfig(string configKey, int defaultValue) => 
            int.TryParse(this.configuration[configKey], out var configValue) ? configValue : defaultValue;

        /// <summary>
        /// Establishes a connection to the RabbitMQ server and returns an asynchronous <see cref="IModel"/> Channel.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for task cancellation.</param>
        /// <returns>An asynchronous task returning a <see cref="IModel"/> Channel.</returns>
        protected async Task<IModel> GetChannelAsync(CancellationToken cancellationToken = default)
        {
            var currentThreadChannel = this.threadLocalChannel.Value;

            if (currentThreadChannel is { IsOpen: true })
            {
                return currentThreadChannel;
            }

            var attemptNumber = 0;

            var policy = Policy.HandleResult<bool>(result =>
                {
                    if (result)
                    {
                        this.Logger.LogInformation("Established connection to the message broker.");
                        return false;
                    }

                    this.HandleConnectionFailed(ref attemptNumber);
                    return true;
                })
                .Or<Exception>(x => this.HandleConnectionFailed(ref attemptNumber, x))
                .WaitAndRetryAsync(this.maxConnectionRetryAttempts, _ => TimeSpan.FromSeconds(this.timeSpanBetweenAttempts));
            
            var result = await policy.ExecuteAndCaptureAsync(x => this.GetChannel(), cancellationToken);

            if (result.Outcome is not OutcomeType.Successful)
            {
                throw result.FinalException ?? new TimeoutException(
                    $"Unable to connect to {(this.ConnectionFactory is ConnectionFactory connectionFactory ? connectionFactory.Endpoint : "Unknown")} after {attemptNumber} attempts");
            }

            return this.threadLocalChannel.Value;
        }
        
        /// <summary>
        /// Creates a RabbitMQ connection and a channel, establishing a connection to the server.
        /// </summary>
        /// <returns>An asynchronous task returning a value indicating whether the channel is open.</returns>
        private Task<bool> GetChannel()
        {
            this.connection = this.ConnectionFactory.CreateConnection();

            this.connection.ConnectionBlocked += this.OnConnectionBlocked;
            this.connection.ConnectionShutdown += this.OnConnectionShutdown;
            this.connection.ConnectionUnblocked += this.OnConnectionUnblocked;

            var newChannel = this.connection.CreateModel();

            newChannel.ModelShutdown += this.OnChannelModelShutdown;

            this.threadLocalChannel.Value = newChannel;

            this.AfterChannelCreation();

            return Task.FromResult(newChannel is { IsOpen: true });
        }

        /// <summary>
        /// Handles connection to the RabbitMQ server failures
        /// </summary>
        /// <param name="attemptNumber">The current attempt number</param>
        /// <param name="exception">The exception which occured</param>
        private bool HandleConnectionFailed(ref int attemptNumber, Exception exception = null)
        {
            if (this.connection != null)
            {
                this.connection.ConnectionBlocked -= this.OnConnectionBlocked;
                this.connection.ConnectionShutdown -= this.OnConnectionShutdown;
                this.connection.ConnectionUnblocked -= this.OnConnectionUnblocked;
            }

            if (this.threadLocalChannel.Value != null)
            {
                this.threadLocalChannel.Value.ModelShutdown -= this.OnChannelModelShutdown;
            }

            var message = $"The message client failed to connect to {(this.ConnectionFactory is ConnectionFactory connectionFactory ? connectionFactory.Endpoint : "Unknown")}. {(exception?.Message ?? "")}";

            if (attemptNumber > this.maxConnectionRetryAttempts)
            {
                this.Logger.LogError("{Message} A time out occurred", message);
                return false;
            }

            attemptNumber++;
            this.Logger.LogError("{Message} Retrying in {SleepInterval} seconds...", message, this.timeSpanBetweenAttempts);
            return true;
        }

        /// <summary>
        /// Logic to run after the <see cref="IModel"/> has been created
        /// </summary>
        protected virtual void AfterChannelCreation()
        {
        }

        /// <summary>
        /// Model shutdown event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        protected virtual void OnChannelModelShutdown(object sender, ShutdownEventArgs e)
        {
            this.Logger.LogWarning("Message broker channel model has shut down. {Cause}", e.Cause);
        }

        /// <summary>
        /// Connection unblocked event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        protected virtual void OnConnectionUnblocked(object sender, EventArgs e)
        {
            this.Logger.LogInformation($"Message broker connection unblocked.");
        }

        /// <summary>
        /// Connection shutdown event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        protected virtual void OnConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            this.Logger.LogWarning("Message broker connection shutdown. {Cause}", e.Cause);
        }

        /// <summary>
        /// Connection blocked event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        protected virtual void OnConnectionBlocked(object sender, RabbitMQ.Client.Events.ConnectionBlockedEventArgs e)
        {
            this.Logger.LogWarning("Message broker connection blocked. {Reason}", e.Reason);
        }

        /// <summary>
        /// Disposes of the even handlers
        /// </summary>
        /// <param name="disposing">A value indicating whether this client is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this.connection != null)
            {
                this.connection.ConnectionBlocked -= this.OnConnectionBlocked;
                this.connection.ConnectionShutdown -= this.OnConnectionShutdown;
                this.connection.ConnectionUnblocked -= this.OnConnectionUnblocked;
                this.connection.Dispose();
            }

            if (this.threadLocalChannel.IsValueCreated)
            {
                this.threadLocalChannel.Value.ModelShutdown -= this.OnChannelModelShutdown;
                this.threadLocalChannel.Value.Dispose();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
