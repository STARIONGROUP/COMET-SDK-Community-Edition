// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageQueueClientBaseService.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The <see cref="IMessageQueueClientBaseService"/> is the interface definition for the <see cref="MessageClientBaseService"/>
    /// </summary>
    public interface IMessageQueueClientBaseService : IDisposable
    {
        /// <summary>
        /// Initializes the <see cref="MessageClientBaseService.ConnectionFactory"/> based on the specified <paramref name="configurationSectionName"></paramref>
        /// This overrides the connection factory initialized in <see cref="MessageClientBaseService(IConfiguration)"/> or in <see cref="MessageClientBaseService(IApplicationSettingsBase)"/>
        /// </summary>
        /// <param name="configurationSectionName">The configuration section name, default value is "MessageBroker"</param>
        void InitializeConnectionFactory(string configurationSectionName = "MessageBroker");
    }
}