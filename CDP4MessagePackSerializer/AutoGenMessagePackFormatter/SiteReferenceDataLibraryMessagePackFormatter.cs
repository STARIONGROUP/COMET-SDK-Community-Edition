// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibraryMessagePackFormatter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
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
 | 11    | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 12    | name                                 | string                       | 1..1        |  1.0.0  |
 | 13    | parameterType                        | Guid                         | 0..*        |  1.0.0  |
 | 14    | referenceSource                      | Guid                         | 0..*        |  1.0.0  |
 | 15    | requiredRdl                          | Guid                         | 0..1        |  1.0.0  |
 | 16    | rule                                 | Guid                         | 0..*        |  1.0.0  |
 | 17    | scale                                | Guid                         | 0..*        |  1.0.0  |
 | 18    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 19    | unit                                 | Guid                         | 0..*        |  1.0.0  |
 | 20    | unitPrefix                           | Guid                         | 0..*        |  1.0.0  |
 | 21    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 22    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 23    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 24    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 25    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 26    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="SiteReferenceDataLibraryMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SiteReferenceDataLibrary"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SiteReferenceDataLibraryMessagePackFormatter : IMessagePackFormatter<SiteReferenceDataLibrary>
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
        /// Serializes an <see cref="SiteReferenceDataLibrary"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="siteReferenceDataLibrary">
        /// The <see cref="SiteReferenceDataLibrary"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SiteReferenceDataLibrary siteReferenceDataLibrary, MessagePackSerializerOptions options)
        {
            if (siteReferenceDataLibrary == null)
            {
                throw new ArgumentNullException(nameof(siteReferenceDataLibrary), "The SiteReferenceDataLibrary may not be null");
            }

            writer.WriteArrayHeader(27);

            writer.Write(siteReferenceDataLibrary.Iid.ToByteArray());
            writer.Write(siteReferenceDataLibrary.RevisionNumber);

            writer.WriteArrayHeader(siteReferenceDataLibrary.Alias.Count);
            foreach (var identifier in siteReferenceDataLibrary.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.BaseQuantityKind.Count);
            foreach (var orderedItem in siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.BaseUnit.Count);
            foreach (var identifier in siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Constant.Count);
            foreach (var identifier in siteReferenceDataLibrary.Constant.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.DefinedCategory.Count);
            foreach (var identifier in siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Definition.Count);
            foreach (var identifier in siteReferenceDataLibrary.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.FileType.Count);
            foreach (var identifier in siteReferenceDataLibrary.FileType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Glossary.Count);
            foreach (var identifier in siteReferenceDataLibrary.Glossary.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.HyperLink.Count);
            foreach (var identifier in siteReferenceDataLibrary.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteReferenceDataLibrary.IsDeprecated);
            writer.Write(siteReferenceDataLibrary.Name);
            writer.WriteArrayHeader(siteReferenceDataLibrary.ParameterType.Count);
            foreach (var identifier in siteReferenceDataLibrary.ParameterType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.ReferenceSource.Count);
            foreach (var identifier in siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (siteReferenceDataLibrary.RequiredRdl.HasValue)
            {
                writer.Write(siteReferenceDataLibrary.RequiredRdl.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Rule.Count);
            foreach (var identifier in siteReferenceDataLibrary.Rule.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Scale.Count);
            foreach (var identifier in siteReferenceDataLibrary.Scale.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteReferenceDataLibrary.ShortName);
            writer.WriteArrayHeader(siteReferenceDataLibrary.Unit.Count);
            foreach (var identifier in siteReferenceDataLibrary.Unit.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.UnitPrefix.Count);
            foreach (var identifier in siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.ExcludedDomain.Count);
            foreach (var identifier in siteReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.ExcludedPerson.Count);
            foreach (var identifier in siteReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteReferenceDataLibrary.ModifiedOn);
            writer.Write(siteReferenceDataLibrary.ThingPreference);
            if (siteReferenceDataLibrary.Actor.HasValue)
            {
                writer.Write(siteReferenceDataLibrary.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(siteReferenceDataLibrary.Attachment.Count);
            foreach (var identifier in siteReferenceDataLibrary.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SiteReferenceDataLibrary"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SiteReferenceDataLibrary"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SiteReferenceDataLibrary"/>.
        /// </returns>
        public SiteReferenceDataLibrary Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var siteReferenceDataLibrary = new SiteReferenceDataLibrary();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        siteReferenceDataLibrary.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        siteReferenceDataLibrary.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Alias.Add(reader.ReadBytes().ToGuid());
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
                            siteReferenceDataLibrary.BaseQuantityKind.Add(orderedItem);
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.BaseUnit.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Constant.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.DefinedCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.FileType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Glossary.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        siteReferenceDataLibrary.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 12:
                        siteReferenceDataLibrary.Name = reader.ReadString();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.ParameterType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.ReferenceSource.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            siteReferenceDataLibrary.RequiredRdl = null;
                        }
                        else
                        {
                            siteReferenceDataLibrary.RequiredRdl = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Rule.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Scale.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        siteReferenceDataLibrary.ShortName = reader.ReadString();
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Unit.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.UnitPrefix.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 22:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 23:
                        siteReferenceDataLibrary.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 24:
                        siteReferenceDataLibrary.ThingPreference = reader.ReadString();
                        break;
                    case 25:
                        if (reader.TryReadNil())
                        {
                            siteReferenceDataLibrary.Actor = null;
                        }
                        else
                        {
                            siteReferenceDataLibrary.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 26:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteReferenceDataLibrary.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return siteReferenceDataLibrary;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
