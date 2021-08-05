// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetup.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of the set-up information of a concurrent engineering model
    /// Note: The data that defines a complete engineering model is split over two containers: EngineeringModelSetup and EngineeringModel. The rationale behind this is as follows: the EngineeringModelSetup contains the minimum information needed to provide an overview of all models available on a site and the associated EngineeringModel contains the actual detailed content of the model. In E-TM-10-25 applications it is then possible that all EngineeringModelSetups reside inside the SiteDirectory database and each EngineeringModel resides in its own separate database.
    /// </summary>
    [Container(typeof(SiteDirectory), "Model")]
    public sealed partial class EngineeringModelSetup : DefinedThing, IParticipantAffectedAccessThing
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
        /// Initializes a new instance of the <see cref="EngineeringModelSetup"/> class.
        /// </summary>
        public EngineeringModelSetup()
        {
            this.ActiveDomain = new List<DomainOfExpertise>();
            this.IterationSetup = new ContainerList<IterationSetup>(this);
            this.OrganizationalParticipant = new ContainerList<OrganizationalParticipant>(this);
            this.Participant = new ContainerList<Participant>(this);
            this.RequiredRdl = new ContainerList<ModelReferenceDataLibrary>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelSetup"/> class.
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
        public EngineeringModelSetup(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ActiveDomain = new List<DomainOfExpertise>();
            this.IterationSetup = new ContainerList<IterationSetup>(this);
            this.OrganizationalParticipant = new ContainerList<OrganizationalParticipant>(this);
            this.Participant = new ContainerList<Participant>(this);
            this.RequiredRdl = new ContainerList<ModelReferenceDataLibrary>(this);
        }

        /// <summary>
        /// Gets or sets a list of DomainOfExpertise.
        /// </summary>
        /// <remarks>
        /// refererence to the active domains of expertise (DomainOfExpertise) for this EngineeringModelSetup and associated EngineeringModel
        /// Note: The possible domains of expertise are defined in the SiteDirectory in which this EngineeringModelSetup is contained.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<DomainOfExpertise> ActiveDomain { get; set; }

        /// <summary>
        /// Gets or sets the DefaultOrganizationalParticipant.
        /// </summary>
        /// <remarks>
        /// represents a list of OrganizationalParticipant, signifying an Organization's participation in the study.
        /// NOTE: if no list is empty the EngineeringModel behaves in a normal E-TM-10-25 manner.
        /// NOTE 2: if list is not empty at least one defaultOrganizationalParticipant must be specified, and should be a member of this list.
        /// NOTE 3: if defaultOrganizationalParticipant is set, it should not be removable from this list. Clearing this list can only be done by setting defaultOrganizationalParticipant  to null.
        /// </remarks>
        [CDPVersion("1.2.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public OrganizationalParticipant DefaultOrganizationalParticipant { get; set; }

        /// <summary>
        /// Gets or sets the EngineeringModelIid.
        /// </summary>
        /// <remarks>
        /// definition of the unique instance identifier (<i>iid</i>) of the associated EngineeringModel instance
        /// Note: No direct reference is made to the EngineeringModel instance since it possibly resides in a different persistent data store partition than the EngineeringModelSetup, and it should be possible to load the EngineeringModelSetup without loading the associated EngineeringModel. The EngineeringModel instance is existence dependent on the EngineeringModelSetup instance.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Guid EngineeringModelIid { get; set; }

        /// <summary>
        /// Gets or sets a list of contained IterationSetup.
        /// </summary>
        /// <remarks>
        /// representation of the collection of IterationSetups in this EngineeringModelSetup that records the history of iterations of the associated EngineeringModel
        /// Note 1: An iteration is a version of the associated EngineeringModel that was considered as one complete step in the development of the EngineeringModel in a concurrent engineering activity.
        /// Note 2: The content of each iteration is stored in an instance of EngineeringModel denoted by its <i>iterationNumber</i>. In order to support efficient database implementations a data partitioning technique may be used in the database architecture. The ECSS-E-TM-10-25 application will need to implement a mechanism to retrieve a complete set or a subset of iterations of an EngineeringModel, but this mechanism is not defined in this data model.
        /// Note 3: The record of iterations is kept inside EngineeringModelSetup so that in an implementation only the EngineeringModelSetup needs to be accessed in order to get a list of iterations that are present in the associated EngineeringModel.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<IterationSetup> IterationSetup { get; protected set; }

        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        /// <remarks>
        /// definition of the kind of the engineering model
        /// Note: See EngineeringModelKind for definitions of the different kinds of engineering model.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public EngineeringModelKind Kind { get; set; }

        /// <summary>
        /// Gets or sets a list of contained OrganizationalParticipant.
        /// </summary>
        /// <remarks>
        /// represents a list of OrganizationalParticipant, signifying an Organization's participation in the study.
        /// NOTE: if no list is empty the EngineeringModel behaves in a normal E-TM-10-25 manner.
        /// NOTE 2: if list is not empty at least one defaultOrganizationalParticipant must be specified, and should be a member of this list.
        /// NOTE 3: if defaultOrganizationalParticipant is set, it should not be removable from this list. Clearing this list can only be done by setting defaultOrganizationalParticipant  to null.
        /// </remarks>
        [CDPVersion("1.2.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<OrganizationalParticipant> OrganizationalParticipant { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Participant.
        /// </summary>
        /// <remarks>
        /// reference to the actual Participants of the team that is allowed to access this EngineeringModelSetup and associated EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Participant> Participant { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ModelReferenceDataLibrary.
        /// </summary>
        /// <remarks>
        /// reference to the (first) ReferenceDataLibrary that contains reference data for the engineering model
        /// Note 1: Reference data consists of predefined instances that can be used across one or more studies.
        /// Note 2: A chain of more than one ReferenceDataLibrary can be specified by linking to a ReferenceDataLibrary through the <i>requiredRdl</i> property of the associated ReferenceDataLibrary.
        /// Note 3:The ReferenceDataLibraries are loaded in the reverse order of the chain, at runtime when an EngineeringModelSetup is opened. If the same concept (predefined instance) appears in more than one ReferenceDataLibrary the definition from the last loaded instance overwrites the definition of any earlier loaded instance (TBC!).
        /// Note 4: Typically an EngineeringModelSetup has 3 ReferenceDataLibraries, as follows:
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ModelReferenceDataLibrary> RequiredRdl { get; protected set; }

        /// <summary>
        /// Gets or sets the SourceEngineeringModelSetupIid.
        /// </summary>
        /// <remarks>
        /// optional unique identifier that references the source EngineeringModelSetup (and associated EngineeringModel) that was used as the basis to create this EngineeringModelSetup (and associated EngineeringModel)
        /// Note: This reference should be specified when a new engineering model is created as a copy from an existing (source) engineering model, and in particular when the source engineering model is a template model (with <i>kind</i> is EngineeringModelKind.TEMPLATE_MODEL).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public Guid? SourceEngineeringModelSetupIid { get; set; }

        /// <summary>
        /// Gets or sets the StudyPhase.
        /// </summary>
        /// <remarks>
        /// definition of the actual phase that the engineering model is in
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public StudyPhaseKind StudyPhase { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModelSetup"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.IterationSetup);
                containers.Add(this.OrganizationalParticipant);
                containers.Add(this.Participant);
                containers.Add(this.RequiredRdl);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="EngineeringModelSetup"/>
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

            foreach (var thing in this.ActiveDomain)
            {
                yield return thing;
            }

            if (this.DefaultOrganizationalParticipant != null)
            {
                yield return this.DefaultOrganizationalParticipant;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModelSetup"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModelSetup"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (EngineeringModelSetup)this.MemberwiseClone();
            clone.ActiveDomain = new List<DomainOfExpertise>(this.ActiveDomain);
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.IterationSetup = cloneContainedThings ? new ContainerList<IterationSetup>(clone) : new ContainerList<IterationSetup>(this.IterationSetup, clone);
            clone.OrganizationalParticipant = cloneContainedThings ? new ContainerList<OrganizationalParticipant>(clone) : new ContainerList<OrganizationalParticipant>(this.OrganizationalParticipant, clone);
            clone.Participant = cloneContainedThings ? new ContainerList<Participant>(clone) : new ContainerList<Participant>(this.Participant, clone);
            clone.RequiredRdl = cloneContainedThings ? new ContainerList<ModelReferenceDataLibrary>(clone) : new ContainerList<ModelReferenceDataLibrary>(this.RequiredRdl, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.IterationSetup.AddRange(this.IterationSetup.Select(x => x.Clone(true)));
                clone.OrganizationalParticipant.AddRange(this.OrganizationalParticipant.Select(x => x.Clone(true)));
                clone.Participant.AddRange(this.Participant.Select(x => x.Clone(true)));
                clone.RequiredRdl.AddRange(this.RequiredRdl.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModelSetup"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModelSetup"/>.
        /// </returns>
        public new EngineeringModelSetup Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (EngineeringModelSetup)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="EngineeringModelSetup"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var activeDomainCount = this.ActiveDomain.Count();
            if (activeDomainCount < 1)
            {
                errorList.Add("The number of elements in the property ActiveDomain is wrong. It should be at least 1.");
            }

            var iterationSetupCount = this.IterationSetup.Count();
            if (iterationSetupCount < 1)
            {
                errorList.Add("The number of elements in the property IterationSetup is wrong. It should be at least 1.");
            }

            var participantCount = this.Participant.Count();
            if (participantCount < 1)
            {
                errorList.Add("The number of elements in the property Participant is wrong. It should be at least 1.");
            }

            var requiredRdlCount = this.RequiredRdl.Count();
            if (requiredRdlCount < 1)
            {
                errorList.Add("The number of elements in the property RequiredRdl is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="EngineeringModelSetup"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.EngineeringModelSetup;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current EngineeringModelSetup POCO.", dtoThing.GetType()));
            }

            this.ActiveDomain.ResolveList(dto.ActiveDomain, dto.IterationContainerId, this.Cache);
            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.DefaultOrganizationalParticipant = (dto.DefaultOrganizationalParticipant.HasValue) ? this.Cache.Get<OrganizationalParticipant>(dto.DefaultOrganizationalParticipant.Value, dto.IterationContainerId) : null;
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.EngineeringModelIid = dto.EngineeringModelIid;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IterationSetup.ResolveList(dto.IterationSetup, dto.IterationContainerId, this.Cache);
            this.Kind = dto.Kind;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.OrganizationalParticipant.ResolveList(dto.OrganizationalParticipant, dto.IterationContainerId, this.Cache);
            this.Participant.ResolveList(dto.Participant, dto.IterationContainerId, this.Cache);
            this.RequiredRdl.ResolveList(dto.RequiredRdl, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.SourceEngineeringModelSetupIid = dto.SourceEngineeringModelSetupIid;
            this.StudyPhase = dto.StudyPhase;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="EngineeringModelSetup"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.EngineeringModelSetup(this.Iid, this.RevisionNumber);

            dto.ActiveDomain.AddRange(this.ActiveDomain.Select(x => x.Iid));
            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.DefaultOrganizationalParticipant = this.DefaultOrganizationalParticipant != null ? (Guid?)this.DefaultOrganizationalParticipant.Iid : null;
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.EngineeringModelIid = this.EngineeringModelIid;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IterationSetup.AddRange(this.IterationSetup.Select(x => x.Iid));
            dto.Kind = this.Kind;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.OrganizationalParticipant.AddRange(this.OrganizationalParticipant.Select(x => x.Iid));
            dto.Participant.AddRange(this.Participant.Select(x => x.Iid));
            dto.RequiredRdl.AddRange(this.RequiredRdl.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.SourceEngineeringModelSetupIid = this.SourceEngineeringModelSetupIid;
            dto.StudyPhase = this.StudyPhase;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
