// ------------------------------------------------------------------------------------------------
// <copyright file="SiteLogEntryPropertyAccessor.cs" company="RHEA System S.A.">
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
    public partial class SiteLogEntry
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
                case "affecteddomainiid":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for the AffectedDomainIid property, the lower and upper bound must be specified");
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.AffectedDomainIid.Any())
                    {
                        return new List<Guid>();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.AffectedDomainIid.Count - 1;
                    }

                    if (this.AffectedDomainIid.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the AffectedDomainIid property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.AffectedDomainIid.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the AffectedDomainIid property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.AffectedDomainIid[pd.Lower.Value];
                    }

                    var affectedDomainIidobjects = new List<Guid>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        affectedDomainIidobjects.Add(this.AffectedDomainIid[i]);
                    }

                    return affectedDomainIidobjects;
                case "affecteditemiid":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for the AffectedItemIid property, the lower and upper bound must be specified");
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.AffectedItemIid.Any())
                    {
                        return new List<Guid>();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.AffectedItemIid.Count - 1;
                    }

                    if (this.AffectedItemIid.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the AffectedItemIid property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.AffectedItemIid.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the AffectedItemIid property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.AffectedItemIid[pd.Lower.Value];
                    }

                    var affectedItemIidobjects = new List<Guid>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        affectedItemIidobjects.Add(this.AffectedItemIid[i]);
                    }

                    return affectedItemIidobjects;
                case "author":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Author;
                    }

                    if (this.Author != null)
                    {
                        return this.Author.QueryValue(pd.Next.Input);
                    }

                    var sentinelauthor = new Person(Guid.Empty, null, null);
                    return sentinelauthor.QuerySentinelValue(pd.Next.Input, false);
                case "category":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var categoryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && categoryUpperBound == int.MaxValue && !this.Category.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Category>();
                        }

                        var sentinelCategory = new Category(Guid.Empty, null, null);

                        return sentinelCategory.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        categoryUpperBound = this.Category.Count - 1;
                    }

                    if (this.Category.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Category property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Category.Count - 1 < categoryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Category property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Category[pd.Lower.Value];
                        }

                        return this.Category[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var categoryObjects = new List<Category>();

                        for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                        {
                            categoryObjects.Add(this.Category[i]);
                        }

                        return categoryObjects;
                    }

                    var categoryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                    {
                        var queryResult = this.Category[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    categoryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                categoryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return categoryNextObjects;
                case "content":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Content;
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.CreatedOn;
                case "languagecode":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.LanguageCode;
                case "level":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Level;
                case "logentrychangelogitem":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var logEntryChangelogItemUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && logEntryChangelogItemUpperBound == int.MaxValue && !this.LogEntryChangelogItem.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<LogEntryChangelogItem>();
                        }

                        var sentinelLogEntryChangelogItem = new LogEntryChangelogItem(Guid.Empty, null, null);

                        return sentinelLogEntryChangelogItem.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        logEntryChangelogItemUpperBound = this.LogEntryChangelogItem.Count - 1;
                    }

                    if (this.LogEntryChangelogItem.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for LogEntryChangelogItem property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.LogEntryChangelogItem.Count - 1 < logEntryChangelogItemUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the LogEntryChangelogItem property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.LogEntryChangelogItem[pd.Lower.Value];
                        }

                        return this.LogEntryChangelogItem[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var logEntryChangelogItemObjects = new List<LogEntryChangelogItem>();

                        for (var i = pd.Lower.Value; i < logEntryChangelogItemUpperBound + 1; i++)
                        {
                            logEntryChangelogItemObjects.Add(this.LogEntryChangelogItem[i]);
                        }

                        return logEntryChangelogItemObjects;
                    }

                    var logEntryChangelogItemNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < logEntryChangelogItemUpperBound + 1; i++)
                    {
                        var queryResult = this.LogEntryChangelogItem[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    logEntryChangelogItemNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                logEntryChangelogItemNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return logEntryChangelogItemNextObjects;
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
                case "affecteddomainiid":

                    if(value == null)
                    {
                        this.AffectedDomainIid.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Guid affectedDomainIidValue:
                            this.AffectedDomainIid.Clear();
                            this.AffectedDomainIid.Add(affectedDomainIidValue);
                            return;
                        case IEnumerable<Guid> affectedDomainIidValues:
                            this.AffectedDomainIid.Clear();
                            this.AffectedDomainIid.AddRange(affectedDomainIidValues);
                            return;
                        case string affectedDomainIidStringValue:
                            if(!(Guid.TryParse(affectedDomainIidStringValue, out var affectedDomainIidFromStringValue)))
                            {
                                throw new ArgumentException($"The provided value {value} cannot be parsed to a Guid" , nameof(value));
                            }
                            
                            this.AffectedDomainIid.Clear();
                            this.AffectedDomainIid.Add(affectedDomainIidFromStringValue);
                            return;
                        case IEnumerable<string> affectedDomainIidStringValues:
                            var affectedDomainIidFromStringValues = new List<Guid>();

                            foreach(var affectedDomainIidSingleStringValue in affectedDomainIidStringValues)
                            {
                                if(!(Guid.TryParse(affectedDomainIidSingleStringValue, out var affectedDomainIidFromSingleStringValue)))
                                {
                                    throw new ArgumentException($"The provided value { affectedDomainIidSingleStringValue } cannot be parsed to a Guid" , nameof(value));
                                }

                                affectedDomainIidFromStringValues.Add(affectedDomainIidFromSingleStringValue);
                            }

                            this.AffectedDomainIid.Clear();
                            this.AffectedDomainIid.AddRange(affectedDomainIidFromStringValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Guid or a collection of Guid" , nameof(value));
                    }
                case "affecteditemiid":

                    if(value == null)
                    {
                        this.AffectedItemIid.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Guid affectedItemIidValue:
                            this.AffectedItemIid.Clear();
                            this.AffectedItemIid.Add(affectedItemIidValue);
                            return;
                        case IEnumerable<Guid> affectedItemIidValues:
                            this.AffectedItemIid.Clear();
                            this.AffectedItemIid.AddRange(affectedItemIidValues);
                            return;
                        case string affectedItemIidStringValue:
                            if(!(Guid.TryParse(affectedItemIidStringValue, out var affectedItemIidFromStringValue)))
                            {
                                throw new ArgumentException($"The provided value {value} cannot be parsed to a Guid" , nameof(value));
                            }
                            
                            this.AffectedItemIid.Clear();
                            this.AffectedItemIid.Add(affectedItemIidFromStringValue);
                            return;
                        case IEnumerable<string> affectedItemIidStringValues:
                            var affectedItemIidFromStringValues = new List<Guid>();

                            foreach(var affectedItemIidSingleStringValue in affectedItemIidStringValues)
                            {
                                if(!(Guid.TryParse(affectedItemIidSingleStringValue, out var affectedItemIidFromSingleStringValue)))
                                {
                                    throw new ArgumentException($"The provided value { affectedItemIidSingleStringValue } cannot be parsed to a Guid" , nameof(value));
                                }

                                affectedItemIidFromStringValues.Add(affectedItemIidFromSingleStringValue);
                            }

                            this.AffectedItemIid.Clear();
                            this.AffectedItemIid.AddRange(affectedItemIidFromStringValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Guid or a collection of Guid" , nameof(value));
                    }
                case "author":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Person authorValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Person" , nameof(value));
                    }

                    this.Author = authorValue;
                    return;
                case "category":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Category.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Category categoryValue:
                            this.Category.Clear();
                            this.Category.Add(categoryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Category.Clear();
                            this.Category.AddRange(thingValues.OfType<Category>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Category or a collection of Category" , nameof(value));
                    }
                case "content":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.Content = null;
                        return;
                    }

                    if(!(value is string contentValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.Content = contentValue;
                    return;
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is DateTime createdOnValue || (value is string createdOnString) && DateTime.TryParse(createdOnString, out createdOnValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DateTime" , nameof(value));
                    }

                    this.CreatedOn = createdOnValue;
                    return;
                case "languagecode":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.LanguageCode = null;
                        return;
                    }

                    if(!(value is string languageCodeValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.LanguageCode = languageCodeValue;
                    return;
                case "level":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is LogLevelKind levelValue || (value is string levelString) && LogLevelKind.TryParse(levelString, out levelValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a LogLevelKind" , nameof(value));
                    }

                    this.Level = levelValue;
                    return;
                case "logentrychangelogitem":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.LogEntryChangelogItem.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case LogEntryChangelogItem logEntryChangelogItemValue:
                            this.LogEntryChangelogItem.Clear();
                            this.LogEntryChangelogItem.Add(logEntryChangelogItemValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.LogEntryChangelogItem.Clear();
                            this.LogEntryChangelogItem.AddRange(thingValues.OfType<LogEntryChangelogItem>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a LogEntryChangelogItem or a collection of LogEntryChangelogItem" , nameof(value));
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
                case "affecteddomainiid":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<Guid>() : null;
                case "affecteditemiid":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<Guid>() : null;
                case "author":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Person>() : default(Person);
                case "category":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "content":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "languagecode":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "level":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<LogLevelKind>() : null;
                case "logentrychangelogitem":
                    return pd.Next == null ? (object) new List<LogEntryChangelogItem>() : new LogEntryChangelogItem(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
