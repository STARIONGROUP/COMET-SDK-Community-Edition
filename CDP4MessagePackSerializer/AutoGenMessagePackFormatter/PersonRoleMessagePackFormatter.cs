// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonRoleMessagePackFormatter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
 | 7     | personPermission                     | Guid                         | 0..*        |  1.0.0  |
 | 8     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 12    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 13    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 14    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="PersonRoleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="PersonRole"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class PersonRoleMessagePackFormatter : IMessagePackFormatter<PersonRole>
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
        /// Serializes an <see cref="PersonRole"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="personRole">
        /// The <see cref="PersonRole"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, PersonRole personRole, MessagePackSerializerOptions options)
        {
            if (personRole == null)
            {
                throw new ArgumentNullException(nameof(personRole), "The PersonRole may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(personRole.Iid.ToByteArray());
            writer.Write(personRole.RevisionNumber);

            writer.WriteArrayHeader(personRole.Alias.Count);
            foreach (var identifier in personRole.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(personRole.Definition.Count);
            foreach (var identifier in personRole.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(personRole.HyperLink.Count);
            foreach (var identifier in personRole.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(personRole.IsDeprecated);
            writer.Write(personRole.Name);
            writer.WriteArrayHeader(personRole.PersonPermission.Count);
            foreach (var identifier in personRole.PersonPermission.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(personRole.ShortName);
            writer.WriteArrayHeader(personRole.ExcludedDomain.Count);
            foreach (var identifier in personRole.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(personRole.ExcludedPerson.Count);
            foreach (var identifier in personRole.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(personRole.ModifiedOn);
            writer.Write(personRole.ThingPreference);
            if (personRole.Actor.HasValue)
            {
                writer.Write(personRole.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(personRole.Attachment.Count);
            foreach (var identifier in personRole.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="PersonRole"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="PersonRole"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="PersonRole"/>.
        /// </returns>
        public PersonRole Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var personRole = new PersonRole();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        personRole.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        personRole.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        personRole.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 6:
                        personRole.Name = reader.ReadString();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.PersonPermission.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        personRole.ShortName = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        personRole.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        personRole.ThingPreference = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            personRole.Actor = null;
                        }
                        else
                        {
                            personRole.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            personRole.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return personRole;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
