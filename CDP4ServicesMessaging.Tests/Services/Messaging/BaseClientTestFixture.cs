// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClientTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.MetaInfo;

    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Serializers.Json;
    using CDP4ServicesMessaging.Services.Messaging;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Moq;

    using RabbitMQ.Client;
    
    public class BaseClientTestFixture<T> where T : MessageClientService
    {
        protected Mock<ILogger<T>> Logger;
        protected Mock<IConfiguration> Configuration;
        protected Mock<IConnection> Connection;
        protected Mock<IModel> Model;
        protected Mock<IConnectionFactory> ConnectionFactory;
        protected Mock<IConfigurationSection> MessageBrokerSettings;
        protected T Service;
        protected Mock<ICdp4MessageSerializer> Serializer;

        public BaseClientTestFixture()
        {
            this.Configuration = new Mock<IConfiguration>();

            this.Logger = new Mock<ILogger<T>>();

            this.Connection = new Mock<IConnection>();
            this.Model = new Mock<IModel>();
            this.ConnectionFactory = new Mock<IConnectionFactory>();

            var value = new Mock<IConfigurationSection>(MockBehavior.Loose);

            this.MessageBrokerSettings = new Mock<IConfigurationSection>(MockBehavior.Loose);

            this.MessageBrokerSettings.Setup(x => x.GetSection(It.IsAny<string>()))
                .Returns(value.Object);

            this.Configuration
                .Setup(x => x.GetSection(It.IsAny<string>()))
                .Returns(this.MessageBrokerSettings.Object);

            this.Serializer = new Mock<ICdp4MessageSerializer>();
            
            this.ConnectionFactory
                .Setup(x => x.CreateConnection())
                .Returns(this.Connection.Object);

            this.Connection
                .Setup(x => x.CreateModel())
                .Returns(this.Model.Object);
        }
    }
}
