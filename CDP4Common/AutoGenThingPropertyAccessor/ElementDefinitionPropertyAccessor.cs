// ------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionPropertyAccessor.cs" company="RHEA System S.A.">
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
    public partial class ElementDefinition
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
                case "alias":
                    return base.QueryValue(pd.Input);
                case "category":
                    return base.QueryValue(pd.Input);
                case "containedelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var containedElementUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && containedElementUpperBound == int.MaxValue && !this.ContainedElement.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ElementUsage>();
                        }

                        var sentinelElementUsage = new ElementUsage(Guid.Empty, null, null);

                        return sentinelElementUsage.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        containedElementUpperBound = this.ContainedElement.Count - 1;
                    }

                    if (this.ContainedElement.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ContainedElement property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ContainedElement.Count - 1 < containedElementUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ContainedElement property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ContainedElement[pd.Lower.Value];
                        }

                        return this.ContainedElement[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var containedElementObjects = new List<ElementUsage>();

                        for (var i = pd.Lower.Value; i < containedElementUpperBound + 1; i++)
                        {
                            containedElementObjects.Add(this.ContainedElement[i]);
                        }

                        return containedElementObjects;
                    }

                    var containedElementNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < containedElementUpperBound + 1; i++)
                    {
                        var queryResult = this.ContainedElement[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    containedElementNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                containedElementNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return containedElementNextObjects;
                case "definition":
                    return base.QueryValue(pd.Input);
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "organizationalparticipant":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var organizationalParticipantUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && organizationalParticipantUpperBound == int.MaxValue && !this.OrganizationalParticipant.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<OrganizationalParticipant>();
                        }

                        var sentinelOrganizationalParticipant = new OrganizationalParticipant(Guid.Empty, null, null);

                        return sentinelOrganizationalParticipant.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        organizationalParticipantUpperBound = this.OrganizationalParticipant.Count - 1;
                    }

                    if (this.OrganizationalParticipant.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for OrganizationalParticipant property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.OrganizationalParticipant.Count - 1 < organizationalParticipantUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the OrganizationalParticipant property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.OrganizationalParticipant[pd.Lower.Value];
                        }

                        return this.OrganizationalParticipant[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var organizationalParticipantObjects = new List<OrganizationalParticipant>();

                        for (var i = pd.Lower.Value; i < organizationalParticipantUpperBound + 1; i++)
                        {
                            organizationalParticipantObjects.Add(this.OrganizationalParticipant[i]);
                        }

                        return organizationalParticipantObjects;
                    }

                    var organizationalParticipantNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < organizationalParticipantUpperBound + 1; i++)
                    {
                        var queryResult = this.OrganizationalParticipant[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    organizationalParticipantNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                organizationalParticipantNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return organizationalParticipantNextObjects;
                case "owner":
                    return base.QueryValue(pd.Input);
                case "parameter":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var parameterUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && parameterUpperBound == int.MaxValue && !this.Parameter.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Parameter>();
                        }

                        var sentinelParameter = new Parameter(Guid.Empty, null, null);

                        return sentinelParameter.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        parameterUpperBound = this.Parameter.Count - 1;
                    }

                    if (this.Parameter.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Parameter property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Parameter.Count - 1 < parameterUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Parameter property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Parameter[pd.Lower.Value];
                        }

                        return this.Parameter[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var parameterObjects = new List<Parameter>();

                        for (var i = pd.Lower.Value; i < parameterUpperBound + 1; i++)
                        {
                            parameterObjects.Add(this.Parameter[i]);
                        }

                        return parameterObjects;
                    }

                    var parameterNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < parameterUpperBound + 1; i++)
                    {
                        var queryResult = this.Parameter[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    parameterNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                parameterNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return parameterNextObjects;
                case "parametergroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var parameterGroupUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && parameterGroupUpperBound == int.MaxValue && !this.ParameterGroup.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ParameterGroup>();
                        }

                        var sentinelParameterGroup = new ParameterGroup(Guid.Empty, null, null);

                        return sentinelParameterGroup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        parameterGroupUpperBound = this.ParameterGroup.Count - 1;
                    }

                    if (this.ParameterGroup.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ParameterGroup property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ParameterGroup.Count - 1 < parameterGroupUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ParameterGroup property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ParameterGroup[pd.Lower.Value];
                        }

                        return this.ParameterGroup[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var parameterGroupObjects = new List<ParameterGroup>();

                        for (var i = pd.Lower.Value; i < parameterGroupUpperBound + 1; i++)
                        {
                            parameterGroupObjects.Add(this.ParameterGroup[i]);
                        }

                        return parameterGroupObjects;
                    }

                    var parameterGroupNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < parameterGroupUpperBound + 1; i++)
                    {
                        var queryResult = this.ParameterGroup[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    parameterGroupNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                parameterGroupNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return parameterGroupNextObjects;
                case "referencedelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var referencedElementUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && referencedElementUpperBound == int.MaxValue && !this.ReferencedElement.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<NestedElement>();
                        }

                        var sentinelNestedElement = new NestedElement(Guid.Empty, null, null);

                        return sentinelNestedElement.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        referencedElementUpperBound = this.ReferencedElement.Count - 1;
                    }

                    if (this.ReferencedElement.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ReferencedElement property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ReferencedElement.Count - 1 < referencedElementUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ReferencedElement property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ReferencedElement[pd.Lower.Value];
                        }

                        return this.ReferencedElement[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var referencedElementObjects = new List<NestedElement>();

                        for (var i = pd.Lower.Value; i < referencedElementUpperBound + 1; i++)
                        {
                            referencedElementObjects.Add(this.ReferencedElement[i]);
                        }

                        return referencedElementObjects;
                    }

                    var referencedElementNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < referencedElementUpperBound + 1; i++)
                    {
                        var queryResult = this.ReferencedElement[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    referencedElementNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                referencedElementNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return referencedElementNextObjects;
                case "shortname":
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
                case "containedelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ContainedElement.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ElementUsage containedElementValue:
                            this.ContainedElement.Clear();
                            this.ContainedElement.Add(containedElementValue);
                            return;
                        case IEnumerable<ElementUsage> containedElementValues:
                            this.ContainedElement.Clear();
                            this.ContainedElement.AddRange(containedElementValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ElementUsage or a collection of ElementUsage" , nameof(value));
                    }
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "organizationalparticipant":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.OrganizationalParticipant.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case OrganizationalParticipant organizationalParticipantValue:
                            this.OrganizationalParticipant.Clear();
                            this.OrganizationalParticipant.Add(organizationalParticipantValue);
                            return;
                        case IEnumerable<OrganizationalParticipant> organizationalParticipantValues:
                            this.OrganizationalParticipant.Clear();
                            this.OrganizationalParticipant.AddRange(organizationalParticipantValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a OrganizationalParticipant or a collection of OrganizationalParticipant" , nameof(value));
                    }
                case "owner":
                    base.SetValue(pd.Input, value);
                    return;
                case "parameter":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Parameter.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Parameter parameterValue:
                            this.Parameter.Clear();
                            this.Parameter.Add(parameterValue);
                            return;
                        case IEnumerable<Parameter> parameterValues:
                            this.Parameter.Clear();
                            this.Parameter.AddRange(parameterValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Parameter or a collection of Parameter" , nameof(value));
                    }
                case "parametergroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ParameterGroup.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ParameterGroup parameterGroupValue:
                            this.ParameterGroup.Clear();
                            this.ParameterGroup.Add(parameterGroupValue);
                            return;
                        case IEnumerable<ParameterGroup> parameterGroupValues:
                            this.ParameterGroup.Clear();
                            this.ParameterGroup.AddRange(parameterGroupValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterGroup or a collection of ParameterGroup" , nameof(value));
                    }
                case "referencedelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ReferencedElement.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case NestedElement referencedElementValue:
                            this.ReferencedElement.Clear();
                            this.ReferencedElement.Add(referencedElementValue);
                            return;
                        case IEnumerable<NestedElement> referencedElementValues:
                            this.ReferencedElement.Clear();
                            this.ReferencedElement.AddRange(referencedElementValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a NestedElement or a collection of NestedElement" , nameof(value));
                    }
                case "shortname":
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
                case "containedelement":
                    return pd.Next == null ? (object) new List<ElementUsage>() : new ElementUsage(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "organizationalparticipant":
                    return pd.Next == null ? (object) new List<OrganizationalParticipant>() : new OrganizationalParticipant(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                case "parameter":
                    return pd.Next == null ? (object) new List<Parameter>() : new Parameter(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "parametergroup":
                    return pd.Next == null ? (object) new List<ParameterGroup>() : new ParameterGroup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "referencedelement":
                    return pd.Next == null ? (object) new List<NestedElement>() : new NestedElement(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
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
