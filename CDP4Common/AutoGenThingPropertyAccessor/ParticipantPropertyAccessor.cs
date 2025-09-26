// ------------------------------------------------------------------------------------------------
// <copyright file="ParticipantPropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class Participant
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
                case "domain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var domainUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && domainUpperBound == int.MaxValue && !this.Domain.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DomainOfExpertise>();
                        }

                        var sentinelDomainOfExpertise = new DomainOfExpertise(Guid.Empty, null, null);

                        return sentinelDomainOfExpertise.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        domainUpperBound = this.Domain.Count - 1;
                    }

                    if (this.Domain.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Domain property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Domain.Count - 1 < domainUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Domain property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Domain[pd.Lower.Value];
                        }

                        return this.Domain[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var domainObjects = new List<DomainOfExpertise>();

                        for (var i = pd.Lower.Value; i < domainUpperBound + 1; i++)
                        {
                            domainObjects.Add(this.Domain[i]);
                        }

                        return domainObjects;
                    }

                    var domainNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < domainUpperBound + 1; i++)
                    {
                        var queryResult = this.Domain[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    domainNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                domainNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return domainNextObjects;
                case "isactive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsActive;
                case "person":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Person;
                    }

                    if (this.Person != null)
                    {
                        return this.Person.QueryValue(pd.Next.Input);
                    }

                    var sentinelperson = new Person(Guid.Empty, null, null);
                    return sentinelperson.QuerySentinelValue(pd.Next.Input, false);
                case "role":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Role;
                    }

                    if (this.Role != null)
                    {
                        return this.Role.QueryValue(pd.Next.Input);
                    }

                    var sentinelrole = new ParticipantRole(Guid.Empty, null, null);
                    return sentinelrole.QuerySentinelValue(pd.Next.Input, false);
                case "selecteddomain":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.SelectedDomain;
                    }

                    if (this.SelectedDomain != null)
                    {
                        return this.SelectedDomain.QueryValue(pd.Next.Input);
                    }

                    var sentinelselecteddomain = new DomainOfExpertise(Guid.Empty, null, null);
                    return sentinelselecteddomain.QuerySentinelValue(pd.Next.Input, false);
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
                case "domain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Domain.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case DomainOfExpertise domainValue:
                            this.Domain.Clear();
                            this.Domain.Add(domainValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Domain.Clear();
                            this.Domain.AddRange(thingValues.OfType<DomainOfExpertise>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertise or a collection of DomainOfExpertise" , nameof(value));
                    }
                case "isactive":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isActiveValue || (value is string isActiveString) && bool.TryParse(isActiveString, out isActiveValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsActive = isActiveValue;
                    return;
                case "person":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Person personValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Person" , nameof(value));
                    }

                    this.Person = personValue;
                    return;
                case "role":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ParticipantRole roleValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParticipantRole" , nameof(value));
                    }

                    this.Role = roleValue;
                    return;
                case "selecteddomain":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is DomainOfExpertise selectedDomainValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertise" , nameof(value));
                    }

                    this.SelectedDomain = selectedDomainValue;
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
                case "domain":
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "isactive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "person":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Person>() : default(Person);
                case "role":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ParticipantRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ParticipantRole>() : default(ParticipantRole);
                case "selecteddomain":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
