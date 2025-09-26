// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleParameterValueMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | parameterType                        | Guid                         | 1..1        |  1.0.0  |
 | 3     | scale                                | Guid                         | 0..1        |  1.0.0  |
 | 4     | value                                | ValueArray<string>           | 1..*        |  1.0.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 8     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 9     | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="SimpleParameterValueMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SimpleParameterValue"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SimpleParameterValueMessagePackFormatter : IMessagePackFormatter<SimpleParameterValue>
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
        /// Serializes an <see cref="SimpleParameterValue"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="simpleParameterValue">
        /// The <see cref="SimpleParameterValue"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SimpleParameterValue simpleParameterValue, MessagePackSerializerOptions options)
        {
            if (simpleParameterValue == null)
            {
                throw new ArgumentNullException(nameof(simpleParameterValue), "The SimpleParameterValue may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(simpleParameterValue.Iid.ToByteArray());
            writer.Write(simpleParameterValue.RevisionNumber);

            writer.Write(simpleParameterValue.ParameterType.ToByteArray());
            if (simpleParameterValue.Scale.HasValue)
            {
                writer.Write(simpleParameterValue.Scale.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(simpleParameterValue.Value.Count);
            foreach (var valueArrayItem in simpleParameterValue.Value)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(simpleParameterValue.ExcludedDomain.Count);
            foreach (var identifier in simpleParameterValue.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(simpleParameterValue.ExcludedPerson.Count);
            foreach (var identifier in simpleParameterValue.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(simpleParameterValue.ModifiedOn);
            writer.Write(simpleParameterValue.ThingPreference);
            if (simpleParameterValue.Actor.HasValue)
            {
                writer.Write(simpleParameterValue.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SimpleParameterValue"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SimpleParameterValue"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SimpleParameterValue"/>.
        /// </returns>
        public SimpleParameterValue Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var simpleParameterValue = new SimpleParameterValue();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        simpleParameterValue.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        simpleParameterValue.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        simpleParameterValue.ParameterType = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            simpleParameterValue.Scale = null;
                        }
                        else
                        {
                            simpleParameterValue.Scale = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        var simpleParameterValueValue = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleParameterValueValue.Add(reader.ReadString());
                        }
                        simpleParameterValue.Value = new ValueArray<string>(simpleParameterValueValue);
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleParameterValue.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleParameterValue.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        simpleParameterValue.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        simpleParameterValue.ThingPreference = reader.ReadString();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            simpleParameterValue.Actor = null;
                        }
                        else
                        {
                            simpleParameterValue.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return simpleParameterValue;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
