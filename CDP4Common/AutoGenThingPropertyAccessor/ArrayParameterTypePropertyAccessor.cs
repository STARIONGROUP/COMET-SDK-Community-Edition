// ------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterTypePropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class ArrayParameterType
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
                case "category":
                    return base.QueryValue(pd.Input);
                case "component":
                    return base.QueryValue(pd.Input);
                case "definition":
                    return base.QueryValue(pd.Input);
                case "dimension":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for the Dimension property, the lower and upper bound must be specified");
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Dimension.Any())
                    {
                        return new List<int>();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Dimension.Count - 1;
                    }

                    if (this.Dimension.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Dimension property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Dimension.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Dimension property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Dimension[pd.Lower.Value];
                    }

                    var dimensionobjects = new List<int>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        dimensionobjects.Add(this.Dimension[i]);
                    }

                    return dimensionobjects;
                case "hassinglecomponenttype":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.HasSingleComponentType;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "isdeprecated":
                    return base.QueryValue(pd.Input);
                case "isfinalized":
                    return base.QueryValue(pd.Input);
                case "istensor":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsTensor;
                case "name":
                    return base.QueryValue(pd.Input);
                case "numberofvalues":
                    return base.QueryValue(pd.Input);
                case "rank":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Rank;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "symbol":
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
                case "category":
                    base.SetValue(pd.Input, value);
                    return;
                case "component":
                    base.SetValue(pd.Input, value);
                    return;
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "dimension":

                    if(value == null)
                    {
                        this.Dimension.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case int dimensionValue:
                            this.Dimension.Clear();
                            this.Dimension.Add(dimensionValue);
                            return;
                        case IEnumerable<int> dimensionValues:
                            this.Dimension.Clear();
                            this.Dimension.AddRange(dimensionValues);
                            return;
                        case string dimensionStringValue:
                            if(!(int.TryParse(dimensionStringValue, out var dimensionFromStringValue)))
                            {
                                throw new ArgumentException($"The provided value {value} cannot be parsed to a int" , nameof(value));
                            }
                            
                            this.Dimension.Clear();
                            this.Dimension.Add(dimensionFromStringValue);
                            return;
                        case IEnumerable<string> dimensionStringValues:
                            var dimensionFromStringValues = new List<int>();

                            foreach(var dimensionSingleStringValue in dimensionStringValues)
                            {
                                if(!(int.TryParse(dimensionSingleStringValue, out var dimensionFromSingleStringValue)))
                                {
                                    throw new ArgumentException($"The provided value { dimensionSingleStringValue } cannot be parsed to a int" , nameof(value));
                                }

                                dimensionFromStringValues.Add(dimensionFromSingleStringValue);
                            }

                            this.Dimension.Clear();
                            this.Dimension.AddRange(dimensionFromStringValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a int or a collection of int" , nameof(value));
                    }
                case "hassinglecomponenttype":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool hasSingleComponentTypeValue || (value is string hasSingleComponentTypeString) && bool.TryParse(hasSingleComponentTypeString, out hasSingleComponentTypeValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.HasSingleComponentType = hasSingleComponentTypeValue;
                    return;
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "isdeprecated":
                    base.SetValue(pd.Input, value);
                    return;
                case "isfinalized":
                    base.SetValue(pd.Input, value);
                    return;
                case "istensor":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is bool isTensorValue || (value is string isTensorString) && bool.TryParse(isTensorString, out isTensorValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.IsTensor = isTensorValue;
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "numberofvalues":
                    base.SetValue(pd.Input, value);
                    return;
                case "rank":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is int rankValue || (value is string rankString) && int.TryParse(rankString, out rankValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a int" , nameof(value));
                    }

                    this.Rank = rankValue;
                    return;
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "symbol":
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
                case "category":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "component":
                    return pd.Next == null ? (object) new List<ParameterTypeComponent>() : new ParameterTypeComponent(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "dimension":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<int>() : null;
                case "hassinglecomponenttype":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "isfinalized":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "istensor":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "numberofvalues":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "rank":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "symbol":
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
