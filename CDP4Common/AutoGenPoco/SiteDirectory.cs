// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectory.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    /// resource directory that contains (references to) the data that is used
    /// across all models, templates, catalogues and reference data for a
    /// specific concurrent design centre
    /// Note: Typically one concurrent design centre will deploy a single
    /// instance of a  SiteDirectory which is then a
    /// central administrative resource.
    /// </summary>
    public partial class SiteDirectory : TopContainer, INamedThing, IShortNamedThing, ITimeStampedThing
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
        /// Initializes a new instance of the <see cref="SiteDirectory"/> class.
        /// </summary>
        public SiteDirectory()
        {
            this.Annotation = new ContainerList<SiteDirectoryDataAnnotation>(this);
            this.Domain = new ContainerList<DomainOfExpertise>(this);
            this.DomainGroup = new ContainerList<DomainOfExpertiseGroup>(this);
            this.LogEntry = new ContainerList<SiteLogEntry>(this);
            this.Model = new ContainerList<EngineeringModelSetup>(this);
            this.NaturalLanguage = new ContainerList<NaturalLanguage>(this);
            this.Organization = new ContainerList<Organization>(this);
            this.ParticipantRole = new ContainerList<ParticipantRole>(this);
            this.Person = new ContainerList<Person>(this);
            this.PersonRole = new ContainerList<PersonRole>(this);
            this.SiteReferenceDataLibrary = new ContainerList<SiteReferenceDataLibrary>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectory"/> class.
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
        public SiteDirectory(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Annotation = new ContainerList<SiteDirectoryDataAnnotation>(this);
            this.Domain = new ContainerList<DomainOfExpertise>(this);
            this.DomainGroup = new ContainerList<DomainOfExpertiseGroup>(this);
            this.LogEntry = new ContainerList<SiteLogEntry>(this);
            this.Model = new ContainerList<EngineeringModelSetup>(this);
            this.NaturalLanguage = new ContainerList<NaturalLanguage>(this);
            this.Organization = new ContainerList<Organization>(this);
            this.ParticipantRole = new ContainerList<ParticipantRole>(this);
            this.Person = new ContainerList<Person>(this);
            this.PersonRole = new ContainerList<PersonRole>(this);
            this.SiteReferenceDataLibrary = new ContainerList<SiteReferenceDataLibrary>(this);
        }

        /// <summary>
        /// Gets or sets a list of contained SiteDirectoryDataAnnotation.
        /// </summary>
        /// <remarks>
        /// Annotation on Things that are contained by the SiteDirectory
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SiteDirectoryDataAnnotation> Annotation { get; protected set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        /// <remarks>
        /// Note 1: This implies that any value shall comply with the following (informative) ISO 8601 format "yyyy-mm-ddThh:mm:ss.sssZ".
        /// Note 2: All persistent date-and-time-stamps in this model shall be stored in UTC. When local calendar dates and clock times in a specific timezone are needed they shall be converted on the fly from and to UTC by client applications.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the DefaultParticipantRole.
        /// </summary>
        /// <remarks>
        /// specification of the default ParticipantRole to be used when creating a new Participant in an EngineeringModelSetup
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParticipantRole DefaultParticipantRole { get; set; }

        /// <summary>
        /// Gets or sets the DefaultPersonRole.
        /// </summary>
        /// <remarks>
        /// specification of the default PersonRole to be used when creating a new Person
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public PersonRole DefaultPersonRole { get; set; }

        /// <summary>
        /// Gets or sets a list of contained DomainOfExpertise.
        /// </summary>
        /// <remarks>
        /// collection of domains of expertise (DomainOfExpertise) known in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<DomainOfExpertise> Domain { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained DomainOfExpertiseGroup.
        /// </summary>
        /// <remarks>
        /// collection of DomainOfExpertiseGroups defined for this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<DomainOfExpertiseGroup> DomainGroup { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained SiteLogEntry.
        /// </summary>
        /// <remarks>
        /// collection of logbook entries (SiteLogEntry) for this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SiteLogEntry> LogEntry { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained EngineeringModelSetup.
        /// </summary>
        /// <remarks>
        /// specification of the engineering models (EngineeringModelSetups) defined in this SiteDirectory
        /// Note: In an implementation of SiteDirectory it may be useful - for performance reasons - to add a cache that contains consolidated information from a collection of models, e.g. the participants with their roles and domains in various concurrent engineering studies.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<EngineeringModelSetup> Model { get; protected set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// human readable character string in English by which something can be       referred       to
        /// Note: The implied LanguageCode of <i>name</i> is "en-GB".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of contained NaturalLanguage.
        /// </summary>
        /// <remarks>
        /// collection of NaturalLanguages known in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<NaturalLanguage> NaturalLanguage { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Organization.
        /// </summary>
        /// <remarks>
        /// specification of the Organizations known in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Organization> Organization { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ParticipantRole.
        /// </summary>
        /// <remarks>
        /// collection of ParticipantRoles defined in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParticipantRole> ParticipantRole { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Person.
        /// </summary>
        /// <remarks>
        /// specification of the Persons known in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Person> Person { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained PersonRole.
        /// </summary>
        /// <remarks>
        /// collection of PersonRoles defined in this SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<PersonRole> PersonRole { get; protected set; }

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
        /// Gets or sets a list of contained SiteReferenceDataLibrary.
        /// </summary>
        /// <remarks>
        /// specification of the ReferenceDataLibraries defined in this     SiteDirectory
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SiteReferenceDataLibrary> SiteReferenceDataLibrary { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="SiteDirectory"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Annotation);
                containers.Add(this.Domain);
                containers.Add(this.DomainGroup);
                containers.Add(this.LogEntry);
                containers.Add(this.Model);
                containers.Add(this.NaturalLanguage);
                containers.Add(this.Organization);
                containers.Add(this.ParticipantRole);
                containers.Add(this.Person);
                containers.Add(this.PersonRole);
                containers.Add(this.SiteReferenceDataLibrary);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="SiteDirectory"/>
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

            if (this.DefaultParticipantRole != null)
            {
                yield return this.DefaultParticipantRole;
            }

            if (this.DefaultPersonRole != null)
            {
                yield return this.DefaultPersonRole;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteDirectory"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteDirectory"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (SiteDirectory)this.MemberwiseClone();
            clone.Annotation = cloneContainedThings ? new ContainerList<SiteDirectoryDataAnnotation>(clone) : new ContainerList<SiteDirectoryDataAnnotation>(this.Annotation, clone);
            clone.Domain = cloneContainedThings ? new ContainerList<DomainOfExpertise>(clone) : new ContainerList<DomainOfExpertise>(this.Domain, clone);
            clone.DomainGroup = cloneContainedThings ? new ContainerList<DomainOfExpertiseGroup>(clone) : new ContainerList<DomainOfExpertiseGroup>(this.DomainGroup, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.LogEntry = cloneContainedThings ? new ContainerList<SiteLogEntry>(clone) : new ContainerList<SiteLogEntry>(this.LogEntry, clone);
            clone.Model = cloneContainedThings ? new ContainerList<EngineeringModelSetup>(clone) : new ContainerList<EngineeringModelSetup>(this.Model, clone);
            clone.NaturalLanguage = cloneContainedThings ? new ContainerList<NaturalLanguage>(clone) : new ContainerList<NaturalLanguage>(this.NaturalLanguage, clone);
            clone.Organization = cloneContainedThings ? new ContainerList<Organization>(clone) : new ContainerList<Organization>(this.Organization, clone);
            clone.ParticipantRole = cloneContainedThings ? new ContainerList<ParticipantRole>(clone) : new ContainerList<ParticipantRole>(this.ParticipantRole, clone);
            clone.Person = cloneContainedThings ? new ContainerList<Person>(clone) : new ContainerList<Person>(this.Person, clone);
            clone.PersonRole = cloneContainedThings ? new ContainerList<PersonRole>(clone) : new ContainerList<PersonRole>(this.PersonRole, clone);
            clone.SiteReferenceDataLibrary = cloneContainedThings ? new ContainerList<SiteReferenceDataLibrary>(clone) : new ContainerList<SiteReferenceDataLibrary>(this.SiteReferenceDataLibrary, clone);

            if (cloneContainedThings)
            {
                clone.Annotation.AddRange(this.Annotation.Select(x => x.Clone(true)));
                clone.Domain.AddRange(this.Domain.Select(x => x.Clone(true)));
                clone.DomainGroup.AddRange(this.DomainGroup.Select(x => x.Clone(true)));
                clone.LogEntry.AddRange(this.LogEntry.Select(x => x.Clone(true)));
                clone.Model.AddRange(this.Model.Select(x => x.Clone(true)));
                clone.NaturalLanguage.AddRange(this.NaturalLanguage.Select(x => x.Clone(true)));
                clone.Organization.AddRange(this.Organization.Select(x => x.Clone(true)));
                clone.ParticipantRole.AddRange(this.ParticipantRole.Select(x => x.Clone(true)));
                clone.Person.AddRange(this.Person.Select(x => x.Clone(true)));
                clone.PersonRole.AddRange(this.PersonRole.Select(x => x.Clone(true)));
                clone.SiteReferenceDataLibrary.AddRange(this.SiteReferenceDataLibrary.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteDirectory"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteDirectory"/>.
        /// </returns>
        public new SiteDirectory Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (SiteDirectory)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="SiteDirectory"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errorList.Add("The property Name is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.ShortName))
            {
                errorList.Add("The property ShortName is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="SiteDirectory"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.SiteDirectory;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current SiteDirectory POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.Annotation.ResolveList(dto.Annotation, dto.IterationContainerId, this.Cache);
            this.CreatedOn = dto.CreatedOn;
            this.DefaultParticipantRole = (dto.DefaultParticipantRole.HasValue) ? this.Cache.Get<ParticipantRole>(dto.DefaultParticipantRole.Value, dto.IterationContainerId) : null;
            this.DefaultPersonRole = (dto.DefaultPersonRole.HasValue) ? this.Cache.Get<PersonRole>(dto.DefaultPersonRole.Value, dto.IterationContainerId) : null;
            this.Domain.ResolveList(dto.Domain, dto.IterationContainerId, this.Cache);
            this.DomainGroup.ResolveList(dto.DomainGroup, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LastModifiedOn = dto.LastModifiedOn;
            this.LogEntry.ResolveList(dto.LogEntry, dto.IterationContainerId, this.Cache);
            this.Model.ResolveList(dto.Model, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.NaturalLanguage.ResolveList(dto.NaturalLanguage, dto.IterationContainerId, this.Cache);
            this.Organization.ResolveList(dto.Organization, dto.IterationContainerId, this.Cache);
            this.ParticipantRole.ResolveList(dto.ParticipantRole, dto.IterationContainerId, this.Cache);
            this.Person.ResolveList(dto.Person, dto.IterationContainerId, this.Cache);
            this.PersonRole.ResolveList(dto.PersonRole, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.SiteReferenceDataLibrary.ResolveList(dto.SiteReferenceDataLibrary, dto.IterationContainerId, this.Cache);
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="SiteDirectory"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.SiteDirectory(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.Annotation.AddRange(this.Annotation.Select(x => x.Iid));
            dto.CreatedOn = this.CreatedOn;
            dto.DefaultParticipantRole = this.DefaultParticipantRole != null ? (Guid?)this.DefaultParticipantRole.Iid : null;
            dto.DefaultPersonRole = this.DefaultPersonRole != null ? (Guid?)this.DefaultPersonRole.Iid : null;
            dto.Domain.AddRange(this.Domain.Select(x => x.Iid));
            dto.DomainGroup.AddRange(this.DomainGroup.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LastModifiedOn = this.LastModifiedOn;
            dto.LogEntry.AddRange(this.LogEntry.Select(x => x.Iid));
            dto.Model.AddRange(this.Model.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.NaturalLanguage.AddRange(this.NaturalLanguage.Select(x => x.Iid));
            dto.Organization.AddRange(this.Organization.Select(x => x.Iid));
            dto.ParticipantRole.AddRange(this.ParticipantRole.Select(x => x.Iid));
            dto.Person.AddRange(this.Person.Select(x => x.Iid));
            dto.PersonRole.AddRange(this.PersonRole.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.SiteReferenceDataLibrary.AddRange(this.SiteReferenceDataLibrary.Select(x => x.Iid));
            dto.ThingPreference = this.ThingPreference;

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
