// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntervalScaleMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 5     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 6     | isMaximumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 7     | isMinimumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 8     | mappingToReferenceScale              | Guid                         | 0..*        |  1.0.0  |
 | 9     | maximumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 10    | minimumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 11    | name                                 | string                       | 1..1        |  1.0.0  |
 | 12    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 13    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 14    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 15    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 16    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 17    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 18    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 20    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 21    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 22    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="IntervalScaleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="IntervalScale"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class IntervalScaleMessagePackFormatter : IMessagePackFormatter<IntervalScale>
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
        /// Serializes an <see cref="IntervalScale"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="intervalScale">
        /// The <see cref="IntervalScale"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, IntervalScale intervalScale, MessagePackSerializerOptions options)
        {
            if (intervalScale == null)
            {
                throw new ArgumentNullException(nameof(intervalScale), "The IntervalScale may not be null");
            }

            writer.WriteArrayHeader(23);

            writer.Write(intervalScale.Iid.ToByteArray());
            writer.Write(intervalScale.RevisionNumber);

            writer.WriteArrayHeader(intervalScale.Alias.Count);
            foreach (var identifier in intervalScale.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(intervalScale.Definition.Count);
            foreach (var identifier in intervalScale.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(intervalScale.HyperLink.Count);
            foreach (var identifier in intervalScale.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(intervalScale.IsDeprecated);
            writer.Write(intervalScale.IsMaximumInclusive);
            writer.Write(intervalScale.IsMinimumInclusive);
            writer.WriteArrayHeader(intervalScale.MappingToReferenceScale.Count);
            foreach (var identifier in intervalScale.MappingToReferenceScale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(intervalScale.MaximumPermissibleValue);
            writer.Write(intervalScale.MinimumPermissibleValue);
            writer.Write(intervalScale.Name);
            writer.Write(intervalScale.NegativeValueConnotation);
            writer.Write(intervalScale.NumberSet.ToString());
            writer.Write(intervalScale.PositiveValueConnotation);
            writer.Write(intervalScale.ShortName);
            writer.Write(intervalScale.Unit.ToByteArray());
            writer.WriteArrayHeader(intervalScale.ValueDefinition.Count);
            foreach (var identifier in intervalScale.ValueDefinition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(intervalScale.ExcludedDomain.Count);
            foreach (var identifier in intervalScale.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(intervalScale.ExcludedPerson.Count);
            foreach (var identifier in intervalScale.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(intervalScale.ModifiedOn);
            writer.Write(intervalScale.ThingPreference);
            if (intervalScale.Actor.HasValue)
            {
                writer.Write(intervalScale.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="IntervalScale"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="IntervalScale"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="IntervalScale"/>.
        /// </returns>
        public IntervalScale Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var intervalScale = new IntervalScale();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        intervalScale.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        intervalScale.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        intervalScale.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 6:
                        intervalScale.IsMaximumInclusive = reader.ReadBoolean();
                        break;
                    case 7:
                        intervalScale.IsMinimumInclusive = reader.ReadBoolean();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.MappingToReferenceScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        intervalScale.MaximumPermissibleValue = reader.ReadString();
                        break;
                    case 10:
                        intervalScale.MinimumPermissibleValue = reader.ReadString();
                        break;
                    case 11:
                        intervalScale.Name = reader.ReadString();
                        break;
                    case 12:
                        intervalScale.NegativeValueConnotation = reader.ReadString();
                        break;
                    case 13:
                        intervalScale.NumberSet = (CDP4Common.SiteDirectoryData.NumberSetKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), reader.ReadString(), true);
                        break;
                    case 14:
                        intervalScale.PositiveValueConnotation = reader.ReadString();
                        break;
                    case 15:
                        intervalScale.ShortName = reader.ReadString();
                        break;
                    case 16:
                        intervalScale.Unit = reader.ReadBytes().ToGuid();
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.ValueDefinition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            intervalScale.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        intervalScale.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 21:
                        intervalScale.ThingPreference = reader.ReadString();
                        break;
                    case 22:
                        if (reader.TryReadNil())
                        {
                            intervalScale.Actor = null;
                        }
                        else
                        {
                            intervalScale.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return intervalScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
