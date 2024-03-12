// ------------------------------------------------------------------------------------------------
// <copyright file="RequestForWaiverPropertyAccessor.cs" company="RHEA System S.A.">
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

namespace CDP4Common.ReportingData
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
    public partial class RequestForWaiver
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
                case "approvedby":
                    return base.QueryValue(pd.Input);
                case "author":
                    return base.QueryValue(pd.Input);
                case "category":
                    return base.QueryValue(pd.Input);
                case "classification":
                    return base.QueryValue(pd.Input);
                case "content":
                    return base.QueryValue(pd.Input);
                case "createdon":
                    return base.QueryValue(pd.Input);
                case "discussion":
                    return base.QueryValue(pd.Input);
                case "languagecode":
                    return base.QueryValue(pd.Input);
                case "owner":
                    return base.QueryValue(pd.Input);
                case "primaryannotatedthing":
                    return base.QueryValue(pd.Input);
                case "relatedthing":
                    return base.QueryValue(pd.Input);
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "sourceannotation":
                    return base.QueryValue(pd.Input);
                case "status":
                    return base.QueryValue(pd.Input);
                case "title":
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
                case "approvedby":
                    base.SetValue(pd.Input, value);
                    return;
                case "author":
                    base.SetValue(pd.Input, value);
                    return;
                case "category":
                    base.SetValue(pd.Input, value);
                    return;
                case "classification":
                    base.SetValue(pd.Input, value);
                    return;
                case "content":
                    base.SetValue(pd.Input, value);
                    return;
                case "createdon":
                    base.SetValue(pd.Input, value);
                    return;
                case "discussion":
                    base.SetValue(pd.Input, value);
                    return;
                case "languagecode":
                    base.SetValue(pd.Input, value);
                    return;
                case "owner":
                    base.SetValue(pd.Input, value);
                    return;
                case "primaryannotatedthing":
                    base.SetValue(pd.Input, value);
                    return;
                case "relatedthing":
                    base.SetValue(pd.Input, value);
                    return;
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "sourceannotation":
                    base.SetValue(pd.Input, value);
                    return;
                case "status":
                    base.SetValue(pd.Input, value);
                    return;
                case "title":
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
                case "approvedby":
                    return pd.Next == null ? (object) new List<Approval>() : new Approval(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "author":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Participant(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Participant>() : default(Participant);
                case "category":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "classification":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<AnnotationClassificationKind>() : null;
                case "content":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "discussion":
                    return pd.Next == null ? (object) new List<EngineeringModelDataDiscussionItem>() : new EngineeringModelDataDiscussionItem(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "languagecode":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                case "primaryannotatedthing":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ModellingThingReference(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ModellingThingReference>() : default(ModellingThingReference);
                case "relatedthing":
                    return pd.Next == null ? (object) new List<ModellingThingReference>() : new ModellingThingReference(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "sourceannotation":
                    return pd.Next == null ? (object) new List<ActionItem>() : new ActionItem(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "status":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<AnnotationStatusKind>() : null;
                case "title":
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
