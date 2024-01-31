// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingMessageProducer.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging
{
    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Serializers.Json;
    using CDP4ServicesMessaging.Services.BackgroundMessageProducers;
    using CDP4ServicesMessaging.Services.Messaging;
    using CDP4ServicesMessaging.Services.Messaging.Interfaces;
    using CDP4ServicesMessaging.Services.ThingMessaging;
    using CDP4ServicesMessaging.Services.ThingMessaging.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The <see cref="ServicesMessagingRegistration"/> provides extension method for service registrations on the target entry assembly
    /// </summary>
    public static class ServicesMessagingRegistration
    {
        /// <summary>
        /// Registers this library services in the provided <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection ConfigureServicesMessaging(this IServiceCollection services)
        {
            services.AddScoped<IThingMessageProducer, ThingMessageProducer>();
            services.AddScoped<IThingMessageConsumer, ThingMessageConsumer>();
            services.AddScoped<IMessageClientService, MessageClientService>();
            services.AddScoped<ICdp4MessageSerializer, Cdp4MessageSerializer>();
            services.AddScoped<IMessageSerializer>(x => x.GetService<ICdp4MessageSerializer>());
            services.AddSingleton<IBackgroundThingsMessageProducer, BackgroundThingsMessageProducer>();
            services.AddHostedService<BackgroundThingsMessageProducer>(x => x.GetService<IBackgroundThingsMessageProducer>() as BackgroundThingsMessageProducer);

            return services;
        }
    }
}
