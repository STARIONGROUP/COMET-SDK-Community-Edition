// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRule.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// representation of a validation rule for BinaryRelationships
    /// Note: A BinaryRelationshipRule specifies for BinaryRelationships that are a member of the <i>relationshipCategory</i> what are the valid Categories for the related <i>source</i> and <i>target</i> Things
    /// Example: A rule where the <i>relationshipCategory</i> is Category "RequirementSatisfactionTraces", the sourceCategory is "ArchitecturalElements" (with <i>permissibleClass</i> ElementDefinition, ElementUsage) and the <i>targetCategory</i> is Category "Requirements" (with <i>permissibleClass</i> Requirement).
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Rule")]
    public sealed partial class BinaryRelationshipRule : Rule
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationshipRule"/> class.
        /// </summary>
        public BinaryRelationshipRule()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationshipRule"/> class.
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
        public BinaryRelationshipRule(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ForwardRelationshipName.
        /// </summary>
        /// <remarks>
        /// name of the relationship when read from the <i>source</i> to the <i>target</i> of a BinaryRelationship
        /// Example: For a "RequirementsSatisfactionTraces" Category between "ArchitecturalElements" (source) and "Requirements" (target) the <i>forwardRelationshipName</i> would be "satisfies" and the <i>inverseRelationshipName</i> would be "is satisfied by".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string ForwardRelationshipName { get; set; }

        /// <summary>
        /// Gets or sets the InverseRelationshipName.
        /// </summary>
        /// <remarks>
        /// name of the inverse relationship, i.e. the name of the relationship when read from <i>target</i> to <i>source</i> of a BinaryRelationship
        /// Example: If the <i>forwardRelationshipName</i> is "satisfies", then the <i>inverseRelationshipName</i> would be  "is satisfied by".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string InverseRelationshipName { get; set; }

        /// <summary>
        /// Gets or sets the RelationshipCategory.
        /// </summary>
        /// <remarks>
        /// reference to the Category whose member BinaryRelationships shall comply with this BinaryRelationshipRule
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Category RelationshipCategory { get; set; }

        /// <summary>
        /// Gets or sets the SourceCategory.
        /// </summary>
        /// <remarks>
        /// reference to the Category to which the <i>source</i> of the BinaryRelationship must belong
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Category SourceCategory { get; set; }

        /// <summary>
        /// Gets or sets the TargetCategory.
        /// </summary>
        /// <remarks>
        /// reference to the Category to which the <i>target</i> of the BinaryRelationship must belong
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Category TargetCategory { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="BinaryRelationshipRule"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="BinaryRelationshipRule"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (BinaryRelationshipRule)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="BinaryRelationshipRule"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="BinaryRelationshipRule"/>.
        /// </returns>
        public new BinaryRelationshipRule Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (BinaryRelationshipRule)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="BinaryRelationshipRule"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.ForwardRelationshipName))
            {
                errorList.Add("The property ForwardRelationshipName is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.InverseRelationshipName))
            {
                errorList.Add("The property InverseRelationshipName is null or empty.");
            }

            if (this.RelationshipCategory == null || this.RelationshipCategory.Iid == Guid.Empty)
            {
                errorList.Add("The property RelationshipCategory is null.");
                this.RelationshipCategory = SentinelThingProvider.GetSentinel<Category>();
                this.sentinelResetMap["RelationshipCategory"] = () => this.RelationshipCategory = null;
            }

            if (this.SourceCategory == null || this.SourceCategory.Iid == Guid.Empty)
            {
                errorList.Add("The property SourceCategory is null.");
                this.SourceCategory = SentinelThingProvider.GetSentinel<Category>();
                this.sentinelResetMap["SourceCategory"] = () => this.SourceCategory = null;
            }

            if (this.TargetCategory == null || this.TargetCategory.Iid == Guid.Empty)
            {
                errorList.Add("The property TargetCategory is null.");
                this.TargetCategory = SentinelThingProvider.GetSentinel<Category>();
                this.sentinelResetMap["TargetCategory"] = () => this.TargetCategory = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="BinaryRelationshipRule"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.BinaryRelationshipRule;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current BinaryRelationshipRule POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ForwardRelationshipName = dto.ForwardRelationshipName;
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.InverseRelationshipName = dto.InverseRelationshipName;
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RelationshipCategory = this.Cache.Get<Category>(dto.RelationshipCategory, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Category>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.SourceCategory = this.Cache.Get<Category>(dto.SourceCategory, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Category>();
            this.TargetCategory = this.Cache.Get<Category>(dto.TargetCategory, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Category>();

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="BinaryRelationshipRule"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.BinaryRelationshipRule(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ForwardRelationshipName = this.ForwardRelationshipName;
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.InverseRelationshipName = this.InverseRelationshipName;
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.RelationshipCategory = this.RelationshipCategory != null ? this.RelationshipCategory.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.SourceCategory = this.SourceCategory != null ? this.SourceCategory.Iid : Guid.Empty;
            dto.TargetCategory = this.TargetCategory != null ? this.TargetCategory.Iid : Guid.Empty;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
