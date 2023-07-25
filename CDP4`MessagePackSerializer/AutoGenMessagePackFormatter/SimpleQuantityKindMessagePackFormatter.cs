// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleQuantityKindMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 4     | defaultScale                         | Guid                         | 1..1        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | possibleScale                        | Guid                         | 0..*        |  1.0.0  |
 | 10    | quantityDimensionSymbol              | string                       | 0..1        |  1.0.0  |
 | 11    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 12    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 16    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="SimpleQuantityKindMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SimpleQuantityKind"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SimpleQuantityKindMessagePackFormatter : IMessagePackFormatter<SimpleQuantityKind>
    {
        /// <summary>
        /// Serializes an <see cref="SimpleQuantityKind"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="simpleQuantityKind">
        /// The <see cref="SimpleQuantityKind"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SimpleQuantityKind simpleQuantityKind, MessagePackSerializerOptions options)
        {
            if (simpleQuantityKind == null)
            {
                throw new ArgumentNullException(nameof(simpleQuantityKind), "The SimpleQuantityKind may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(simpleQuantityKind.Iid.ToByteArray());
            writer.Write(simpleQuantityKind.RevisionNumber);

            writer.WriteArrayHeader(simpleQuantityKind.Alias.Count);
            foreach (var identifier in simpleQuantityKind.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(simpleQuantityKind.Category.Count);
            foreach (var identifier in simpleQuantityKind.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(simpleQuantityKind.DefaultScale.ToByteArray());
            writer.WriteArrayHeader(simpleQuantityKind.Definition.Count);
            foreach (var identifier in simpleQuantityKind.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(simpleQuantityKind.HyperLink.Count);
            foreach (var identifier in simpleQuantityKind.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(simpleQuantityKind.IsDeprecated);
            writer.Write(simpleQuantityKind.Name);
            writer.WriteArrayHeader(simpleQuantityKind.PossibleScale.Count);
            foreach (var identifier in simpleQuantityKind.PossibleScale)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(simpleQuantityKind.QuantityDimensionSymbol);
            writer.Write(simpleQuantityKind.ShortName);
            writer.Write(simpleQuantityKind.Symbol);
            writer.WriteArrayHeader(simpleQuantityKind.ExcludedDomain.Count);
            foreach (var identifier in simpleQuantityKind.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(simpleQuantityKind.ExcludedPerson.Count);
            foreach (var identifier in simpleQuantityKind.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(simpleQuantityKind.ModifiedOn);
            writer.Write(simpleQuantityKind.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SimpleQuantityKind"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SimpleQuantityKind"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SimpleQuantityKind"/>.
        /// </returns>
        public SimpleQuantityKind Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var simpleQuantityKind = new SimpleQuantityKind();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        simpleQuantityKind.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        simpleQuantityKind.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        simpleQuantityKind.DefaultScale = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        simpleQuantityKind.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        simpleQuantityKind.Name = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.PossibleScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        simpleQuantityKind.QuantityDimensionSymbol = reader.ReadString();
                        break;
                    case 11:
                        simpleQuantityKind.ShortName = reader.ReadString();
                        break;
                    case 12:
                        simpleQuantityKind.Symbol = reader.ReadString();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            simpleQuantityKind.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        simpleQuantityKind.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        simpleQuantityKind.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return simpleQuantityKind;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
