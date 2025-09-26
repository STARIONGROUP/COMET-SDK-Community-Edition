// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevisionMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | containingFolder                     | Guid                         | 0..1        |  1.0.0  |
 | 3     | contentHash                          | string                       | 1..1        |  1.0.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 5     | creator                              | Guid                         | 1..1        |  1.0.0  |
 | 6     | fileType                             | Guid                         | 1..*        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 11    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 12    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="FileRevisionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="FileRevision"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class FileRevisionMessagePackFormatter : IMessagePackFormatter<FileRevision>
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
        /// Serializes an <see cref="FileRevision"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="fileRevision">
        /// The <see cref="FileRevision"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, FileRevision fileRevision, MessagePackSerializerOptions options)
        {
            if (fileRevision == null)
            {
                throw new ArgumentNullException(nameof(fileRevision), "The FileRevision may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(fileRevision.Iid.ToByteArray());
            writer.Write(fileRevision.RevisionNumber);

            if (fileRevision.ContainingFolder.HasValue)
            {
                writer.Write(fileRevision.ContainingFolder.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(fileRevision.ContentHash);
            writer.Write(fileRevision.CreatedOn);
            writer.Write(fileRevision.Creator.ToByteArray());
            writer.WriteArrayHeader(fileRevision.FileType.Count);
            foreach (var orderedItem in fileRevision.FileType.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.Write(fileRevision.Name);
            writer.WriteArrayHeader(fileRevision.ExcludedDomain.Count);
            foreach (var identifier in fileRevision.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(fileRevision.ExcludedPerson.Count);
            foreach (var identifier in fileRevision.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(fileRevision.ModifiedOn);
            writer.Write(fileRevision.ThingPreference);
            if (fileRevision.Actor.HasValue)
            {
                writer.Write(fileRevision.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="FileRevision"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="FileRevision"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="FileRevision"/>.
        /// </returns>
        public FileRevision Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var fileRevision = new FileRevision();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        fileRevision.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        fileRevision.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            fileRevision.ContainingFolder = null;
                        }
                        else
                        {
                            fileRevision.ContainingFolder = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        fileRevision.ContentHash = reader.ReadString();
                        break;
                    case 4:
                        fileRevision.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        fileRevision.Creator = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            fileRevision.FileType.Add(orderedItem);
                        }
                        break;
                    case 7:
                        fileRevision.Name = reader.ReadString();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileRevision.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileRevision.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        fileRevision.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 11:
                        fileRevision.ThingPreference = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            fileRevision.Actor = null;
                        }
                        else
                        {
                            fileRevision.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return fileRevision;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
