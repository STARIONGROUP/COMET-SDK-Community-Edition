// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 5     | isAbstract                           | bool                         | 1..1        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | permissibleClass                     | ClassKind                    | 1..*        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | superCategory                        | Guid                         | 0..*        |  1.0.0  |
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
    /// The purpose of the <see cref="CategoryMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Category"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class CategoryMessagePackFormatter : IMessagePackFormatter<Category>
    {
        /// <summary>
        /// Serializes an <see cref="Category"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="category">
        /// The <see cref="Category"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Category category, MessagePackSerializerOptions options)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "The Category may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(category.Iid.ToByteArray());
            writer.Write(category.RevisionNumber);

            writer.WriteArrayHeader(category.Alias.Count);
            foreach (var identifier in category.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(category.Definition.Count);
            foreach (var identifier in category.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(category.HyperLink.Count);
            foreach (var identifier in category.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(category.IsAbstract);
            writer.Write(category.IsDeprecated);
            writer.Write(category.Name);
            writer.WriteArrayHeader(category.PermissibleClass.Count);
            foreach (var @enum in category.PermissibleClass)
            {
                writer.Write(@enum.ToString());
            }
            writer.Write(category.ShortName);
            writer.WriteArrayHeader(category.SuperCategory.Count);
            foreach (var identifier in category.SuperCategory)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(category.ExcludedDomain.Count);
            foreach (var identifier in category.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(category.ExcludedPerson.Count);
            foreach (var identifier in category.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(category.ModifiedOn);
            writer.Write(category.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Category"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Category"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Category"/>.
        /// </returns>
        public Category Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var category = new Category();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        category.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        category.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        category.IsAbstract = reader.ReadBoolean();
                        break;
                    case 6:
                        category.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        category.Name = reader.ReadString();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var @enum = (CDP4Common.CommonData.ClassKind)Enum.Parse(typeof(CDP4Common.CommonData.ClassKind), reader.ReadString(), true);
                            category.PermissibleClass.Add(@enum);
                        }
                        break;
                    case 9:
                        category.ShortName = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.SuperCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            category.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        category.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        category.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return category;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
