// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextualNoteMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 3     | content                              | string                       | 1..1        |  1.1.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | name                                 | string                       | 1..1        |  1.1.0  |
 | 10    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 11    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 12    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="TextualNoteMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="TextualNote"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class TextualNoteMessagePackFormatter : IMessagePackFormatter<TextualNote>
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
        /// Serializes an <see cref="TextualNote"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="textualNote">
        /// The <see cref="TextualNote"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, TextualNote textualNote, MessagePackSerializerOptions options)
        {
            if (textualNote == null)
            {
                throw new ArgumentNullException(nameof(textualNote), "The TextualNote may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(textualNote.Iid.ToByteArray());
            writer.Write(textualNote.RevisionNumber);

            writer.WriteArrayHeader(textualNote.Category.Count);
            foreach (var identifier in textualNote.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(textualNote.Content);
            writer.Write(textualNote.CreatedOn);
            writer.WriteArrayHeader(textualNote.ExcludedDomain.Count);
            foreach (var identifier in textualNote.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(textualNote.ExcludedPerson.Count);
            foreach (var identifier in textualNote.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(textualNote.LanguageCode);
            writer.Write(textualNote.ModifiedOn);
            writer.Write(textualNote.Name);
            writer.Write(textualNote.Owner.ToByteArray());
            writer.Write(textualNote.ShortName);
            writer.Write(textualNote.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="TextualNote"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="TextualNote"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="TextualNote"/>.
        /// </returns>
        public TextualNote Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var textualNote = new TextualNote();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        textualNote.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        textualNote.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            textualNote.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        textualNote.Content = reader.ReadString();
                        break;
                    case 4:
                        textualNote.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            textualNote.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            textualNote.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        textualNote.LanguageCode = reader.ReadString();
                        break;
                    case 8:
                        textualNote.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        textualNote.Name = reader.ReadString();
                        break;
                    case 10:
                        textualNote.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 11:
                        textualNote.ShortName = reader.ReadString();
                        break;
                    case 12:
                        textualNote.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return textualNote;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
