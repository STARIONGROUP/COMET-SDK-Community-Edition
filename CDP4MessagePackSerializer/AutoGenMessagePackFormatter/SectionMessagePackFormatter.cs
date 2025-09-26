// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 3     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 4     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 7     | name                                 | string                       | 1..1        |  1.1.0  |
 | 8     | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 9     | page                                 | Guid                         | 0..*        |  1.1.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.1.0  |
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
    /// The purpose of the <see cref="SectionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Section"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class SectionMessagePackFormatter : IMessagePackFormatter<Section>
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
        /// Serializes an <see cref="Section"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="section">
        /// The <see cref="Section"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Section section, MessagePackSerializerOptions options)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section), "The Section may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(section.Iid.ToByteArray());
            writer.Write(section.RevisionNumber);

            writer.WriteArrayHeader(section.Category.Count);
            foreach (var identifier in section.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(section.CreatedOn);
            writer.WriteArrayHeader(section.ExcludedDomain.Count);
            foreach (var identifier in section.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(section.ExcludedPerson.Count);
            foreach (var identifier in section.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(section.ModifiedOn);
            writer.Write(section.Name);
            writer.Write(section.Owner.ToByteArray());
            writer.WriteArrayHeader(section.Page.Count);
            foreach (var orderedItem in section.Page.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.Write(section.ShortName);
            writer.Write(section.ThingPreference);
            if (section.Actor.HasValue)
            {
                writer.Write(section.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Section"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Section"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Section"/>.
        /// </returns>
        public Section Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var section = new Section();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        section.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        section.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            section.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        section.CreatedOn = reader.ReadDateTime();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            section.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            section.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        section.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 7:
                        section.Name = reader.ReadString();
                        break;
                    case 8:
                        section.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            section.Page.Add(orderedItem);
                        }
                        break;
                    case 10:
                        section.ShortName = reader.ReadString();
                        break;
                    case 11:
                        section.ThingPreference = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            section.Actor = null;
                        }
                        else
                        {
                            section.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return section;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
