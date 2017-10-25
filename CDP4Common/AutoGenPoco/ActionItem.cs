// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItem.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    /// Represents an action that shall be performed following a ReviewItemDiscrepancy
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModel), "ModellingAnnotation")]
    public sealed partial class ActionItem : ModellingAnnotationItem
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
        /// Initializes a new instance of the <see cref="ActionItem"/> class.
        /// </summary>
        public ActionItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionItem"/> class.
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
        public ActionItem(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Actionee.
        /// </summary>
        /// <remarks>
        /// The participant that shall perform the action
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Participant Actionee { get; set; }

        /// <summary>
        /// Gets or sets the CloseOutDate.
        /// </summary>
        /// <remarks>
        /// The date that the current action was closed at
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public DateTime? CloseOutDate { get; set; }

        /// <summary>
        /// Gets or sets the CloseOutStatement.
        /// </summary>
        /// <remarks>
        /// The close-out statement
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string CloseOutStatement { get; set; }

        /// <summary>
        /// Gets or sets the DueDate.
        /// </summary>
        /// <remarks>
        /// The date that the current action is due
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ActionItem"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ActionItem"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ActionItem)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="ActionItem"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ActionItem"/>.
        /// </returns>
        public new ActionItem Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ActionItem)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ActionItem"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Actionee == null || this.Actionee.Iid == Guid.Empty)
            {
                errorList.Add("The property Actionee is null.");
                this.Actionee = SentinelThingProvider.GetSentinel<Participant>();
                this.sentinelResetMap["Actionee"] = () => this.Actionee = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ActionItem"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ActionItem;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ActionItem POCO.", dtoThing.GetType()));
            }

            this.Actionee = this.Cache.Get<Participant>(dto.Actionee, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.ApprovedBy.ResolveList(dto.ApprovedBy, dto.IterationContainerId, this.Cache);
            this.Author = this.Cache.Get<Participant>(dto.Author, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Classification = dto.Classification;
            this.CloseOutDate = dto.CloseOutDate;
            this.CloseOutStatement = dto.CloseOutStatement;
            this.Content = dto.Content;
            this.CreatedOn = dto.CreatedOn;
            this.Discussion.ResolveList(dto.Discussion, dto.IterationContainerId, this.Cache);
            this.DueDate = dto.DueDate;
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
            this.Title = dto.Title;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ActionItem"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ActionItem(this.Iid, this.RevisionNumber);

            dto.Actionee = this.Actionee != null ? this.Actionee.Iid : Guid.Empty;
            dto.ApprovedBy.AddRange(this.ApprovedBy.Select(x => x.Iid));
            dto.Author = this.Author != null ? this.Author.Iid : Guid.Empty;
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Classification = this.Classification;
            dto.CloseOutDate = this.CloseOutDate;
            dto.CloseOutStatement = this.CloseOutStatement;
            dto.Content = this.Content;
            dto.CreatedOn = this.CreatedOn;
            dto.Discussion.AddRange(this.Discussion.Select(x => x.Iid));
            dto.DueDate = this.DueDate;
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
            dto.Title = this.Title;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
