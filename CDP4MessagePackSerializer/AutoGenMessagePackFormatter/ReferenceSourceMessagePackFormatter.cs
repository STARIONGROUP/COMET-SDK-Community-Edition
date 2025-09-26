// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSourceMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 3     | author                               | string                       | 0..1        |  1.0.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | language                             | string                       | 0..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | publicationYear                      | int                          | 0..1        |  1.0.0  |
 | 11    | publishedIn                          | Guid                         | 0..1        |  1.0.0  |
 | 12    | publisher                            | Guid                         | 0..1        |  1.0.0  |
 | 13    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 14    | versionDate                          | DateTime                     | 0..1        |  1.0.0  |
 | 15    | versionIdentifier                    | string                       | 0..1        |  1.0.0  |
 | 16    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 17    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 18    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 19    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 20    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ReferenceSourceMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ReferenceSource"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ReferenceSourceMessagePackFormatter : IMessagePackFormatter<ReferenceSource>
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
        /// Serializes an <see cref="ReferenceSource"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="referenceSource">
        /// The <see cref="ReferenceSource"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ReferenceSource referenceSource, MessagePackSerializerOptions options)
        {
            if (referenceSource == null)
            {
                throw new ArgumentNullException(nameof(referenceSource), "The ReferenceSource may not be null");
            }

            writer.WriteArrayHeader(21);

            writer.Write(referenceSource.Iid.ToByteArray());
            writer.Write(referenceSource.RevisionNumber);

            writer.WriteArrayHeader(referenceSource.Alias.Count);
            foreach (var identifier in referenceSource.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referenceSource.Author);
            writer.WriteArrayHeader(referenceSource.Category.Count);
            foreach (var identifier in referenceSource.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referenceSource.Definition.Count);
            foreach (var identifier in referenceSource.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referenceSource.HyperLink.Count);
            foreach (var identifier in referenceSource.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referenceSource.IsDeprecated);
            writer.Write(referenceSource.Language);
            writer.Write(referenceSource.Name);
            if (referenceSource.PublicationYear.HasValue)
            {
                writer.Write(referenceSource.PublicationYear.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (referenceSource.PublishedIn.HasValue)
            {
                writer.Write(referenceSource.PublishedIn.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (referenceSource.Publisher.HasValue)
            {
                writer.Write(referenceSource.Publisher.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(referenceSource.ShortName);
            if (referenceSource.VersionDate.HasValue)
            {
                writer.Write(referenceSource.VersionDate.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(referenceSource.VersionIdentifier);
            writer.WriteArrayHeader(referenceSource.ExcludedDomain.Count);
            foreach (var identifier in referenceSource.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referenceSource.ExcludedPerson.Count);
            foreach (var identifier in referenceSource.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referenceSource.ModifiedOn);
            writer.Write(referenceSource.ThingPreference);
            if (referenceSource.Actor.HasValue)
            {
                writer.Write(referenceSource.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ReferenceSource"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ReferenceSource"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ReferenceSource"/>.
        /// </returns>
        public ReferenceSource Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var referenceSource = new ReferenceSource();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        referenceSource.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        referenceSource.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        referenceSource.Author = reader.ReadString();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        referenceSource.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        referenceSource.Language = reader.ReadString();
                        break;
                    case 9:
                        referenceSource.Name = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            referenceSource.PublicationYear = null;
                        }
                        else
                        {
                            referenceSource.PublicationYear = reader.ReadInt32();
                        }
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            referenceSource.PublishedIn = null;
                        }
                        else
                        {
                            referenceSource.PublishedIn = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            referenceSource.Publisher = null;
                        }
                        else
                        {
                            referenceSource.Publisher = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 13:
                        referenceSource.ShortName = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            referenceSource.VersionDate = null;
                        }
                        else
                        {
                            referenceSource.VersionDate = reader.ReadDateTime();
                        }
                        break;
                    case 15:
                        referenceSource.VersionIdentifier = reader.ReadString();
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referenceSource.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        referenceSource.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 19:
                        referenceSource.ThingPreference = reader.ReadString();
                        break;
                    case 20:
                        if (reader.TryReadNil())
                        {
                            referenceSource.Actor = null;
                        }
                        else
                        {
                            referenceSource.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return referenceSource;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
