// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponentMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | parameterType                        | Guid                         | 1..1        |  1.0.0  |
 | 3     | scale                                | Guid                         | 0..1        |  1.0.0  |
 | 4     | shortName                            | string                       | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ParameterTypeComponentMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterTypeComponent"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterTypeComponentMessagePackFormatter : IMessagePackFormatter<ParameterTypeComponent>
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
        /// Serializes an <see cref="ParameterTypeComponent"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterTypeComponent">
        /// The <see cref="ParameterTypeComponent"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterTypeComponent parameterTypeComponent, MessagePackSerializerOptions options)
        {
            if (parameterTypeComponent == null)
            {
                throw new ArgumentNullException(nameof(parameterTypeComponent), "The ParameterTypeComponent may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(parameterTypeComponent.Iid.ToByteArray());
            writer.Write(parameterTypeComponent.RevisionNumber);

            writer.Write(parameterTypeComponent.ParameterType.ToByteArray());
            if (parameterTypeComponent.Scale.HasValue)
            {
                writer.Write(parameterTypeComponent.Scale.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(parameterTypeComponent.ShortName);
            writer.WriteArrayHeader(parameterTypeComponent.ExcludedDomain.Count);
            foreach (var identifier in parameterTypeComponent.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterTypeComponent.ExcludedPerson.Count);
            foreach (var identifier in parameterTypeComponent.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterTypeComponent.ModifiedOn);
            writer.Write(parameterTypeComponent.ThingPreference);
            if (parameterTypeComponent.Actor.HasValue)
            {
                writer.Write(parameterTypeComponent.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterTypeComponent"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterTypeComponent"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterTypeComponent"/>.
        /// </returns>
        public ParameterTypeComponent Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterTypeComponent = new ParameterTypeComponent();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterTypeComponent.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterTypeComponent.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        parameterTypeComponent.ParameterType = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            parameterTypeComponent.Scale = null;
                        }
                        else
                        {
                            parameterTypeComponent.Scale = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        parameterTypeComponent.ShortName = reader.ReadString();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterTypeComponent.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterTypeComponent.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        parameterTypeComponent.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        parameterTypeComponent.ThingPreference = reader.ReadString();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            parameterTypeComponent.Actor = null;
                        }
                        else
                        {
                            parameterTypeComponent.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterTypeComponent;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
