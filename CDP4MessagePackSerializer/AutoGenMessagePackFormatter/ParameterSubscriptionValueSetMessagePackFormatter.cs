// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
 | 2     | manual                               | ValueArray<string>           | 1..*        |  1.0.0  |
 | 3     | subscribedValueSet                   | Guid                         | 1..1        |  1.0.0  |
 | 4     | valueSwitch                          | ParameterSwitchKind          | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterSubscriptionValueSet"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterSubscriptionValueSetMessagePackFormatter : IMessagePackFormatter<ParameterSubscriptionValueSet>
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
        /// Serializes an <see cref="ParameterSubscriptionValueSet"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterSubscriptionValueSet">
        /// The <see cref="ParameterSubscriptionValueSet"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterSubscriptionValueSet parameterSubscriptionValueSet, MessagePackSerializerOptions options)
        {
            if (parameterSubscriptionValueSet == null)
            {
                throw new ArgumentNullException(nameof(parameterSubscriptionValueSet), "The ParameterSubscriptionValueSet may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(parameterSubscriptionValueSet.Iid.ToByteArray());
            writer.Write(parameterSubscriptionValueSet.RevisionNumber);

            writer.WriteArrayHeader(parameterSubscriptionValueSet.Manual.Count);
            foreach (var valueArrayItem in parameterSubscriptionValueSet.Manual)
            {
                writer.Write(valueArrayItem);
            }
            writer.Write(parameterSubscriptionValueSet.SubscribedValueSet.ToByteArray());
            writer.Write(parameterSubscriptionValueSet.ValueSwitch.ToString());
            writer.WriteArrayHeader(parameterSubscriptionValueSet.ExcludedDomain.Count);
            foreach (var identifier in parameterSubscriptionValueSet.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterSubscriptionValueSet.ExcludedPerson.Count);
            foreach (var identifier in parameterSubscriptionValueSet.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterSubscriptionValueSet.ModifiedOn);
            writer.Write(parameterSubscriptionValueSet.ThingPreference);
            if (parameterSubscriptionValueSet.Actor.HasValue)
            {
                writer.Write(parameterSubscriptionValueSet.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterSubscriptionValueSet"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterSubscriptionValueSet"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterSubscriptionValueSet"/>.
        /// </returns>
        public ParameterSubscriptionValueSet Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterSubscriptionValueSet = new ParameterSubscriptionValueSet();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterSubscriptionValueSet.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterSubscriptionValueSet.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        var parameterSubscriptionValueSetManual = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterSubscriptionValueSetManual.Add(reader.ReadString());
                        }
                        parameterSubscriptionValueSet.Manual = new ValueArray<string>(parameterSubscriptionValueSetManual);
                        break;
                    case 3:
                        parameterSubscriptionValueSet.SubscribedValueSet = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        parameterSubscriptionValueSet.ValueSwitch = (CDP4Common.EngineeringModelData.ParameterSwitchKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), reader.ReadString(), true);
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterSubscriptionValueSet.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterSubscriptionValueSet.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        parameterSubscriptionValueSet.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        parameterSubscriptionValueSet.ThingPreference = reader.ReadString();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            parameterSubscriptionValueSet.Actor = null;
                        }
                        else
                        {
                            parameterSubscriptionValueSet.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterSubscriptionValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
