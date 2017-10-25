// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationship.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
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
    /// representation of a relationship between exactly two Things
    /// Note: This allows very generic relationships to be defined between any two Things. In order to make its use controlled and meaningful the semantics of the relationship should be defined by making the BinaryRelationship a member of a Category and defining an applicable BinaryRelationshipRule.
    /// </summary>
    [Container(typeof(Iteration), "Relationship")]
    public sealed partial class BinaryRelationship : Relationship
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationship"/> class.
        /// </summary>
        public BinaryRelationship()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationship"/> class.
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
        public BinaryRelationship(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        /// <remarks>
        /// reference to the source Thing of this BinaryRelationship
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Thing Source { get; set; }

        /// <summary>
        /// Gets or sets the Target.
        /// </summary>
        /// <remarks>
        /// reference to the target Thing of this BinaryRelationship
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Thing Target { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="BinaryRelationship"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="BinaryRelationship"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (BinaryRelationship)this.MemberwiseClone();
            clone.Category = new List<Category>(this.Category);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ParameterValue = cloneContainedThings ? new ContainerList<RelationshipParameterValue>(clone) : new ContainerList<RelationshipParameterValue>(this.ParameterValue, clone);

            if (cloneContainedThings)
            {
                clone.ParameterValue.AddRange(this.ParameterValue.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="BinaryRelationship"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="BinaryRelationship"/>.
        /// </returns>
        public new BinaryRelationship Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (BinaryRelationship)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="BinaryRelationship"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Source == null || this.Source.Iid == Guid.Empty)
            {
                errorList.Add("The property Source is null.");
                this.Source = SentinelThingProvider.GetSentinel<Thing>();
                this.sentinelResetMap["Source"] = () => this.Source = null;
            }

            if (this.Target == null || this.Target.Iid == Guid.Empty)
            {
                errorList.Add("The property Target is null.");
                this.Target = SentinelThingProvider.GetSentinel<Thing>();
                this.sentinelResetMap["Target"] = () => this.Target = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="BinaryRelationship"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.BinaryRelationship;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current BinaryRelationship POCO.", dtoThing.GetType()));
            }

            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.ParameterValue.ResolveList(dto.ParameterValue, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.Source = this.Cache.Get<Thing>(dto.Source, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Thing>();
            this.Target = this.Cache.Get<Thing>(dto.Target, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Thing>();

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="BinaryRelationship"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.BinaryRelationship(this.Iid, this.RevisionNumber);

            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.ParameterValue.AddRange(this.ParameterValue.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.Source = this.Source != null ? this.Source.Iid : Guid.Empty;
            dto.Target = this.Target != null ? this.Target.Iid : Guid.Empty;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
