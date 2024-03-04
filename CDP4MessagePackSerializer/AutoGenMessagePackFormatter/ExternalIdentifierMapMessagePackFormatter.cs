// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalIdentifierMapMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | correspondence                       | Guid                         | 0..*        |  1.0.0  |
 | 3     | externalFormat                       | Guid                         | 0..1        |  1.0.0  |
 | 4     | externalModelName                    | string                       | 1..1        |  1.0.0  |
 | 5     | externalToolName                     | string                       | 1..1        |  1.0.0  |
 | 6     | externalToolVersion                  | string                       | 0..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | owner                                | Guid                         | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ExternalIdentifierMapMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ExternalIdentifierMap"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ExternalIdentifierMapMessagePackFormatter : IMessagePackFormatter<ExternalIdentifierMap>
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
        /// Serializes an <see cref="ExternalIdentifierMap"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="externalIdentifierMap">
        /// The <see cref="ExternalIdentifierMap"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ExternalIdentifierMap externalIdentifierMap, MessagePackSerializerOptions options)
        {
            if (externalIdentifierMap == null)
            {
                throw new ArgumentNullException(nameof(externalIdentifierMap), "The ExternalIdentifierMap may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(externalIdentifierMap.Iid.ToByteArray());
            writer.Write(externalIdentifierMap.RevisionNumber);

            writer.WriteArrayHeader(externalIdentifierMap.Correspondence.Count);
            foreach (var identifier in externalIdentifierMap.Correspondence.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (externalIdentifierMap.ExternalFormat.HasValue)
            {
                writer.Write(externalIdentifierMap.ExternalFormat.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(externalIdentifierMap.ExternalModelName);
            writer.Write(externalIdentifierMap.ExternalToolName);
            writer.Write(externalIdentifierMap.ExternalToolVersion);
            writer.Write(externalIdentifierMap.Name);
            writer.Write(externalIdentifierMap.Owner.ToByteArray());
            writer.WriteArrayHeader(externalIdentifierMap.ExcludedDomain.Count);
            foreach (var identifier in externalIdentifierMap.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(externalIdentifierMap.ExcludedPerson.Count);
            foreach (var identifier in externalIdentifierMap.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(externalIdentifierMap.ModifiedOn);
            writer.Write(externalIdentifierMap.ThingPreference);
            if (externalIdentifierMap.Actor.HasValue)
            {
                writer.Write(externalIdentifierMap.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ExternalIdentifierMap"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ExternalIdentifierMap"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ExternalIdentifierMap"/>.
        /// </returns>
        public ExternalIdentifierMap Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var externalIdentifierMap = new ExternalIdentifierMap();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        externalIdentifierMap.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        externalIdentifierMap.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            externalIdentifierMap.Correspondence.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            externalIdentifierMap.ExternalFormat = null;
                        }
                        else
                        {
                            externalIdentifierMap.ExternalFormat = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        externalIdentifierMap.ExternalModelName = reader.ReadString();
                        break;
                    case 5:
                        externalIdentifierMap.ExternalToolName = reader.ReadString();
                        break;
                    case 6:
                        externalIdentifierMap.ExternalToolVersion = reader.ReadString();
                        break;
                    case 7:
                        externalIdentifierMap.Name = reader.ReadString();
                        break;
                    case 8:
                        externalIdentifierMap.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            externalIdentifierMap.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            externalIdentifierMap.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        externalIdentifierMap.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        externalIdentifierMap.ThingPreference = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            externalIdentifierMap.Actor = null;
                        }
                        else
                        {
                            externalIdentifierMap.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return externalIdentifierMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
