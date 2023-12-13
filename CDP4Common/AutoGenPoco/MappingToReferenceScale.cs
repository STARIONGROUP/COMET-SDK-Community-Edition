// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingToReferenceScale.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a mapping of a value on a dependent MeasurementScale to a value on a reference MeasurementScale that represents the same quantity
    /// Note 1: One or more of these mappings would be defined for a dependent MeasurementScale (the scale being mapped) with respect to a reference MeasurementScale (the scale being mapped to) in order to enable quantity value conversion.
    /// Note 2: For conversion between measurement scales other than OrdinalScales, i.e. scales with a meaningful MeasurementUnit that defines intervals of one on that scale, a single MappingToReferenceScale implicitly defines the offset by which measurement values need to be transformed when converting from the dependent to the reference scale or vice versa.
    /// Note 3: For conversion to or from an OrdinalScale, a complete set of MappingToReferenceScale instances would need to be defined, one for each value on the OrdinalScale, since for an OrdinalScale the intervals between the scale values do not have particular significance, and therefore the mapping cannot be represented by a simple (linear or logarithmic) transformation function.
    /// Example: The mapping between the thermodynamic temperature RatioScale in kelvin (the reference scale) and the Celsius temperature IntervalScale in degree Celsius (the dependent scale) is defined by a MappingToReferenceScale with <i>referenceScaleValue.value</i> = 0.0 [K] and <i>dependentScaleValue.value</i> = -273.15 [°C].
    /// </summary>
    [Container(typeof(MeasurementScale), "MappingToReferenceScale")]
    public partial class MappingToReferenceScale : Thing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingToReferenceScale"/> class.
        /// </summary>
        public MappingToReferenceScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingToReferenceScale"/> class.
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
        public MappingToReferenceScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the DependentScaleValue.
        /// </summary>
        /// <remarks>
        /// reference to the ScaleValueDefinition of the dependent MeasurementScale, i.e. the value on the dependent scale that represents the same quantity as the one defined by the given <i>referenceScaleValue</i>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ScaleValueDefinition DependentScaleValue { get; set; }

        /// <summary>
        /// Gets or sets the ReferenceScaleValue.
        /// </summary>
        /// <remarks>
        /// reference to the ScaleValueDefinition of the reference MeasurementScale
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ScaleValueDefinition ReferenceScaleValue { get; set; }

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();
            dictionary.Add("DependentScaleValue", new [] { this.DependentScaleValue?.Iid ?? Guid.Empty });
            dictionary.Add("ExcludedDomain", this.ExcludedDomain.Select(x => x.Iid));
            dictionary.Add("ExcludedPerson", this.ExcludedPerson.Select(x => x.Iid));
            dictionary.Add("ReferenceScaleValue", new [] { this.ReferenceScaleValue?.Iid ?? Guid.Empty });

            return dictionary;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to any of the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to search for.</param>
        /// <returns>True is any of the id's in <paramref name="ids"/> is found in this instance's reference properties.</returns>
        public override bool HasMandatoryReferenceToAny(IEnumerable<Guid> ids)
        {
            var result = false;

            if (!ids.Any())
            {
                return false;
            }

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "DependentScaleValue":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;

                    case "ReferenceScaleValue":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to an id that cannot be found in the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The HashSet of Guids to search for.</param>
        /// <returns>True is the id in this instance's mandatory reference properties is not found in in <paramref name="ids"/>.</returns>
        public override bool HasMandatoryReferenceNotIn(HashSet<Guid> ids)
        {
            var result = false;

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "DependentScaleValue":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;

                    case "ReferenceScaleValue":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="MappingToReferenceScale"/>
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

            if (this.DependentScaleValue != null)
            {
                yield return this.DependentScaleValue;
            }

            if (this.ReferenceScaleValue != null)
            {
                yield return this.ReferenceScaleValue;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="MappingToReferenceScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="MappingToReferenceScale"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (MappingToReferenceScale)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="MappingToReferenceScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="MappingToReferenceScale"/>.
        /// </returns>
        public new MappingToReferenceScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (MappingToReferenceScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="MappingToReferenceScale"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.DependentScaleValue == null || this.DependentScaleValue.Iid == Guid.Empty)
            {
                errorList.Add("The property DependentScaleValue is null.");
                this.DependentScaleValue = SentinelThingProvider.GetSentinel<ScaleValueDefinition>();
                this.sentinelResetMap["DependentScaleValue"] = () => this.DependentScaleValue = null;
            }

            if (this.ReferenceScaleValue == null || this.ReferenceScaleValue.Iid == Guid.Empty)
            {
                errorList.Add("The property ReferenceScaleValue is null.");
                this.ReferenceScaleValue = SentinelThingProvider.GetSentinel<ScaleValueDefinition>();
                this.sentinelResetMap["ReferenceScaleValue"] = () => this.ReferenceScaleValue = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="MappingToReferenceScale"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.MappingToReferenceScale;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current MappingToReferenceScale POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.DependentScaleValue = this.Cache.Get<ScaleValueDefinition>(dto.DependentScaleValue, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ScaleValueDefinition>();
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.ReferenceScaleValue = this.Cache.Get<ScaleValueDefinition>(dto.ReferenceScaleValue, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ScaleValueDefinition>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="MappingToReferenceScale"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.MappingToReferenceScale(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.DependentScaleValue = this.DependentScaleValue != null ? this.DependentScaleValue.Iid : Guid.Empty;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.ReferenceScaleValue = this.ReferenceScaleValue != null ? this.ReferenceScaleValue.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
