// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageClientServiceTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    using Moq;

    using NUnit.Framework;

    using RabbitMQ.Client.Events;
    using RabbitMQ.Client;

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
                this.ConnectionFactory.Verify(x => x.CreateConnection(), Times.Exactly(10));
                this.Connection.Verify(x => x.CreateModel(), Times.Exactly(10));
            });
        }
        
        [Test]
        public void Verify_that_Retry_Works()
        {
            this.Model.SetupAdd(m => m.ModelShutdown += (sender, args) => { });
            this.Connection.SetupAdd(m => m.ConnectionBlocked += (sender, args) => { });
            this.Connection.SetupAdd(m => m.ConnectionUnblocked += (sender, args) => { });
            this.Connection.SetupAdd(m => m.ConnectionShutdown += (sender, args) => { });
            
            this.Service.ThrowErrorOnRegisterListenersAndDeclareQueues = true;

            Assert.Multiple(() =>
            {
                Assert.That(() => this.Service.Connect(), Throws.Exception.TypeOf<TimeoutException>());

                this.Model.VerifyAdd(m => m.ModelShutdown += It.IsAny<EventHandler<ShutdownEventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionBlocked += It.IsAny<EventHandler<ConnectionBlockedEventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionUnblocked += It.IsAny<EventHandler<EventArgs>>(), Times.Exactly(5));
                this.Connection.VerifyAdd(m => m.ConnectionShutdown += It.IsAny<EventHandler<ShutdownEventArgs>>(), Times.Exactly(5));
            
                this.Model.Verify(x => x.IsOpen, Times.Exactly(4));

                this.ConnectionFactory
                    .Verify(x => x.CreateConnection(), Times.Exactly(5));

                this.Connection
                    .Verify(x => x.CreateModel(), Times.Exactly(5));

                this.Model.VerifyRemove(m => m.ModelShutdown -= It.IsAny<EventHandler<ShutdownEventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionBlocked -= It.IsAny<EventHandler<ConnectionBlockedEventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionUnblocked -= It.IsAny<EventHandler<EventArgs>>(), Times.Exactly(6));
                this.Connection.VerifyRemove(m => m.ConnectionShutdown -= It.IsAny<EventHandler<ShutdownEventArgs>>(), Times.Exactly(6));
            });
        }
    }
}
