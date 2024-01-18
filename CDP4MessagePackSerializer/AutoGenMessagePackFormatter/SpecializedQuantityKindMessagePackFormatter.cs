// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecializedQuantityKindMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | attachment                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | defaultScale                         | Guid                         | 1..1        |  1.0.0  |
 | 6     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 7     | general                              | Guid                         | 1..1        |  1.0.0  |
 | 8     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 9     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 10    | name                                 | string                       | 1..1        |  1.0.0  |
 | 11    | possibleScale                        | Guid                         | 0..*        |  1.0.0  |
 | 12    | quantityDimensionSymbol              | string                       | 0..1        |  1.0.0  |
 | 13    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 14    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 15    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 17    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 18    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 19    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="SpecializedQuantityKindMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SpecializedQuantityKind"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SpecializedQuantityKindMessagePackFormatter : IMessagePackFormatter<SpecializedQuantityKind>
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
        /// Serializes an <see cref="SpecializedQuantityKind"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="specializedQuantityKind">
        /// The <see cref="SpecializedQuantityKind"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SpecializedQuantityKind specializedQuantityKind, MessagePackSerializerOptions options)
        {
            if (specializedQuantityKind == null)
            {
                throw new ArgumentNullException(nameof(specializedQuantityKind), "The SpecializedQuantityKind may not be null");
            }

            writer.WriteArrayHeader(20);

            writer.Write(specializedQuantityKind.Iid.ToByteArray());
            writer.Write(specializedQuantityKind.RevisionNumber);

            writer.WriteArrayHeader(specializedQuantityKind.Alias.Count);
            foreach (var identifier in specializedQuantityKind.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(specializedQuantityKind.Attachment.Count);
            foreach (var identifier in specializedQuantityKind.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(specializedQuantityKind.Category.Count);
            foreach (var identifier in specializedQuantityKind.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(specializedQuantityKind.DefaultScale.ToByteArray());
            writer.WriteArrayHeader(specializedQuantityKind.Definition.Count);
            foreach (var identifier in specializedQuantityKind.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(specializedQuantityKind.General.ToByteArray());
            writer.WriteArrayHeader(specializedQuantityKind.HyperLink.Count);
            foreach (var identifier in specializedQuantityKind.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(specializedQuantityKind.IsDeprecated);
            writer.Write(specializedQuantityKind.Name);
            writer.WriteArrayHeader(specializedQuantityKind.PossibleScale.Count);
            foreach (var identifier in specializedQuantityKind.PossibleScale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(specializedQuantityKind.QuantityDimensionSymbol);
            writer.Write(specializedQuantityKind.ShortName);
            writer.Write(specializedQuantityKind.Symbol);
            writer.WriteArrayHeader(specializedQuantityKind.ExcludedDomain.Count);
            foreach (var identifier in specializedQuantityKind.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(specializedQuantityKind.ExcludedPerson.Count);
            foreach (var identifier in specializedQuantityKind.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(specializedQuantityKind.ModifiedOn);
            writer.Write(specializedQuantityKind.ThingPreference);
            if (specializedQuantityKind.Actor.HasValue)
            {
                writer.Write(specializedQuantityKind.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SpecializedQuantityKind"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SpecializedQuantityKind"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SpecializedQuantityKind"/>.
        /// </returns>
        public SpecializedQuantityKind Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var specializedQuantityKind = new SpecializedQuantityKind();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        specializedQuantityKind.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        specializedQuantityKind.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        specializedQuantityKind.DefaultScale = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        specializedQuantityKind.General = reader.ReadBytes().ToGuid();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        specializedQuantityKind.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 10:
                        specializedQuantityKind.Name = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.PossibleScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        specializedQuantityKind.QuantityDimensionSymbol = reader.ReadString();
                        break;
                    case 13:
                        specializedQuantityKind.ShortName = reader.ReadString();
                        break;
                    case 14:
                        specializedQuantityKind.Symbol = reader.ReadString();
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            specializedQuantityKind.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        specializedQuantityKind.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 18:
                        specializedQuantityKind.ThingPreference = reader.ReadString();
                        break;
                    case 19:
                        if (reader.TryReadNil())
                        {
                            specializedQuantityKind.Actor = null;
                        }
                        else
                        {
                            specializedQuantityKind.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return specializedQuantityKind;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
