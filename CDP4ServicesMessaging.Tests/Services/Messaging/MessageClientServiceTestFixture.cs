// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageClientServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2023 Starion Group S.A.
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

namespace CDP4ServicesMessaging.Tests.Services.Messaging
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Moq;

    using NUnit.Framework;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    [TestFixture]
    public class MessageClientServiceTestFixture : BaseClientTestFixture<TestMessageClient>
    {
        [SetUp]
        public void Setup()
        {
            this.Service = new TestMessageClient(this.ConnectionFactory.Object, this.Configuration.Object, this.Serializer.Object,
                this.Logger.Object);
        }

        [Test]
        public void Verify_that_Start_Works()
        {
            this.Service.ThrowErrorOnRegisterListenersAndDeclareQueues = true;

            Assert.Multiple(() =>
            {
                Assert.That(() => this.Service.Connect(), Throws.Exception.TypeOf<TimeoutException>());
                this.ConnectionFactory.Verify(x => x.CreateConnectionAsync(It.IsAny<CancellationToken>()), Times.Exactly(10));
                this.Connection.Verify(x => x.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()), Times.Exactly(10));
            });
        }

        [Test]
        public void Verify_that_Retry_Works()
        {
            this.Model.SetupAdd(m => m.ChannelShutdownAsync += (sender, args) => Task.CompletedTask);
            this.Connection.SetupAdd(m => m.ConnectionBlockedAsync += (sender, args) => Task.CompletedTask);
            this.Connection.SetupAdd(m => m.ConnectionUnblockedAsync += (sender, args) => Task.CompletedTask);
            this.Connection.SetupAdd(m => m.ConnectionShutdownAsync += (sender, args) => Task.CompletedTask);

            this.Service.ThrowErrorOnRegisterListenersAndDeclareQueues = true;

            Assert.Multiple(() =>
            {
                Assert.That(() => this.Service.Connect(), Throws.Exception.TypeOf<TimeoutException>());

                this.Model.VerifyAdd(m => m.ChannelShutdownAsync += It.IsAny<AsyncEventHandler<ShutdownEventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionBlockedAsync += It.IsAny<AsyncEventHandler<ConnectionBlockedEventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionUnblockedAsync += It.IsAny<AsyncEventHandler<AsyncEventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionShutdownAsync += It.IsAny<AsyncEventHandler<ShutdownEventArgs>>(), Times.Exactly(5));

                this.Model.Verify(x => x.IsOpen, Times.Exactly(4));

                this.ConnectionFactory
                    .Verify(x => x.CreateConnectionAsync(It.IsAny<CancellationToken>()), Times.Exactly(5));

                this.Connection
                    .Verify(x => x.CreateChannelAsync(It.IsAny<CreateChannelOptions>(), It.IsAny<CancellationToken>()), Times.Exactly(5));

                this.Model.VerifyRemove(m => m.ChannelShutdownAsync -= It.IsAny<AsyncEventHandler<ShutdownEventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionBlockedAsync -= It.IsAny<AsyncEventHandler<ConnectionBlockedEventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionUnblockedAsync -= It.IsAny<AsyncEventHandler<AsyncEventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionShutdownAsync -= It.IsAny<AsyncEventHandler<ShutdownEventArgs>>(), Times.Exactly(6));
            });
        }
    }
}
