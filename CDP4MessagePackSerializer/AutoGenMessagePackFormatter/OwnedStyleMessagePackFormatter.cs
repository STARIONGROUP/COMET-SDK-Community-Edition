// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyleMessagePackFormatter.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="OwnedStyleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="OwnedStyle"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class OwnedStyleMessagePackFormatter : IMessagePackFormatter<OwnedStyle>
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
        /// Serializes an <see cref="OwnedStyle"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="ownedStyle">
        /// The <see cref="OwnedStyle"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, OwnedStyle ownedStyle, MessagePackSerializerOptions options)
        {
            if (ownedStyle == null)
            {
                throw new ArgumentNullException(nameof(ownedStyle), "The OwnedStyle may not be null");
            }

            writer.WriteArrayHeader(21);

            writer.Write(ownedStyle.Iid.ToByteArray());
            writer.Write(ownedStyle.RevisionNumber);

            writer.WriteArrayHeader(ownedStyle.ExcludedDomain.Count);
            foreach (var identifier in ownedStyle.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ownedStyle.ExcludedPerson.Count);
            foreach (var identifier in ownedStyle.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (ownedStyle.FillColor.HasValue)
            {
                writer.Write(ownedStyle.FillColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FillOpacity.HasValue)
            {
                writer.Write(ownedStyle.FillOpacity.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FontBold.HasValue)
            {
                writer.Write(ownedStyle.FontBold.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FontColor.HasValue)
            {
                writer.Write(ownedStyle.FontColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FontItalic.HasValue)
            {
                writer.Write(ownedStyle.FontItalic.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(ownedStyle.FontName);
            if (ownedStyle.FontSize.HasValue)
            {
                writer.Write(ownedStyle.FontSize.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FontStrokeThrough.HasValue)
            {
                writer.Write(ownedStyle.FontStrokeThrough.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.FontUnderline.HasValue)
            {
                writer.Write(ownedStyle.FontUnderline.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(ownedStyle.ModifiedOn);
            writer.Write(ownedStyle.Name);
            if (ownedStyle.StrokeColor.HasValue)
            {
                writer.Write(ownedStyle.StrokeColor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.StrokeOpacity.HasValue)
            {
                writer.Write(ownedStyle.StrokeOpacity.Value);
            }
            else
            {
                writer.WriteNil();
            }
            if (ownedStyle.StrokeWidth.HasValue)
            {
                writer.Write(ownedStyle.StrokeWidth.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(ownedStyle.UsedColor.Count);
            foreach (var identifier in ownedStyle.UsedColor.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(ownedStyle.ThingPreference);
            if (ownedStyle.Actor.HasValue)
            {
                writer.Write(ownedStyle.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="OwnedStyle"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="OwnedStyle"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="OwnedStyle"/>.
        /// </returns>
        public OwnedStyle Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var ownedStyle = new OwnedStyle();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        ownedStyle.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        ownedStyle.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ownedStyle.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ownedStyle.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.FillColor = null;
                        }
                        else
                        {
                            ownedStyle.FillColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.FillOpacity = null;
                        }
                        else
                        {
                            ownedStyle.FillOpacity = reader.ReadSingle();
                        }
                        break;
                    case 6:
                        ownedStyle.FontBold = reader.ReadBoolean();
                        break;
                    case 7:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.FontColor = null;
                        }
                        else
                        {
                            ownedStyle.FontColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 8:
                        ownedStyle.FontItalic = reader.ReadBoolean();
                        break;
                    case 9:
                        ownedStyle.FontName = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.FontSize = null;
                        }
                        else
                        {
                            ownedStyle.FontSize = reader.ReadSingle();
                        }
                        break;
                    case 11:
                        ownedStyle.FontStrokeThrough = reader.ReadBoolean();
                        break;
                    case 12:
                        ownedStyle.FontUnderline = reader.ReadBoolean();
                        break;
                    case 13:
                        ownedStyle.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        ownedStyle.Name = reader.ReadString();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.StrokeColor = null;
                        }
                        else
                        {
                            ownedStyle.StrokeColor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.StrokeOpacity = null;
                        }
                        else
                        {
                            ownedStyle.StrokeOpacity = reader.ReadSingle();
                        }
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.StrokeWidth = null;
                        }
                        else
                        {
                            ownedStyle.StrokeWidth = reader.ReadSingle();
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ownedStyle.UsedColor.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        ownedStyle.ThingPreference = reader.ReadString();
                        break;
                    case 20:
                        if (reader.TryReadNil())
                        {
                            ownedStyle.Actor = null;
                        }
                        else
                        {
                            ownedStyle.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return ownedStyle;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
