// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractChangeNotice.cs" company="Starion Group S.A.">
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
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
    /// The ContractChangeNotice is the vehicle for notifying a contract change following a ChangeProposal
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModel), "ModellingAnnotation")]
    public partial class ContractChangeNotice : ModellingAnnotationItem
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
        /// Initializes a new instance of the <see cref="ContractChangeNotice"/> class.
        /// </summary>
        public ContractChangeNotice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractChangeNotice"/> class.
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
        public ContractChangeNotice(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ChangeProposal.
        /// </summary>
        /// <remarks>
        /// The ChangeProposal that is at the origin of this ContractChangeNotice
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ChangeProposal ChangeProposal { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="ContractChangeNotice"/>
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

            if (this.ChangeProposal != null)
            {
                yield return this.ChangeProposal;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ContractChangeNotice"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ContractChangeNotice"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ContractChangeNotice)this.MemberwiseClone();
            clone.ApprovedBy = cloneContainedThings ? new ContainerList<Approval>(clone) : new ContainerList<Approval>(this.ApprovedBy, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Discussion = cloneContainedThings ? new ContainerList<EngineeringModelDataDiscussionItem>(clone) : new ContainerList<EngineeringModelDataDiscussionItem>(this.Discussion, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.RelatedThing = cloneContainedThings ? new ContainerList<ModellingThingReference>(clone) : new ContainerList<ModellingThingReference>(this.RelatedThing, clone);
            clone.SourceAnnotation = new List<ModellingAnnotationItem>(this.SourceAnnotation);

            if (cloneContainedThings)
            {
                clone.ApprovedBy.AddRange(this.ApprovedBy.Select(x => x.Clone(true)));
                clone.Discussion.AddRange(this.Discussion.Select(x => x.Clone(true)));
                clone.RelatedThing.AddRange(this.RelatedThing.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ContractChangeNotice"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ContractChangeNotice"/>.
        /// </returns>
        public new ContractChangeNotice Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ContractChangeNotice)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ContractChangeNotice"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.ChangeProposal == null || this.ChangeProposal.Iid == Guid.Empty)
            {
                errorList.Add("The property ChangeProposal is null.");
                this.ChangeProposal = SentinelThingProvider.GetSentinel<ChangeProposal>();
                this.sentinelResetMap["ChangeProposal"] = () => this.ChangeProposal = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ContractChangeNotice"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ContractChangeNotice;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current ContractChangeNotice POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.ApprovedBy.ResolveList(dto.ApprovedBy, dto.IterationContainerId, this.Cache);
            this.Author = this.Cache.Get<Participant>(dto.Author, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.ChangeProposal = this.Cache.Get<ChangeProposal>(dto.ChangeProposal, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ChangeProposal>();
            this.Classification = dto.Classification;
            this.Content = dto.Content;
            this.CreatedOn = dto.CreatedOn;
            this.Discussion.ResolveList(dto.Discussion, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LanguageCode = dto.LanguageCode;
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.PrimaryAnnotatedThing = (dto.PrimaryAnnotatedThing.HasValue) ? this.Cache.Get<ModellingThingReference>(dto.PrimaryAnnotatedThing.Value, dto.IterationContainerId) : null;
            this.RelatedThing.ResolveList(dto.RelatedThing, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.SourceAnnotation.ResolveList(dto.SourceAnnotation, dto.IterationContainerId, this.Cache);
            this.Status = dto.Status;
            this.ThingPreference = dto.ThingPreference;
            this.Title = dto.Title;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ContractChangeNotice"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ContractChangeNotice(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.ApprovedBy.AddRange(this.ApprovedBy.Select(x => x.Iid));
            dto.Author = this.Author != null ? this.Author.Iid : Guid.Empty;
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.ChangeProposal = this.ChangeProposal != null ? this.ChangeProposal.Iid : Guid.Empty;
            dto.Classification = this.Classification;
            dto.Content = this.Content;
            dto.CreatedOn = this.CreatedOn;
            dto.Discussion.AddRange(this.Discussion.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LanguageCode = this.LanguageCode;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.PrimaryAnnotatedThing = this.PrimaryAnnotatedThing != null ? (Guid?)this.PrimaryAnnotatedThing.Iid : null;
            dto.RelatedThing.AddRange(this.RelatedThing.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.SourceAnnotation.AddRange(this.SourceAnnotation.Select(x => x.Iid));
            dto.Status = this.Status;
            dto.ThingPreference = this.ThingPreference;
            dto.Title = this.Title;

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
