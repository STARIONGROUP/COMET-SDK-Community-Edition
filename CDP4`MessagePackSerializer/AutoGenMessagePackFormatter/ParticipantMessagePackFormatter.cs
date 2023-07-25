// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantMessagePackFormatter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
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
 | 2     | domain                               | Guid                         | 1..*        |  1.0.0  |
 | 3     | isActive                             | bool                         | 1..1        |  1.0.0  |
 | 4     | person                               | Guid                         | 1..1        |  1.0.0  |
 | 5     | role                                 | Guid                         | 1..1        |  1.0.0  |
 | 6     | selectedDomain                       | Guid                         | 1..1        |  1.0.0  |
 | 7     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="ParticipantMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Participant"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParticipantMessagePackFormatter : IMessagePackFormatter<Participant>
    {
        /// <summary>
        /// Serializes an <see cref="Participant"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="participant">
        /// The <see cref="Participant"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Participant participant, MessagePackSerializerOptions options)
        {
            if (participant == null)
            {
                throw new ArgumentNullException(nameof(participant), "The Participant may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(participant.Iid.ToByteArray());
            writer.Write(participant.RevisionNumber);

            writer.WriteArrayHeader(participant.Domain.Count);
            foreach (var identifier in participant.Domain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participant.IsActive);
            writer.Write(participant.Person.ToByteArray());
            writer.Write(participant.Role.ToByteArray());
            writer.Write(participant.SelectedDomain.ToByteArray());
            writer.WriteArrayHeader(participant.ExcludedDomain.Count);
            foreach (var identifier in participant.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(participant.ExcludedPerson.Count);
            foreach (var identifier in participant.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(participant.ModifiedOn);
            writer.Write(participant.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Participant"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Participant"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Participant"/>.
        /// </returns>
        public Participant Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var participant = new Participant();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        participant.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        participant.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participant.Domain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        participant.IsActive = reader.ReadBoolean();
                        break;
                    case 4:
                        participant.Person = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        participant.Role = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        participant.SelectedDomain = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participant.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            participant.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        participant.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        participant.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return participant;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
