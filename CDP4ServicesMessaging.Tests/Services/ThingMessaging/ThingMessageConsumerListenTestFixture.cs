// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageConsumerListenTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2026 Starion Group S.A.
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

namespace CDP4ServicesMessaging.Tests.Services.ThingMessaging
{
    using System.Threading;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Serializers.Json;
    using CDP4ServicesMessaging.Services.ThingMessaging;
    using CDP4ServicesMessaging.Tests.Services.Messaging;

    using Moq;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    /// <summary>
    /// Tests how <see cref="ThingMessageConsumer.Listen(CancellationToken)"/> handles messages, shutdowns and disposal
    /// of the subscription. The channel and serializer mocks are created for each test, so that the invocation
    /// counts of one test do not affect another.
    /// </summary>
    [TestFixture]
    public class ThingMessageConsumerListenTestFixture : BaseClientTestFixture<ThingMessageConsumer>
    {
        private TaskCompletionSource<AsyncEventingBasicConsumer> consumerCaptured;

        [SetUp]
        public void Setup()
        {
            this.Model = new Mock<IChannel>();
            this.Serializer = new Mock<ICdp4MessageSerializer>();

            this.Connection
                .Setup(x => x.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(this.Model.Object);

            this.consumerCaptured = new TaskCompletionSource<AsyncEventingBasicConsumer>(TaskCreationOptions.RunContinuationsAsynchronously);

            this.Model.Setup(x => x.IsOpen).Returns(true);

            this.Model.Setup(x => x.QueueDeclareAsync(
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new QueueDeclareOk("generated-queue", 0, 1));

            this.Model.Setup(x => x.BasicConsumeAsync(
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>(), It.IsAny<IAsyncBasicConsumer>(), It.IsAny<CancellationToken>()))
                .Callback((string _, bool _, string _, bool _, bool _, IDictionary<string, object> _, IAsyncBasicConsumer consumer, CancellationToken _) =>
                    this.consumerCaptured.TrySetResult((AsyncEventingBasicConsumer)consumer))
                .ReturnsAsync("consumer-tag");

            this.Service = new ThingMessageConsumer(this.Configuration.Object, this.Logger.Object, this.Serializer.Object)
            {
                ConnectionFactory = this.ConnectionFactory.Object
            };
        }

        [Test]
        public async Task Verify_that_Listen_pushes_received_message_to_subscriber()
        {
            var message = new ThingsChangedMessage { ActorId = Guid.NewGuid() };
            var body = new byte[] { 1, 2, 3 };

            this.Serializer.Setup(x => x.Deserialize<ThingsChangedMessage>(It.IsAny<ReadOnlyMemory<byte>>())).Returns(message);

            var messageReceived = new List<ThingsChangedMessage>();

            using var subscription = (await this.Service.Listen()).Subscribe(x => messageReceived.Add(x), x => throw x);

            var consumer = await this.WaitForConsumer();

            await consumer.HandleBasicDeliverAsync("consumer-tag", 1, false, "ThingsChangedMessage", string.Empty, new BasicProperties(), body);

            Assert.Multiple(() =>
            {
                Assert.That(messageReceived, Has.Count.EqualTo(1));
                Assert.That(messageReceived[0], Is.SameAs(message));
                this.Serializer.Verify(x => x.Deserialize<ThingsChangedMessage>(It.Is<ReadOnlyMemory<byte>>(m => m.ToArray().SequenceEqual(body))), Times.Once);
            });
        }

        [Test]
        public async Task Verify_that_Listen_reports_OperationCanceledException_on_consumer_shutdown()
        {
            Exception receivedError = null;

            using var subscription = (await this.Service.Listen()).Subscribe(_ => { }, x => receivedError = x);

            var consumer = await this.WaitForConsumer();

            await consumer.HandleChannelShutdownAsync(this.Model.Object, new ShutdownEventArgs(ShutdownInitiator.Peer, 320, "CONNECTION_FORCED"));

            Assert.Multiple(() =>
            {
                Assert.That(receivedError, Is.TypeOf<OperationCanceledException>());
                Assert.That(receivedError?.Message, Does.Contain("CONNECTION_FORCED"));
                Assert.That(receivedError?.Message, Does.Contain("320"));
            });
        }

        [Test]
        public async Task Verify_that_disposing_Listen_subscription_detaches_handlers()
        {
            this.Serializer.Setup(x => x.Deserialize<ThingsChangedMessage>(It.IsAny<ReadOnlyMemory<byte>>())).Returns(new ThingsChangedMessage());

            var subscription = (await this.Service.Listen()).Subscribe(_ => { }, x => throw x);

            var consumer = await this.WaitForConsumer();

            this.Model.VerifyAdd(m => m.CallbackExceptionAsync += It.IsAny<AsyncEventHandler<CallbackExceptionEventArgs>>(), Times.Once);

            subscription.Dispose();

            await consumer.HandleBasicDeliverAsync("consumer-tag", 1, false, "ThingsChangedMessage", string.Empty, new BasicProperties(), new byte[] { 1 });

            Assert.Multiple(() =>
            {
                this.Model.VerifyRemove(m => m.CallbackExceptionAsync -= It.IsAny<AsyncEventHandler<CallbackExceptionEventArgs>>(), Times.Once);
                this.Serializer.Verify(x => x.Deserialize<ThingsChangedMessage>(It.IsAny<ReadOnlyMemory<byte>>()), Times.Never);
            });
        }

        /// <summary>
        /// Waits until <see cref="ThingMessageConsumer.Listen(CancellationToken)"/> has registered its consumer on the channel
        /// </summary>
        /// <returns>The captured <see cref="AsyncEventingBasicConsumer"/></returns>
        private async Task<AsyncEventingBasicConsumer> WaitForConsumer()
        {
            var completed = await Task.WhenAny(this.consumerCaptured.Task, Task.Delay(TimeSpan.FromSeconds(5)));

            Assert.That(completed, Is.SameAs(this.consumerCaptured.Task), "The consumer was not registered on the channel");

            return await this.consumerCaptured.Task;
        }
    }
}
