// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | fillColor                            | Guid                         | 0..1        |  1.1.0  |
 | 5     | fillOpacity                          | float                        | 0..1        |  1.1.0  |
 | 6     | fontBold                             | bool                         | 0..1        |  1.1.0  |
 | 7     | fontColor                            | Guid                         | 0..1        |  1.1.0  |
 | 8     | fontItalic                           | bool                         | 0..1        |  1.1.0  |
 | 9     | fontName                             | string                       | 0..1        |  1.1.0  |
 | 10    | fontSize                             | float                        | 0..1        |  1.1.0  |
 | 11    | fontStrokeThrough                    | bool                         | 0..1        |  1.1.0  |
 | 12    | fontUnderline                        | bool                         | 0..1        |  1.1.0  |
 | 13    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 14    | name                                 | string                       | 1..1        |  1.1.0  |
 | 15    | strokeColor                          | Guid                         | 0..1        |  1.1.0  |
 | 16    | strokeOpacity                        | float                        | 0..1        |  1.1.0  |
 | 17    | strokeWidth                          | float                        | 0..1        |  1.1.0  |
 | 18    | usedColor                            | Guid                         | 0..*        |  1.1.0  |
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
    /// The purpose of the <see cref="SharedStyleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SharedStyle"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class SharedStyleMessagePackFormatter : IMessagePackFormatter<SharedStyle>
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
        /// Serializes an <see cref="SharedStyle"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="sharedStyle">
        /// The <see cref="SharedStyle"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SharedStyle sharedStyle, MessagePackSerializerOptions options)
        {
            if (sharedStyle == null)
            {
                throw new ArgumentNullException(nameof(sharedStyle), "The SharedStyle may not be null");
            }

            writer.WriteArrayHeader(21);

            writer.Write(sharedStyle.Iid.ToByteArray());
            writer.Write(sharedStyle.RevisionNumber);

            writer.WriteArrayHeader(sharedStyle.ExcludedDomain.Count);
            foreach (var identifier in sharedStyle.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(sharedStyle.ExcludedPerson.Count);
            foreach (var identifier in sharedStyle.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (sharedStyle.FillColor.HasValue)
            {
                writer.Write(sharedStyle.FillColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FillOpacity.HasValue)
            {
                writer.Write(sharedStyle.FillOpacity.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FontBold.HasValue)
            {
                writer.Write(sharedStyle.FontBold.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FontColor.HasValue)
            {
                writer.Write(sharedStyle.FontColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FontItalic.HasValue)
            {
                writer.Write(sharedStyle.FontItalic.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(sharedStyle.FontName);
            if (sharedStyle.FontSize.HasValue)
            {
                writer.Write(sharedStyle.FontSize.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FontStrokeThrough.HasValue)
            {
                writer.Write(sharedStyle.FontStrokeThrough.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.FontUnderline.HasValue)
            {
                writer.Write(sharedStyle.FontUnderline.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(sharedStyle.ModifiedOn);
            writer.Write(sharedStyle.Name);
            if (sharedStyle.StrokeColor.HasValue)
            {
                writer.Write(sharedStyle.StrokeColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.StrokeOpacity.HasValue)
            {
                writer.Write(sharedStyle.StrokeOpacity.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (sharedStyle.StrokeWidth.HasValue)
            {
                writer.Write(sharedStyle.StrokeWidth.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(sharedStyle.UsedColor.Count);
            foreach (var identifier in sharedStyle.UsedColor.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(sharedStyle.ThingPreference);
            if (sharedStyle.Actor.HasValue)
            {
                writer.Write(sharedStyle.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SharedStyle"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SharedStyle"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SharedStyle"/>.
        /// </returns>
        public SharedStyle Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var sharedStyle = new SharedStyle();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        sharedStyle.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        sharedStyle.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sharedStyle.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sharedStyle.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.FillColor = null;
                        }
                        else
                        {
                            sharedStyle.FillColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.FillOpacity = null;
                        }
                        else
                        {
                            sharedStyle.FillOpacity = reader.ReadSingle();
                        }
                        break;
                    case 6:
                        sharedStyle.FontBold = reader.ReadBoolean();
                        break;
                    case 7:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.FontColor = null;
                        }
                        else
                        {
                            sharedStyle.FontColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 8:
                        sharedStyle.FontItalic = reader.ReadBoolean();
                        break;
                    case 9:
                        sharedStyle.FontName = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.FontSize = null;
                        }
                        else
                        {
                            sharedStyle.FontSize = reader.ReadSingle();
                        }
                        break;
                    case 11:
                        sharedStyle.FontStrokeThrough = reader.ReadBoolean();
                        break;
                    case 12:
                        sharedStyle.FontUnderline = reader.ReadBoolean();
                        break;
                    case 13:
                        sharedStyle.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        sharedStyle.Name = reader.ReadString();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.StrokeColor = null;
                        }
                        else
                        {
                            sharedStyle.StrokeColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.StrokeOpacity = null;
                        }
                        else
                        {
                            sharedStyle.StrokeOpacity = reader.ReadSingle();
                        }
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.StrokeWidth = null;
                        }
                        else
                        {
                            sharedStyle.StrokeWidth = reader.ReadSingle();
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sharedStyle.UsedColor.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        sharedStyle.ThingPreference = reader.ReadString();
                        break;
                    case 20:
                        if (reader.TryReadNil())
                        {
                            sharedStyle.Actor = null;
                        }
                        else
                        {
                            sharedStyle.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return sharedStyle;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
