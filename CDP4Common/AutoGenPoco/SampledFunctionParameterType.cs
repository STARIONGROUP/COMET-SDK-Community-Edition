// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampledFunctionParameterType.cs" company="RHEA System S.A.">
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
    /// ParameterType for parameters whose value is a discretely sampled function where each sample consists of a given unique tuple of independent parameter values mapped to a tuple of dependent parameter values
    /// <br>Note 1: See also a http://mathworld.wolfram.com/Map.html for a formal mathematical definition.
    /// <br>Note 2: A ParameterValueSet associated with a SampledFunctionParameterType holds a flattened list of values, where each discrete sample is represented by the concatenation of a tuple of values for the independentParameterType(s) followed by a tuple of values for the dependentParameterType(s).
    /// <br>Note 3: The total number of values in an associated ParameterValueSet is therefore not fixed but rather a multiple of the sum of independent and dependent scalar parameter types.
    /// <br>Example: The SampledFunctionParameterType can be used to define among others the following: (1) a time series of analysis predictions or measurements, (2) a temperature dependent set of material properties, (3) a frequency spectrum displacement response of a structural item, (4) a mapping of key-value pairs, i.e. the same data structure as a dictionary or hash map in a programming language.
    /// <br>
    /// </summary>
    [CDPVersion("1.2.0")]
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public sealed partial class SampledFunctionParameterType : ParameterType
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
        /// Initializes a new instance of the <see cref="SampledFunctionParameterType"/> class.
        /// </summary>
        public SampledFunctionParameterType()
        {
            this.DependentParameterType = new OrderedItemList<DependentParameterTypeAssignment>(this, true);
            this.IndependentParameterType = new OrderedItemList<IndependentParameterTypeAssignment>(this, true);
            this.InterpolationPeriod = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SampledFunctionParameterType"/> class.
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
        public SampledFunctionParameterType(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.DependentParameterType = new OrderedItemList<DependentParameterTypeAssignment>(this, true);
            this.IndependentParameterType = new OrderedItemList<IndependentParameterTypeAssignment>(this, true);
            this.InterpolationPeriod = new List<string>();
        }

        /// <summary>
        /// Gets or sets the DegreeOfInterpolation.
        /// </summary>
        /// <remarks>
        /// optional definition of a degree of interpolation to be used when computing a function value for a domain value that lies in between stored discretely sampled values
        /// <br>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public int? DegreeOfInterpolation { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered contained DependentParameterTypeAssignment.
        /// </summary>
        /// <remarks>
        /// ordered set of ScalarParameterTypes for the dependent values of the sampled function, i.e. representing its range
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<DependentParameterTypeAssignment> DependentParameterType { get; protected set; }

        /// <summary>
        /// Gets or sets a list of ordered contained IndependentParameterTypeAssignment.
        /// </summary>
        /// <remarks>
        /// ordered set of ScalarParameterTypes for the independent values of the sampled function, i.e. representing its domain
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<IndependentParameterTypeAssignment> IndependentParameterType { get; protected set; }

        /// <summary>
        /// Gets or sets a list of String.
        /// </summary>
        /// <remarks>
        /// optional representation of a period in case of a cyclic function to be taken into account for interpolation
        /// Note: The number of values shall be equal to the number of parameter types in the <i>independentParameterType</i> property. An empty value means no cyclic interpolation for the corresponding <i>independentParameterType</i>.
        /// Example: The function could represent the incident albedo flux as a function of mission elapsed time for a spacecraft in a circular orbit.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<string> InterpolationPeriod { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="SampledFunctionParameterType"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.DependentParameterType);
                containers.Add(this.IndependentParameterType);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SampledFunctionParameterType"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SampledFunctionParameterType"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (SampledFunctionParameterType)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.DependentParameterType = cloneContainedThings ? null : new OrderedItemList<DependentParameterTypeAssignment>(this.DependentParameterType, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.IndependentParameterType = cloneContainedThings ? null : new OrderedItemList<IndependentParameterTypeAssignment>(this.IndependentParameterType, clone);
            clone.InterpolationPeriod = new List<string>(this.InterpolationPeriod);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.DependentParameterType = this.DependentParameterType.Clone(clone);
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.IndependentParameterType = this.IndependentParameterType.Clone(clone);
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SampledFunctionParameterType"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SampledFunctionParameterType"/>.
        /// </returns>
        public new SampledFunctionParameterType Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (SampledFunctionParameterType)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="SampledFunctionParameterType"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var dependentParameterTypeCount = this.DependentParameterType.Count();
            if (dependentParameterTypeCount < 1)
            {
                errorList.Add("The number of elements in the property DependentParameterType is wrong. It should be at least 1.");
            }

            var independentParameterTypeCount = this.IndependentParameterType.Count();
            if (independentParameterTypeCount < 1)
            {
                errorList.Add("The number of elements in the property IndependentParameterType is wrong. It should be at least 1.");
            }

            var interpolationPeriodCount = this.InterpolationPeriod.Count();
            if (interpolationPeriodCount < 1)
            {
                errorList.Add("The number of elements in the property InterpolationPeriod is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="SampledFunctionParameterType"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.SampledFunctionParameterType;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current SampledFunctionParameterType POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.DegreeOfInterpolation = dto.DegreeOfInterpolation;
            this.DependentParameterType.ResolveList(dto.DependentParameterType, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IndependentParameterType.ResolveList(dto.IndependentParameterType, dto.IterationContainerId, this.Cache);
            this.InterpolationPeriod.ClearAndAddRange(dto.InterpolationPeriod);
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.Symbol = dto.Symbol;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="SampledFunctionParameterType"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.SampledFunctionParameterType(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.DegreeOfInterpolation = this.DegreeOfInterpolation;
            dto.DependentParameterType.AddRange(this.DependentParameterType.ToDtoOrderedItemList());
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IndependentParameterType.AddRange(this.IndependentParameterType.ToDtoOrderedItemList());
            dto.InterpolationPeriod.AddRange(this.InterpolationPeriod);
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.Symbol = this.Symbol;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
