// ------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScalePropertyAccessor.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    public partial class LogarithmicScale
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
                case "exponent":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Exponent;
                case "factor":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Factor;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "isdeprecated":
                    return base.QueryValue(pd.Input);
                case "ismaximuminclusive":
                    return base.QueryValue(pd.Input);
                case "isminimuminclusive":
                    return base.QueryValue(pd.Input);
                case "logarithmbase":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.LogarithmBase;
                case "mappingtoreferencescale":
                    return base.QueryValue(pd.Input);
                case "maximumpermissiblevalue":
                    return base.QueryValue(pd.Input);
                case "minimumpermissiblevalue":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "negativevalueconnotation":
                    return base.QueryValue(pd.Input);
                case "numberset":
                    return base.QueryValue(pd.Input);
                case "positivevalueconnotation":
                    return base.QueryValue(pd.Input);
                case "referencequantitykind":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.ReferenceQuantityKind;
                    }

                    if (this.ReferenceQuantityKind != null)
                    {
                        return this.ReferenceQuantityKind.QueryValue(pd.Next.Input);
                    }

                    var sentinelreferencequantitykind = new DerivedQuantityKind(Guid.Empty, null, null);
                    return sentinelreferencequantitykind.QuerySentinelValue(pd.Next.Input, false);
                case "referencequantityvalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var referenceQuantityValueUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && referenceQuantityValueUpperBound == int.MaxValue && !this.ReferenceQuantityValue.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ScaleReferenceQuantityValue>();
                        }

                        var sentinelScaleReferenceQuantityValue = new ScaleReferenceQuantityValue(Guid.Empty, null, null);

                        return sentinelScaleReferenceQuantityValue.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        referenceQuantityValueUpperBound = this.ReferenceQuantityValue.Count - 1;
                    }

                    if (this.ReferenceQuantityValue.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ReferenceQuantityValue property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ReferenceQuantityValue.Count - 1 < referenceQuantityValueUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ReferenceQuantityValue property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ReferenceQuantityValue[pd.Lower.Value];
                        }

                        return this.ReferenceQuantityValue[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var referenceQuantityValueObjects = new List<ScaleReferenceQuantityValue>();

                        for (var i = pd.Lower.Value; i < referenceQuantityValueUpperBound + 1; i++)
                        {
                            referenceQuantityValueObjects.Add(this.ReferenceQuantityValue[i]);
                        }

                        return referenceQuantityValueObjects;
                    }

                    var referenceQuantityValueNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < referenceQuantityValueUpperBound + 1; i++)
                    {
                        var queryResult = this.ReferenceQuantityValue[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    referenceQuantityValueNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                referenceQuantityValueNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return referenceQuantityValueNextObjects;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "unit":
                    return base.QueryValue(pd.Input);
                case "valuedefinition":
                    return base.QueryValue(pd.Input);
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
                case "exponent":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.Exponent = null;
                        return;
                    }

                    if(!(value is string exponentValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.Exponent = exponentValue;
                    return;
                case "factor":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.Factor = null;
                        return;
                    }

                    if(!(value is string factorValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.Factor = factorValue;
                    return;
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "isdeprecated":
                    base.SetValue(pd.Input, value);
                    return;
                case "ismaximuminclusive":
                    base.SetValue(pd.Input, value);
                    return;
                case "isminimuminclusive":
                    base.SetValue(pd.Input, value);
                    return;
                case "logarithmbase":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is LogarithmBaseKind logarithmBaseValue || (value is string logarithmBaseString) && LogarithmBaseKind.TryParse(logarithmBaseString, out logarithmBaseValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a LogarithmBaseKind" , nameof(value));
                    }

                    this.LogarithmBase = logarithmBaseValue;
                    return;
                case "mappingtoreferencescale":
                    base.SetValue(pd.Input, value);
                    return;
                case "maximumpermissiblevalue":
                    base.SetValue(pd.Input, value);
                    return;
                case "minimumpermissiblevalue":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "negativevalueconnotation":
                    base.SetValue(pd.Input, value);
                    return;
                case "numberset":
                    base.SetValue(pd.Input, value);
                    return;
                case "positivevalueconnotation":
                    base.SetValue(pd.Input, value);
                    return;
                case "referencequantitykind":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is QuantityKind referenceQuantityKindValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a QuantityKind" , nameof(value));
                    }

                    this.ReferenceQuantityKind = referenceQuantityKindValue;
                    return;
                case "referencequantityvalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ReferenceQuantityValue.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ScaleReferenceQuantityValue referenceQuantityValueValue:
                            this.ReferenceQuantityValue.Clear();
                            this.ReferenceQuantityValue.Add(referenceQuantityValueValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ReferenceQuantityValue.Clear();
                            this.ReferenceQuantityValue.AddRange(thingValues.OfType<ScaleReferenceQuantityValue>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ScaleReferenceQuantityValue or a collection of ScaleReferenceQuantityValue" , nameof(value));
                    }
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "unit":
                    base.SetValue(pd.Input, value);
                    return;
                case "valuedefinition":
                    base.SetValue(pd.Input, value);
                    return;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }

        /// <summary>
        /// Queries the value of a Sentinel object
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <param name="isCallerEmunerable">
        /// A value indicating whether the result is a single value or an enumeration
        /// </param>
        /// <returns>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof 
        /// </returns>
        internal object QuerySentinelValue(string path, bool isCallerEmunerable)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "revisionnumber":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "classkind":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<ClassKind>() : null;
                case "excludeddomain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "excludedperson":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "modifiedon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "thingpreference":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "actor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Person>() : default(Person);
                case "alias":
                    return pd.Next == null ? (object) new List<Alias>() : new Alias(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "exponent":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "factor":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "ismaximuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "isminimuminclusive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "logarithmbase":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<LogarithmBaseKind>() : null;
                case "mappingtoreferencescale":
                    return pd.Next == null ? (object) new List<MappingToReferenceScale>() : new MappingToReferenceScale(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "maximumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "minimumpermissiblevalue":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "negativevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "numberset":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<NumberSetKind>() : null;
                case "positivevalueconnotation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "referencequantitykind":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DerivedQuantityKind(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<QuantityKind>() : default(QuantityKind);
                case "referencequantityvalue":
                    return pd.Next == null ? (object) new List<ScaleReferenceQuantityValue>() : new ScaleReferenceQuantityValue(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "unit":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DerivedUnit(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<MeasurementUnit>() : default(MeasurementUnit);
                case "valuedefinition":
                    return pd.Next == null ? (object) new List<ScaleValueDefinition>() : new ScaleValueDefinition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
