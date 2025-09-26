// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileTypeMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 3     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | extension                            | string                       | 1..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="FileTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="FileType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class FileTypeMessagePackFormatter : IMessagePackFormatter<FileType>
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
        /// Serializes an <see cref="FileType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="fileType">
        /// The <see cref="FileType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, FileType fileType, MessagePackSerializerOptions options)
        {
            if (fileType == null)
            {
                throw new ArgumentNullException(nameof(fileType), "The FileType may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(fileType.Iid.ToByteArray());
            writer.Write(fileType.RevisionNumber);

            writer.WriteArrayHeader(fileType.Alias.Count);
            foreach (var identifier in fileType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(fileType.Category.Count);
            foreach (var identifier in fileType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(fileType.Definition.Count);
            foreach (var identifier in fileType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(fileType.Extension);
            writer.WriteArrayHeader(fileType.HyperLink.Count);
            foreach (var identifier in fileType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(fileType.IsDeprecated);
            writer.Write(fileType.Name);
            writer.Write(fileType.ShortName);
            writer.WriteArrayHeader(fileType.ExcludedDomain.Count);
            foreach (var identifier in fileType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(fileType.ExcludedPerson.Count);
            foreach (var identifier in fileType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(fileType.ModifiedOn);
            writer.Write(fileType.ThingPreference);
            if (fileType.Actor.HasValue)
            {
                writer.Write(fileType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="FileType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="FileType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="FileType"/>.
        /// </returns>
        public FileType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var fileType = new FileType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        fileType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        fileType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        fileType.Extension = reader.ReadString();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        fileType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        fileType.Name = reader.ReadString();
                        break;
                    case 9:
                        fileType.ShortName = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            fileType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        fileType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        fileType.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            fileType.Actor = null;
                        }
                        else
                        {
                            fileType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return fileType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
