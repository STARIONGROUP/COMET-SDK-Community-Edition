// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageConsumerTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Tests.Services.ThingMessaging
{
    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Services.ThingMessaging;
    using CDP4ServicesMessaging.Tests.Services.Messaging;

    using Moq;

    using RabbitMQ.Client;

    [TestFixture]
    public class ThingMessageConsumerTestFixture : BaseClientTestFixture<ThingMessageConsumer>
    {
        [SetUp]
        public void Setup()
        {
            this.Service = new ThingMessageConsumer(this.Configuration.Object, this.Logger.Object, this.Serializer.Object)
            {
                ConnectionFactory = this.ConnectionFactory.Object
            };
        }

        [Test]
        public async Task VerifyAddListener()
        {
            this.Model.Setup(x => x.IsOpen).Returns(true);
            
            this.Model.Setup(x => x.QueueDeclare(
                It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()))
                .Returns(new QueueDeclareOk("", 1, 1));
            
            var messageReceived = new List<ThingsChangedMessage>();

            Assert.Multiple(() =>
            {
                Assert.That(() => this.Service.AddListener(x => messageReceived.Add(x)), Throws.Nothing);
                Assert.That(messageReceived, Is.Empty);
            });

            var disposable = await this.Service.AddListener(x => messageReceived.Add(x));

            Assert.That(disposable, Is.SameAs(this.Model.Object));
            this.Model.Setup(x => x.IsOpen).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.That(() => this.Service.AddListener(x => messageReceived.Add(x)), Throws.Exception.TypeOf<TimeoutException>());
                this.Model.Verify(x => x.IsOpen, Times.Exactly(8));
            
                this.Model.Verify(x => x.QueueDeclare(
                        It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()), 
                    Times.Exactly(2));

                this.Model.Verify(x => x.ExchangeDeclare("ThingsChangedMessage", "fanout", true, false, null),
                    Times.Exactly(2));
            });
        }

        [Test]
        public async Task VerifyListen()
        {
            this.Model.Setup(x => x.IsOpen).Returns(true);

            this.Model.Setup(x => x.QueueDeclare(
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()))
                .Returns(new QueueDeclareOk("", 1, 1));
            
            var messageReceived = new List<ThingsChangedMessage>();

            Assert.Multiple(() =>
            {
                Assert.That(async () => (await this.Service.Listen())
                    .Subscribe(x => messageReceived.Add(x), x => throw x), Throws.Nothing);
            
                Assert.That(messageReceived, Is.Empty);
            });

            using var observable = (await this.Service.Listen())
                .Subscribe(x => messageReceived.Add(x), x => throw x);

            this.Model.Setup(x => x.IsOpen).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.That(async () => (await this.Service.Listen())
                    .Subscribe(x => messageReceived.Add(x), x => throw x), Throws.Exception.TypeOf<TimeoutException>());

                this.Model.Verify(x => x.IsOpen, Times.AtLeast(10));

                this.Model.Verify(x => x.ExchangeDeclare("ThingsChangedMessage", "fanout", true, false, null),
                    Times.AtLeast(2));
            });
        }
    }
}
