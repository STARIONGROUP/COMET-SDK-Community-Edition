// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependentParameterTypeAssignmentMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 5     | measurementScale                     | Guid                         | 0..1        |  1.2.0  |
 | 6     | parameterType                        | Guid                         | 1..1        |  1.2.0  |
 | 7     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 8     | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="DependentParameterTypeAssignmentMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DependentParameterTypeAssignment"/> type
    /// </summary>
    [CDPVersion("1.2.0")]
    public class DependentParameterTypeAssignmentMessagePackFormatter : IMessagePackFormatter<DependentParameterTypeAssignment>
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
        /// Serializes an <see cref="DependentParameterTypeAssignment"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="dependentParameterTypeAssignment">
        /// The <see cref="DependentParameterTypeAssignment"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DependentParameterTypeAssignment dependentParameterTypeAssignment, MessagePackSerializerOptions options)
        {
            if (dependentParameterTypeAssignment == null)
            {
                throw new ArgumentNullException(nameof(dependentParameterTypeAssignment), "The DependentParameterTypeAssignment may not be null");
            }

            writer.WriteArrayHeader(9);

            writer.Write(dependentParameterTypeAssignment.Iid.ToByteArray());
            writer.Write(dependentParameterTypeAssignment.RevisionNumber);

            writer.WriteArrayHeader(dependentParameterTypeAssignment.ExcludedDomain.Count);
            foreach (var identifier in dependentParameterTypeAssignment.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dependentParameterTypeAssignment.ExcludedPerson.Count);
            foreach (var identifier in dependentParameterTypeAssignment.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(dependentParameterTypeAssignment.ModifiedOn);
            if (dependentParameterTypeAssignment.MeasurementScale.HasValue)
            {
                writer.Write(dependentParameterTypeAssignment.MeasurementScale.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(dependentParameterTypeAssignment.ParameterType.ToByteArray());
            writer.Write(dependentParameterTypeAssignment.ThingPreference);
            if (dependentParameterTypeAssignment.Actor.HasValue)
            {
                writer.Write(dependentParameterTypeAssignment.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DependentParameterTypeAssignment"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DependentParameterTypeAssignment"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DependentParameterTypeAssignment"/>.
        /// </returns>
        public DependentParameterTypeAssignment Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var dependentParameterTypeAssignment = new DependentParameterTypeAssignment();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        dependentParameterTypeAssignment.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        dependentParameterTypeAssignment.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dependentParameterTypeAssignment.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dependentParameterTypeAssignment.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        dependentParameterTypeAssignment.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        if (reader.TryReadNil())
                        {
                            dependentParameterTypeAssignment.MeasurementScale = null;
                        }
                        else
                        {
                            dependentParameterTypeAssignment.MeasurementScale = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 6:
                        dependentParameterTypeAssignment.ParameterType = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        dependentParameterTypeAssignment.ThingPreference = reader.ReadString();
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            dependentParameterTypeAssignment.Actor = null;
                        }
                        else
                        {
                            dependentParameterTypeAssignment.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return dependentParameterTypeAssignment;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
