// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteStateListMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 4     | defaultState                         | Guid                         | 0..1        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 9     | possibleState                        | Guid                         | 1..*        |  1.0.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 11    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 14    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="PossibleFiniteStateListMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="PossibleFiniteStateList"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class PossibleFiniteStateListMessagePackFormatter : IMessagePackFormatter<PossibleFiniteStateList>
    {
        /// <summary>
        /// Serializes an <see cref="PossibleFiniteStateList"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="possibleFiniteStateList">
        /// The <see cref="PossibleFiniteStateList"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, PossibleFiniteStateList possibleFiniteStateList, MessagePackSerializerOptions options)
        {
            if (possibleFiniteStateList == null)
            {
                throw new ArgumentNullException(nameof(possibleFiniteStateList), "The PossibleFiniteStateList may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(possibleFiniteStateList.Iid.ToByteArray());
            writer.Write(possibleFiniteStateList.RevisionNumber);

            writer.WriteArrayHeader(possibleFiniteStateList.Alias.Count);
            foreach (var identifier in possibleFiniteStateList.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(possibleFiniteStateList.Category.Count);
            foreach (var identifier in possibleFiniteStateList.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            if (possibleFiniteStateList.DefaultState.HasValue)
            {
                writer.Write(possibleFiniteStateList.DefaultState.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(possibleFiniteStateList.Definition.Count);
            foreach (var identifier in possibleFiniteStateList.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(possibleFiniteStateList.HyperLink.Count);
            foreach (var identifier in possibleFiniteStateList.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(possibleFiniteStateList.Name);
            writer.Write(possibleFiniteStateList.Owner.ToByteArray());
            writer.WriteArrayHeader(possibleFiniteStateList.PossibleState.Count);
            foreach (var orderedItem in possibleFiniteStateList.PossibleState)
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(((Guid)orderedItem.V).ToByteArray());
            }
            writer.Write(possibleFiniteStateList.ShortName);
            writer.WriteArrayHeader(possibleFiniteStateList.ExcludedDomain.Count);
            foreach (var identifier in possibleFiniteStateList.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(possibleFiniteStateList.ExcludedPerson.Count);
            foreach (var identifier in possibleFiniteStateList.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(possibleFiniteStateList.ModifiedOn);
            writer.Write(possibleFiniteStateList.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="PossibleFiniteStateList"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="PossibleFiniteStateList"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="PossibleFiniteStateList"/>.
        /// </returns>
        public PossibleFiniteStateList Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var possibleFiniteStateList = new PossibleFiniteStateList();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        possibleFiniteStateList.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        possibleFiniteStateList.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            possibleFiniteStateList.DefaultState = null;
                        }
                        else
                        {
                            possibleFiniteStateList.DefaultState = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        possibleFiniteStateList.Name = reader.ReadString();
                        break;
                    case 8:
                        possibleFiniteStateList.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadBytes().ToGuid();
                            possibleFiniteStateList.PossibleState.Add(orderedItem);
                        }
                        break;
                    case 10:
                        possibleFiniteStateList.ShortName = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            possibleFiniteStateList.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        possibleFiniteStateList.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        possibleFiniteStateList.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return possibleFiniteStateList;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
