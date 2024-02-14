// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchitectureDiagram.cs" company="RHEA System S.A.">
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

namespace CDP4Common.DiagramData
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
    /// Represents a complete Architecture Diagram that contains visual elements for ElementDefinitions, ElementUsages, Requirements and Relationships.
    /// </summary>
    [CDPVersion("1.4.0")]
    [Container(typeof(Iteration), "DiagramCanvas")]
    public partial class ArchitectureDiagram : DiagramCanvas, IOwnedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NONE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchitectureDiagram"/> class.
        /// </summary>
        public ArchitectureDiagram()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchitectureDiagram"/> class.
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
        public ArchitectureDiagram(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to a DomainOfExpertise that is the owner of this OwnedThing
        /// Note: Ownership in this data model implies the responsibility for the presence and content of this OwnedThing. The owner is always a DomainOfExpertise. The Participant or Participants representing an owner DomainOfExpertise are thus responsible for (i.e. take ownership of) a coherent set of concerns in a concurrent engineering activity.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DomainOfExpertise Owner { get; set; }

        /// <summary>
        /// Gets or sets the TopArchitectureElement.
        /// </summary>
        /// <remarks>
        /// The top ArchitectureElement that serves as the top Element of the architecture.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ArchitectureElement TopArchitectureElement { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="ArchitectureDiagram"/>
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

            if (this.Owner != null)
            {
                yield return this.Owner;
            }

            if (this.TopArchitectureElement != null)
            {
                yield return this.TopArchitectureElement;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ArchitectureDiagram"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ArchitectureDiagram"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ArchitectureDiagram)this.MemberwiseClone();
            clone.Bounds = cloneContainedThings ? new ContainerList<Bounds>(clone) : new ContainerList<Bounds>(this.Bounds, clone);
            clone.DiagramElement = cloneContainedThings ? new ContainerList<DiagramElementThing>(clone) : new ContainerList<DiagramElementThing>(this.DiagramElement, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);

            if (cloneContainedThings)
            {
                clone.Bounds.AddRange(this.Bounds.Select(x => x.Clone(true)));
                clone.DiagramElement.AddRange(this.DiagramElement.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ArchitectureDiagram"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ArchitectureDiagram"/>.
        /// </returns>
        public new ArchitectureDiagram Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ArchitectureDiagram)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ArchitectureDiagram"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Owner == null || this.Owner.Iid == Guid.Empty)
            {
                errorList.Add("The property Owner is null.");
                this.Owner = SentinelThingProvider.GetSentinel<DomainOfExpertise>();
                this.sentinelResetMap["Owner"] = () => this.Owner = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ArchitectureDiagram"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ArchitectureDiagram;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current ArchitectureDiagram POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.Bounds.ResolveList(dto.Bounds, dto.IterationContainerId, this.Cache);
            this.CreatedOn = dto.CreatedOn;
            this.Description = dto.Description;
            this.DiagramElement.ResolveList(dto.DiagramElement, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.IsHidden = dto.IsHidden;
            this.LockedBy = (dto.LockedBy.HasValue) ? this.Cache.Get<Person>(dto.LockedBy.Value, dto.IterationContainerId) : null;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;
            this.TopArchitectureElement = (dto.TopArchitectureElement.HasValue) ? this.Cache.Get<ArchitectureElement>(dto.TopArchitectureElement.Value, dto.IterationContainerId) : null;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ArchitectureDiagram"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ArchitectureDiagram(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.Bounds.AddRange(this.Bounds.Select(x => x.Iid));
            dto.CreatedOn = this.CreatedOn;
            dto.Description = this.Description;
            dto.DiagramElement.AddRange(this.DiagramElement.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.IsHidden = this.IsHidden;
            dto.LockedBy = this.LockedBy != null ? (Guid?)this.LockedBy.Iid : null;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;
            dto.TopArchitectureElement = this.TopArchitectureElement != null ? (Guid?)this.TopArchitectureElement.Iid : null;

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
