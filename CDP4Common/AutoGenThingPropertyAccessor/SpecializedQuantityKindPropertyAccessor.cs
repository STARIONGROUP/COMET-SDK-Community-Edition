// ------------------------------------------------------------------------------------------------
// <copyright file="SpecializedQuantityKindPropertyAccessor.cs" company="RHEA System S.A.">
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
    public partial class SpecializedQuantityKind
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
                case "allpossiblescale":
                    return base.QueryValue(pd.Input);
                case "category":
                    return base.QueryValue(pd.Input);
                case "defaultscale":
                    return base.QueryValue(pd.Input);
                case "definition":
                    return base.QueryValue(pd.Input);
                case "general":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.General;
                    }

                    if (this.General != null)
                    {
                        return this.General.QueryValue(pd.Next.Input);
                    }

                    var sentinelgeneral = new DerivedQuantityKind(Guid.Empty, null, null);
                    return sentinelgeneral.QuerySentinelValue(pd.Next.Input, false);
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "isdeprecated":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "numberofvalues":
                    return base.QueryValue(pd.Input);
                case "possiblescale":
                    return base.QueryValue(pd.Input);
                case "quantitydimensionexponent":
                    return base.QueryValue(pd.Input);
                case "quantitydimensionexpression":
                    return base.QueryValue(pd.Input);
                case "quantitydimensionsymbol":
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
                case "allpossiblescale":
                    base.SetValue(pd.Input, value);
                    return;
                case "category":
                    base.SetValue(pd.Input, value);
                    return;
                case "defaultscale":
                    base.SetValue(pd.Input, value);
                    return;
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "general":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is QuantityKind generalValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a QuantityKind" , nameof(value));
                    }

                    this.General = generalValue;
                    return;
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "isdeprecated":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "numberofvalues":
                    base.SetValue(pd.Input, value);
                    return;
                case "possiblescale":
                    base.SetValue(pd.Input, value);
                    return;
                case "quantitydimensionexponent":
                    base.SetValue(pd.Input, value);
                    return;
                case "quantitydimensionexpression":
                    base.SetValue(pd.Input, value);
                    return;
                case "quantitydimensionsymbol":
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
                case "allpossiblescale":
                    return pd.Next == null ? (object) new List<IntervalScale>() : new IntervalScale(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "category":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "defaultscale":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new IntervalScale(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<MeasurementScale>() : default(MeasurementScale);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "general":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DerivedQuantityKind(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<QuantityKind>() : default(QuantityKind);
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "numberofvalues":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "possiblescale":
                    return pd.Next == null ? (object) new List<IntervalScale>() : new IntervalScale(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "quantitydimensionexponent":
                    pd.VerifyPropertyDescriptorForEnumerableValueProperty();
                    return isCallerEmunerable ? (object)new List<string>() : null;
                case "quantitydimensionexpression":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "quantitydimensionsymbol":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
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
