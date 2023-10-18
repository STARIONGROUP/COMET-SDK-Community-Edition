// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibraryMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | baseQuantityKind                     | Guid                         | 0..*        |  1.0.0  |
 | 4     | baseUnit                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | constant                             | Guid                         | 0..*        |  1.0.0  |
 | 6     | definedCategory                      | Guid                         | 0..*        |  1.0.0  |
 | 7     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 8     | fileType                             | Guid                         | 0..*        |  1.0.0  |
 | 9     | glossary                             | Guid                         | 0..*        |  1.0.0  |
 | 10    | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 11    | name                                 | string                       | 1..1        |  1.0.0  |
 | 12    | parameterType                        | Guid                         | 0..*        |  1.0.0  |
 | 13    | referenceSource                      | Guid                         | 0..*        |  1.0.0  |
 | 14    | requiredRdl                          | Guid                         | 0..1        |  1.0.0  |
 | 15    | rule                                 | Guid                         | 0..*        |  1.0.0  |
 | 16    | scale                                | Guid                         | 0..*        |  1.0.0  |
 | 17    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 18    | unit                                 | Guid                         | 0..*        |  1.0.0  |
 | 19    | unitPrefix                           | Guid                         | 0..*        |  1.0.0  |
 | 20    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 21    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 22    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 23    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 24    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common;
    using CDP4Common.Comparers;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="ModelReferenceDataLibraryMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ModelReferenceDataLibrary"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ModelReferenceDataLibraryMessagePackFormatter : IMessagePackFormatter<ModelReferenceDataLibrary>
    {
        /// <summary>
        /// The <see cref="GuidComparer"/> used to compare 2 <see cref="Guid"/>s
        /// </summary>
        private static readonly GuidComparer guidComparer = new GuidComparer();

        /// <summary>
        /// The <see cref="OrderedItemComparer"/> used to compare 2 <see cref="OrderedItem"/>s
        /// </summary>
        private static readonly OrderedItemComparer orderedItemComparer = new OrderedItemComparer();

        /// <summary>
        /// Serializes an <see cref="ModelReferenceDataLibrary"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="ModelReferenceDataLibrary"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ModelReferenceDataLibrary modelReferenceDataLibrary, MessagePackSerializerOptions options)
        {
            if (modelReferenceDataLibrary == null)
            {
                throw new ArgumentNullException(nameof(modelReferenceDataLibrary), "The ModelReferenceDataLibrary may not be null");
            }

            writer.WriteArrayHeader(25);

            writer.Write(modelReferenceDataLibrary.Iid.ToByteArray());
            writer.Write(modelReferenceDataLibrary.RevisionNumber);

            writer.WriteArrayHeader(modelReferenceDataLibrary.Alias.Count);
            foreach (var identifier in modelReferenceDataLibrary.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.BaseQuantityKind.Count);
            foreach (var orderedItem in modelReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.BaseUnit.Count);
            foreach (var identifier in modelReferenceDataLibrary.BaseUnit.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.Constant.Count);
            foreach (var identifier in modelReferenceDataLibrary.Constant.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.DefinedCategory.Count);
            foreach (var identifier in modelReferenceDataLibrary.DefinedCategory.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.Definition.Count);
            foreach (var identifier in modelReferenceDataLibrary.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.FileType.Count);
            foreach (var identifier in modelReferenceDataLibrary.FileType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.Glossary.Count);
            foreach (var identifier in modelReferenceDataLibrary.Glossary.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.HyperLink.Count);
            foreach (var identifier in modelReferenceDataLibrary.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(modelReferenceDataLibrary.Name);
            writer.WriteArrayHeader(modelReferenceDataLibrary.ParameterType.Count);
            foreach (var identifier in modelReferenceDataLibrary.ParameterType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.ReferenceSource.Count);
            foreach (var identifier in modelReferenceDataLibrary.ReferenceSource.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (modelReferenceDataLibrary.RequiredRdl.HasValue)
            {
                writer.Write(modelReferenceDataLibrary.RequiredRdl.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.Rule.Count);
            foreach (var identifier in modelReferenceDataLibrary.Rule.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.Scale.Count);
            foreach (var identifier in modelReferenceDataLibrary.Scale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(modelReferenceDataLibrary.ShortName);
            writer.WriteArrayHeader(modelReferenceDataLibrary.Unit.Count);
            foreach (var identifier in modelReferenceDataLibrary.Unit.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.UnitPrefix.Count);
            foreach (var identifier in modelReferenceDataLibrary.UnitPrefix.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.ExcludedDomain.Count);
            foreach (var identifier in modelReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(modelReferenceDataLibrary.ExcludedPerson.Count);
            foreach (var identifier in modelReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(modelReferenceDataLibrary.ModifiedOn);
            writer.Write(modelReferenceDataLibrary.ThingPreference);
            if (modelReferenceDataLibrary.Actor.HasValue)
            {
                writer.Write(modelReferenceDataLibrary.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ModelReferenceDataLibrary"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ModelReferenceDataLibrary"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ModelReferenceDataLibrary"/>.
        /// </returns>
        public ModelReferenceDataLibrary Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var modelReferenceDataLibrary = new ModelReferenceDataLibrary();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        modelReferenceDataLibrary.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        modelReferenceDataLibrary.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            modelReferenceDataLibrary.BaseQuantityKind.Add(orderedItem);
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.BaseUnit.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Constant.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.DefinedCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.FileType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Glossary.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        modelReferenceDataLibrary.Name = reader.ReadString();
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.ParameterType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.ReferenceSource.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            modelReferenceDataLibrary.RequiredRdl = null;
                        }
                        else
                        {
                            modelReferenceDataLibrary.RequiredRdl = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Rule.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Scale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        modelReferenceDataLibrary.ShortName = reader.ReadString();
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.Unit.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.UnitPrefix.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            modelReferenceDataLibrary.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 22:
                        modelReferenceDataLibrary.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 23:
                        modelReferenceDataLibrary.ThingPreference = reader.ReadString();
                        break;
                    case 24:
                        if (reader.TryReadNil())
                        {
                            modelReferenceDataLibrary.Actor = null;
                        }
                        else
                        {
                            modelReferenceDataLibrary.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return modelReferenceDataLibrary;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
