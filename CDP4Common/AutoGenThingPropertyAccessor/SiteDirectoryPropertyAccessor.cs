// ------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryPropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class SiteDirectory
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
                case "annotation":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var annotationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && annotationUpperBound == int.MaxValue && !this.Annotation.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<SiteDirectoryDataAnnotation>();
                        }

                        var sentinelSiteDirectoryDataAnnotation = new SiteDirectoryDataAnnotation(Guid.Empty, null, null);

                        return sentinelSiteDirectoryDataAnnotation.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        annotationUpperBound = this.Annotation.Count - 1;
                    }

                    if (this.Annotation.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Annotation property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Annotation.Count - 1 < annotationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Annotation property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Annotation[pd.Lower.Value];
                        }

                        return this.Annotation[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var annotationObjects = new List<SiteDirectoryDataAnnotation>();

                        for (var i = pd.Lower.Value; i < annotationUpperBound + 1; i++)
                        {
                            annotationObjects.Add(this.Annotation[i]);
                        }

                        return annotationObjects;
                    }

                    var annotationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < annotationUpperBound + 1; i++)
                    {
                        var queryResult = this.Annotation[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    annotationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                annotationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return annotationNextObjects;
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.CreatedOn;
                case "defaultparticipantrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultParticipantRole;
                    }

                    if (this.DefaultParticipantRole != null)
                    {
                        return this.DefaultParticipantRole.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultparticipantrole = new ParticipantRole(Guid.Empty, null, null);
                    return sentineldefaultparticipantrole.QuerySentinelValue(pd.Next.Input, false);
                case "defaultpersonrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultPersonRole;
                    }

                    if (this.DefaultPersonRole != null)
                    {
                        return this.DefaultPersonRole.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultpersonrole = new PersonRole(Guid.Empty, null, null);
                    return sentineldefaultpersonrole.QuerySentinelValue(pd.Next.Input, false);
                case "domain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var domainUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && domainUpperBound == int.MaxValue && !this.Domain.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DomainOfExpertise>();
                        }

                        var sentinelDomainOfExpertise = new DomainOfExpertise(Guid.Empty, null, null);

                        return sentinelDomainOfExpertise.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        domainUpperBound = this.Domain.Count - 1;
                    }

                    if (this.Domain.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Domain property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Domain.Count - 1 < domainUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Domain property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Domain[pd.Lower.Value];
                        }

                        return this.Domain[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var domainObjects = new List<DomainOfExpertise>();

                        for (var i = pd.Lower.Value; i < domainUpperBound + 1; i++)
                        {
                            domainObjects.Add(this.Domain[i]);
                        }

                        return domainObjects;
                    }

                    var domainNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < domainUpperBound + 1; i++)
                    {
                        var queryResult = this.Domain[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    domainNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                domainNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return domainNextObjects;
                case "domaingroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var domainGroupUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && domainGroupUpperBound == int.MaxValue && !this.DomainGroup.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DomainOfExpertiseGroup>();
                        }

                        var sentinelDomainOfExpertiseGroup = new DomainOfExpertiseGroup(Guid.Empty, null, null);

                        return sentinelDomainOfExpertiseGroup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        domainGroupUpperBound = this.DomainGroup.Count - 1;
                    }

                    if (this.DomainGroup.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DomainGroup property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DomainGroup.Count - 1 < domainGroupUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DomainGroup property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DomainGroup[pd.Lower.Value];
                        }

                        return this.DomainGroup[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var domainGroupObjects = new List<DomainOfExpertiseGroup>();

                        for (var i = pd.Lower.Value; i < domainGroupUpperBound + 1; i++)
                        {
                            domainGroupObjects.Add(this.DomainGroup[i]);
                        }

                        return domainGroupObjects;
                    }

                    var domainGroupNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < domainGroupUpperBound + 1; i++)
                    {
                        var queryResult = this.DomainGroup[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    domainGroupNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                domainGroupNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return domainGroupNextObjects;
                case "lastmodifiedon":
                    return base.QueryValue(pd.Input);
                case "logentry":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var logEntryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && logEntryUpperBound == int.MaxValue && !this.LogEntry.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<SiteLogEntry>();
                        }

                        var sentinelSiteLogEntry = new SiteLogEntry(Guid.Empty, null, null);

                        return sentinelSiteLogEntry.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        logEntryUpperBound = this.LogEntry.Count - 1;
                    }

                    if (this.LogEntry.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for LogEntry property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.LogEntry.Count - 1 < logEntryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the LogEntry property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.LogEntry[pd.Lower.Value];
                        }

                        return this.LogEntry[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var logEntryObjects = new List<SiteLogEntry>();

                        for (var i = pd.Lower.Value; i < logEntryUpperBound + 1; i++)
                        {
                            logEntryObjects.Add(this.LogEntry[i]);
                        }

                        return logEntryObjects;
                    }

                    var logEntryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < logEntryUpperBound + 1; i++)
                    {
                        var queryResult = this.LogEntry[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    logEntryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                logEntryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return logEntryNextObjects;
                case "model":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var modelUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && modelUpperBound == int.MaxValue && !this.Model.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<EngineeringModelSetup>();
                        }

                        var sentinelEngineeringModelSetup = new EngineeringModelSetup(Guid.Empty, null, null);

                        return sentinelEngineeringModelSetup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        modelUpperBound = this.Model.Count - 1;
                    }

                    if (this.Model.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Model property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Model.Count - 1 < modelUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Model property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Model[pd.Lower.Value];
                        }

                        return this.Model[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var modelObjects = new List<EngineeringModelSetup>();

                        for (var i = pd.Lower.Value; i < modelUpperBound + 1; i++)
                        {
                            modelObjects.Add(this.Model[i]);
                        }

                        return modelObjects;
                    }

                    var modelNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < modelUpperBound + 1; i++)
                    {
                        var queryResult = this.Model[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    modelNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                modelNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return modelNextObjects;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Name;
                case "naturallanguage":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var naturalLanguageUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && naturalLanguageUpperBound == int.MaxValue && !this.NaturalLanguage.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<NaturalLanguage>();
                        }

                        var sentinelNaturalLanguage = new NaturalLanguage(Guid.Empty, null, null);

                        return sentinelNaturalLanguage.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        naturalLanguageUpperBound = this.NaturalLanguage.Count - 1;
                    }

                    if (this.NaturalLanguage.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for NaturalLanguage property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.NaturalLanguage.Count - 1 < naturalLanguageUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the NaturalLanguage property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.NaturalLanguage[pd.Lower.Value];
                        }

                        return this.NaturalLanguage[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var naturalLanguageObjects = new List<NaturalLanguage>();

                        for (var i = pd.Lower.Value; i < naturalLanguageUpperBound + 1; i++)
                        {
                            naturalLanguageObjects.Add(this.NaturalLanguage[i]);
                        }

                        return naturalLanguageObjects;
                    }

                    var naturalLanguageNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < naturalLanguageUpperBound + 1; i++)
                    {
                        var queryResult = this.NaturalLanguage[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    naturalLanguageNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                naturalLanguageNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return naturalLanguageNextObjects;
                case "organization":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var organizationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && organizationUpperBound == int.MaxValue && !this.Organization.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Organization>();
                        }

                        var sentinelOrganization = new Organization(Guid.Empty, null, null);

                        return sentinelOrganization.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        organizationUpperBound = this.Organization.Count - 1;
                    }

                    if (this.Organization.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Organization property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Organization.Count - 1 < organizationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Organization property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Organization[pd.Lower.Value];
                        }

                        return this.Organization[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var organizationObjects = new List<Organization>();

                        for (var i = pd.Lower.Value; i < organizationUpperBound + 1; i++)
                        {
                            organizationObjects.Add(this.Organization[i]);
                        }

                        return organizationObjects;
                    }

                    var organizationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < organizationUpperBound + 1; i++)
                    {
                        var queryResult = this.Organization[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    organizationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                organizationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return organizationNextObjects;
                case "participantrole":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var participantRoleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && participantRoleUpperBound == int.MaxValue && !this.ParticipantRole.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ParticipantRole>();
                        }

                        var sentinelParticipantRole = new ParticipantRole(Guid.Empty, null, null);

                        return sentinelParticipantRole.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        participantRoleUpperBound = this.ParticipantRole.Count - 1;
                    }

                    if (this.ParticipantRole.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ParticipantRole property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ParticipantRole.Count - 1 < participantRoleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ParticipantRole property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ParticipantRole[pd.Lower.Value];
                        }

                        return this.ParticipantRole[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var participantRoleObjects = new List<ParticipantRole>();

                        for (var i = pd.Lower.Value; i < participantRoleUpperBound + 1; i++)
                        {
                            participantRoleObjects.Add(this.ParticipantRole[i]);
                        }

                        return participantRoleObjects;
                    }

                    var participantRoleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < participantRoleUpperBound + 1; i++)
                    {
                        var queryResult = this.ParticipantRole[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    participantRoleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                participantRoleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return participantRoleNextObjects;
                case "person":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var personUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && personUpperBound == int.MaxValue && !this.Person.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Person>();
                        }

                        var sentinelPerson = new Person(Guid.Empty, null, null);

                        return sentinelPerson.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        personUpperBound = this.Person.Count - 1;
                    }

                    if (this.Person.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Person property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Person.Count - 1 < personUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Person property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Person[pd.Lower.Value];
                        }

                        return this.Person[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var personObjects = new List<Person>();

                        for (var i = pd.Lower.Value; i < personUpperBound + 1; i++)
                        {
                            personObjects.Add(this.Person[i]);
                        }

                        return personObjects;
                    }

                    var personNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < personUpperBound + 1; i++)
                    {
                        var queryResult = this.Person[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    personNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                personNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return personNextObjects;
                case "personrole":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var personRoleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && personRoleUpperBound == int.MaxValue && !this.PersonRole.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<PersonRole>();
                        }

                        var sentinelPersonRole = new PersonRole(Guid.Empty, null, null);

                        return sentinelPersonRole.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        personRoleUpperBound = this.PersonRole.Count - 1;
                    }

                    if (this.PersonRole.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for PersonRole property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.PersonRole.Count - 1 < personRoleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the PersonRole property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.PersonRole[pd.Lower.Value];
                        }

                        return this.PersonRole[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var personRoleObjects = new List<PersonRole>();

                        for (var i = pd.Lower.Value; i < personRoleUpperBound + 1; i++)
                        {
                            personRoleObjects.Add(this.PersonRole[i]);
                        }

                        return personRoleObjects;
                    }

                    var personRoleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < personRoleUpperBound + 1; i++)
                    {
                        var queryResult = this.PersonRole[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    personRoleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                personRoleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return personRoleNextObjects;
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ShortName;
                case "sitereferencedatalibrary":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var siteReferenceDataLibraryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && siteReferenceDataLibraryUpperBound == int.MaxValue && !this.SiteReferenceDataLibrary.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<SiteReferenceDataLibrary>();
                        }

                        var sentinelSiteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.Empty, null, null);

                        return sentinelSiteReferenceDataLibrary.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        siteReferenceDataLibraryUpperBound = this.SiteReferenceDataLibrary.Count - 1;
                    }

                    if (this.SiteReferenceDataLibrary.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for SiteReferenceDataLibrary property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.SiteReferenceDataLibrary.Count - 1 < siteReferenceDataLibraryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the SiteReferenceDataLibrary property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.SiteReferenceDataLibrary[pd.Lower.Value];
                        }

                        return this.SiteReferenceDataLibrary[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var siteReferenceDataLibraryObjects = new List<SiteReferenceDataLibrary>();

                        for (var i = pd.Lower.Value; i < siteReferenceDataLibraryUpperBound + 1; i++)
                        {
                            siteReferenceDataLibraryObjects.Add(this.SiteReferenceDataLibrary[i]);
                        }

                        return siteReferenceDataLibraryObjects;
                    }

                    var siteReferenceDataLibraryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < siteReferenceDataLibraryUpperBound + 1; i++)
                    {
                        var queryResult = this.SiteReferenceDataLibrary[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    siteReferenceDataLibraryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                siteReferenceDataLibraryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return siteReferenceDataLibraryNextObjects;
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
                case "annotation":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Annotation.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case SiteDirectoryDataAnnotation annotationValue:
                            this.Annotation.Clear();
                            this.Annotation.Add(annotationValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Annotation.Clear();
                            this.Annotation.AddRange(thingValues.OfType<SiteDirectoryDataAnnotation>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a SiteDirectoryDataAnnotation or a collection of SiteDirectoryDataAnnotation" , nameof(value));
                    }
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
                case "defaultparticipantrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ParticipantRole defaultParticipantRoleValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParticipantRole" , nameof(value));
                    }

                    this.DefaultParticipantRole = defaultParticipantRoleValue;
                    return;
                case "defaultpersonrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is PersonRole defaultPersonRoleValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a PersonRole" , nameof(value));
                    }

                    this.DefaultPersonRole = defaultPersonRoleValue;
                    return;
                case "domain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Domain.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case DomainOfExpertise domainValue:
                            this.Domain.Clear();
                            this.Domain.Add(domainValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Domain.Clear();
                            this.Domain.AddRange(thingValues.OfType<DomainOfExpertise>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertise or a collection of DomainOfExpertise" , nameof(value));
                    }
                case "domaingroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.DomainGroup.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case DomainOfExpertiseGroup domainGroupValue:
                            this.DomainGroup.Clear();
                            this.DomainGroup.Add(domainGroupValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.DomainGroup.Clear();
                            this.DomainGroup.AddRange(thingValues.OfType<DomainOfExpertiseGroup>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertiseGroup or a collection of DomainOfExpertiseGroup" , nameof(value));
                    }
                case "lastmodifiedon":
                    base.SetValue(pd.Input, value);
                    return;
                case "logentry":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.LogEntry.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case SiteLogEntry logEntryValue:
                            this.LogEntry.Clear();
                            this.LogEntry.Add(logEntryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.LogEntry.Clear();
                            this.LogEntry.AddRange(thingValues.OfType<SiteLogEntry>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a SiteLogEntry or a collection of SiteLogEntry" , nameof(value));
                    }
                case "model":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Model.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case EngineeringModelSetup modelValue:
                            this.Model.Clear();
                            this.Model.Add(modelValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Model.Clear();
                            this.Model.AddRange(thingValues.OfType<EngineeringModelSetup>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a EngineeringModelSetup or a collection of EngineeringModelSetup" , nameof(value));
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
                case "naturallanguage":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.NaturalLanguage.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case NaturalLanguage naturalLanguageValue:
                            this.NaturalLanguage.Clear();
                            this.NaturalLanguage.Add(naturalLanguageValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.NaturalLanguage.Clear();
                            this.NaturalLanguage.AddRange(thingValues.OfType<NaturalLanguage>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a NaturalLanguage or a collection of NaturalLanguage" , nameof(value));
                    }
                case "organization":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Organization.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Organization organizationValue:
                            this.Organization.Clear();
                            this.Organization.Add(organizationValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Organization.Clear();
                            this.Organization.AddRange(thingValues.OfType<Organization>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Organization or a collection of Organization" , nameof(value));
                    }
                case "participantrole":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ParticipantRole.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ParticipantRole participantRoleValue:
                            this.ParticipantRole.Clear();
                            this.ParticipantRole.Add(participantRoleValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ParticipantRole.Clear();
                            this.ParticipantRole.AddRange(thingValues.OfType<ParticipantRole>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParticipantRole or a collection of ParticipantRole" , nameof(value));
                    }
                case "person":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Person.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Person personValue:
                            this.Person.Clear();
                            this.Person.Add(personValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Person.Clear();
                            this.Person.AddRange(thingValues.OfType<Person>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Person or a collection of Person" , nameof(value));
                    }
                case "personrole":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.PersonRole.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case PersonRole personRoleValue:
                            this.PersonRole.Clear();
                            this.PersonRole.Add(personRoleValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.PersonRole.Clear();
                            this.PersonRole.AddRange(thingValues.OfType<PersonRole>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a PersonRole or a collection of PersonRole" , nameof(value));
                    }
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.ShortName = null;
                        return;
                    }

                    if(!(value is string shortNameValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.ShortName = shortNameValue;
                    return;
                case "sitereferencedatalibrary":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.SiteReferenceDataLibrary.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case SiteReferenceDataLibrary siteReferenceDataLibraryValue:
                            this.SiteReferenceDataLibrary.Clear();
                            this.SiteReferenceDataLibrary.Add(siteReferenceDataLibraryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.SiteReferenceDataLibrary.Clear();
                            this.SiteReferenceDataLibrary.AddRange(thingValues.OfType<SiteReferenceDataLibrary>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a SiteReferenceDataLibrary or a collection of SiteReferenceDataLibrary" , nameof(value));
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
                case "annotation":
                    return pd.Next == null ? (object) new List<SiteDirectoryDataAnnotation>() : new SiteDirectoryDataAnnotation(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "createdon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "defaultparticipantrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ParticipantRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ParticipantRole>() : default(ParticipantRole);
                case "defaultpersonrole":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new PersonRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<PersonRole>() : default(PersonRole);
                case "domain":
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "domaingroup":
                    return pd.Next == null ? (object) new List<DomainOfExpertiseGroup>() : new DomainOfExpertiseGroup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "lastmodifiedon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "logentry":
                    return pd.Next == null ? (object) new List<SiteLogEntry>() : new SiteLogEntry(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "model":
                    return pd.Next == null ? (object) new List<EngineeringModelSetup>() : new EngineeringModelSetup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "naturallanguage":
                    return pd.Next == null ? (object) new List<NaturalLanguage>() : new NaturalLanguage(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "organization":
                    return pd.Next == null ? (object) new List<Organization>() : new Organization(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "participantrole":
                    return pd.Next == null ? (object) new List<ParticipantRole>() : new ParticipantRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "person":
                    return pd.Next == null ? (object) new List<Person>() : new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "personrole":
                    return pd.Next == null ? (object) new List<PersonRole>() : new PersonRole(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "sitereferencedatalibrary":
                    return pd.Next == null ? (object) new List<SiteReferenceDataLibrary>() : new SiteReferenceDataLibrary(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
