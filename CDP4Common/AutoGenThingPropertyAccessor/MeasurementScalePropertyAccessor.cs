// ------------------------------------------------------------------------------------------------
// <copyright file="MeasurementScalePropertyAccessor.cs" company="RHEA System S.A.">
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
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.PropertyAccesor;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class MeasurementScale
    {
        /// <summary>
        /// Queries the value(s) of the specified property
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <returns>
        /// an object that represents the value.
        /// </returns>
        /// <remarks>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof
        /// </remarks>
        public override object QueryValue(string path)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    return base.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return base.QueryThingValues(pd.Input);
                case "classkind":
                    return base.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return base.QueryThingValues(pd.Input);
                case "excludedperson":
                    return base.QueryThingValues(pd.Input);
                case "modifiedon":
                    return base.QueryThingValues(pd.Input);
                case "thingpreference":
                    return base.QueryThingValues(pd.Input);
                case "actor":
                    return base.QueryThingValues(pd.Input);
                case "alias":
                    return base.QueryValue(pd.Input);
                case "attachment":
                    return base.QueryValue(pd.Input);
                case "definition":
                    return base.QueryValue(pd.Input);
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsDeprecated;
                case "ismaximuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsMaximumInclusive;
                case "isminimuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsMinimumInclusive;
                case "mappingtoreferencescale":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var mappingToReferenceScaleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && mappingToReferenceScaleUpperBound == int.MaxValue && !this.MappingToReferenceScale.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<MappingToReferenceScale>();
                        }

                        var sentinelMappingToReferenceScale = new MappingToReferenceScale(Guid.Empty, null, null);

                        return sentinelMappingToReferenceScale.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        mappingToReferenceScaleUpperBound = this.MappingToReferenceScale.Count - 1;
                    }

                    if (this.MappingToReferenceScale.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for MappingToReferenceScale property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.MappingToReferenceScale.Count - 1 < mappingToReferenceScaleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the MappingToReferenceScale property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.MappingToReferenceScale[pd.Lower.Value];
                        }

                        return this.MappingToReferenceScale[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var mappingToReferenceScaleObjects = new List<MappingToReferenceScale>();

                        for (var i = pd.Lower.Value; i < mappingToReferenceScaleUpperBound + 1; i++)
                        {
                            mappingToReferenceScaleObjects.Add(this.MappingToReferenceScale[i]);
                        }

                        return mappingToReferenceScaleObjects;
                    }

                    var mappingToReferenceScaleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < mappingToReferenceScaleUpperBound + 1; i++)
                    {
                        var queryResult = this.MappingToReferenceScale[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    mappingToReferenceScaleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                mappingToReferenceScaleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return mappingToReferenceScaleNextObjects;
                case "maximumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.MaximumPermissibleValue;
                case "minimumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.MinimumPermissibleValue;
                case "name":
                    return base.QueryValue(pd.Input);
                case "negativevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.NegativeValueConnotation;
                case "numberset":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.NumberSet;
                case "positivevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.PositiveValueConnotation;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "unit":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Unit;
                    }

                    if (this.Unit != null)
                    {
                        return this.Unit.QueryValue(pd.Next.Input);
                    }

                    var sentinelunit = new DerivedUnit(Guid.Empty, null, null);
                    return sentinelunit.QuerySentinelValue(pd.Next.Input, false);
                case "valuedefinition":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var valueDefinitionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && valueDefinitionUpperBound == int.MaxValue && !this.ValueDefinition.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ScaleValueDefinition>();
                        }

                        var sentinelScaleValueDefinition = new ScaleValueDefinition(Guid.Empty, null, null);

                        return sentinelScaleValueDefinition.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        valueDefinitionUpperBound = this.ValueDefinition.Count - 1;
                    }

                    if (this.ValueDefinition.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ValueDefinition property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ValueDefinition.Count - 1 < valueDefinitionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ValueDefinition property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ValueDefinition[pd.Lower.Value];
                        }

                        return this.ValueDefinition[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var valueDefinitionObjects = new List<ScaleValueDefinition>();

                        for (var i = pd.Lower.Value; i < valueDefinitionUpperBound + 1; i++)
                        {
                            valueDefinitionObjects.Add(this.ValueDefinition[i]);
                        }

                        return valueDefinitionObjects;
                    }

                    var valueDefinitionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < valueDefinitionUpperBound + 1; i++)
                    {
                        var queryResult = this.ValueDefinition[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    valueDefinitionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                valueDefinitionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return valueDefinitionNextObjects;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
