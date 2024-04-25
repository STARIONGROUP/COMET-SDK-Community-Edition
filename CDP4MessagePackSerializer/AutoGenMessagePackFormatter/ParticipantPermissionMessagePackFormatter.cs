// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantPermissionMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

/* -------------------------------------------- | ---------------------------- | ----------- | ------- *
 | index | name                                 | Type                         | Cardinality | version |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 0     | iid                                  | Guid                         |  1..1       |  1.0.0  |
 | 1     | revisionNumber                       | int                          |  1..1       |  1.0.0  |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 2     | accessRight                          | ParticipantAccessRightKind   | 1..1        |  1.0.0  |
 | 3     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 4     | objectClass                          | ClassKind                    | 1..1        |  1.0.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 8     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 9     | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common;
    using CDP4Common.Comparers;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="ParticipantPermissionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParticipantPermission"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParticipantPermissionMessagePackFormatter : IMessagePackFormatter<ParticipantPermission>
    {
        /// <summary>
        /// The <see cref="GuidComparer"/> used to compare 2 <see cref="Guid"/>s
        /// </summary>
        private static readonly GuidComparer guidComparer = new GuidComparer();

        /// <summary>
        /// The <see cref="OrderedItemComparer"/> used to compare 2 <see cref="OrderedItem"/>s
        /// </summary>
        private static readonly OrderedItemComparer orderedItemComparer = new OrderedItemComparer();

        /// <summary>
        /// Serializes an <see cref="ParticipantPermission"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="participantPermission">
        /// The <see cref="ParticipantPermission"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParticipantPermission participantPermission, MessagePackSerializerOptions options)
        {
            if (participantPermission == null)
            {
                throw new ArgumentNullException(nameof(participantPermission), "The ParticipantPermission may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(participantPermission.Iid.ToByteArray());
            writer.Write(participantPermission.RevisionNumber);

            writer.Write(participantPermission.AccessRight.ToString());
            writer.Write(participantPermission.IsDeprecated);
            writer.Write(participantPermission.ObjectClass.ToString());
            writer.WriteArrayHeader(participantPermission.ExcludedDomain.Count);
            foreach (var identifier in participantPermission.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(participantPermission.ExcludedPerson.Count);
            foreach (var identifier in participantPermission.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participantPermission.ModifiedOn);
            writer.Write(participantPermission.ThingPreference);
            if (participantPermission.Actor.HasValue)
            {
                writer.Write(participantPermission.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParticipantPermission"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParticipantPermission"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParticipantPermission"/>.
        /// </returns>
        public ParticipantPermission Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var participantPermission = new ParticipantPermission();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        participantPermission.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        participantPermission.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        participantPermission.AccessRight = (CDP4Common.CommonData.ParticipantAccessRightKind)Enum.Parse(typeof(CDP4Common.CommonData.ParticipantAccessRightKind), reader.ReadString(), true);
                        break;
                    case 3:
                        participantPermission.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 4:
                        participantPermission.ObjectClass = (CDP4Common.CommonData.ClassKind)Enum.Parse(typeof(CDP4Common.CommonData.ClassKind), reader.ReadString(), true);
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantPermission.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantPermission.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        participantPermission.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        participantPermission.ThingPreference = reader.ReadString();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            participantPermission.Actor = null;
                        }
                        else
                        {
                            participantPermission.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return participantPermission;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
