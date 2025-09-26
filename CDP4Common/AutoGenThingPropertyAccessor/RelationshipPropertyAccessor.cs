// ------------------------------------------------------------------------------------------------
// <copyright file="RelationshipPropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class Relationship
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
                case "parametervalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var parameterValueUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && parameterValueUpperBound == int.MaxValue && !this.ParameterValue.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<RelationshipParameterValue>();
                        }

                        var sentinelRelationshipParameterValue = new RelationshipParameterValue(Guid.Empty, null, null);

                        return sentinelRelationshipParameterValue.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        parameterValueUpperBound = this.ParameterValue.Count - 1;
                    }

                    if (this.ParameterValue.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ParameterValue property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ParameterValue.Count - 1 < parameterValueUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ParameterValue property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ParameterValue[pd.Lower.Value];
                        }

                        return this.ParameterValue[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var parameterValueObjects = new List<RelationshipParameterValue>();

                        for (var i = pd.Lower.Value; i < parameterValueUpperBound + 1; i++)
                        {
                            parameterValueObjects.Add(this.ParameterValue[i]);
                        }

                        return parameterValueObjects;
                    }

                    var parameterValueNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < parameterValueUpperBound + 1; i++)
                    {
                        var queryResult = this.ParameterValue[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    parameterValueNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                parameterValueNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return parameterValueNextObjects;
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
                case "parametervalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ParameterValue.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case RelationshipParameterValue parameterValueValue:
                            this.ParameterValue.Clear();
                            this.ParameterValue.Add(parameterValueValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ParameterValue.Clear();
                            this.ParameterValue.AddRange(thingValues.OfType<RelationshipParameterValue>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a RelationshipParameterValue or a collection of RelationshipParameterValue" , nameof(value));
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
