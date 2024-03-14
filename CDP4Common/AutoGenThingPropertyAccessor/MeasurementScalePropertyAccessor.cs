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
    using CDP4Common.Types;

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
                case "container":
                    return base.QueryThingValues(pd.Input);
                case "alias":
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

        /// <summary>
        /// Sets the value of the specified property
        /// </summary>
        /// <param name="path">The path of the property for which the value is to be set</param>
        /// <param name="value">Any value to set</param>
        /// <exception cref="ArgumentException">If the type of the <paramref name="value"/> do not match the type of the property to set</exception>
        /// <remarks>This action override the currently set value, if any</remarks>
        public override void SetValue(string path, object value)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);
            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "revisionnumber":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "classkind":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludeddomain":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludedperson":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "modifiedon":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "thingpreference":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "actor":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "alias":
                    base.SetValue(pd.Input, value);
                    return;
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isDeprecatedValue || (value is string isDeprecatedString) && bool.TryParse(isDeprecatedString, out isDeprecatedValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsDeprecated = isDeprecatedValue;
                    return;
                case "ismaximuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isMaximumInclusiveValue || (value is string isMaximumInclusiveString) && bool.TryParse(isMaximumInclusiveString, out isMaximumInclusiveValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsMaximumInclusive = isMaximumInclusiveValue;
                    return;
                case "isminimuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isMinimumInclusiveValue || (value is string isMinimumInclusiveString) && bool.TryParse(isMinimumInclusiveString, out isMinimumInclusiveValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsMinimumInclusive = isMinimumInclusiveValue;
                    return;
                case "mappingtoreferencescale":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.MappingToReferenceScale.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case MappingToReferenceScale mappingToReferenceScaleValue:
                            this.MappingToReferenceScale.Clear();
                            this.MappingToReferenceScale.Add(mappingToReferenceScaleValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.MappingToReferenceScale.Clear();
                            this.MappingToReferenceScale.AddRange(thingValues.OfType<MappingToReferenceScale>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MappingToReferenceScale or a collection of MappingToReferenceScale" , nameof(value));
                    }
                case "maximumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.MaximumPermissibleValue = null;
                        return;
                    }

                    if(!(value is string maximumPermissibleValueValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.MaximumPermissibleValue = maximumPermissibleValueValue;
                    return;
                case "minimumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.MinimumPermissibleValue = null;
                        return;
                    }

                    if(!(value is string minimumPermissibleValueValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.MinimumPermissibleValue = minimumPermissibleValueValue;
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "negativevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.NegativeValueConnotation = null;
                        return;
                    }

                    if(!(value is string negativeValueConnotationValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.NegativeValueConnotation = negativeValueConnotationValue;
                    return;
                case "numberset":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is NumberSetKind numberSetValue || (value is string numberSetString) && NumberSetKind.TryParse(numberSetString, out numberSetValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a NumberSetKind" , nameof(value));
                    }

                    this.NumberSet = numberSetValue;
                    return;
                case "positivevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.PositiveValueConnotation = null;
                        return;
                    }

                    if(!(value is string positiveValueConnotationValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.PositiveValueConnotation = positiveValueConnotationValue;
                    return;
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "unit":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is MeasurementUnit unitValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MeasurementUnit" , nameof(value));
                    }

                    this.Unit = unitValue;
                    return;
                case "valuedefinition":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ValueDefinition.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ScaleValueDefinition valueDefinitionValue:
                            this.ValueDefinition.Clear();
                            this.ValueDefinition.Add(valueDefinitionValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ValueDefinition.Clear();
                            this.ValueDefinition.AddRange(thingValues.OfType<ScaleValueDefinition>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ScaleValueDefinition or a collection of ScaleValueDefinition" , nameof(value));
                    }
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
