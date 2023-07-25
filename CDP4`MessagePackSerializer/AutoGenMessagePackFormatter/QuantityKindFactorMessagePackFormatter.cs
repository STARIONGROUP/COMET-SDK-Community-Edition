// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindFactorMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | exponent                             | string                       | 1..1        |  1.0.0  |
 | 3     | quantityKind                         | Guid                         | 1..1        |  1.0.0  |
 | 4     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 7     | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="QuantityKindFactorMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="QuantityKindFactor"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class QuantityKindFactorMessagePackFormatter : IMessagePackFormatter<QuantityKindFactor>
    {
        /// <summary>
        /// Serializes an <see cref="QuantityKindFactor"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="quantityKindFactor">
        /// The <see cref="QuantityKindFactor"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, QuantityKindFactor quantityKindFactor, MessagePackSerializerOptions options)
        {
            if (quantityKindFactor == null)
            {
                throw new ArgumentNullException(nameof(quantityKindFactor), "The QuantityKindFactor may not be null");
            }

            writer.WriteArrayHeader(8);

            writer.Write(quantityKindFactor.Iid.ToByteArray());
            writer.Write(quantityKindFactor.RevisionNumber);

            writer.Write(quantityKindFactor.Exponent);
            writer.Write(quantityKindFactor.QuantityKind.ToByteArray());
            writer.WriteArrayHeader(quantityKindFactor.ExcludedDomain.Count);
            foreach (var identifier in quantityKindFactor.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(quantityKindFactor.ExcludedPerson.Count);
            foreach (var identifier in quantityKindFactor.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(quantityKindFactor.ModifiedOn);
            writer.Write(quantityKindFactor.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="QuantityKindFactor"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="QuantityKindFactor"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="QuantityKindFactor"/>.
        /// </returns>
        public QuantityKindFactor Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var quantityKindFactor = new QuantityKindFactor();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        quantityKindFactor.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        quantityKindFactor.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        quantityKindFactor.Exponent = reader.ReadString();
                        break;
                    case 3:
                        quantityKindFactor.QuantityKind = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            quantityKindFactor.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            quantityKindFactor.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        quantityKindFactor.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 7:
                        quantityKindFactor.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return quantityKindFactor;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
