// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | actualState                          | Guid                         | 0..1        |  1.0.0  |
 | 3     | actualValue                          | string                       | 1..1        |  1.0.0  |
 | 4     | associatedParameter                  | Guid                         | 1..1        |  1.0.0  |
 | 5     | formula                              | string                       | 1..1        |  1.0.0  |
 | 6     | isVolatile                           | bool                         | 1..1        |  1.0.0  |
 | 7     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 8     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 11    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 12    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="NestedParameterMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="NestedParameter"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class NestedParameterMessagePackFormatter : IMessagePackFormatter<NestedParameter>
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
        /// Serializes an <see cref="NestedParameter"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="nestedParameter">
        /// The <see cref="NestedParameter"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, NestedParameter nestedParameter, MessagePackSerializerOptions options)
        {
            if (nestedParameter == null)
            {
                throw new ArgumentNullException(nameof(nestedParameter), "The NestedParameter may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(nestedParameter.Iid.ToByteArray());
            writer.Write(nestedParameter.RevisionNumber);

            if (nestedParameter.ActualState.HasValue)
            {
                writer.Write(nestedParameter.ActualState.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(nestedParameter.ActualValue);
            writer.Write(nestedParameter.AssociatedParameter.ToByteArray());
            writer.Write(nestedParameter.Formula);
            writer.Write(nestedParameter.IsVolatile);
            writer.Write(nestedParameter.Owner.ToByteArray());
            writer.WriteArrayHeader(nestedParameter.ExcludedDomain.Count);
            foreach (var identifier in nestedParameter.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(nestedParameter.ExcludedPerson.Count);
            foreach (var identifier in nestedParameter.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(nestedParameter.ModifiedOn);
            writer.Write(nestedParameter.ThingPreference);
            if (nestedParameter.Actor.HasValue)
            {
                writer.Write(nestedParameter.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="NestedParameter"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="NestedParameter"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="NestedParameter"/>.
        /// </returns>
        public NestedParameter Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var nestedParameter = new NestedParameter();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        nestedParameter.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        nestedParameter.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            nestedParameter.ActualState = null;
                        }
                        else
                        {
                            nestedParameter.ActualState = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        nestedParameter.ActualValue = reader.ReadString();
                        break;
                    case 4:
                        nestedParameter.AssociatedParameter = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        nestedParameter.Formula = reader.ReadString();
                        break;
                    case 6:
                        nestedParameter.IsVolatile = reader.ReadBoolean();
                        break;
                    case 7:
                        nestedParameter.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            nestedParameter.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            nestedParameter.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        nestedParameter.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 11:
                        nestedParameter.ThingPreference = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            nestedParameter.Actor = null;
                        }
                        else
                        {
                            nestedParameter.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return nestedParameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
