// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicRatioScale.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
    /// representation of a ratio MeasurementScale with a periodic cycle
    /// Note: The magnitude of the periodic cycle is defined by the modulus of the scale.
    /// Example: Planar angle with modulus 360 degree, therefore an angle of 450 degree is the same as an angle of 90 degree, and -60 degree is the same as 300 degree.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public sealed partial class CyclicRatioScale : RatioScale
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
        /// Initializes a new instance of the <see cref="CyclicRatioScale"/> class.
        /// </summary>
        public CyclicRatioScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CyclicRatioScale"/> class.
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
        public CyclicRatioScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Modulus.
        /// </summary>
        /// <remarks>
        /// definition of the modulus of this CyclicRatioScale
        /// Note: The value is expressed in the <i>unit</i> of this CyclicRatioScale.
        /// Example: For a plane angle scale in degree the modulus would be specified as 360 degree.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Modulus { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="CyclicRatioScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="CyclicRatioScale"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (CyclicRatioScale)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.MappingToReferenceScale = cloneContainedThings ? new ContainerList<MappingToReferenceScale>(clone) : new ContainerList<MappingToReferenceScale>(this.MappingToReferenceScale, clone);
            clone.ValueDefinition = cloneContainedThings ? new ContainerList<ScaleValueDefinition>(clone) : new ContainerList<ScaleValueDefinition>(this.ValueDefinition, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.MappingToReferenceScale.AddRange(this.MappingToReferenceScale.Select(x => x.Clone(true)));
                clone.ValueDefinition.AddRange(this.ValueDefinition.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="CyclicRatioScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="CyclicRatioScale"/>.
        /// </returns>
        public new CyclicRatioScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (CyclicRatioScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="CyclicRatioScale"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Modulus))
            {
                errorList.Add("The property Modulus is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="CyclicRatioScale"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.CyclicRatioScale;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current CyclicRatioScale POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.IsMaximumInclusive = dto.IsMaximumInclusive;
            this.IsMinimumInclusive = dto.IsMinimumInclusive;
            this.MappingToReferenceScale.ResolveList(dto.MappingToReferenceScale, dto.IterationContainerId, this.Cache);
            this.MaximumPermissibleValue = dto.MaximumPermissibleValue;
            this.MinimumPermissibleValue = dto.MinimumPermissibleValue;
            this.ModifiedOn = dto.ModifiedOn;
            this.Modulus = dto.Modulus;
            this.Name = dto.Name;
            this.NegativeValueConnotation = dto.NegativeValueConnotation;
            this.NumberSet = dto.NumberSet;
            this.PositiveValueConnotation = dto.PositiveValueConnotation;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.ThingPreference = dto.ThingPreference;
            this.Unit = this.Cache.Get<MeasurementUnit>(dto.Unit, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementUnit>();
            this.ValueDefinition.ResolveList(dto.ValueDefinition, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="CyclicRatioScale"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.CyclicRatioScale(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.IsMaximumInclusive = this.IsMaximumInclusive;
            dto.IsMinimumInclusive = this.IsMinimumInclusive;
            dto.MappingToReferenceScale.AddRange(this.MappingToReferenceScale.Select(x => x.Iid));
            dto.MaximumPermissibleValue = this.MaximumPermissibleValue;
            dto.MinimumPermissibleValue = this.MinimumPermissibleValue;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Modulus = this.Modulus;
            dto.Name = this.Name;
            dto.NegativeValueConnotation = this.NegativeValueConnotation;
            dto.NumberSet = this.NumberSet;
            dto.PositiveValueConnotation = this.PositiveValueConnotation;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.ThingPreference = this.ThingPreference;
            dto.Unit = this.Unit != null ? this.Unit.Iid : Guid.Empty;
            dto.ValueDefinition.AddRange(this.ValueDefinition.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
