// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | computed                             | ValueArray<string>           | 1..*        |  1.0.0  |
 | 3     | formula                              | ValueArray<string>           | 1..*        |  1.0.0  |
 | 4     | manual                               | ValueArray<string>           | 1..*        |  1.0.0  |
 | 5     | parameterValueSet                    | Guid                         | 1..1        |  1.0.0  |
 | 6     | published                            | ValueArray<string>           | 1..*        |  1.0.0  |
 | 7     | reference                            | ValueArray<string>           | 1..*        |  1.0.0  |
 | 8     | valueSwitch                          | ParameterSwitchKind          | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ParameterOverrideValueSetMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterOverrideValueSet"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterOverrideValueSetMessagePackFormatter : IMessagePackFormatter<ParameterOverrideValueSet>
    {
        /// <summary>
        /// Serializes an <see cref="ParameterOverrideValueSet"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterOverrideValueSet">
        /// The <see cref="ParameterOverrideValueSet"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterOverrideValueSet parameterOverrideValueSet, MessagePackSerializerOptions options)
        {
            if (parameterOverrideValueSet == null)
            {
                throw new ArgumentNullException(nameof(parameterOverrideValueSet), "The ParameterOverrideValueSet may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(parameterOverrideValueSet.Iid.ToByteArray());
            writer.Write(parameterOverrideValueSet.RevisionNumber);

            writer.WriteArrayHeader(parameterOverrideValueSet.Computed.Count);
            foreach (var valueArrayItem in parameterOverrideValueSet.Computed)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterOverrideValueSet.Formula.Count);
            foreach (var valueArrayItem in parameterOverrideValueSet.Formula)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterOverrideValueSet.Manual.Count);
            foreach (var valueArrayItem in parameterOverrideValueSet.Manual)
            {
                writer.Write(valueArrayItem);
            }
            writer.Write(parameterOverrideValueSet.ParameterValueSet.ToByteArray());
            writer.WriteArrayHeader(parameterOverrideValueSet.Published.Count);
            foreach (var valueArrayItem in parameterOverrideValueSet.Published)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(parameterOverrideValueSet.Reference.Count);
            foreach (var valueArrayItem in parameterOverrideValueSet.Reference)
            {
                writer.Write(valueArrayItem);
            }
            writer.Write(parameterOverrideValueSet.ValueSwitch.ToString());
            writer.WriteArrayHeader(parameterOverrideValueSet.ExcludedDomain.Count);
            foreach (var identifier in parameterOverrideValueSet.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterOverrideValueSet.ExcludedPerson.Count);
            foreach (var identifier in parameterOverrideValueSet.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterOverrideValueSet.ModifiedOn);
            writer.Write(parameterOverrideValueSet.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterOverrideValueSet"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterOverrideValueSet"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterOverrideValueSet"/>.
        /// </returns>
        public ParameterOverrideValueSet Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterOverrideValueSet = new ParameterOverrideValueSet();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterOverrideValueSet.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterOverrideValueSet.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        var parameterOverrideValueSetComputed = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSetComputed.Add(reader.ReadString());
                        }
                        parameterOverrideValueSet.Computed = new ValueArray<string>(parameterOverrideValueSetComputed);
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        var parameterOverrideValueSetFormula = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSetFormula.Add(reader.ReadString());
                        }
                        parameterOverrideValueSet.Formula = new ValueArray<string>(parameterOverrideValueSetFormula);
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        var parameterOverrideValueSetManual = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSetManual.Add(reader.ReadString());
                        }
                        parameterOverrideValueSet.Manual = new ValueArray<string>(parameterOverrideValueSetManual);
                        break;
                    case 5:
                        parameterOverrideValueSet.ParameterValueSet = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        var parameterOverrideValueSetPublished = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSetPublished.Add(reader.ReadString());
                        }
                        parameterOverrideValueSet.Published = new ValueArray<string>(parameterOverrideValueSetPublished);
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        var parameterOverrideValueSetReference = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSetReference.Add(reader.ReadString());
                        }
                        parameterOverrideValueSet.Reference = new ValueArray<string>(parameterOverrideValueSetReference);
                        break;
                    case 8:
                        parameterOverrideValueSet.ValueSwitch = (CDP4Common.EngineeringModelData.ParameterSwitchKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), reader.ReadString(), true);
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSet.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterOverrideValueSet.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        parameterOverrideValueSet.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        parameterOverrideValueSet.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterOverrideValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
