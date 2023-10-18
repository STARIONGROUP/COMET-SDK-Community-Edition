// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | allowDifferentOwnerOfOverride        | bool                         | 1..1        |  1.0.0  |
 | 3     | expectsOverride                      | bool                         | 1..1        |  1.0.0  |
 | 4     | group                                | Guid                         | 0..1        |  1.0.0  |
 | 5     | isOptionDependent                    | bool                         | 1..1        |  1.0.0  |
 | 6     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 7     | parameterSubscription                | Guid                         | 0..*        |  1.0.0  |
 | 8     | parameterType                        | Guid                         | 1..1        |  1.0.0  |
 | 9     | requestedBy                          | Guid                         | 0..1        |  1.0.0  |
 | 10    | scale                                | Guid                         | 0..1        |  1.0.0  |
 | 11    | stateDependence                      | Guid                         | 0..1        |  1.0.0  |
 | 12    | valueSet                             | Guid                         | 1..*        |  1.0.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 16    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 17    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ParameterMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Parameter"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterMessagePackFormatter : IMessagePackFormatter<Parameter>
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
        /// Serializes an <see cref="Parameter"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameter">
        /// The <see cref="Parameter"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Parameter parameter, MessagePackSerializerOptions options)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter), "The Parameter may not be null");
            }

            writer.WriteArrayHeader(18);

            writer.Write(parameter.Iid.ToByteArray());
            writer.Write(parameter.RevisionNumber);

            writer.Write(parameter.AllowDifferentOwnerOfOverride);
            writer.Write(parameter.ExpectsOverride);
            if (parameter.Group.HasValue)
            {
                writer.Write(parameter.Group.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(parameter.IsOptionDependent);
            writer.Write(parameter.Owner.ToByteArray());
            writer.WriteArrayHeader(parameter.ParameterSubscription.Count);
            foreach (var identifier in parameter.ParameterSubscription.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameter.ParameterType.ToByteArray());
            if (parameter.RequestedBy.HasValue)
            {
                writer.Write(parameter.RequestedBy.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (parameter.Scale.HasValue)
            {
                writer.Write(parameter.Scale.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (parameter.StateDependence.HasValue)
            {
                writer.Write(parameter.StateDependence.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(parameter.ValueSet.Count);
            foreach (var identifier in parameter.ValueSet.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameter.ExcludedDomain.Count);
            foreach (var identifier in parameter.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameter.ExcludedPerson.Count);
            foreach (var identifier in parameter.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameter.ModifiedOn);
            writer.Write(parameter.ThingPreference);
            if (parameter.Actor.HasValue)
            {
                writer.Write(parameter.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Parameter"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Parameter"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Parameter"/>.
        /// </returns>
        public Parameter Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameter = new Parameter();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameter.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameter.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        parameter.AllowDifferentOwnerOfOverride = reader.ReadBoolean();
                        break;
                    case 3:
                        parameter.ExpectsOverride = reader.ReadBoolean();
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            parameter.Group = null;
                        }
                        else
                        {
                            parameter.Group = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        parameter.IsOptionDependent = reader.ReadBoolean();
                        break;
                    case 6:
                        parameter.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameter.ParameterSubscription.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        parameter.ParameterType = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            parameter.RequestedBy = null;
                        }
                        else
                        {
                            parameter.RequestedBy = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            parameter.Scale = null;
                        }
                        else
                        {
                            parameter.Scale = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            parameter.StateDependence = null;
                        }
                        else
                        {
                            parameter.StateDependence = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameter.ValueSet.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameter.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameter.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        parameter.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        parameter.ThingPreference = reader.ReadString();
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            parameter.Actor = null;
                        }
                        else
                        {
                            parameter.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
