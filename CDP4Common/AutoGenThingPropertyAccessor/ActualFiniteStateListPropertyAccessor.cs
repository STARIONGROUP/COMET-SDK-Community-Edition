// ------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateListPropertyAccessor.cs" company="RHEA System S.A.">
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
    public partial class ActualFiniteStateList
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
                    return this.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return this.QueryThingValues(pd.Input);
                case "classkind":
                    return this.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return this.QueryThingValues(pd.Input);
                case "excludedperson":
                    return this.QueryThingValues(pd.Input);
                case "modifiedon":
                    return this.QueryThingValues(pd.Input);
                case "thingpreference":
                    return this.QueryThingValues(pd.Input);
                case "actor":
                    return this.QueryThingValues(pd.Input);
                case "container":
                    return this.QueryThingValues(pd.Input);
                case "actualstate":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var actualStateUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && actualStateUpperBound == int.MaxValue && !this.ActualState.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ActualFiniteState>();
                        }

                        var sentinelActualFiniteState = new ActualFiniteState(Guid.Empty, null, null);

                        return sentinelActualFiniteState.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        actualStateUpperBound = this.ActualState.Count - 1;
                    }

                    if (this.ActualState.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ActualState property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ActualState.Count - 1 < actualStateUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ActualState property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ActualState[pd.Lower.Value];
                        }

                        return this.ActualState[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var actualStateObjects = new List<ActualFiniteState>();

                        for (var i = pd.Lower.Value; i < actualStateUpperBound + 1; i++)
                        {
                            actualStateObjects.Add(this.ActualState[i]);
                        }

                        return actualStateObjects;
                    }

                    var actualStateNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < actualStateUpperBound + 1; i++)
                    {
                        var queryResult = this.ActualState[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    actualStateNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                actualStateNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return actualStateNextObjects;
                case "excludeoption":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var excludeOptionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && excludeOptionUpperBound == int.MaxValue && !this.ExcludeOption.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Option>();
                        }

                        var sentinelOption = new Option(Guid.Empty, null, null);

                        return sentinelOption.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        excludeOptionUpperBound = this.ExcludeOption.Count - 1;
                    }

                    if (this.ExcludeOption.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ExcludeOption property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ExcludeOption.Count - 1 < excludeOptionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ExcludeOption property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ExcludeOption[pd.Lower.Value];
                        }

                        return this.ExcludeOption[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var excludeOptionObjects = new List<Option>();

                        for (var i = pd.Lower.Value; i < excludeOptionUpperBound + 1; i++)
                        {
                            excludeOptionObjects.Add(this.ExcludeOption[i]);
                        }

                        return excludeOptionObjects;
                    }

                    var excludeOptionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < excludeOptionUpperBound + 1; i++)
                    {
                        var queryResult = this.ExcludeOption[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    excludeOptionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                excludeOptionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return excludeOptionNextObjects;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Name;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Owner;
                    }

                    if (this.Owner != null)
                    {
                        return this.Owner.QueryValue(pd.Next.Input);
                    }

                    var sentinelowner = new DomainOfExpertise(Guid.Empty, null, null);
                    return sentinelowner.QuerySentinelValue(pd.Next.Input, false);
                case "possiblefinitestatelist":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var possibleFiniteStateListUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && possibleFiniteStateListUpperBound == int.MaxValue && !this.PossibleFiniteStateList.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<PossibleFiniteStateList>();
                        }

                        var sentinelPossibleFiniteStateList = new PossibleFiniteStateList(Guid.Empty, null, null);

                        return sentinelPossibleFiniteStateList.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        possibleFiniteStateListUpperBound = this.PossibleFiniteStateList.Count - 1;
                    }

                    if (this.PossibleFiniteStateList.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for PossibleFiniteStateList property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.PossibleFiniteStateList.Count - 1 < possibleFiniteStateListUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the PossibleFiniteStateList property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.PossibleFiniteStateList[pd.Lower.Value];
                        }

                        return this.PossibleFiniteStateList[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var possibleFiniteStateListObjects = new List<PossibleFiniteStateList>();

                        for (var i = pd.Lower.Value; i < possibleFiniteStateListUpperBound + 1; i++)
                        {
                            possibleFiniteStateListObjects.Add(this.PossibleFiniteStateList[i]);
                        }

                        return possibleFiniteStateListObjects;
                    }

                    var possibleFiniteStateListNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < possibleFiniteStateListUpperBound + 1; i++)
                    {
                        var queryResult = this.PossibleFiniteStateList[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    possibleFiniteStateListNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                possibleFiniteStateListNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return possibleFiniteStateListNextObjects;
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ShortName;
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
                case "actualstate":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ActualState.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ActualFiniteState actualStateValue:
                            this.ActualState.Clear();
                            this.ActualState.Add(actualStateValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ActualState.Clear();
                            this.ActualState.AddRange(thingValues.OfType<ActualFiniteState>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ActualFiniteState or a collection of ActualFiniteState" , nameof(value));
                    }
                case "excludeoption":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ExcludeOption.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Option excludeOptionValue:
                            this.ExcludeOption.Clear();
                            this.ExcludeOption.Add(excludeOptionValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ExcludeOption.Clear();
                            this.ExcludeOption.AddRange(thingValues.OfType<Option>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Option or a collection of Option" , nameof(value));
                    }
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.Name = null;
                        return;
                    }

                    if(!(value is string nameValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.Name = nameValue;
                    return;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is DomainOfExpertise ownerValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertise" , nameof(value));
                    }

                    this.Owner = ownerValue;
                    return;
                case "possiblefinitestatelist":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.PossibleFiniteStateList.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case PossibleFiniteStateList possibleFiniteStateListValue:
                            this.PossibleFiniteStateList.Clear();
                            this.PossibleFiniteStateList.Add(possibleFiniteStateListValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.PossibleFiniteStateList.Clear();
                            this.PossibleFiniteStateList.AddRange(thingValues.OfType<PossibleFiniteStateList>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a PossibleFiniteStateList or a collection of PossibleFiniteStateList" , nameof(value));
                    }
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.ShortName = null;
                        return;
                    }

                    if(!(value is string shortNameValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.ShortName = shortNameValue;
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
                case "actualstate":
                    return pd.Next == null ? (object) new List<ActualFiniteState>() : new ActualFiniteState(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "excludeoption":
                    return pd.Next == null ? (object) new List<Option>() : new Option(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                case "possiblefinitestatelist":
                    return pd.Next == null ? (object) new List<PossibleFiniteStateList>() : new PossibleFiniteStateList(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
