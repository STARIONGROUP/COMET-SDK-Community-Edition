// ------------------------------------------------------------------------------------------------
// <copyright file="SampledFunctionParameterTypePropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class SampledFunctionParameterType
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
                case "definition":
                    return base.QueryValue(pd.Input);
                case "degreeofinterpolation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.DegreeOfInterpolation;
                case "dependentparametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var dependentParameterTypeUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && dependentParameterTypeUpperBound == int.MaxValue && !this.DependentParameterType.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DependentParameterTypeAssignment>();
                        }

                        var sentinelDependentParameterTypeAssignment = new DependentParameterTypeAssignment(Guid.Empty, null, null);

                        return sentinelDependentParameterTypeAssignment.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        dependentParameterTypeUpperBound = this.DependentParameterType.Count - 1;
                    }

                    if (this.DependentParameterType.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DependentParameterType property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DependentParameterType.Count - 1 < dependentParameterTypeUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DependentParameterType property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DependentParameterType[pd.Lower.Value];
                        }

                        return this.DependentParameterType[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var dependentParameterTypeObjects = new List<DependentParameterTypeAssignment>();

                        for (var i = pd.Lower.Value; i < dependentParameterTypeUpperBound + 1; i++)
                        {
                            dependentParameterTypeObjects.Add(this.DependentParameterType[i]);
                        }

                        return dependentParameterTypeObjects;
                    }

                    var dependentParameterTypeNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < dependentParameterTypeUpperBound + 1; i++)
                    {
                        var queryResult = this.DependentParameterType[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    dependentParameterTypeNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                dependentParameterTypeNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return dependentParameterTypeNextObjects;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "independentparametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var independentParameterTypeUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && independentParameterTypeUpperBound == int.MaxValue && !this.IndependentParameterType.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<IndependentParameterTypeAssignment>();
                        }

                        var sentinelIndependentParameterTypeAssignment = new IndependentParameterTypeAssignment(Guid.Empty, null, null);

                        return sentinelIndependentParameterTypeAssignment.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        independentParameterTypeUpperBound = this.IndependentParameterType.Count - 1;
                    }

                    if (this.IndependentParameterType.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for IndependentParameterType property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.IndependentParameterType.Count - 1 < independentParameterTypeUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the IndependentParameterType property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.IndependentParameterType[pd.Lower.Value];
                        }

                        return this.IndependentParameterType[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var independentParameterTypeObjects = new List<IndependentParameterTypeAssignment>();

                        for (var i = pd.Lower.Value; i < independentParameterTypeUpperBound + 1; i++)
                        {
                            independentParameterTypeObjects.Add(this.IndependentParameterType[i]);
                        }

                        return independentParameterTypeObjects;
                    }

                    var independentParameterTypeNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < independentParameterTypeUpperBound + 1; i++)
                    {
                        var queryResult = this.IndependentParameterType[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    independentParameterTypeNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                independentParameterTypeNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return independentParameterTypeNextObjects;
                case "interpolationperiod":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for InterpolationPeriod property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for InterpolationPeriod property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.InterpolationPeriod.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.InterpolationPeriod.Any())
                    {
                        return this.InterpolationPeriod.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.InterpolationPeriod.Count - 1;
                    }

                    if (this.InterpolationPeriod.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the InterpolationPeriod property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.InterpolationPeriod.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the InterpolationPeriod property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.InterpolationPeriod[pd.Lower.Value];
                    }

                    var interpolationPeriodObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        interpolationPeriodObjects.Add(this.InterpolationPeriod[i]);
                    }

                    return interpolationPeriodObjects;
                case "isdeprecated":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "numberofvalues":
                    return base.QueryValue(pd.Input);
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
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "degreeofinterpolation":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.DegreeOfInterpolation = null;
                        return;
                    }

                    if(!(value is int degreeOfInterpolationValue || (value is string degreeOfInterpolationString) && int.TryParse(degreeOfInterpolationString, out degreeOfInterpolationValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a int" , nameof(value));
                    }

                    this.DegreeOfInterpolation = degreeOfInterpolationValue;
                    return;
                case "dependentparametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.DependentParameterType.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case DependentParameterTypeAssignment dependentParameterTypeValue:
                            this.DependentParameterType.Clear();
                            this.DependentParameterType.Add(dependentParameterTypeValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.DependentParameterType.Clear();
                            this.DependentParameterType.AddRange(thingValues.OfType<DependentParameterTypeAssignment>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DependentParameterTypeAssignment or a collection of DependentParameterTypeAssignment" , nameof(value));
                    }
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "independentparametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.IndependentParameterType.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case IndependentParameterTypeAssignment independentParameterTypeValue:
                            this.IndependentParameterType.Clear();
                            this.IndependentParameterType.Add(independentParameterTypeValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.IndependentParameterType.Clear();
                            this.IndependentParameterType.AddRange(thingValues.OfType<IndependentParameterTypeAssignment>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a IndependentParameterTypeAssignment or a collection of IndependentParameterTypeAssignment" , nameof(value));
                    }
                case "interpolationperiod":

                    if(value == null)
                    {
                        this.InterpolationPeriod = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string interpolationPeriodValue:
                            this.InterpolationPeriod = new ValueArray<string>(new List<string>{ interpolationPeriodValue });
                            return;
                        case IEnumerable<string> interpolationPeriodValues:
                            this.InterpolationPeriod = new ValueArray<string>(interpolationPeriodValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "isdeprecated":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "numberofvalues":
                    base.SetValue(pd.Input, value);
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
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "degreeofinterpolation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "dependentparametertype":
                    return pd.Next == null ? (object) new List<DependentParameterTypeAssignment>() : new DependentParameterTypeAssignment(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "independentparametertype":
                    return pd.Next == null ? (object) new List<IndependentParameterTypeAssignment>() : new IndependentParameterTypeAssignment(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "interpolationperiod":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<string>() : null;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "numberofvalues":
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
