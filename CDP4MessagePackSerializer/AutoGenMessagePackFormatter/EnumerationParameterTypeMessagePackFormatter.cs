// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationParameterTypeMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 3     | allowMultiSelect                     | bool                         | 1..1        |  1.0.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 11    | valueDefinition                      | Guid                         | 1..*        |  1.0.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 16    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="EnumerationParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="EnumerationParameterType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class EnumerationParameterTypeMessagePackFormatter : IMessagePackFormatter<EnumerationParameterType>
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
        /// Serializes an <see cref="EnumerationParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="enumerationParameterType">
        /// The <see cref="EnumerationParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, EnumerationParameterType enumerationParameterType, MessagePackSerializerOptions options)
        {
            if (enumerationParameterType == null)
            {
                throw new ArgumentNullException(nameof(enumerationParameterType), "The EnumerationParameterType may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(enumerationParameterType.Iid.ToByteArray());
            writer.Write(enumerationParameterType.RevisionNumber);

            writer.WriteArrayHeader(enumerationParameterType.Alias.Count);
            foreach (var identifier in enumerationParameterType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(enumerationParameterType.AllowMultiSelect);
            writer.WriteArrayHeader(enumerationParameterType.Category.Count);
            foreach (var identifier in enumerationParameterType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(enumerationParameterType.Definition.Count);
            foreach (var identifier in enumerationParameterType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(enumerationParameterType.HyperLink.Count);
            foreach (var identifier in enumerationParameterType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(enumerationParameterType.IsDeprecated);
            writer.Write(enumerationParameterType.Name);
            writer.Write(enumerationParameterType.ShortName);
            writer.Write(enumerationParameterType.Symbol);
            writer.WriteArrayHeader(enumerationParameterType.ValueDefinition.Count);
            foreach (var orderedItem in enumerationParameterType.ValueDefinition.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(enumerationParameterType.ExcludedDomain.Count);
            foreach (var identifier in enumerationParameterType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(enumerationParameterType.ExcludedPerson.Count);
            foreach (var identifier in enumerationParameterType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(enumerationParameterType.ModifiedOn);
            writer.Write(enumerationParameterType.ThingPreference);
            if (enumerationParameterType.Actor.HasValue)
            {
                writer.Write(enumerationParameterType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="EnumerationParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="EnumerationParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="EnumerationParameterType"/>.
        /// </returns>
        public EnumerationParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var enumerationParameterType = new EnumerationParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        enumerationParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        enumerationParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        enumerationParameterType.AllowMultiSelect = reader.ReadBoolean();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        enumerationParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        enumerationParameterType.Name = reader.ReadString();
                        break;
                    case 9:
                        enumerationParameterType.ShortName = reader.ReadString();
                        break;
                    case 10:
                        enumerationParameterType.Symbol = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            enumerationParameterType.ValueDefinition.Add(orderedItem);
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            enumerationParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        enumerationParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        enumerationParameterType.ThingPreference = reader.ReadString();
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            enumerationParameterType.Actor = null;
                        }
                        else
                        {
                            enumerationParameterType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return enumerationParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
