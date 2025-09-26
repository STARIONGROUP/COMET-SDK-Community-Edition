// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRoleMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 5     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 6     | name                                 | string                       | 1..1        |  1.0.0  |
 | 7     | participantPermission                | Guid                         | 0..*        |  1.0.0  |
 | 8     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 12    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 13    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ParticipantRoleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParticipantRole"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParticipantRoleMessagePackFormatter : IMessagePackFormatter<ParticipantRole>
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
        /// Serializes an <see cref="ParticipantRole"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="participantRole">
        /// The <see cref="ParticipantRole"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParticipantRole participantRole, MessagePackSerializerOptions options)
        {
            if (participantRole == null)
            {
                throw new ArgumentNullException(nameof(participantRole), "The ParticipantRole may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(participantRole.Iid.ToByteArray());
            writer.Write(participantRole.RevisionNumber);

            writer.WriteArrayHeader(participantRole.Alias.Count);
            foreach (var identifier in participantRole.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(participantRole.Definition.Count);
            foreach (var identifier in participantRole.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(participantRole.HyperLink.Count);
            foreach (var identifier in participantRole.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participantRole.IsDeprecated);
            writer.Write(participantRole.Name);
            writer.WriteArrayHeader(participantRole.ParticipantPermission.Count);
            foreach (var identifier in participantRole.ParticipantPermission.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participantRole.ShortName);
            writer.WriteArrayHeader(participantRole.ExcludedDomain.Count);
            foreach (var identifier in participantRole.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(participantRole.ExcludedPerson.Count);
            foreach (var identifier in participantRole.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participantRole.ModifiedOn);
            writer.Write(participantRole.ThingPreference);
            if (participantRole.Actor.HasValue)
            {
                writer.Write(participantRole.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParticipantRole"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParticipantRole"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParticipantRole"/>.
        /// </returns>
        public ParticipantRole Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var participantRole = new ParticipantRole();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        participantRole.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        participantRole.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        participantRole.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 6:
                        participantRole.Name = reader.ReadString();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.ParticipantPermission.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        participantRole.ShortName = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participantRole.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        participantRole.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        participantRole.ThingPreference = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            participantRole.Actor = null;
                        }
                        else
                        {
                            participantRole.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return participantRole;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
