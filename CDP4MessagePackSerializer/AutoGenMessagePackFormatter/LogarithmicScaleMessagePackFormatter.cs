// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScaleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | exponent                             | string                       | 1..1        |  1.0.0  |
 | 5     | factor                               | string                       | 1..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | isMaximumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 9     | isMinimumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 10    | logarithmBase                        | LogarithmBaseKind            | 1..1        |  1.0.0  |
 | 11    | mappingToReferenceScale              | Guid                         | 0..*        |  1.0.0  |
 | 12    | maximumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 13    | minimumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 14    | name                                 | string                       | 1..1        |  1.0.0  |
 | 15    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 16    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 17    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 18    | referenceQuantityKind                | Guid                         | 1..1        |  1.0.0  |
 | 19    | referenceQuantityValue               | Guid                         | 0..1        |  1.0.0  |
 | 20    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 21    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 22    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 23    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 24    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 25    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 26    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 27    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 28    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="LogarithmicScaleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="LogarithmicScale"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class LogarithmicScaleMessagePackFormatter : IMessagePackFormatter<LogarithmicScale>
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
        /// Serializes an <see cref="LogarithmicScale"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="logarithmicScale">
        /// The <see cref="LogarithmicScale"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, LogarithmicScale logarithmicScale, MessagePackSerializerOptions options)
        {
            if (logarithmicScale == null)
            {
                throw new ArgumentNullException(nameof(logarithmicScale), "The LogarithmicScale may not be null");
            }

            writer.WriteArrayHeader(29);

            writer.Write(logarithmicScale.Iid.ToByteArray());
            writer.Write(logarithmicScale.RevisionNumber);

            writer.WriteArrayHeader(logarithmicScale.Alias.Count);
            foreach (var identifier in logarithmicScale.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(logarithmicScale.Definition.Count);
            foreach (var identifier in logarithmicScale.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logarithmicScale.Exponent);
            writer.Write(logarithmicScale.Factor);
            writer.WriteArrayHeader(logarithmicScale.HyperLink.Count);
            foreach (var identifier in logarithmicScale.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logarithmicScale.IsDeprecated);
            writer.Write(logarithmicScale.IsMaximumInclusive);
            writer.Write(logarithmicScale.IsMinimumInclusive);
            writer.Write(logarithmicScale.LogarithmBase.ToString());
            writer.WriteArrayHeader(logarithmicScale.MappingToReferenceScale.Count);
            foreach (var identifier in logarithmicScale.MappingToReferenceScale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logarithmicScale.MaximumPermissibleValue);
            writer.Write(logarithmicScale.MinimumPermissibleValue);
            writer.Write(logarithmicScale.Name);
            writer.Write(logarithmicScale.NegativeValueConnotation);
            writer.Write(logarithmicScale.NumberSet.ToString());
            writer.Write(logarithmicScale.PositiveValueConnotation);
            writer.Write(logarithmicScale.ReferenceQuantityKind.ToByteArray());
            writer.WriteArrayHeader(logarithmicScale.ReferenceQuantityValue.Count);
            foreach (var identifier in logarithmicScale.ReferenceQuantityValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logarithmicScale.ShortName);
            writer.Write(logarithmicScale.Unit.ToByteArray());
            writer.WriteArrayHeader(logarithmicScale.ValueDefinition.Count);
            foreach (var identifier in logarithmicScale.ValueDefinition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(logarithmicScale.ExcludedDomain.Count);
            foreach (var identifier in logarithmicScale.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(logarithmicScale.ExcludedPerson.Count);
            foreach (var identifier in logarithmicScale.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logarithmicScale.ModifiedOn);
            writer.Write(logarithmicScale.ThingPreference);
            if (logarithmicScale.Actor.HasValue)
            {
                writer.Write(logarithmicScale.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(logarithmicScale.Attachment.Count);
            foreach (var identifier in logarithmicScale.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="LogarithmicScale"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="LogarithmicScale"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="LogarithmicScale"/>.
        /// </returns>
        public LogarithmicScale Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var logarithmicScale = new LogarithmicScale();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        logarithmicScale.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        logarithmicScale.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        logarithmicScale.Exponent = reader.ReadString();
                        break;
                    case 5:
                        logarithmicScale.Factor = reader.ReadString();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        logarithmicScale.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        logarithmicScale.IsMaximumInclusive = reader.ReadBoolean();
                        break;
                    case 9:
                        logarithmicScale.IsMinimumInclusive = reader.ReadBoolean();
                        break;
                    case 10:
                        logarithmicScale.LogarithmBase = (CDP4Common.SiteDirectoryData.LogarithmBaseKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.LogarithmBaseKind), reader.ReadString(), true);
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.MappingToReferenceScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        logarithmicScale.MaximumPermissibleValue = reader.ReadString();
                        break;
                    case 13:
                        logarithmicScale.MinimumPermissibleValue = reader.ReadString();
                        break;
                    case 14:
                        logarithmicScale.Name = reader.ReadString();
                        break;
                    case 15:
                        logarithmicScale.NegativeValueConnotation = reader.ReadString();
                        break;
                    case 16:
                        logarithmicScale.NumberSet = (CDP4Common.SiteDirectoryData.NumberSetKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), reader.ReadString(), true);
                        break;
                    case 17:
                        logarithmicScale.PositiveValueConnotation = reader.ReadString();
                        break;
                    case 18:
                        logarithmicScale.ReferenceQuantityKind = reader.ReadBytes().ToGuid();
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.ReferenceQuantityValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        logarithmicScale.ShortName = reader.ReadString();
                        break;
                    case 21:
                        logarithmicScale.Unit = reader.ReadBytes().ToGuid();
                        break;
                    case 22:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.ValueDefinition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 23:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 24:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 25:
                        logarithmicScale.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 26:
                        logarithmicScale.ThingPreference = reader.ReadString();
                        break;
                    case 27:
                        if (reader.TryReadNil())
                        {
                            logarithmicScale.Actor = null;
                        }
                        else
                        {
                            logarithmicScale.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 28:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logarithmicScale.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return logarithmicScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
