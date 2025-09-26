// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramObjectPropertyAccessor.cs" company="Starion Group S.A.">
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

namespace CDP4Common.DiagramData
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
    public partial class DiagramObject
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
                case "bounds":
                    return base.QueryValue(pd.Input);
                case "depictedthing":
                    return base.QueryValue(pd.Input);
                case "diagramelement":
                    return base.QueryValue(pd.Input);
                case "documentation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Documentation;
                case "localstyle":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "resolution":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Resolution;
                case "sharedstyle":
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
                case "bounds":
                    base.SetValue(pd.Input, value);
                    return;
                case "depictedthing":
                    base.SetValue(pd.Input, value);
                    return;
                case "diagramelement":
                    base.SetValue(pd.Input, value);
                    return;
                case "documentation":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.Documentation = null;
                        return;
                    }

                    if(!(value is string documentationValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.Documentation = documentationValue;
                    return;
                case "localstyle":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "resolution":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is float resolutionValue || (value is string resolutionString) && float.TryParse(resolutionString, out resolutionValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a float" , nameof(value));
                    }

                    this.Resolution = resolutionValue;
                    return;
                case "sharedstyle":
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
                case "bounds":
                    return pd.Next == null ? (object) new List<Bounds>() : new Bounds(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "depictedthing":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ActualFiniteState(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Thing>() : default(Thing);
                case "diagramelement":
                    return pd.Next == null ? (object) new List<DiagramEdge>() : new DiagramEdge(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "documentation":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "localstyle":
                    return pd.Next == null ? (object) new List<OwnedStyle>() : new OwnedStyle(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "resolution":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<float>() : null;
                case "sharedstyle":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new SharedStyle(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<SharedStyle>() : default(SharedStyle);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
