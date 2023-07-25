// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKindMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 11    | quantityKindFactor                   | Guid                         | 1..*        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 14    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 17    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="DerivedQuantityKindMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DerivedQuantityKind"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class DerivedQuantityKindMessagePackFormatter : IMessagePackFormatter<DerivedQuantityKind>
    {
        /// <summary>
        /// Serializes an <see cref="DerivedQuantityKind"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="derivedQuantityKind">
        /// The <see cref="DerivedQuantityKind"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DerivedQuantityKind derivedQuantityKind, MessagePackSerializerOptions options)
        {
            if (derivedQuantityKind == null)
            {
                throw new ArgumentNullException(nameof(derivedQuantityKind), "The DerivedQuantityKind may not be null");
            }

            writer.WriteArrayHeader(18);

            writer.Write(derivedQuantityKind.Iid.ToByteArray());
            writer.Write(derivedQuantityKind.RevisionNumber);

            writer.WriteArrayHeader(derivedQuantityKind.Alias.Count);
            foreach (var identifier in derivedQuantityKind.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(derivedQuantityKind.Category.Count);
            foreach (var identifier in derivedQuantityKind.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(derivedQuantityKind.DefaultScale.ToByteArray());
            writer.WriteArrayHeader(derivedQuantityKind.Definition.Count);
            foreach (var identifier in derivedQuantityKind.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(derivedQuantityKind.HyperLink.Count);
            foreach (var identifier in derivedQuantityKind.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(derivedQuantityKind.IsDeprecated);
            writer.Write(derivedQuantityKind.Name);
            writer.WriteArrayHeader(derivedQuantityKind.PossibleScale.Count);
            foreach (var identifier in derivedQuantityKind.PossibleScale)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(derivedQuantityKind.QuantityDimensionSymbol);
            writer.WriteArrayHeader(derivedQuantityKind.QuantityKindFactor.Count);
            foreach (var orderedItem in derivedQuantityKind.QuantityKindFactor)
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(((Guid)orderedItem.V).ToByteArray());
            }
            writer.Write(derivedQuantityKind.ShortName);
            writer.Write(derivedQuantityKind.Symbol);
            writer.WriteArrayHeader(derivedQuantityKind.ExcludedDomain.Count);
            foreach (var identifier in derivedQuantityKind.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(derivedQuantityKind.ExcludedPerson.Count);
            foreach (var identifier in derivedQuantityKind.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(derivedQuantityKind.ModifiedOn);
            writer.Write(derivedQuantityKind.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DerivedQuantityKind"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DerivedQuantityKind"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DerivedQuantityKind"/>.
        /// </returns>
        public DerivedQuantityKind Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var derivedQuantityKind = new DerivedQuantityKind();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        derivedQuantityKind.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        derivedQuantityKind.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        derivedQuantityKind.DefaultScale = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        derivedQuantityKind.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        derivedQuantityKind.Name = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.PossibleScale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        derivedQuantityKind.QuantityDimensionSymbol = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadBytes().ToGuid();
                            derivedQuantityKind.QuantityKindFactor.Add(orderedItem);
                        }
                        break;
                    case 12:
                        derivedQuantityKind.ShortName = reader.ReadString();
                        break;
                    case 13:
                        derivedQuantityKind.Symbol = reader.ReadString();
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            derivedQuantityKind.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        derivedQuantityKind.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 17:
                        derivedQuantityKind.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return derivedQuantityKind;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
