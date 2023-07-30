// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | containingFolder                     | Guid                         | 0..1        |  1.0.0  |
 | 3     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 4     | creator                              | Guid                         | 1..1        |  1.0.0  |
 | 5     | name                                 | string                       | 1..1        |  1.0.0  |
 | 6     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 7     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="FolderMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Folder"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class FolderMessagePackFormatter : IMessagePackFormatter<Folder>
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
        /// Serializes an <see cref="Folder"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="folder">
        /// The <see cref="Folder"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Folder folder, MessagePackSerializerOptions options)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder), "The Folder may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(folder.Iid.ToByteArray());
            writer.Write(folder.RevisionNumber);

            if (folder.ContainingFolder.HasValue)
            {
                writer.Write(folder.ContainingFolder.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(folder.CreatedOn);
            writer.Write(folder.Creator.ToByteArray());
            writer.Write(folder.Name);
            writer.Write(folder.Owner.ToByteArray());
            writer.WriteArrayHeader(folder.ExcludedDomain.Count);
            foreach (var identifier in folder.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(folder.ExcludedPerson.Count);
            foreach (var identifier in folder.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(folder.ModifiedOn);
            writer.Write(folder.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Folder"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Folder"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Folder"/>.
        /// </returns>
        public Folder Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var folder = new Folder();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        folder.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        folder.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            folder.ContainingFolder = null;
                        }
                        else
                        {
                            folder.ContainingFolder = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        folder.CreatedOn = reader.ReadDateTime();
                        break;
                    case 4:
                        folder.Creator = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        folder.Name = reader.ReadString();
                        break;
                    case 6:
                        folder.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            folder.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            folder.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        folder.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        folder.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return folder;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
