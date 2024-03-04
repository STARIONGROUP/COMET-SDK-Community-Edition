// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampledFunctionParameterTypeMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 5     | alias                                | Guid                         | 0..*        |  1.2.0  |
 | 6     | category                             | Guid                         | 0..*        |  1.2.0  |
 | 7     | definition                           | Guid                         | 0..*        |  1.2.0  |
 | 8     | degreeOfInterpolation                | int                          | 0..1        |  1.2.0  |
 | 9     | dependentParameterType               | Guid                         | 1..*        |  1.2.0  |
 | 10    | hyperLink                            | Guid                         | 0..*        |  1.2.0  |
 | 11    | independentParameterType             | Guid                         | 1..*        |  1.2.0  |
 | 12    | interpolationPeriod                  | ValueArray<string>           | 1..*        |  1.2.0  |
 | 13    | isDeprecated                         | bool                         | 1..1        |  1.2.0  |
 | 14    | name                                 | string                       | 1..1        |  1.2.0  |
 | 15    | shortName                            | string                       | 1..1        |  1.2.0  |
 | 16    | symbol                               | string                       | 1..1        |  1.2.0  |
 | 17    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 18    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 19    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="SampledFunctionParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SampledFunctionParameterType"/> type
    /// </summary>
    [CDPVersion("1.2.0")]
    public class SampledFunctionParameterTypeMessagePackFormatter : IMessagePackFormatter<SampledFunctionParameterType>
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
        /// Serializes an <see cref="SampledFunctionParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="SampledFunctionParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SampledFunctionParameterType sampledFunctionParameterType, MessagePackSerializerOptions options)
        {
            if (sampledFunctionParameterType == null)
            {
                throw new ArgumentNullException(nameof(sampledFunctionParameterType), "The SampledFunctionParameterType may not be null");
            }

            writer.WriteArrayHeader(20);

            writer.Write(sampledFunctionParameterType.Iid.ToByteArray());
            writer.Write(sampledFunctionParameterType.RevisionNumber);

            writer.WriteArrayHeader(sampledFunctionParameterType.ExcludedDomain.Count);
            foreach (var identifier in sampledFunctionParameterType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.ExcludedPerson.Count);
            foreach (var identifier in sampledFunctionParameterType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(sampledFunctionParameterType.ModifiedOn);
            writer.WriteArrayHeader(sampledFunctionParameterType.Alias.Count);
            foreach (var identifier in sampledFunctionParameterType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.Category.Count);
            foreach (var identifier in sampledFunctionParameterType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.Definition.Count);
            foreach (var identifier in sampledFunctionParameterType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (sampledFunctionParameterType.DegreeOfInterpolation.HasValue)
            {
                writer.Write(sampledFunctionParameterType.DegreeOfInterpolation.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.DependentParameterType.Count);
            foreach (var orderedItem in sampledFunctionParameterType.DependentParameterType.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.HyperLink.Count);
            foreach (var identifier in sampledFunctionParameterType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.IndependentParameterType.Count);
            foreach (var orderedItem in sampledFunctionParameterType.IndependentParameterType.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.InterpolationPeriod.Count);
            foreach (var valueArrayItem in sampledFunctionParameterType.InterpolationPeriod)
            {
                writer.Write(valueArrayItem);
            }
            writer.Write(sampledFunctionParameterType.IsDeprecated);
            writer.Write(sampledFunctionParameterType.Name);
            writer.Write(sampledFunctionParameterType.ShortName);
            writer.Write(sampledFunctionParameterType.Symbol);
            writer.Write(sampledFunctionParameterType.ThingPreference);
            if (sampledFunctionParameterType.Actor.HasValue)
            {
                writer.Write(sampledFunctionParameterType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(sampledFunctionParameterType.Attachment.Count);
            foreach (var identifier in sampledFunctionParameterType.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SampledFunctionParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SampledFunctionParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SampledFunctionParameterType"/>.
        /// </returns>
        public SampledFunctionParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var sampledFunctionParameterType = new SampledFunctionParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        sampledFunctionParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        sampledFunctionParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        sampledFunctionParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            sampledFunctionParameterType.DegreeOfInterpolation = null;
                        }
                        else
                        {
                            sampledFunctionParameterType.DegreeOfInterpolation = reader.ReadInt32();
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            sampledFunctionParameterType.DependentParameterType.Add(orderedItem);
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            sampledFunctionParameterType.IndependentParameterType.Add(orderedItem);
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        var sampledFunctionParameterTypeInterpolationPeriod = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterTypeInterpolationPeriod.Add(reader.ReadString());
                        }
                        sampledFunctionParameterType.InterpolationPeriod = new ValueArray<string>(sampledFunctionParameterTypeInterpolationPeriod);
                        break;
                    case 13:
                        sampledFunctionParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 14:
                        sampledFunctionParameterType.Name = reader.ReadString();
                        break;
                    case 15:
                        sampledFunctionParameterType.ShortName = reader.ReadString();
                        break;
                    case 16:
                        sampledFunctionParameterType.Symbol = reader.ReadString();
                        break;
                    case 17:
                        sampledFunctionParameterType.ThingPreference = reader.ReadString();
                        break;
                    case 18:
                        if (reader.TryReadNil())
                        {
                            sampledFunctionParameterType.Actor = null;
                        }
                        else
                        {
                            sampledFunctionParameterType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            sampledFunctionParameterType.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return sampledFunctionParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
