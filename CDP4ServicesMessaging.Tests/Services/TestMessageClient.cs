// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMessageClient.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Tests.Services
{
    using Microsoft.Extensions.Configuration;
    
    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Services.Messaging;
    
    using Microsoft.Extensions.Logging;

    using RabbitMQ.Client;

    public class TestMessageClient : MessageClientService
    {
        public bool ThrowErrorOnRegisterListenersAndDeclareQueues;
        public int NoErrorAfterNTimes = 1;

        private int time;
        private bool failed;

        public TestMessageClient(IConnectionFactory connectionFactory, IConfiguration configuration, IMessageSerializer serializer, ILogger<TestMessageClient> logger)
            : base(configuration, logger, serializer)
        {
            this.ConnectionFactory = connectionFactory;
        }

        public async Task<IModel> Connect()
        {
            try
            {
                return await this.GetChannelAsync();
            }
            catch (TimeoutException)
            {
                if (this.ThrowErrorOnRegisterListenersAndDeclareQueues)
                {
                    throw;
                }
            }

            return default;
        }

        protected override void AfterChannelCreation()
        {
            if (!this.failed && this.ThrowErrorOnRegisterListenersAndDeclareQueues)
            {
                this.time++;

                if (this.time >= this.NoErrorAfterNTimes)
                {
                    this.failed = true;
                }

                throw new NotImplementedException();
            }
        }
    }
}
