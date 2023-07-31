// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroupMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | containingGroup                      | Guid                         | 0..1        |  1.0.0  |
 | 3     | name                                 | string                       | 1..1        |  1.0.0  |
 | 4     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 7     | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="ParameterGroupMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterGroup"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterGroupMessagePackFormatter : IMessagePackFormatter<ParameterGroup>
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
        /// Serializes an <see cref="ParameterGroup"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterGroup">
        /// The <see cref="ParameterGroup"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterGroup parameterGroup, MessagePackSerializerOptions options)
        {
            if (parameterGroup == null)
            {
                throw new ArgumentNullException(nameof(parameterGroup), "The ParameterGroup may not be null");
            }

            writer.WriteArrayHeader(8);

            writer.Write(parameterGroup.Iid.ToByteArray());
            writer.Write(parameterGroup.RevisionNumber);

            if (parameterGroup.ContainingGroup.HasValue)
            {
                writer.Write(parameterGroup.ContainingGroup.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(parameterGroup.Name);
            writer.WriteArrayHeader(parameterGroup.ExcludedDomain.Count);
            foreach (var identifier in parameterGroup.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterGroup.ExcludedPerson.Count);
            foreach (var identifier in parameterGroup.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterGroup.ModifiedOn);
            writer.Write(parameterGroup.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterGroup"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterGroup"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterGroup"/>.
        /// </returns>
        public ParameterGroup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterGroup = new ParameterGroup();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterGroup.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterGroup.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            parameterGroup.ContainingGroup = null;
                        }
                        else
                        {
                            parameterGroup.ContainingGroup = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        parameterGroup.Name = reader.ReadString();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterGroup.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterGroup.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        parameterGroup.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 7:
                        parameterGroup.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterGroup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
