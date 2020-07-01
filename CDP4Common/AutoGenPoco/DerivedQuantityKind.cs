// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKind.cs" company="RHEA System S.A.">
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
    /// specialization of QuantityKind that represents a kind of quantity that is defined as a product of powers of one or more other kinds of quantity
    /// Note: A DerivedQuantityKind must define at least one <i>possibleScale</i>.
    /// Examples 1: DerivedQuantityKind "velocity" can be specified as the product of SimpleQuantityKind "length" to the power one times SimpleQuantityKind "time" to the power minus one.
    /// Example 2: DerivedQuantityKind "linear expansion coefficient" can be specified as the product of "length" to the power one times "length" to the power minus one. So, it is permissible to use the same QuantityKind more than once in the list of <i>quantityKindFactor</i>.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public sealed partial class DerivedQuantityKind : QuantityKind
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
        /// Initializes a new instance of the <see cref="DerivedQuantityKind"/> class.
        /// </summary>
        public DerivedQuantityKind()
        {
            this.QuantityKindFactor = new OrderedItemList<QuantityKindFactor>(this, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivedQuantityKind"/> class.
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
        public DerivedQuantityKind(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.QuantityKindFactor = new OrderedItemList<QuantityKindFactor>(this, true);
        }

        /// <summary>
        /// Gets or sets a list of ordered contained QuantityKindFactor.
        /// </summary>
        /// <remarks>
        /// reference to one or more QuantityKindFactors that define the product of powers of other kind(s) of quantity that define this DerivedQuantityKind
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<QuantityKindFactor> QuantityKindFactor { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DerivedQuantityKind"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.QuantityKindFactor);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DerivedQuantityKind"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DerivedQuantityKind"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (DerivedQuantityKind)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.PossibleScale = new List<MeasurementScale>(this.PossibleScale);
            clone.QuantityKindFactor = cloneContainedThings ? null : new OrderedItemList<QuantityKindFactor>(this.QuantityKindFactor, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.QuantityKindFactor = this.QuantityKindFactor.Clone(clone);
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DerivedQuantityKind"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DerivedQuantityKind"/>.
        /// </returns>
        public new DerivedQuantityKind Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (DerivedQuantityKind)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="DerivedQuantityKind"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var quantityKindFactorCount = this.QuantityKindFactor.Count();
            if (quantityKindFactorCount < 1)
            {
                errorList.Add("The number of elements in the property QuantityKindFactor is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="DerivedQuantityKind"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.DerivedQuantityKind;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current DerivedQuantityKind POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.DefaultScale = this.Cache.Get<MeasurementScale>(dto.DefaultScale, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementScale>();
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.PossibleScale.ResolveList(dto.PossibleScale, dto.IterationContainerId, this.Cache);
            this.QuantityDimensionSymbol = dto.QuantityDimensionSymbol;
            this.QuantityKindFactor.ResolveList(dto.QuantityKindFactor, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.Symbol = dto.Symbol;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="DerivedQuantityKind"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.DerivedQuantityKind(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.DefaultScale = this.DefaultScale != null ? this.DefaultScale.Iid : Guid.Empty;
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.PossibleScale.AddRange(this.PossibleScale.Select(x => x.Iid));
            dto.QuantityDimensionSymbol = this.QuantityDimensionSymbol;
            dto.QuantityKindFactor.AddRange(this.QuantityKindFactor.ToDtoOrderedItemList());
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.Symbol = this.Symbol;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
