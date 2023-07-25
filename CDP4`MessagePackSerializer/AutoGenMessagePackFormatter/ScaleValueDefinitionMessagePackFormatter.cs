// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleValueDefinitionMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 5     | name                                 | string                       | 1..1        |  1.0.0  |
 | 6     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 7     | value                                | string                       | 1..1        |  1.0.0  |
 | 8     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 11    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="ScaleValueDefinitionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ScaleValueDefinition"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ScaleValueDefinitionMessagePackFormatter : IMessagePackFormatter<ScaleValueDefinition>
    {
        /// <summary>
        /// Serializes an <see cref="ScaleValueDefinition"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="scaleValueDefinition">
        /// The <see cref="ScaleValueDefinition"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ScaleValueDefinition scaleValueDefinition, MessagePackSerializerOptions options)
        {
            if (scaleValueDefinition == null)
            {
                throw new ArgumentNullException(nameof(scaleValueDefinition), "The ScaleValueDefinition may not be null");
            }

            writer.WriteArrayHeader(12);

            writer.Write(scaleValueDefinition.Iid.ToByteArray());
            writer.Write(scaleValueDefinition.RevisionNumber);

            writer.WriteArrayHeader(scaleValueDefinition.Alias.Count);
            foreach (var identifier in scaleValueDefinition.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(scaleValueDefinition.Definition.Count);
            foreach (var identifier in scaleValueDefinition.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(scaleValueDefinition.HyperLink.Count);
            foreach (var identifier in scaleValueDefinition.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(scaleValueDefinition.Name);
            writer.Write(scaleValueDefinition.ShortName);
            writer.Write(scaleValueDefinition.Value);
            writer.WriteArrayHeader(scaleValueDefinition.ExcludedDomain.Count);
            foreach (var identifier in scaleValueDefinition.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(scaleValueDefinition.ExcludedPerson.Count);
            foreach (var identifier in scaleValueDefinition.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(scaleValueDefinition.ModifiedOn);
            writer.Write(scaleValueDefinition.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ScaleValueDefinition"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ScaleValueDefinition"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ScaleValueDefinition"/>.
        /// </returns>
        public ScaleValueDefinition Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var scaleValueDefinition = new ScaleValueDefinition();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        scaleValueDefinition.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        scaleValueDefinition.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleValueDefinition.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleValueDefinition.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleValueDefinition.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        scaleValueDefinition.Name = reader.ReadString();
                        break;
                    case 6:
                        scaleValueDefinition.ShortName = reader.ReadString();
                        break;
                    case 7:
                        scaleValueDefinition.Value = reader.ReadString();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleValueDefinition.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            scaleValueDefinition.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        scaleValueDefinition.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 11:
                        scaleValueDefinition.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return scaleValueDefinition;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
