// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | name                                 | string                       | 1..1        |  1.0.0  |
 | 7     | nestedElement                        | Guid                         | 0..*        |  1.0.0  |
 | 8     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 12    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="OptionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Option"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class OptionMessagePackFormatter : IMessagePackFormatter<Option>
    {
        /// <summary>
        /// Serializes an <see cref="Option"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Option option, MessagePackSerializerOptions options)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option), "The Option may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(option.Iid.ToByteArray());
            writer.Write(option.RevisionNumber);

            writer.WriteArrayHeader(option.Alias.Count);
            foreach (var identifier in option.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(option.Category.Count);
            foreach (var identifier in option.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(option.Definition.Count);
            foreach (var identifier in option.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(option.HyperLink.Count);
            foreach (var identifier in option.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(option.Name);
            writer.WriteArrayHeader(option.NestedElement.Count);
            foreach (var identifier in option.NestedElement)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(option.ShortName);
            writer.WriteArrayHeader(option.ExcludedDomain.Count);
            foreach (var identifier in option.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(option.ExcludedPerson.Count);
            foreach (var identifier in option.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(option.ModifiedOn);
            writer.Write(option.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Option"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Option"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Option"/>.
        /// </returns>
        public Option Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var option = new Option();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        option.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        option.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        option.Name = reader.ReadString();
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.NestedElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        option.ShortName = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            option.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        option.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        option.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return option;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
