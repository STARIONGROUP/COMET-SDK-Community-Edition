// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RatioScaleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 12    | name                                 | string                       | 1..1        |  1.0.0  |
 | 13    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 14    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 15    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 16    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 17    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 18    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 19    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 20    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 21    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 22    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 23    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="RatioScaleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="RatioScale"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class RatioScaleMessagePackFormatter : IMessagePackFormatter<RatioScale>
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
        /// Serializes an <see cref="RatioScale"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="ratioScale">
        /// The <see cref="RatioScale"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, RatioScale ratioScale, MessagePackSerializerOptions options)
        {
            if (ratioScale == null)
            {
                throw new ArgumentNullException(nameof(ratioScale), "The RatioScale may not be null");
            }

            writer.WriteArrayHeader(24);

            writer.Write(ratioScale.Iid.ToByteArray());
            writer.Write(ratioScale.RevisionNumber);

            writer.WriteArrayHeader(ratioScale.Alias.Count);
            foreach (var identifier in ratioScale.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ratioScale.Attachment.Count);
            foreach (var identifier in ratioScale.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ratioScale.Definition.Count);
            foreach (var identifier in ratioScale.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ratioScale.HyperLink.Count);
            foreach (var identifier in ratioScale.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(ratioScale.IsDeprecated);
            writer.Write(ratioScale.IsMaximumInclusive);
            writer.Write(ratioScale.IsMinimumInclusive);
            writer.WriteArrayHeader(ratioScale.MappingToReferenceScale.Count);
            foreach (var identifier in ratioScale.MappingToReferenceScale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(ratioScale.MaximumPermissibleValue);
            writer.Write(ratioScale.MinimumPermissibleValue);
            writer.Write(ratioScale.Name);
            writer.Write(ratioScale.NegativeValueConnotation);
            writer.Write(ratioScale.NumberSet.ToString());
            writer.Write(ratioScale.PositiveValueConnotation);
            writer.Write(ratioScale.ShortName);
            writer.Write(ratioScale.Unit.ToByteArray());
            writer.WriteArrayHeader(ratioScale.ValueDefinition.Count);
            foreach (var identifier in ratioScale.ValueDefinition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ratioScale.ExcludedDomain.Count);
            foreach (var identifier in ratioScale.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(ratioScale.ExcludedPerson.Count);
            foreach (var identifier in ratioScale.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(ratioScale.ModifiedOn);
            writer.Write(ratioScale.ThingPreference);
            if (ratioScale.Actor.HasValue)
            {
                writer.Write(ratioScale.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="RatioScale"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="RatioScale"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="RatioScale"/>.
        /// </returns>
        public RatioScale Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var ratioScale = new RatioScale();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        ratioScale.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        ratioScale.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        ratioScale.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        ratioScale.IsMaximumInclusive = reader.ReadBoolean();
                        break;
                    case 8:
                        ratioScale.IsMinimumInclusive = reader.ReadBoolean();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.MappingToReferenceScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        ratioScale.MaximumPermissibleValue = reader.ReadString();
                        break;
                    case 11:
                        ratioScale.MinimumPermissibleValue = reader.ReadString();
                        break;
                    case 12:
                        ratioScale.Name = reader.ReadString();
                        break;
                    case 13:
                        ratioScale.NegativeValueConnotation = reader.ReadString();
                        break;
                    case 14:
                        ratioScale.NumberSet = (CDP4Common.SiteDirectoryData.NumberSetKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), reader.ReadString(), true);
                        break;
                    case 15:
                        ratioScale.PositiveValueConnotation = reader.ReadString();
                        break;
                    case 16:
                        ratioScale.ShortName = reader.ReadString();
                        break;
                    case 17:
                        ratioScale.Unit = reader.ReadBytes().ToGuid();
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.ValueDefinition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            ratioScale.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 21:
                        ratioScale.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 22:
                        ratioScale.ThingPreference = reader.ReadString();
                        break;
                    case 23:
                        if (reader.TryReadNil())
                        {
                            ratioScale.Actor = null;
                        }
                        else
                        {
                            ratioScale.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return ratioScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
