// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleReferenceQuantityValueMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | scale                                | Guid                         | 1..1        |  1.0.0  |
 | 3     | value                                | string                       | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ScaleReferenceQuantityValueMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ScaleReferenceQuantityValue"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ScaleReferenceQuantityValueMessagePackFormatter : IMessagePackFormatter<ScaleReferenceQuantityValue>
    {
        /// <summary>
        /// Serializes an <see cref="ScaleReferenceQuantityValue"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="scaleReferenceQuantityValue">
        /// The <see cref="ScaleReferenceQuantityValue"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ScaleReferenceQuantityValue scaleReferenceQuantityValue, MessagePackSerializerOptions options)
        {
            if (scaleReferenceQuantityValue == null)
            {
                throw new ArgumentNullException(nameof(scaleReferenceQuantityValue), "The ScaleReferenceQuantityValue may not be null");
            }

            writer.WriteArrayHeader(8);

            writer.Write(scaleReferenceQuantityValue.Iid.ToByteArray());
            writer.Write(scaleReferenceQuantityValue.RevisionNumber);

            writer.Write(scaleReferenceQuantityValue.Scale.ToByteArray());
            writer.Write(scaleReferenceQuantityValue.Value);
            writer.WriteArrayHeader(scaleReferenceQuantityValue.ExcludedDomain.Count);
            foreach (var identifier in scaleReferenceQuantityValue.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(scaleReferenceQuantityValue.ExcludedPerson.Count);
            foreach (var identifier in scaleReferenceQuantityValue.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(scaleReferenceQuantityValue.ModifiedOn);
            writer.Write(scaleReferenceQuantityValue.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ScaleReferenceQuantityValue"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ScaleReferenceQuantityValue"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ScaleReferenceQuantityValue"/>.
        /// </returns>
        public ScaleReferenceQuantityValue Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var scaleReferenceQuantityValue = new ScaleReferenceQuantityValue();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        scaleReferenceQuantityValue.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        scaleReferenceQuantityValue.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        scaleReferenceQuantityValue.Scale = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        scaleReferenceQuantityValue.Value = reader.ReadString();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleReferenceQuantityValue.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleReferenceQuantityValue.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        scaleReferenceQuantityValue.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 7:
                        scaleReferenceQuantityValue.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return scaleReferenceQuantityValue;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
