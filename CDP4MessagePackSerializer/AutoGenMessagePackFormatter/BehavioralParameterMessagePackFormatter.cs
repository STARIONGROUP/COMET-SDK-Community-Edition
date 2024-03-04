// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehavioralParameterMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 5     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 6     | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 7     | behavioralParameterKind              | BehavioralParameterKind      | 1..1        |  1.4.0  |
 | 8     | parameter                            | Guid                         | 1..1        |  1.4.0  |
 | 9     | variableName                         | string                       | 1..1        |  1.4.0  |
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
    /// The purpose of the <see cref="BehavioralParameterMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="BehavioralParameter"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class BehavioralParameterMessagePackFormatter : IMessagePackFormatter<BehavioralParameter>
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
        /// Serializes an <see cref="BehavioralParameter"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="behavioralParameter">
        /// The <see cref="BehavioralParameter"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, BehavioralParameter behavioralParameter, MessagePackSerializerOptions options)
        {
            if (behavioralParameter == null)
            {
                throw new ArgumentNullException(nameof(behavioralParameter), "The BehavioralParameter may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(behavioralParameter.Iid.ToByteArray());
            writer.Write(behavioralParameter.RevisionNumber);

            writer.WriteArrayHeader(behavioralParameter.ExcludedDomain.Count);
            foreach (var identifier in behavioralParameter.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(behavioralParameter.ExcludedPerson.Count);
            foreach (var identifier in behavioralParameter.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(behavioralParameter.ModifiedOn);
            writer.Write(behavioralParameter.ThingPreference);
            if (behavioralParameter.Actor.HasValue)
            {
                writer.Write(behavioralParameter.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(behavioralParameter.BehavioralParameterKind.ToString());
            writer.Write(behavioralParameter.Parameter.ToByteArray());
            writer.Write(behavioralParameter.VariableName);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="BehavioralParameter"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="BehavioralParameter"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="BehavioralParameter"/>.
        /// </returns>
        public BehavioralParameter Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var behavioralParameter = new BehavioralParameter();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        behavioralParameter.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        behavioralParameter.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavioralParameter.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavioralParameter.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        behavioralParameter.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        behavioralParameter.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            behavioralParameter.Actor = null;
                        }
                        else
                        {
                            behavioralParameter.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        behavioralParameter.BehavioralParameterKind = (CDP4Common.EngineeringModelData.BehavioralParameterKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.BehavioralParameterKind), reader.ReadString(), true);
                        break;
                    case 8:
                        behavioralParameter.Parameter = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        behavioralParameter.VariableName = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return behavioralParameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
