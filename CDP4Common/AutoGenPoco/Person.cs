// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="RHEA System S.A.">
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a physical person that is a potential Participant in a       concurrent       engineering       activity
    /// Note 1: Person maps to 'person' as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF       RFC       4519</a>).
    /// Note 2: Property <i>shortName</i> is used as a user account name       for       E-TM-10-25       implementations.       It       maps       to       LDAP attribute       'uid',       as       defined       in       LDAP       (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF       RFC       4519</a>).
    /// </summary>
    [Container(typeof(SiteDirectory), "Person")]
    public partial class Person : Thing, IDeprecatableThing, INamedThing, IShortNamedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NONE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.EmailAddress = new ContainerList<EmailAddress>(this);
            this.TelephoneNumber = new ContainerList<TelephoneNumber>(this);
            this.UserPreference = new ContainerList<UserPreference>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="CacheKey"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public Person(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.EmailAddress = new ContainerList<EmailAddress>(this);
            this.TelephoneNumber = new ContainerList<TelephoneNumber>(this);
            this.UserPreference = new ContainerList<UserPreference>(this);
        }

        /// <summary>
        /// Gets or sets the DefaultDomain.
        /// </summary>
        /// <remarks>
        /// optional reference to the DomainOfExpertise that this Person represents by default
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DomainOfExpertise DefaultDomain { get; set; }

        /// <summary>
        /// Gets or sets the DefaultEmailAddress.
        /// </summary>
        /// <remarks>
        /// optional reference to the default e-mail address of this Person
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public EmailAddress DefaultEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the DefaultTelephoneNumber.
        /// </summary>
        /// <remarks>
        /// optional reference to the default telephone number of this Person
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public TelephoneNumber DefaultTelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a list of contained EmailAddress.
        /// </summary>
        /// <remarks>
        /// e-mail address(es) of this Person
        /// Note: Each e-mail address shall comply with the SMTP protocol as specified in <a href="http://datatracker.ietf.org/doc/rfc5321/">IETF RFC 5321</a>, i.e. "user-name@domain" or "Full Name <user-name@domain>".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<EmailAddress> EmailAddress { get; protected set; }

        /// <summary>
        /// Gets or sets the GivenName.
        /// </summary>
        /// <remarks>
        /// given name of this Person
        /// Note: Property <i>givenName</i> maps to 'givenName', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF RFC 4519</a>).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        /// <remarks>
        /// assertion whether this Person is still an active member in at least one       concurrent       engineering       team
        /// Note: Set to <i>false</i> implies that this Person does no longer       have       access       to       the       E-TM-10-25       environment       and       data       that       is       controlled       via       the       SiteDirectory       containing       the       Person.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// derived full name of this Person
        /// Note: This property maps to 'cn' or 'commonName', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF       RFC       4519</a>),       and       consists       of       the       concatenation       of       <i>givenName</i>,       a       space       and       <i>surname</i>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string Name
        {
            get { return this.GetDerivedName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property Person.Name"); }
        }

        /// <summary>
        /// Gets or sets the Organization.
        /// </summary>
        /// <remarks>
        /// optional reference to the Organization that this Person works for
        /// Note: Property <i>organization</i> maps to 'o' or 'organization', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF RFC 4519</a>).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationalUnit.
        /// </summary>
        /// <remarks>
        /// optional organizational unit that this Person belongs to
        /// Note: Property <i>organizationalUnit</i> maps to 'ou' or 'organizationalUnit', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF RFC 4519</a>).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string OrganizationalUnit { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <remarks>
        /// optional definition of the password for this Person for use with user authentication handling by an implementation of this data model
        /// Note: A server implementation may provide several modes of authentication: e.g. based on local / self-contained or LDAP or other network accessible authentication services. The local / self-contained mode would use this password property. The mode using LDAP or other network accessible services would neglect this password property and use the passwords from the network service.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        /// <remarks>
        /// reference to the PersonRole assigned to this Person
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public PersonRole Role { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <remarks>
        /// Note 1: The implied LanguageCode of <i>shortName</i> is "en-GB".
        /// Note 2: The <i>shortName</i> is meant to be used to refer to something where little space is available, for example to name a domain of expertise, a parameter or a measurement scale or unit in the column header of a table or in a formula.
        /// Note 3: A <i>shortName</i> may be an acronym or an abbreviated term.
        /// Note 4: A <i>shortName</i> should not contain any whitespace. Additional constraints are defined for some specializations of ShortNamedThing in order to ensure that the <i>shortName</i> can be used as a variable name in a programming or modelling language.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the Surname.
        /// </summary>
        /// <remarks>
        /// surname of this Person
        /// Note: Property <i>surname</i> maps to 'sn' or 'surname', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF RFC 4519</a>).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets a list of contained TelephoneNumber.
        /// </summary>
        /// <remarks>
        /// telephone number(s) of this Person
        /// Note 1: The telephone numbers shall be written in the following form:  "+cc-ac-localnumber", where cc is the country code and ac is the area code.
        /// Note 2: Property <i>telephoneNumber</i> maps to 'telephoneNumber', as defined in LDAP (<a href="http://datatracker.ietf.org/doc/rfc4519/">IETF RFC 4519</a>).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<TelephoneNumber> TelephoneNumber { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained UserPreference.
        /// </summary>
        /// <remarks>
        /// set of user-defined preferences of this Person
        /// Note: UserPreferences provide a flexible and extensible way to define preferences in the form of key-value pairs that a Person can store on an E-TM-10-25 compatible server in order to configure one or more client applications for his or her use.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<UserPreference> UserPreference { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Person"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.EmailAddress);
                containers.Add(this.TelephoneNumber);
                containers.Add(this.UserPreference);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Person"/>
        /// </summary>
        /// <remarks>
        /// This does not include the contained <see cref="Thing"/>s, the contained <see cref="Thing"/>s
        /// are exposed via the <see cref="ContainerLists"/> property
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerable{Thing}"/>
        /// </returns>
        public override IEnumerable<Thing> QueryReferencedThings()
        {
            foreach (var thing in base.QueryReferencedThings())
            {
                yield return thing;
            }

            if (this.DefaultDomain != null)
            {
                yield return this.DefaultDomain;
            }

            if (this.DefaultEmailAddress != null)
            {
                yield return this.DefaultEmailAddress;
            }

            if (this.DefaultTelephoneNumber != null)
            {
                yield return this.DefaultTelephoneNumber;
            }

            if (this.Organization != null)
            {
                yield return this.Organization;
            }

            if (this.Role != null)
            {
                yield return this.Role;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Person"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Person"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Person)this.MemberwiseClone();
            clone.EmailAddress = cloneContainedThings ? new ContainerList<EmailAddress>(clone) : new ContainerList<EmailAddress>(this.EmailAddress, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.TelephoneNumber = cloneContainedThings ? new ContainerList<TelephoneNumber>(clone) : new ContainerList<TelephoneNumber>(this.TelephoneNumber, clone);
            clone.UserPreference = cloneContainedThings ? new ContainerList<UserPreference>(clone) : new ContainerList<UserPreference>(this.UserPreference, clone);

            if (cloneContainedThings)
            {
                clone.EmailAddress.AddRange(this.EmailAddress.Select(x => x.Clone(true)));
                clone.TelephoneNumber.AddRange(this.TelephoneNumber.Select(x => x.Clone(true)));
                clone.UserPreference.AddRange(this.UserPreference.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Person"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Person"/>.
        /// </returns>
        public new Person Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Person)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Person"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.GivenName))
            {
                errorList.Add("The property GivenName is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.ShortName))
            {
                errorList.Add("The property ShortName is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.Surname))
            {
                errorList.Add("The property Surname is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="Person"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Person;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current Person POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.DefaultDomain = (dto.DefaultDomain.HasValue) ? this.Cache.Get<DomainOfExpertise>(dto.DefaultDomain.Value, dto.IterationContainerId) : null;
            this.DefaultEmailAddress = (dto.DefaultEmailAddress.HasValue) ? this.Cache.Get<EmailAddress>(dto.DefaultEmailAddress.Value, dto.IterationContainerId) : null;
            this.DefaultTelephoneNumber = (dto.DefaultTelephoneNumber.HasValue) ? this.Cache.Get<TelephoneNumber>(dto.DefaultTelephoneNumber.Value, dto.IterationContainerId) : null;
            this.EmailAddress.ResolveList(dto.EmailAddress, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.GivenName = dto.GivenName;
            this.IsActive = dto.IsActive;
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Organization = (dto.Organization.HasValue) ? this.Cache.Get<Organization>(dto.Organization.Value, dto.IterationContainerId) : null;
            this.OrganizationalUnit = dto.OrganizationalUnit;
            this.Password = dto.Password;
            this.RevisionNumber = dto.RevisionNumber;
            this.Role = (dto.Role.HasValue) ? this.Cache.Get<PersonRole>(dto.Role.Value, dto.IterationContainerId) : null;
            this.ShortName = dto.ShortName;
            this.Surname = dto.Surname;
            this.TelephoneNumber.ResolveList(dto.TelephoneNumber, dto.IterationContainerId, this.Cache);
            this.ThingPreference = dto.ThingPreference;
            this.UserPreference.ResolveList(dto.UserPreference, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Person"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Person(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.DefaultDomain = this.DefaultDomain != null ? (Guid?)this.DefaultDomain.Iid : null;
            dto.DefaultEmailAddress = this.DefaultEmailAddress != null ? (Guid?)this.DefaultEmailAddress.Iid : null;
            dto.DefaultTelephoneNumber = this.DefaultTelephoneNumber != null ? (Guid?)this.DefaultTelephoneNumber.Iid : null;
            dto.EmailAddress.AddRange(this.EmailAddress.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.GivenName = this.GivenName;
            dto.IsActive = this.IsActive;
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Organization = this.Organization != null ? (Guid?)this.Organization.Iid : null;
            dto.OrganizationalUnit = this.OrganizationalUnit;
            dto.Password = this.Password;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Role = this.Role != null ? (Guid?)this.Role.Iid : null;
            dto.ShortName = this.ShortName;
            dto.Surname = this.Surname;
            dto.TelephoneNumber.AddRange(this.TelephoneNumber.Select(x => x.Iid));
            dto.ThingPreference = this.ThingPreference;
            dto.UserPreference.AddRange(this.UserPreference.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
