// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4MessageSerializerTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4ServicesMessaging.Tests.Serializers.Json
{
    using System.Text;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using CDP4ServicesMessaging.Messages;
    using CDP4ServicesMessaging.Serializers;
    using CDP4ServicesMessaging.Serializers.Json;

    using NUnit.Framework;

    [TestFixture]
    public class Cdp4MessageSerializerTestFixture
    {
        private Cdp4MessageSerializer cdp4JsonSerializer;

        [SetUp]
        public void Setup()
        {
            var metadataInfoProvider = new MetaDataProvider();

            this.cdp4JsonSerializer = new Cdp4MessageSerializer(metadataInfoProvider);
        }

        [Test]
        public void VerifyMessagesAreSerializedAsExpected()
        {
            var message = new ThingsChangedMessage()
            {
                ChangedThings = { new ElementDefinition() { Name = nameof(ElementDefinition) }, new EngineeringModel(), new Parameter() { } },
                ActorId = Guid.NewGuid(),
            };

            var json = Encoding.UTF8.GetString(this.cdp4JsonSerializer.Serialize(message).Span);

            Assert.That(json, Does.Contain(nameof(ElementDefinition)));

            var newMessage = this.cdp4JsonSerializer.Deserialize<ThingsChangedMessage>(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(json)));

            Assert.Multiple(() =>
            {
                Assert.That(newMessage.ChangedThings.Count, Is.EqualTo(3));
                Assert.That(newMessage.ActorId, Is.EqualTo(message.ActorId));
            });
        }
    }
}
