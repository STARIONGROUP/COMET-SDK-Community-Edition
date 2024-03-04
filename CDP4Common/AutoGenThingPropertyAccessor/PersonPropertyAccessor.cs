// ------------------------------------------------------------------------------------------------
// <copyright file="PersonPropertyAccessor.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class Person
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
                case "defaultdomain":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultDomain;
                    }

                    if (this.DefaultDomain != null)
                    {
                        return this.DefaultDomain.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultdomain = new DomainOfExpertise(Guid.Empty, null, null);
                    return sentineldefaultdomain.QuerySentinelValue(pd.Next.Input, false);
                case "defaultemailaddress":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultEmailAddress;
                    }

                    if (this.DefaultEmailAddress != null)
                    {
                        return this.DefaultEmailAddress.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultemailaddress = new EmailAddress(Guid.Empty, null, null);
                    return sentineldefaultemailaddress.QuerySentinelValue(pd.Next.Input, false);
                case "defaulttelephonenumber":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultTelephoneNumber;
                    }

                    if (this.DefaultTelephoneNumber != null)
                    {
                        return this.DefaultTelephoneNumber.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaulttelephonenumber = new TelephoneNumber(Guid.Empty, null, null);
                    return sentineldefaulttelephonenumber.QuerySentinelValue(pd.Next.Input, false);
                case "emailaddress":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var emailAddressUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && emailAddressUpperBound == int.MaxValue && !this.EmailAddress.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<EmailAddress>();
                        }

                        var sentinelEmailAddress = new EmailAddress(Guid.Empty, null, null);

                        return sentinelEmailAddress.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        emailAddressUpperBound = this.EmailAddress.Count - 1;
                    }

                    if (this.EmailAddress.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for EmailAddress property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.EmailAddress.Count - 1 < emailAddressUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the EmailAddress property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.EmailAddress[pd.Lower.Value];
                        }

                        return this.EmailAddress[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var emailAddressObjects = new List<EmailAddress>();

                        for (var i = pd.Lower.Value; i < emailAddressUpperBound + 1; i++)
                        {
                            emailAddressObjects.Add(this.EmailAddress[i]);
                        }

                        return emailAddressObjects;
                    }

                    var emailAddressNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < emailAddressUpperBound + 1; i++)
                    {
                        var queryResult = this.EmailAddress[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    emailAddressNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                emailAddressNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return emailAddressNextObjects;
                case "givenname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.GivenName;
                case "isactive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsActive;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.IsDeprecated;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Name;
                case "organization":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Organization;
                    }

                    if (this.Organization != null)
                    {
                        return this.Organization.QueryValue(pd.Next.Input);
                    }

                    var sentinelorganization = new Organization(Guid.Empty, null, null);
                    return sentinelorganization.QuerySentinelValue(pd.Next.Input, false);
                case "organizationalunit":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.OrganizationalUnit;
                case "password":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Password;
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

                    var sentinelrole = new PersonRole(Guid.Empty, null, null);
                    return sentinelrole.QuerySentinelValue(pd.Next.Input, false);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ShortName;
                case "surname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Surname;
                case "telephonenumber":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var telephoneNumberUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && telephoneNumberUpperBound == int.MaxValue && !this.TelephoneNumber.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<TelephoneNumber>();
                        }

                        var sentinelTelephoneNumber = new TelephoneNumber(Guid.Empty, null, null);

                        return sentinelTelephoneNumber.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        telephoneNumberUpperBound = this.TelephoneNumber.Count - 1;
                    }

                    if (this.TelephoneNumber.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for TelephoneNumber property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.TelephoneNumber.Count - 1 < telephoneNumberUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the TelephoneNumber property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.TelephoneNumber[pd.Lower.Value];
                        }

                        return this.TelephoneNumber[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var telephoneNumberObjects = new List<TelephoneNumber>();

                        for (var i = pd.Lower.Value; i < telephoneNumberUpperBound + 1; i++)
                        {
                            telephoneNumberObjects.Add(this.TelephoneNumber[i]);
                        }

                        return telephoneNumberObjects;
                    }

                    var telephoneNumberNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < telephoneNumberUpperBound + 1; i++)
                    {
                        var queryResult = this.TelephoneNumber[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    telephoneNumberNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                telephoneNumberNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return telephoneNumberNextObjects;
                case "userpreference":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var userPreferenceUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && userPreferenceUpperBound == int.MaxValue && !this.UserPreference.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<UserPreference>();
                        }

                        var sentinelUserPreference = new UserPreference(Guid.Empty, null, null);

                        return sentinelUserPreference.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        userPreferenceUpperBound = this.UserPreference.Count - 1;
                    }

                    if (this.UserPreference.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for UserPreference property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.UserPreference.Count - 1 < userPreferenceUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the UserPreference property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.UserPreference[pd.Lower.Value];
                        }

                        return this.UserPreference[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var userPreferenceObjects = new List<UserPreference>();

                        for (var i = pd.Lower.Value; i < userPreferenceUpperBound + 1; i++)
                        {
                            userPreferenceObjects.Add(this.UserPreference[i]);
                        }

                        return userPreferenceObjects;
                    }

                    var userPreferenceNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < userPreferenceUpperBound + 1; i++)
                    {
                        var queryResult = this.UserPreference[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    userPreferenceNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                userPreferenceNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return userPreferenceNextObjects;
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
                case "defaultdomain":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<DomainOfExpertise>() : default(DomainOfExpertise);
                case "defaultemailaddress":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new EmailAddress(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<EmailAddress>() : default(EmailAddress);
                case "defaulttelephonenumber":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new TelephoneNumber(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<TelephoneNumber>() : default(TelephoneNumber);
                case "emailaddress":
                    return pd.Next == null ? (object) new List<EmailAddress>() : new EmailAddress(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "givenname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "isactive":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "isdeprecated":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<bool>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "organization":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Organization(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Organization>() : default(Organization);
                case "organizationalunit":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "password":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "role":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new PersonRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<PersonRole>() : default(PersonRole);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "surname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "telephonenumber":
                    return pd.Next == null ? (object) new List<TelephoneNumber>() : new TelephoneNumber(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "userpreference":
                    return pd.Next == null ? (object) new List<UserPreference>() : new UserPreference(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
