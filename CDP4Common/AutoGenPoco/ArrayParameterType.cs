// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterType.cs" company="RHEA System S.A.">
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
    /// specialization of CompoundParameterType that specifies a one-dimensional or multi-dimensional array parameter type with elements (components) that are typed by other ScalarParameterTypes
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public sealed partial class ArrayParameterType : CompoundParameterType
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
        /// Initializes a new instance of the <see cref="ArrayParameterType"/> class.
        /// </summary>
        public ArrayParameterType()
        {
            this.Dimension = new OrderedItemList<int>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayParameterType"/> class.
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
        public ArrayParameterType(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Dimension = new OrderedItemList<int>(this);
        }

        /// <summary>
        /// Gets or sets a list of ordered Int.
        /// </summary>
        /// <remarks>
        /// definition of the number of array elements in each dimension
        /// Note: Implicitly this also defines the number of dimensions of the array
        /// which determines its <i>rank</i>
        /// Example: To define an ArrayParameterType for a 3 by 3 matrix, <i>dimension</i>
        /// would be set to {3,3}.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<int> Dimension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasSingleComponentType.
        /// </summary>
        /// <remarks>
        /// derived assertion that all components of an ArrayParameterType are of the same ParameterType, and, if the ParameterType is a QuantityKind, of the same MeasurementScale
        /// Note: In an implementation when creating an ArrayParameterType it is useful to provide the option to specify that all <i>component</i> ParameterTypeComponents will have the same ParameterType and where applicable the same MeasurementScale.
        /// Example: An example of an ArrayParameterType for which <i>hasSingleComponentType</i> is true, is a 3D Cartesian vector (with one <i>dimension </i>with value 3) where the <i>parameterType</i> of each <i>component</i> is the "length" SimpleQuantityKind and the <i>scale</i> is the "millimetre" RatioScale.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The HasSingleComponentType property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public bool HasSingleComponentType
        {
            get { return this.GetDerivedHasSingleComponentType(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ArrayParameterType.HasSingleComponentType"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsTensor.
        /// </summary>
        /// <remarks>
        /// assertion whether this parameter type is a tensor
        /// Note: An nth-rank tensor in m-dimensional space is a mathematical object that has n indices and m<sup>n</sup> components and obeys certain transformation rules. For details see e.g. <a href="http://mathworld.wolfram.com/Tensor.html">http://mathworld.wolfram.com/Tensor.html</a>.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsTensor { get; set; }

        /// <summary>
        /// Gets or sets the Rank.
        /// </summary>
        /// <remarks>
        /// specifies the rank
        /// Note: The rank of an array datatype is equal to the number of dimensions
        /// it has.
        /// Example: A vector has rank = 1, a matrix has rank = 2, a higher order
        /// tensor has rank > 2. Vector and matrix are special cases of the general
        /// concept of tensor.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Rank property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public int Rank
        {
            get { return this.GetDerivedRank(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ArrayParameterType.Rank"); }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ArrayParameterType"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ArrayParameterType"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ArrayParameterType)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Component = cloneContainedThings ? null : new OrderedItemList<ParameterTypeComponent>(this.Component, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.Dimension = new OrderedItemList<int>(this.Dimension, this);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Component = this.Component.Clone(clone);
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ArrayParameterType"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ArrayParameterType"/>.
        /// </returns>
        public new ArrayParameterType Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ArrayParameterType)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ArrayParameterType"/>.
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
        /// Resolve the properties of the current <see cref="ArrayParameterType"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ArrayParameterType;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ArrayParameterType POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Component.ResolveList(dto.Component, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.Dimension.ClearAndAddRange(dto.Dimension);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.IsFinalized = dto.IsFinalized;
            this.IsTensor = dto.IsTensor;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.Symbol = dto.Symbol;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ArrayParameterType"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ArrayParameterType(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Component.AddRange(this.Component.ToDtoOrderedItemList());
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.Dimension.AddRange(this.Dimension.ToDtoOrderedItemList());
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.IsFinalized = this.IsFinalized;
            dto.IsTensor = this.IsTensor;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
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
