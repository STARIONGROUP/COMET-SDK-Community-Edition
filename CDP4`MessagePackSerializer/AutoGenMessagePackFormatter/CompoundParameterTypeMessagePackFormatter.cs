// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterTypeMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 4     | component                            | Guid                         | 1..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | isFinalized                          | bool                         | 1..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 11    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="CompoundParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="CompoundParameterType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class CompoundParameterTypeMessagePackFormatter : IMessagePackFormatter<CompoundParameterType>
    {
        /// <summary>
        /// Serializes an <see cref="CompoundParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="compoundParameterType">
        /// The <see cref="CompoundParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, CompoundParameterType compoundParameterType, MessagePackSerializerOptions options)
        {
            if (compoundParameterType == null)
            {
                throw new ArgumentNullException(nameof(compoundParameterType), "The CompoundParameterType may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(compoundParameterType.Iid.ToByteArray());
            writer.Write(compoundParameterType.RevisionNumber);

            writer.WriteArrayHeader(compoundParameterType.Alias.Count);
            foreach (var identifier in compoundParameterType.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(compoundParameterType.Category.Count);
            foreach (var identifier in compoundParameterType.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(compoundParameterType.Component.Count);
            foreach (var orderedItem in compoundParameterType.Component)
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(((Guid)orderedItem.V).ToByteArray());
            }
            writer.WriteArrayHeader(compoundParameterType.Definition.Count);
            foreach (var identifier in compoundParameterType.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(compoundParameterType.HyperLink.Count);
            foreach (var identifier in compoundParameterType.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(compoundParameterType.IsDeprecated);
            writer.Write(compoundParameterType.IsFinalized);
            writer.Write(compoundParameterType.Name);
            writer.Write(compoundParameterType.ShortName);
            writer.Write(compoundParameterType.Symbol);
            writer.WriteArrayHeader(compoundParameterType.ExcludedDomain.Count);
            foreach (var identifier in compoundParameterType.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(compoundParameterType.ExcludedPerson.Count);
            foreach (var identifier in compoundParameterType.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(compoundParameterType.ModifiedOn);
            writer.Write(compoundParameterType.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="CompoundParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="CompoundParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="CompoundParameterType"/>.
        /// </returns>
        public CompoundParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var compoundParameterType = new CompoundParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        compoundParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        compoundParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadBytes().ToGuid();
                            compoundParameterType.Component.Add(orderedItem);
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        compoundParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        compoundParameterType.IsFinalized = reader.ReadBoolean();
                        break;
                    case 9:
                        compoundParameterType.Name = reader.ReadString();
                        break;
                    case 10:
                        compoundParameterType.ShortName = reader.ReadString();
                        break;
                    case 11:
                        compoundParameterType.Symbol = reader.ReadString();
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            compoundParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        compoundParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        compoundParameterType.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return compoundParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
