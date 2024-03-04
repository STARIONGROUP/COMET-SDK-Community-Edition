// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataNoteMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 3     | content                              | string                       | 1..1        |  1.1.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 5     | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 11    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
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
    /// The purpose of the <see cref="EngineeringModelDataNoteMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="EngineeringModelDataNote"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class EngineeringModelDataNoteMessagePackFormatter : IMessagePackFormatter<EngineeringModelDataNote>
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
        /// Serializes an <see cref="EngineeringModelDataNote"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="engineeringModelDataNote">
        /// The <see cref="EngineeringModelDataNote"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, EngineeringModelDataNote engineeringModelDataNote, MessagePackSerializerOptions options)
        {
            if (engineeringModelDataNote == null)
            {
                throw new ArgumentNullException(nameof(engineeringModelDataNote), "The EngineeringModelDataNote may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(engineeringModelDataNote.Iid.ToByteArray());
            writer.Write(engineeringModelDataNote.RevisionNumber);

            writer.Write(engineeringModelDataNote.Author.ToByteArray());
            writer.Write(engineeringModelDataNote.Content);
            writer.Write(engineeringModelDataNote.CreatedOn);
            writer.WriteArrayHeader(engineeringModelDataNote.Discussion.Count);
            foreach (var identifier in engineeringModelDataNote.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelDataNote.ExcludedDomain.Count);
            foreach (var identifier in engineeringModelDataNote.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelDataNote.ExcludedPerson.Count);
            foreach (var identifier in engineeringModelDataNote.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelDataNote.LanguageCode);
            writer.Write(engineeringModelDataNote.ModifiedOn);
            if (engineeringModelDataNote.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(engineeringModelDataNote.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(engineeringModelDataNote.RelatedThing.Count);
            foreach (var identifier in engineeringModelDataNote.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelDataNote.ThingPreference);
            if (engineeringModelDataNote.Actor.HasValue)
            {
                writer.Write(engineeringModelDataNote.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="EngineeringModelDataNote"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="EngineeringModelDataNote"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="EngineeringModelDataNote"/>.
        /// </returns>
        public EngineeringModelDataNote Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var engineeringModelDataNote = new EngineeringModelDataNote();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        engineeringModelDataNote.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        engineeringModelDataNote.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        engineeringModelDataNote.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        engineeringModelDataNote.Content = reader.ReadString();
                        break;
                    case 4:
                        engineeringModelDataNote.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelDataNote.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelDataNote.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelDataNote.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        engineeringModelDataNote.LanguageCode = reader.ReadString();
                        break;
                    case 9:
                        engineeringModelDataNote.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            engineeringModelDataNote.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            engineeringModelDataNote.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelDataNote.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        engineeringModelDataNote.ThingPreference = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            engineeringModelDataNote.Actor = null;
                        }
                        else
                        {
                            engineeringModelDataNote.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return engineeringModelDataNote;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
