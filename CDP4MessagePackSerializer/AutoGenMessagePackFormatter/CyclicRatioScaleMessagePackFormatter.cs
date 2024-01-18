// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicRatioScaleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | isMaximumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 8     | isMinimumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 9     | mappingToReferenceScale              | Guid                         | 0..*        |  1.0.0  |
 | 10    | maximumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 11    | minimumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 12    | modulus                              | string                       | 1..1        |  1.0.0  |
 | 13    | name                                 | string                       | 1..1        |  1.0.0  |
 | 14    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 15    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 16    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 17    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 18    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 19    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 20    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 21    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 22    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 23    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 24    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="CyclicRatioScaleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="CyclicRatioScale"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class CyclicRatioScaleMessagePackFormatter : IMessagePackFormatter<CyclicRatioScale>
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
        /// Serializes an <see cref="CyclicRatioScale"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="cyclicRatioScale">
        /// The <see cref="CyclicRatioScale"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, CyclicRatioScale cyclicRatioScale, MessagePackSerializerOptions options)
        {
            if (cyclicRatioScale == null)
            {
                throw new ArgumentNullException(nameof(cyclicRatioScale), "The CyclicRatioScale may not be null");
            }

            writer.WriteArrayHeader(25);

            writer.Write(cyclicRatioScale.Iid.ToByteArray());
            writer.Write(cyclicRatioScale.RevisionNumber);

            writer.WriteArrayHeader(cyclicRatioScale.Alias.Count);
            foreach (var identifier in cyclicRatioScale.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(cyclicRatioScale.Attachment.Count);
            foreach (var identifier in cyclicRatioScale.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(cyclicRatioScale.Definition.Count);
            foreach (var identifier in cyclicRatioScale.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(cyclicRatioScale.HyperLink.Count);
            foreach (var identifier in cyclicRatioScale.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(cyclicRatioScale.IsDeprecated);
            writer.Write(cyclicRatioScale.IsMaximumInclusive);
            writer.Write(cyclicRatioScale.IsMinimumInclusive);
            writer.WriteArrayHeader(cyclicRatioScale.MappingToReferenceScale.Count);
            foreach (var identifier in cyclicRatioScale.MappingToReferenceScale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(cyclicRatioScale.MaximumPermissibleValue);
            writer.Write(cyclicRatioScale.MinimumPermissibleValue);
            writer.Write(cyclicRatioScale.Modulus);
            writer.Write(cyclicRatioScale.Name);
            writer.Write(cyclicRatioScale.NegativeValueConnotation);
            writer.Write(cyclicRatioScale.NumberSet.ToString());
            writer.Write(cyclicRatioScale.PositiveValueConnotation);
            writer.Write(cyclicRatioScale.ShortName);
            writer.Write(cyclicRatioScale.Unit.ToByteArray());
            writer.WriteArrayHeader(cyclicRatioScale.ValueDefinition.Count);
            foreach (var identifier in cyclicRatioScale.ValueDefinition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(cyclicRatioScale.ExcludedDomain.Count);
            foreach (var identifier in cyclicRatioScale.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(cyclicRatioScale.ExcludedPerson.Count);
            foreach (var identifier in cyclicRatioScale.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(cyclicRatioScale.ModifiedOn);
            writer.Write(cyclicRatioScale.ThingPreference);
            if (cyclicRatioScale.Actor.HasValue)
            {
                writer.Write(cyclicRatioScale.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="CyclicRatioScale"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="CyclicRatioScale"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="CyclicRatioScale"/>.
        /// </returns>
        public CyclicRatioScale Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var cyclicRatioScale = new CyclicRatioScale();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        cyclicRatioScale.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        cyclicRatioScale.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        cyclicRatioScale.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        cyclicRatioScale.IsMaximumInclusive = reader.ReadBoolean();
                        break;
                    case 8:
                        cyclicRatioScale.IsMinimumInclusive = reader.ReadBoolean();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.MappingToReferenceScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        cyclicRatioScale.MaximumPermissibleValue = reader.ReadString();
                        break;
                    case 11:
                        cyclicRatioScale.MinimumPermissibleValue = reader.ReadString();
                        break;
                    case 12:
                        cyclicRatioScale.Modulus = reader.ReadString();
                        break;
                    case 13:
                        cyclicRatioScale.Name = reader.ReadString();
                        break;
                    case 14:
                        cyclicRatioScale.NegativeValueConnotation = reader.ReadString();
                        break;
                    case 15:
                        cyclicRatioScale.NumberSet = (CDP4Common.SiteDirectoryData.NumberSetKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), reader.ReadString(), true);
                        break;
                    case 16:
                        cyclicRatioScale.PositiveValueConnotation = reader.ReadString();
                        break;
                    case 17:
                        cyclicRatioScale.ShortName = reader.ReadString();
                        break;
                    case 18:
                        cyclicRatioScale.Unit = reader.ReadBytes().ToGuid();
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.ValueDefinition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            cyclicRatioScale.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 22:
                        cyclicRatioScale.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 23:
                        cyclicRatioScale.ThingPreference = reader.ReadString();
                        break;
                    case 24:
                        if (reader.TryReadNil())
                        {
                            cyclicRatioScale.Actor = null;
                        }
                        else
                        {
                            cyclicRatioScale.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return cyclicRatioScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
