// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageProducerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.DTO;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Services.ThingMessaging;
    using CDP4ServicesMessaging.Tests.Services.Messaging;

    using Moq;

    using RabbitMQ.Client;

    [TestFixture]
    public class ThingMessageProducerTestFixture : BaseClientTestFixture<ThingMessageProducer>
    {
        [SetUp]
        public void Setup()
        {
            this.Service = new ThingMessageProducer(this.Configuration.Object, this.Logger.Object, this.Serializer.Object, this.MetaDataProvider.Object)
            {
                ConnectionFactory = this.ConnectionFactory.Object
            };
        }

        [Test]
        public async Task VerifyPush()
        {
            this.Model.Setup(x => x.IsOpen).Returns(true);

            this.Model.Setup(x => x.QueueDeclare(
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()))
                .Returns(new QueueDeclareOk("", 1, 1));

            var properties = new Mock<IBasicProperties>();
            this.Model.Setup(x => x.CreateBasicProperties()).Returns(properties.Object);

            var message = new ThingsChangedMessage()
            {
                ChangedThings = { new ElementDefinition() { Name = nameof(ElementDefinition) }, new EngineeringModel(), new Parameter() { } },
                ActorId = Guid.NewGuid(),
            };
            
            await this.Service.Push(message);
            await this.Service.PushParallel(message);

            Assert.Multiple(() =>
            {
                this.Model.Verify(x => x.BasicPublish(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),It.IsAny<IBasicProperties>(), It.IsAny<ReadOnlyMemory<byte>>()),
                    Times.Exactly(2));

                this.Serializer.Verify(x => x.Serialize(message), Times.Exactly(2));
                this.Model.Verify(x => x.ExchangeDeclare("ThingsChangedMessage", "fanout", true, false, null), Times.Exactly(2));
            });
        }
    }
}
