// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageClientService.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Services.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Services.Messaging.Interfaces;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using IModel = RabbitMQ.Client.IModel;

    /// <summary>
    /// The <see cref="MessageClientService"/> is the main implementation for the RabbitMQ client
    /// </summary>
    public class MessageClientService : MessageClientBaseService, IMessageClientService
    {
        /// <summary>
        /// The <see cref="IMessageSerializer"/>
        /// </summary>
        protected readonly IMessageSerializer Serializer;
        
        /// <summary>
        /// Initializes a new <see cref="MessageClientBaseService"/>
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        /// <param name="logger">The <see cref="ILogger"/></param>
        /// <param name="serializer">The <see cref="IMessageSerializer"/></param>
        public MessageClientService(IConfiguration configuration, ILogger<MessageClientService> logger, IMessageSerializer serializer) : base(configuration, logger)
        {
            this.Serializer = serializer;
        }

        /// <summary>
        /// Listens and emmits <typeparamref name="TMessage"/> message
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="queueName">The queue name</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <returns>An awaitable of <see cref="IObservable{T}"/> of <typeparamref name="TMessage"/></returns>
        public async Task<IObservable<TMessage>> Listen<TMessage>(string queueName, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default) where TMessage : class
        {
            var channel = await this.GetChannelAsync(cancellationToken);

            return Observable.Create<TMessage>(async observer =>
            {
                this.InitializeListener(observer, channel, queueName, exchangeType);
                
                return Disposable.Create(() =>
                {
                    channel?.Close();
                    channel?.Dispose();
                });
            });
        }

        /// <summary>
        /// Initializes a listener on the specified <paramref name="queueName"/>
        /// </summary>
        /// <typeparam name="T">The type of message</typeparam>
        /// <param name="observer">The <see cref="IObserver{T}"/></param>
        /// <param name="channel">The <see cref="IModel"/></param>
        /// <param name="queueName">The queue name</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <returns>A channel</returns>
        private void InitializeListener<T>(IObserver<T> observer, IModel channel, string queueName, ExchangeType exchangeType = ExchangeType.Default) where T : class
        {
            try
            {
                channel.CallbackException += (_, m) => observer.OnError(m.Exception);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (_, m) =>
                    observer.OnNext(this.Serializer.Deserialize<T>(m.Body));

                consumer.Shutdown += (e, a) =>
                    observer.OnError(new OperationCanceledException($"The channel has shutdown [Reply: {a.ReplyText}, AMQPcode: {a.ReplyCode}]"));

                channel.BasicConsume(this.EnsureQueueAndExchangeAreDeclared(queueName, channel, exchangeType), true, consumer);
            }
            catch (Exception exception)
            {
                observer.OnError(exception);
            }
        }

        /// <summary>
        /// Adds a listener to the specified queue
        /// </summary>
        /// <param name="queueName">The <see cref="string"/> queue name</param>
        /// <param name="onReceive">The <see cref="EventHandler"/></param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/> of <see cref="IDisposable"/></return>
        public async Task<IDisposable> AddListener(string queueName, EventHandler<BasicDeliverEventArgs> onReceive, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default)
        {
            IModel channel = default;

            try
            {
                channel = await this.GetChannelAsync(cancellationToken);

                this.EnsureQueueAndExchangeAreDeclared(queueName, channel, exchangeType);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += onReceive;

                channel.BasicConsume(queueName, true, consumer);
            }
            catch (TimeoutException)
            {
                throw;
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception, "Error while adding a listener to the {QueueName}", queueName);
            }

            return channel;
        }

        /// <summary>
        /// Pushes the specified <paramref name="message"/> in parallel, executing the operation in a fire-and-forget manner to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="message"/></param>
        /// <param name="message">The <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/></return>
        public Task PushParallel<TMessage>(string messageQueue, TMessage message, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => this.Push(messageQueue, message, exchangeType, cancellationToken), cancellationToken)
                .ContinueWith(x =>
                {
                    if (x.IsFaulted)
                    {
                        this.Logger.LogError(x.Exception?.InnerException, "The message {MessageName} could not be queued", typeof(TMessage).Name);
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Pushes the specified <paramref name="messages"/> in parallel, executing the operation in a fire-and-forget manner to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="messages"/></param>
        /// <param name="messages">The collection of <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        public void PushParallel<TMessage>(string messageQueue, IEnumerable<TMessage> messages, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default)
        {
            var tasks = messages.Select(item => this.PushParallel(messageQueue, item, exchangeType, cancellationToken));

            Task.WhenAll(tasks)
                .ContinueWith(x =>
                {
                    if (x.IsFaulted)
                    {
                        this.Logger.LogError(x.Exception?.InnerException, "One or more messages could not be queued");
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Pushes synchroniously the specified <paramref name="messages"/> to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="messages"/></param>
        /// <param name="messages">The collection of <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <returns>A <see cref="Task"/></returns>
        public async Task Push<TMessage>(string messageQueue, IEnumerable<TMessage> messages, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default)
        {
            foreach (var message in messages)
            {
                await this.Push(messageQueue, message, exchangeType, cancellationToken);
            }
        }

        /// <summary>
        /// Pushes synchroniously the specified <paramref name="message"/> to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="message"/></param>
        /// <param name="message">The <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">A possible <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task"/></returns>
        public async Task Push<TMessage>(string messageQueue, TMessage message, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            try
            {
                using var channel = await this.GetChannelAsync(cancellationToken);
                this.EnsureQueueAndExchangeAreDeclared(messageQueue, channel, exchangeType, true);

                var properties = channel.CreateBasicProperties();
                properties.Type = typeof(TMessage).Name;
                properties.DeliveryMode = 2;
                properties.ContentType = "application/json";

                channel.BasicPublish(exchange: exchangeType is ExchangeType.Fanout ? messageQueue : "",
                    routingKey: messageQueue,
                    basicProperties: properties,
                    body: this.Serializer.Serialize(message));

                this.Logger.LogInformation("Message {MessageName} sent to {MessageQueue}", typeof(TMessage).Name, messageQueue);
            }
            catch (Exception exception)
            {
                this.Logger.LogError("The message {MessageName} could not be queued to {MessageQueue} reason : {exception}", typeof(TMessage).Name, messageQueue, exception.Message);
            }
        }

        /// <summary>
        /// Declares the message queue if not declared yet
        /// </summary>
        /// <param name="messageQueue">The queue identifier</param>
        /// <param name="channel">The <see cref="IModel"/> channel on which to declare the queue</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="isPush">A value indicating whether the queue and exchange will be used for pushing messages</param>
        /// <returns>The queue name</returns>
        private string EnsureQueueAndExchangeAreDeclared(string messageQueue, IModel channel, ExchangeType exchangeType, bool isPush = false)
        {
            if (exchangeType is ExchangeType.Fanout)
            {
                channel.ExchangeDeclare(exchange: messageQueue, type: exchangeType.ToString().ToLower(), true);

                if (isPush)
                {
                    return messageQueue;
                }

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queueName, messageQueue, messageQueue);
                return queueName;
            }

            channel.QueueDeclare(queue: messageQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            return messageQueue;
        }
    }
}
