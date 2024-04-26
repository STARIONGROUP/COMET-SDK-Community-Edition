// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageClientService.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesMessaging.Services.Messaging.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4ServicesMessaging.Services.Messaging;

    using RabbitMQ.Client.Events;

    /// <summary>
    /// The <see cref="IMessageClientService"/> is the interface definition for the <see cref="MessageClientService"/>
    /// </summary>
    public interface IMessageClientService : IMessageQueueClientBaseService
    {
        /// <summary>
        /// Listens and emmits <typeparamref name="TMessage"/> message
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="queueName">The queue name</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <returns>An awaitable of <see cref="IObservable{T}"/> of <typeparamref name="TMessage"/></returns>
        Task<IObservable<TMessage>> Listen<TMessage>(string queueName, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default) where TMessage : class;

        /// <summary>
        /// Adds a listener to the specified queue
        /// </summary>
        /// <param name="queueName">The <see cref="string"/> queue name</param>
        /// <param name="onReceive">The <see cref="EventHandler"/></param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <return>A <see cref="Task"/> of <see cref="IDisposable"/></return>
        Task<IDisposable> AddListener(string queueName, EventHandler<BasicDeliverEventArgs> onReceive, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pushes the specified <paramref name="message"/> in parallel, executing the operation in a fire-and-forget manner to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="message"/></param>
        /// <param name="message">The <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <exception cref="ArgumentNullException">When the provided <typeparamref name="TMessage"/> is null</exception>
        /// <return>A <see cref="Task"/></return>
        Task PushParallel<TMessage>(string messageQueue, TMessage message, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pushes the specified <paramref name="messages"/> in parallel, executing the operation in a fire-and-forget manner to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="messages"/></param>
        /// <param name="messages">The collection of <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/></param>
        /// <exception cref="ArgumentNullException">When any of the provided <typeparamref name="TMessage"/> is null</exception>
        void PushParallel<TMessage>(string messageQueue, IEnumerable<TMessage> messages, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pushes synchroniously the specified <paramref name="messages"/> to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="messages"/></param>
        /// <param name="messages">The collection of <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">A possible <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task"/></returns>
        /// <exception cref="ArgumentNullException">When any of the provided <typeparamref name="TMessage"/> is null</exception>
        Task Push<TMessage>(string messageQueue, IEnumerable<TMessage> messages, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pushes synchroniously the specified <paramref name="message"/> to the specified <paramref name="messageQueue"/>
        /// </summary>
        /// <typeparam name="TMessage">The type of message</typeparam>
        /// <param name="messageQueue">The <see cref="string"/> queue name on which to send to the <paramref name="message"/></param>
        /// <param name="message">The <typeparamref name="TMessage"/> to push</param>
        /// <param name="exchangeType">The string exchange type It can be any value from <see cref="ExchangeType"/>, default value is <see cref="ExchangeType.Default"/></param>
        /// <param name="cancellationToken">A possible <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task"/></returns>
        /// <exception cref="ArgumentNullException">When the provided <typeparamref name="TMessage"/> is null</exception>
        Task Push<TMessage>(string messageQueue, TMessage message, ExchangeType exchangeType = ExchangeType.Default, CancellationToken cancellationToken = default);
    }
}
