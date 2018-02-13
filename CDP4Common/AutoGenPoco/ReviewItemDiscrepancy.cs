#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancy.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace CDP4Common.ReportingData
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
    /// The Review Item Discrepancy (RID) shall be the mechanism used to record questions
    /// or identified problems and solutions arising from a review.
    /// It is an issue, identified by a reviewer, that is not compliant with a requirement, a review objective or a design goal.
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModel), "ModellingAnnotation")]
    public sealed partial class ReviewItemDiscrepancy : ModellingAnnotationItem
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
        /// Initializes a new instance of the <see cref="ReviewItemDiscrepancy"/> class.
        /// </summary>
        public ReviewItemDiscrepancy()
        {
            this.Solution = new ContainerList<Solution>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewItemDiscrepancy"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public ReviewItemDiscrepancy(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Solution = new ContainerList<Solution>(this);
        }

        /// <summary>
        /// Gets or sets a list of contained Solution.
        /// </summary>
        /// <remarks>
        /// The decision taken to solve this ReviewItemDiscrepancy
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Solution> Solution { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ReviewItemDiscrepancy"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Solution);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ReviewItemDiscrepancy"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ReviewItemDiscrepancy"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ReviewItemDiscrepancy)this.MemberwiseClone();
            clone.ApprovedBy = cloneContainedThings ? new ContainerList<Approval>(clone) : new ContainerList<Approval>(this.ApprovedBy, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Discussion = cloneContainedThings ? new ContainerList<EngineeringModelDataDiscussionItem>(clone) : new ContainerList<EngineeringModelDataDiscussionItem>(this.Discussion, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.RelatedThing = cloneContainedThings ? new ContainerList<ModellingThingReference>(clone) : new ContainerList<ModellingThingReference>(this.RelatedThing, clone);
            clone.Solution = cloneContainedThings ? new ContainerList<Solution>(clone) : new ContainerList<Solution>(this.Solution, clone);
            clone.SourceAnnotation = new List<ModellingAnnotationItem>(this.SourceAnnotation);

            if (cloneContainedThings)
            {
                clone.ApprovedBy.AddRange(this.ApprovedBy.Select(x => x.Clone(true)));
                clone.Discussion.AddRange(this.Discussion.Select(x => x.Clone(true)));
                clone.RelatedThing.AddRange(this.RelatedThing.Select(x => x.Clone(true)));
                clone.Solution.AddRange(this.Solution.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ReviewItemDiscrepancy"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ReviewItemDiscrepancy"/>.
        /// </returns>
        public new ReviewItemDiscrepancy Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ReviewItemDiscrepancy)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ReviewItemDiscrepancy"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ReviewItemDiscrepancy"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ReviewItemDiscrepancy;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ReviewItemDiscrepancy POCO.", dtoThing.GetType()));
            }

            this.ApprovedBy.ResolveList(dto.ApprovedBy, dto.IterationContainerId, this.Cache);
            this.Author = this.Cache.Get<Participant>(dto.Author, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
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
            this.Solution.ResolveList(dto.Solution, dto.IterationContainerId, this.Cache);
            this.SourceAnnotation.ResolveList(dto.SourceAnnotation, dto.IterationContainerId, this.Cache);
            this.Status = dto.Status;
            this.Title = dto.Title;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ReviewItemDiscrepancy"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ReviewItemDiscrepancy(this.Iid, this.RevisionNumber);

            dto.ApprovedBy.AddRange(this.ApprovedBy.Select(x => x.Iid));
            dto.Author = this.Author != null ? this.Author.Iid : Guid.Empty;
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
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
            dto.Solution.AddRange(this.Solution.Select(x => x.Iid));
            dto.SourceAnnotation.AddRange(this.SourceAnnotation.Select(x => x.Iid));
            dto.Status = this.Status;
            dto.Title = this.Title;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
