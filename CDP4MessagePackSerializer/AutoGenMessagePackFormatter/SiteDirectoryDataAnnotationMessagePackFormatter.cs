// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryDataAnnotationMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 3     | content                              | string                       | 1..1        |  1.1.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 5     | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | primaryAnnotatedThing                | Guid                         | 1..1        |  1.1.0  |
 | 11    | relatedThing                         | Guid                         | 1..*        |  1.1.0  |
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
    /// The purpose of the <see cref="SiteDirectoryDataAnnotationMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SiteDirectoryDataAnnotation"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class SiteDirectoryDataAnnotationMessagePackFormatter : IMessagePackFormatter<SiteDirectoryDataAnnotation>
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
        /// Serializes an <see cref="SiteDirectoryDataAnnotation"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="siteDirectoryDataAnnotation">
        /// The <see cref="SiteDirectoryDataAnnotation"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SiteDirectoryDataAnnotation siteDirectoryDataAnnotation, MessagePackSerializerOptions options)
        {
            if (siteDirectoryDataAnnotation == null)
            {
                throw new ArgumentNullException(nameof(siteDirectoryDataAnnotation), "The SiteDirectoryDataAnnotation may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(siteDirectoryDataAnnotation.Iid.ToByteArray());
            writer.Write(siteDirectoryDataAnnotation.RevisionNumber);

            writer.Write(siteDirectoryDataAnnotation.Author.ToByteArray());
            writer.Write(siteDirectoryDataAnnotation.Content);
            writer.Write(siteDirectoryDataAnnotation.CreatedOn);
            writer.WriteArrayHeader(siteDirectoryDataAnnotation.Discussion.Count);
            foreach (var identifier in siteDirectoryDataAnnotation.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectoryDataAnnotation.ExcludedDomain.Count);
            foreach (var identifier in siteDirectoryDataAnnotation.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectoryDataAnnotation.ExcludedPerson.Count);
            foreach (var identifier in siteDirectoryDataAnnotation.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectoryDataAnnotation.LanguageCode);
            writer.Write(siteDirectoryDataAnnotation.ModifiedOn);
            writer.Write(siteDirectoryDataAnnotation.PrimaryAnnotatedThing.ToByteArray());
            writer.WriteArrayHeader(siteDirectoryDataAnnotation.RelatedThing.Count);
            foreach (var identifier in siteDirectoryDataAnnotation.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectoryDataAnnotation.ThingPreference);
            if (siteDirectoryDataAnnotation.Actor.HasValue)
            {
                writer.Write(siteDirectoryDataAnnotation.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SiteDirectoryDataAnnotation"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SiteDirectoryDataAnnotation"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SiteDirectoryDataAnnotation"/>.
        /// </returns>
        public SiteDirectoryDataAnnotation Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var siteDirectoryDataAnnotation = new SiteDirectoryDataAnnotation();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        siteDirectoryDataAnnotation.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        siteDirectoryDataAnnotation.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        siteDirectoryDataAnnotation.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        siteDirectoryDataAnnotation.Content = reader.ReadString();
                        break;
                    case 4:
                        siteDirectoryDataAnnotation.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataAnnotation.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataAnnotation.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataAnnotation.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        siteDirectoryDataAnnotation.LanguageCode = reader.ReadString();
                        break;
                    case 9:
                        siteDirectoryDataAnnotation.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        siteDirectoryDataAnnotation.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataAnnotation.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        siteDirectoryDataAnnotation.ThingPreference = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            siteDirectoryDataAnnotation.Actor = null;
                        }
                        else
                        {
                            siteDirectoryDataAnnotation.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return siteDirectoryDataAnnotation;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
