// ------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionPropertyAccessor.cs" company="Starion Group S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    public partial class ParameterSubscription
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
                case "group":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Group;
                    }

                    if (this.Group != null)
                    {
                        return this.Group.QueryValue(pd.Next.Input);
                    }

                    var sentinelgroup = new ParameterGroup(Guid.Empty, null, null);
                    return sentinelgroup.QuerySentinelValue(pd.Next.Input, false);
                case "isoptiondependent":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsOptionDependent;
                case "owner":
                    return base.QueryValue(pd.Input);
                case "parametertype":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.ParameterType;
                    }

                    if (this.ParameterType != null)
                    {
                        return this.ParameterType.QueryValue(pd.Next.Input);
                    }

                    var sentinelparametertype = new CompoundParameterType(Guid.Empty, null, null);
                    return sentinelparametertype.QuerySentinelValue(pd.Next.Input, false);
                case "scale":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Scale;
                    }

                    if (this.Scale != null)
                    {
                        return this.Scale.QueryValue(pd.Next.Input);
                    }

                    var sentinelscale = new IntervalScale(Guid.Empty, null, null);
                    return sentinelscale.QuerySentinelValue(pd.Next.Input, false);
                case "statedependence":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.StateDependence;
                    }

                    if (this.StateDependence != null)
                    {
                        return this.StateDependence.QueryValue(pd.Next.Input);
                    }

                    var sentinelstatedependence = new ActualFiniteStateList(Guid.Empty, null, null);
                    return sentinelstatedependence.QuerySentinelValue(pd.Next.Input, false);
                case "valueset":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var valueSetUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && valueSetUpperBound == int.MaxValue && !this.ValueSet.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ParameterSubscriptionValueSet>();
                        }

                        var sentinelParameterSubscriptionValueSet = new ParameterSubscriptionValueSet(Guid.Empty, null, null);

                        return sentinelParameterSubscriptionValueSet.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        valueSetUpperBound = this.ValueSet.Count - 1;
                    }

                    if (this.ValueSet.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ValueSet property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ValueSet.Count - 1 < valueSetUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ValueSet property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ValueSet[pd.Lower.Value];
                        }

                        return this.ValueSet[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var valueSetObjects = new List<ParameterSubscriptionValueSet>();

                        for (var i = pd.Lower.Value; i < valueSetUpperBound + 1; i++)
                        {
                            valueSetObjects.Add(this.ValueSet[i]);
                        }

                        return valueSetObjects;
                    }

                    var valueSetNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < valueSetUpperBound + 1; i++)
                    {
                        var queryResult = this.ValueSet[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    valueSetNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                valueSetNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return valueSetNextObjects;
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
                case "group":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ParameterGroup groupValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterGroup" , nameof(value));
                    }

                    this.Group = groupValue;
                    return;
                case "isoptiondependent":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isOptionDependentValue || (value is string isOptionDependentString) && bool.TryParse(isOptionDependentString, out isOptionDependentValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsOptionDependent = isOptionDependentValue;
                    return;
                case "owner":
                    base.SetValue(pd.Input, value);
                    return;
                case "parametertype":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ParameterType parameterTypeValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterType" , nameof(value));
                    }

                    this.ParameterType = parameterTypeValue;
                    return;
                case "scale":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is MeasurementScale scaleValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MeasurementScale" , nameof(value));
                    }

                    this.Scale = scaleValue;
                    return;
                case "statedependence":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ActualFiniteStateList stateDependenceValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ActualFiniteStateList" , nameof(value));
                    }

                    this.StateDependence = stateDependenceValue;
                    return;
                case "valueset":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ValueSet.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ParameterSubscriptionValueSet valueSetValue:
                            this.ValueSet.Clear();
                            this.ValueSet.Add(valueSetValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ValueSet.Clear();
                            this.ValueSet.AddRange(thingValues.OfType<ParameterSubscriptionValueSet>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterSubscriptionValueSet or a collection of ParameterSubscriptionValueSet" , nameof(value));
                    }
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
                case "group":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ParameterGroup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ParameterGroup>() : default(ParameterGroup);
                case "isoptiondependent":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                case "parametertype":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new CompoundParameterType(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ParameterType>() : default(ParameterType);
                case "scale":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new IntervalScale(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<MeasurementScale>() : default(MeasurementScale);
                case "statedependence":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ActualFiniteStateList(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ActualFiniteStateList>() : default(ActualFiniteStateList);
                case "valueset":
                    return pd.Next == null ? (object) new List<ParameterSubscriptionValueSet>() : new ParameterSubscriptionValueSet(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
