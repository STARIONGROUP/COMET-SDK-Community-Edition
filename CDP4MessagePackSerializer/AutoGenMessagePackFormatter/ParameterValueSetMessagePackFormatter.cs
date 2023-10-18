// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | actualOption                         | Guid                         | 0..1        |  1.0.0  |
 | 3     | actualState                          | Guid                         | 0..1        |  1.0.0  |
 | 4     | computed                             | ValueArray<string>           | 1..*        |  1.0.0  |
 | 5     | formula                              | ValueArray<string>           | 1..*        |  1.0.0  |
 | 6     | manual                               | ValueArray<string>           | 1..*        |  1.0.0  |
 | 7     | published                            | ValueArray<string>           | 1..*        |  1.0.0  |
 | 8     | reference                            | ValueArray<string>           | 1..*        |  1.0.0  |
 | 9     | valueSwitch                          | ParameterSwitchKind          | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ParameterValueSetMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterValueSet"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterValueSetMessagePackFormatter : IMessagePackFormatter<ParameterValueSet>
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
        /// Serializes an <see cref="ParameterValueSet"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterValueSet">
        /// The <see cref="ParameterValueSet"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterValueSet parameterValueSet, MessagePackSerializerOptions options)
        {
            if (parameterValueSet == null)
            {
                throw new ArgumentNullException(nameof(parameterValueSet), "The ParameterValueSet may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(parameterValueSet.Iid.ToByteArray());
            writer.Write(parameterValueSet.RevisionNumber);

            if (parameterValueSet.ActualOption.HasValue)
            {
                writer.Write(parameterValueSet.ActualOption.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (parameterValueSet.ActualState.HasValue)
            {
                writer.Write(parameterValueSet.ActualState.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(parameterValueSet.Computed.Count);
            foreach (var valueArrayItem in parameterValueSet.Computed)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterValueSet.Formula.Count);
            foreach (var valueArrayItem in parameterValueSet.Formula)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterValueSet.Manual.Count);
            foreach (var valueArrayItem in parameterValueSet.Manual)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterValueSet.Published.Count);
            foreach (var valueArrayItem in parameterValueSet.Published)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterValueSet.Reference.Count);
            foreach (var valueArrayItem in parameterValueSet.Reference)
            {
                writer.Write(valueArrayItem);
            }
            writer.Write(parameterValueSet.ValueSwitch.ToString());
            writer.WriteArrayHeader(parameterValueSet.ExcludedDomain.Count);
            foreach (var identifier in parameterValueSet.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterValueSet.ExcludedPerson.Count);
            foreach (var identifier in parameterValueSet.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterValueSet.ModifiedOn);
            writer.Write(parameterValueSet.ThingPreference);
            if (parameterValueSet.Actor.HasValue)
            {
                writer.Write(parameterValueSet.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterValueSet"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterValueSet"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterValueSet"/>.
        /// </returns>
        public ParameterValueSet Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterValueSet = new ParameterValueSet();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterValueSet.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterValueSet.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            parameterValueSet.ActualOption = null;
                        }
                        else
                        {
                            parameterValueSet.ActualOption = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            parameterValueSet.ActualState = null;
                        }
                        else
                        {
                            parameterValueSet.ActualState = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        var parameterValueSetComputed = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSetComputed.Add(reader.ReadString());
                        }
                        parameterValueSet.Computed = new ValueArray<string>(parameterValueSetComputed);
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        var parameterValueSetFormula = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSetFormula.Add(reader.ReadString());
                        }
                        parameterValueSet.Formula = new ValueArray<string>(parameterValueSetFormula);
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        var parameterValueSetManual = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSetManual.Add(reader.ReadString());
                        }
                        parameterValueSet.Manual = new ValueArray<string>(parameterValueSetManual);
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        var parameterValueSetPublished = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSetPublished.Add(reader.ReadString());
                        }
                        parameterValueSet.Published = new ValueArray<string>(parameterValueSetPublished);
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        var parameterValueSetReference = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSetReference.Add(reader.ReadString());
                        }
                        parameterValueSet.Reference = new ValueArray<string>(parameterValueSetReference);
                        break;
                    case 9:
                        parameterValueSet.ValueSwitch = (CDP4Common.EngineeringModelData.ParameterSwitchKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), reader.ReadString(), true);
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSet.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterValueSet.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        parameterValueSet.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        parameterValueSet.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            parameterValueSet.Actor = null;
                        }
                        else
                        {
                            parameterValueSet.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
