// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpressionMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | parameterType                        | Guid                         | 1..1        |  1.0.0  |
 | 3     | relationalOperator                   | RelationalOperatorKind       | 1..1        |  1.0.0  |
 | 4     | scale                                | Guid                         | 0..1        |  1.0.0  |
 | 5     | value                                | ValueArray<string>           | 1..*        |  1.0.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="RelationalExpressionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="RelationalExpression"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class RelationalExpressionMessagePackFormatter : IMessagePackFormatter<RelationalExpression>
    {
        /// <summary>
        /// Serializes an <see cref="RelationalExpression"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="relationalExpression">
        /// The <see cref="RelationalExpression"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, RelationalExpression relationalExpression, MessagePackSerializerOptions options)
        {
            if (relationalExpression == null)
            {
                throw new ArgumentNullException(nameof(relationalExpression), "The RelationalExpression may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(relationalExpression.Iid.ToByteArray());
            writer.Write(relationalExpression.RevisionNumber);

            writer.Write(relationalExpression.ParameterType.ToByteArray());
            writer.Write(relationalExpression.RelationalOperator.ToString());
            if (relationalExpression.Scale.HasValue)
            {
                writer.Write(relationalExpression.Scale.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(relationalExpression.Value.Count);
            foreach (var valueArrayItem in relationalExpression.Value)
            {
                writer.Write(valueArrayItem);
            }
            writer.WriteArrayHeader(relationalExpression.ExcludedDomain.Count);
            foreach (var identifier in relationalExpression.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(relationalExpression.ExcludedPerson.Count);
            foreach (var identifier in relationalExpression.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(relationalExpression.ModifiedOn);
            writer.Write(relationalExpression.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="RelationalExpression"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="RelationalExpression"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="RelationalExpression"/>.
        /// </returns>
        public RelationalExpression Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var relationalExpression = new RelationalExpression();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        relationalExpression.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        relationalExpression.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        relationalExpression.ParameterType = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        relationalExpression.RelationalOperator = (CDP4Common.EngineeringModelData.RelationalOperatorKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.RelationalOperatorKind), reader.ReadString(), true);
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            relationalExpression.Scale = null;
                        }
                        else
                        {
                            relationalExpression.Scale = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        var relationalExpressionValue = new List<string>();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            relationalExpressionValue.Add(reader.ReadString());
                        }
                        relationalExpression.Value = new ValueArray<string>(relationalExpressionValue);
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            relationalExpression.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            relationalExpression.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        relationalExpression.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        relationalExpression.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return relationalExpression;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
