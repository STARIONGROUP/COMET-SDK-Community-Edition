// ------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupPropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
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
    public partial class EngineeringModelSetup
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
                case "activedomain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var activeDomainUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && activeDomainUpperBound == int.MaxValue && !this.ActiveDomain.Any())
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
                        activeDomainUpperBound = this.ActiveDomain.Count - 1;
                    }

                    if (this.ActiveDomain.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ActiveDomain property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ActiveDomain.Count - 1 < activeDomainUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ActiveDomain property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ActiveDomain[pd.Lower.Value];
                        }

                        return this.ActiveDomain[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var activeDomainObjects = new List<DomainOfExpertise>();

                        for (var i = pd.Lower.Value; i < activeDomainUpperBound + 1; i++)
                        {
                            activeDomainObjects.Add(this.ActiveDomain[i]);
                        }

                        return activeDomainObjects;
                    }

                    var activeDomainNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < activeDomainUpperBound + 1; i++)
                    {
                        var queryResult = this.ActiveDomain[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    activeDomainNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                activeDomainNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return activeDomainNextObjects;
                case "alias":
                    return base.QueryValue(pd.Input);
                case "defaultorganizationalparticipant":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultOrganizationalParticipant;
                    }

                    if (this.DefaultOrganizationalParticipant != null)
                    {
                        return this.DefaultOrganizationalParticipant.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultorganizationalparticipant = new OrganizationalParticipant(Guid.Empty, null, null);
                    return sentineldefaultorganizationalparticipant.QuerySentinelValue(pd.Next.Input, false);
                case "definition":
                    return base.QueryValue(pd.Input);
                case "engineeringmodeliid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.EngineeringModelIid;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "iterationsetup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var iterationSetupUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && iterationSetupUpperBound == int.MaxValue && !this.IterationSetup.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<IterationSetup>();
                        }

                        var sentinelIterationSetup = new IterationSetup(Guid.Empty, null, null);

                        return sentinelIterationSetup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        iterationSetupUpperBound = this.IterationSetup.Count - 1;
                    }

                    if (this.IterationSetup.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for IterationSetup property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.IterationSetup.Count - 1 < iterationSetupUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the IterationSetup property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.IterationSetup[pd.Lower.Value];
                        }

                        return this.IterationSetup[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var iterationSetupObjects = new List<IterationSetup>();

                        for (var i = pd.Lower.Value; i < iterationSetupUpperBound + 1; i++)
                        {
                            iterationSetupObjects.Add(this.IterationSetup[i]);
                        }

                        return iterationSetupObjects;
                    }

                    var iterationSetupNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < iterationSetupUpperBound + 1; i++)
                    {
                        var queryResult = this.IterationSetup[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    iterationSetupNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                iterationSetupNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return iterationSetupNextObjects;
                case "kind":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Kind;
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
                case "participant":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var participantUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && participantUpperBound == int.MaxValue && !this.Participant.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Participant>();
                        }

                        var sentinelParticipant = new Participant(Guid.Empty, null, null);

                        return sentinelParticipant.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        participantUpperBound = this.Participant.Count - 1;
                    }

                    if (this.Participant.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Participant property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Participant.Count - 1 < participantUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Participant property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Participant[pd.Lower.Value];
                        }

                        return this.Participant[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var participantObjects = new List<Participant>();

                        for (var i = pd.Lower.Value; i < participantUpperBound + 1; i++)
                        {
                            participantObjects.Add(this.Participant[i]);
                        }

                        return participantObjects;
                    }

                    var participantNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < participantUpperBound + 1; i++)
                    {
                        var queryResult = this.Participant[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    participantNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                participantNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return participantNextObjects;
                case "requiredrdl":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var requiredRdlUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && requiredRdlUpperBound == int.MaxValue && !this.RequiredRdl.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ModelReferenceDataLibrary>();
                        }

                        var sentinelModelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.Empty, null, null);

                        return sentinelModelReferenceDataLibrary.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        requiredRdlUpperBound = this.RequiredRdl.Count - 1;
                    }

                    if (this.RequiredRdl.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for RequiredRdl property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.RequiredRdl.Count - 1 < requiredRdlUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the RequiredRdl property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.RequiredRdl[pd.Lower.Value];
                        }

                        return this.RequiredRdl[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var requiredRdlObjects = new List<ModelReferenceDataLibrary>();

                        for (var i = pd.Lower.Value; i < requiredRdlUpperBound + 1; i++)
                        {
                            requiredRdlObjects.Add(this.RequiredRdl[i]);
                        }

                        return requiredRdlObjects;
                    }

                    var requiredRdlNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < requiredRdlUpperBound + 1; i++)
                    {
                        var queryResult = this.RequiredRdl[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    requiredRdlNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                requiredRdlNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return requiredRdlNextObjects;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "sourceengineeringmodelsetupiid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.SourceEngineeringModelSetupIid;
                case "studyphase":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.StudyPhase;
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
                case "activedomain":
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "alias":
                    return pd.Next == null ? (object) new List<Alias>() : new Alias(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "defaultorganizationalparticipant":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new OrganizationalParticipant(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<OrganizationalParticipant>() : default(OrganizationalParticipant);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "engineeringmodeliid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "iterationsetup":
                    return pd.Next == null ? (object) new List<IterationSetup>() : new IterationSetup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "kind":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<EngineeringModelKind>() : null;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "organizationalparticipant":
                    return pd.Next == null ? (object) new List<OrganizationalParticipant>() : new OrganizationalParticipant(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "participant":
                    return pd.Next == null ? (object) new List<Participant>() : new Participant(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "requiredrdl":
                    return pd.Next == null ? (object) new List<ModelReferenceDataLibrary>() : new ModelReferenceDataLibrary(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "sourceengineeringmodelsetupiid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "studyphase":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<StudyPhaseKind>() : null;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
