#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdge.cs" company="RHEA System S.A.">
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

namespace CDP4Common.DiagramData
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
    /// Represents a diagram element that renders as a polyline, connecting a source diagram element to a target diagram element,
    /// and is positioned relative to the origin of the diagram.
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementContainer), "DiagramElement")]
    public sealed partial class DiagramEdge : DiagramElementThing
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
        /// Initializes a new instance of the <see cref="DiagramEdge"/> class.
        /// </summary>
        public DiagramEdge()
        {
            this.Point = new OrderedItemList<Point>(this, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramEdge"/> class.
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
        public DiagramEdge(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Point = new OrderedItemList<Point>(this, true);
        }

        /// <summary>
        /// Gets or sets a list of ordered contained Point.
        /// </summary>
        /// <remarks>
        /// An optional list of points relative to the origin of the nesting diagram that specifies the connected line segments of the edge
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<Point> Point { get; protected set; }

        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        /// <remarks>
        /// The edge's source diagram element, i.e., where this starts from
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DiagramElementThing Source { get; set; }

        /// <summary>
        /// Gets or sets the Target.
        /// </summary>
        /// <remarks>
        /// The edge's target, i.e., where the edge ends at
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DiagramElementThing Target { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagramEdge"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Point);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DiagramEdge"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DiagramEdge"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (DiagramEdge)this.MemberwiseClone();
            clone.Bounds = cloneContainedThings ? new ContainerList<Bounds>(clone) : new ContainerList<Bounds>(this.Bounds, clone);
            clone.DiagramElement = cloneContainedThings ? new ContainerList<DiagramElementThing>(clone) : new ContainerList<DiagramElementThing>(this.DiagramElement, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.LocalStyle = cloneContainedThings ? new ContainerList<OwnedStyle>(clone) : new ContainerList<OwnedStyle>(this.LocalStyle, clone);
            clone.Point = cloneContainedThings ? new OrderedItemList<Point>(clone, true) : new OrderedItemList<Point>(this.Point, clone);

            if (cloneContainedThings)
            {
                clone.Bounds.AddRange(this.Bounds.Select(x => x.Clone(true)));
                clone.DiagramElement.AddRange(this.DiagramElement.Select(x => x.Clone(true)));
                clone.LocalStyle.AddRange(this.LocalStyle.Select(x => x.Clone(true)));
                clone.Point.AddRange(this.Point.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DiagramEdge"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DiagramEdge"/>.
        /// </returns>
        public new DiagramEdge Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (DiagramEdge)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="DiagramEdge"/>.
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
                this.Source = SentinelThingProvider.GetSentinel<DiagramElementThing>();
                this.sentinelResetMap["Source"] = () => this.Source = null;
            }

            if (this.Target == null || this.Target.Iid == Guid.Empty)
            {
                errorList.Add("The property Target is null.");
                this.Target = SentinelThingProvider.GetSentinel<DiagramElementThing>();
                this.sentinelResetMap["Target"] = () => this.Target = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="DiagramEdge"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.DiagramEdge;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current DiagramEdge POCO.", dtoThing.GetType()));
            }

            this.Bounds.ResolveList(dto.Bounds, dto.IterationContainerId, this.Cache);
            this.DepictedThing = (dto.DepictedThing.HasValue) ? this.Cache.Get<Thing>(dto.DepictedThing.Value, dto.IterationContainerId) : null;
            this.DiagramElement.ResolveList(dto.DiagramElement, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LocalStyle.ResolveList(dto.LocalStyle, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.Point.ResolveList(dto.Point, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.SharedStyle = (dto.SharedStyle.HasValue) ? this.Cache.Get<SharedStyle>(dto.SharedStyle.Value, dto.IterationContainerId) : null;
            this.Source = this.Cache.Get<DiagramElementThing>(dto.Source, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DiagramElementThing>();
            this.Target = this.Cache.Get<DiagramElementThing>(dto.Target, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DiagramElementThing>();

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="DiagramEdge"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.DiagramEdge(this.Iid, this.RevisionNumber);

            dto.Bounds.AddRange(this.Bounds.Select(x => x.Iid));
            dto.DepictedThing = this.DepictedThing != null ? (Guid?)this.DepictedThing.Iid : null;
            dto.DiagramElement.AddRange(this.DiagramElement.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LocalStyle.AddRange(this.LocalStyle.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.Point.AddRange(this.Point.ToDtoOrderedItemList());
            dto.RevisionNumber = this.RevisionNumber;
            dto.SharedStyle = this.SharedStyle != null ? (Guid?)this.SharedStyle.Iid : null;
            dto.Source = this.Source != null ? this.Source.Iid : Guid.Empty;
            dto.Target = this.Target != null ? this.Target.Iid : Guid.Empty;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
