// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearConversionUnitMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | conversionFactor                     | string                       | 1..1        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | referenceUnit                        | Guid                         | 1..1        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="LinearConversionUnitMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="LinearConversionUnit"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class LinearConversionUnitMessagePackFormatter : IMessagePackFormatter<LinearConversionUnit>
    {
        /// <summary>
        /// Serializes an <see cref="LinearConversionUnit"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="linearConversionUnit">
        /// The <see cref="LinearConversionUnit"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, LinearConversionUnit linearConversionUnit, MessagePackSerializerOptions options)
        {
            if (linearConversionUnit == null)
            {
                throw new ArgumentNullException(nameof(linearConversionUnit), "The LinearConversionUnit may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(linearConversionUnit.Iid.ToByteArray());
            writer.Write(linearConversionUnit.RevisionNumber);

            writer.WriteArrayHeader(linearConversionUnit.Alias.Count);
            foreach (var identifier in linearConversionUnit.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(linearConversionUnit.ConversionFactor);
            writer.WriteArrayHeader(linearConversionUnit.Definition.Count);
            foreach (var identifier in linearConversionUnit.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(linearConversionUnit.HyperLink.Count);
            foreach (var identifier in linearConversionUnit.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(linearConversionUnit.IsDeprecated);
            writer.Write(linearConversionUnit.Name);
            writer.Write(linearConversionUnit.ReferenceUnit.ToByteArray());
            writer.Write(linearConversionUnit.ShortName);
            writer.WriteArrayHeader(linearConversionUnit.ExcludedDomain.Count);
            foreach (var identifier in linearConversionUnit.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(linearConversionUnit.ExcludedPerson.Count);
            foreach (var identifier in linearConversionUnit.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(linearConversionUnit.ModifiedOn);
            writer.Write(linearConversionUnit.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="LinearConversionUnit"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="LinearConversionUnit"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="LinearConversionUnit"/>.
        /// </returns>
        public LinearConversionUnit Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var linearConversionUnit = new LinearConversionUnit();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        linearConversionUnit.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        linearConversionUnit.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            linearConversionUnit.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        linearConversionUnit.ConversionFactor = reader.ReadString();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            linearConversionUnit.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            linearConversionUnit.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        linearConversionUnit.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        linearConversionUnit.Name = reader.ReadString();
                        break;
                    case 8:
                        linearConversionUnit.ReferenceUnit = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        linearConversionUnit.ShortName = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            linearConversionUnit.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            linearConversionUnit.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        linearConversionUnit.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        linearConversionUnit.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return linearConversionUnit;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
