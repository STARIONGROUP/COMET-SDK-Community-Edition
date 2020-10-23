// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRule.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Authors: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov, Smiechowski Nathanael
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
    /// representation of a validation rule for system-of-interest decomposition through <i>containingElement</i> ElementDefinitions and <i>containedElement</i> ElementUsages
    /// Note: A DecompositionRule specifies for ElementDefinitions that are a member of the <i>containingCategory</i> what are the valid Categories (specified by <i>containedCategory</i>) for the <i>type</i> of contained ElementUsages. A <i>subCategory</i> of a valid Category is also valid.
    /// Example: A rule where the <i>containingCategory</i> is Category "Equipment" and the <i>containedCategory</i> is Category "Subequipment".
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Rule")]
    public sealed partial class DecompositionRule : Rule
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
        /// Initializes a new instance of the <see cref="DecompositionRule"/> class.
        /// </summary>
        public DecompositionRule()
        {
            this.ContainedCategory = new List<Category>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecompositionRule"/> class.
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
        public DecompositionRule(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ContainedCategory = new List<Category>();
        }

        /// <summary>
        /// Gets or sets a list of Category.
        /// </summary>
        /// <remarks>
        /// reference to one or more valid Categories for the <i>elementDefinition</i> of <i>containedElement</i> ElementUsages
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Category> ContainedCategory { get; set; }

        /// <summary>
        /// Gets or sets the ContainingCategory.
        /// </summary>
        /// <remarks>
        /// reference to the Category for <i>containingElement</i> ElementDefinitions to which this rule applies
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Category ContainingCategory { get; set; }

        /// <summary>
        /// Gets or sets the MaxContained.
        /// </summary>
        /// <remarks>
        /// optional definition of the valid maximum number of <i>containedElement</i> ElementUsages
        /// Note 1: This can be used to specify a cardinality constraint.
        /// Note 2: If not specified it signifies that an unlimited number of <i>containedElement</i> is valid.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public int? MaxContained { get; set; }

        /// <summary>
        /// Gets or sets the MinContained.
        /// </summary>
        /// <remarks>
        /// definition of the valid minimum number of <i>containedElement</i> ElementUsages
        /// Note: This can be used to specify a cardinality constraint.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public int MinContained { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="DecompositionRule"/>
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

            foreach (var thing in this.ContainedCategory)
            {
                yield return thing;
            }

            yield return this.ContainingCategory;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DecompositionRule"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DecompositionRule"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (DecompositionRule)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.ContainedCategory = new List<Category>(this.ContainedCategory);
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
        /// Creates and returns a copy of this <see cref="DecompositionRule"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DecompositionRule"/>.
        /// </returns>
        public new DecompositionRule Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (DecompositionRule)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="DecompositionRule"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var containedCategoryCount = this.ContainedCategory.Count();
            if (containedCategoryCount < 1)
            {
                errorList.Add("The number of elements in the property ContainedCategory is wrong. It should be at least 1.");
            }

            if (this.ContainingCategory == null || this.ContainingCategory.Iid == Guid.Empty)
            {
                errorList.Add("The property ContainingCategory is null.");
                this.ContainingCategory = SentinelThingProvider.GetSentinel<Category>();
                this.sentinelResetMap["ContainingCategory"] = () => this.ContainingCategory = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="DecompositionRule"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.DecompositionRule;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current DecompositionRule POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.ContainedCategory.ResolveList(dto.ContainedCategory, dto.IterationContainerId, this.Cache);
            this.ContainingCategory = this.Cache.Get<Category>(dto.ContainingCategory, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Category>();
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.MaxContained = dto.MaxContained;
            this.MinContained = dto.MinContained;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="DecompositionRule"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.DecompositionRule(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.ContainedCategory.AddRange(this.ContainedCategory.Select(x => x.Iid));
            dto.ContainingCategory = this.ContainingCategory != null ? this.ContainingCategory.Iid : Guid.Empty;
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.MaxContained = this.MaxContained;
            dto.MinContained = this.MinContained;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
