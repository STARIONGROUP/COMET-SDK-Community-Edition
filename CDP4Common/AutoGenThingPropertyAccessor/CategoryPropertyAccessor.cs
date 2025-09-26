// ------------------------------------------------------------------------------------------------
// <copyright file="CategoryPropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class Category
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
                case "isabstract":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsAbstract;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsDeprecated;
                case "name":
                    return base.QueryValue(pd.Input);
                case "permissibleclass":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new ArgumentException("Invalid Multiplicity for the PermissibleClass property, the lower and upper bound must be specified");
                    }

                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for the PermissibleClass property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.PermissibleClass.Any())
                    {
                        return new List<ClassKind>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.PermissibleClass.Any())
                    {
                        return this.PermissibleClass.ToList();
                    }

                    var permissibleClassUpperBound = pd.Upper.Value;

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        permissibleClassUpperBound = this.PermissibleClass.Count - 1;
                    }

                    if (this.PermissibleClass.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the PermissibleClass property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.PermissibleClass.Count - 1 < permissibleClassUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the PermissibleClass property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == permissibleClassUpperBound)
                    {
                        return this.PermissibleClass[pd.Lower.Value];
                    }

                    var permissibleClassObjects = new List<ClassKind>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        permissibleClassObjects.Add(this.PermissibleClass[i]);
                    }

                    return permissibleClassObjects;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "supercategory":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var superCategoryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && superCategoryUpperBound == int.MaxValue && !this.SuperCategory.Any())
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
                        superCategoryUpperBound = this.SuperCategory.Count - 1;
                    }

                    if (this.SuperCategory.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for SuperCategory property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.SuperCategory.Count - 1 < superCategoryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the SuperCategory property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.SuperCategory[pd.Lower.Value];
                        }

                        return this.SuperCategory[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var superCategoryObjects = new List<Category>();

                        for (var i = pd.Lower.Value; i < superCategoryUpperBound + 1; i++)
                        {
                            superCategoryObjects.Add(this.SuperCategory[i]);
                        }

                        return superCategoryObjects;
                    }

                    var superCategoryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < superCategoryUpperBound + 1; i++)
                    {
                        var queryResult = this.SuperCategory[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    superCategoryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                superCategoryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return superCategoryNextObjects;
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
                case "isabstract":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isAbstractValue || (value is string isAbstractString) && bool.TryParse(isAbstractString, out isAbstractValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsAbstract = isAbstractValue;
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
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "permissibleclass":

                    if(value == null)
                    {
                        this.PermissibleClass.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ClassKind permissibleClassValue:
                            this.PermissibleClass.Clear();
                            this.PermissibleClass.Add(permissibleClassValue);
                            return;
                        case IEnumerable<ClassKind> permissibleClassValues:
                            this.PermissibleClass.Clear();
                            this.PermissibleClass.AddRange(permissibleClassValues);
                            return;
                        case string permissibleClassStringValue:
                            if(!(Enum.TryParse(permissibleClassStringValue, out ClassKind permissibleClassFromStringValue)))
                            {
                                throw new ArgumentException($"The provided value {value} cannot be parsed to a ClassKind" , nameof(value));
                            }
                            
                            this.PermissibleClass.Clear();
                            this.PermissibleClass.Add(permissibleClassFromStringValue);
                            return;
                        case IEnumerable<string> permissibleClassStringValues:
                            var permissibleClassFromStringValues = new List<ClassKind>();

                            foreach(var permissibleClassSingleStringValue in permissibleClassStringValues)
                            {
                                if(!(Enum.TryParse(permissibleClassSingleStringValue, out ClassKind permissibleClassFromSingleStringValue)))
                                {
                                    throw new ArgumentException($"The provided value { permissibleClassSingleStringValue } cannot be parsed to a ClassKind" , nameof(value));
                                }

                                permissibleClassFromStringValues.Add(permissibleClassFromSingleStringValue);
                            }

                            this.PermissibleClass.Clear();
                            this.PermissibleClass.AddRange(permissibleClassFromStringValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ClassKind or a collection of ClassKind" , nameof(value));
                    }
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "supercategory":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.SuperCategory.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Category superCategoryValue:
                            this.SuperCategory.Clear();
                            this.SuperCategory.Add(superCategoryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.SuperCategory.Clear();
                            this.SuperCategory.AddRange(thingValues.OfType<Category>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Category or a collection of Category" , nameof(value));
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
                case "alias":
                    return pd.Next == null ? (object) new List<Alias>() : new Alias(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "isabstract":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "permissibleclass":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<ClassKind>() : null;
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "supercategory":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
