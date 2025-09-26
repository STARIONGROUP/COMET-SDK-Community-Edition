// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFileStoreMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 3     | file                                 | Guid                         | 0..*        |  1.0.0  |
 | 4     | folder                               | Guid                         | 0..*        |  1.0.0  |
 | 5     | name                                 | string                       | 1..1        |  1.0.0  |
 | 6     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 7     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 11    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="CommonFileStoreMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="CommonFileStore"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class CommonFileStoreMessagePackFormatter : IMessagePackFormatter<CommonFileStore>
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
        /// Serializes an <see cref="CommonFileStore"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="commonFileStore">
        /// The <see cref="CommonFileStore"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, CommonFileStore commonFileStore, MessagePackSerializerOptions options)
        {
            if (commonFileStore == null)
            {
                throw new ArgumentNullException(nameof(commonFileStore), "The CommonFileStore may not be null");
            }

            writer.WriteArrayHeader(12);

            writer.Write(commonFileStore.Iid.ToByteArray());
            writer.Write(commonFileStore.RevisionNumber);

            writer.Write(commonFileStore.CreatedOn);
            writer.WriteArrayHeader(commonFileStore.File.Count);
            foreach (var identifier in commonFileStore.File.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(commonFileStore.Folder.Count);
            foreach (var identifier in commonFileStore.Folder.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(commonFileStore.Name);
            writer.Write(commonFileStore.Owner.ToByteArray());
            writer.WriteArrayHeader(commonFileStore.ExcludedDomain.Count);
            foreach (var identifier in commonFileStore.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(commonFileStore.ExcludedPerson.Count);
            foreach (var identifier in commonFileStore.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(commonFileStore.ModifiedOn);
            writer.Write(commonFileStore.ThingPreference);
            if (commonFileStore.Actor.HasValue)
            {
                writer.Write(commonFileStore.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="CommonFileStore"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="CommonFileStore"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="CommonFileStore"/>.
        /// </returns>
        public CommonFileStore Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var commonFileStore = new CommonFileStore();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        commonFileStore.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        commonFileStore.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        commonFileStore.CreatedOn = reader.ReadDateTime();
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            commonFileStore.File.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            commonFileStore.Folder.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        commonFileStore.Name = reader.ReadString();
                        break;
                    case 6:
                        commonFileStore.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            commonFileStore.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            commonFileStore.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        commonFileStore.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        commonFileStore.ThingPreference = reader.ReadString();
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            commonFileStore.Actor = null;
                        }
                        else
                        {
                            commonFileStore.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return commonFileStore;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
