// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrdinalScale.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    /// kind of MeasurementScale in which the possible valid values are ordered
    /// but where the intervals between the values do not have particular
    /// significance
    /// Note 1: It is therefore is not meaningful to add or subtract values on
    /// such a scale. It is possible to compare values numerically.
    /// Note 2:The MeasurementUnit associated with such scales should be the number one.
    /// Example 1: The NASA/ESA Technology Readiness Level (TRL) scale with
    /// ScaleValueDefinitions: 1 : "Basic principles observed and reported"; 2 :
    /// "Technology concept and/or application formulated"; 3 : "Analytical and
    /// experimental critical function and/or characteristic proof-of- concept";
    /// 4 : "Component and/or breadboard validation in laboratory environment";
    /// 5 : "Component and/or breadboard validation in relevant environment"; 6
    /// : "System/subsystem model or prototype demonstration in a relevant
    /// environment (ground or space)"; 7 : "System prototype demonstration in a
    /// space environment"; 8 : "Actual system completed and 'flight qualified'
    /// through test and demonstration (ground or space)"; 9 : "Actual system
    /// 'flight proven' through successful mission operations".
    /// Example 2: The Beaufort wind force scale with ScaleValueDefinitions (as
    /// defined by the <i>World Meteorological Organization</i>): 0 : "Calm"; 1
    /// : "Light air"; 2: "Light breeze"; 3: "Gentle breeze"; 4: "Moderate
    /// breeze"; 5: "Fresh breeze"; 6: "Strong breeze"; 7: "Near gale"; 8:
    /// "Gale"; 9: "Strong gale"; 10: "Storm"; 11: "Violent storm"; 12:
    /// "Hurricane".
    /// Example 3: A simple "Priority" scale with ScaleValueDefinitions
    /// 1: "low"; 2: "medium"; 3: "high"; that is used to distinguish between
    /// different priorities and be able to tell whether a given priority is
    /// higher or lower than another.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public partial class OrdinalScale : MeasurementScale
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
        /// Initializes a new instance of the <see cref="OrdinalScale"/> class.
        /// </summary>
        public OrdinalScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdinalScale"/> class.
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
        public OrdinalScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether UseShortNameValues.
        /// </summary>
        /// <remarks>
        /// assertion whether shortNames of the associated ScaleValueDefinitions are used as values or numeric values
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool UseShortNameValues { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="OrdinalScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="OrdinalScale"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (OrdinalScale)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="OrdinalScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="OrdinalScale"/>.
        /// </returns>
        public new OrdinalScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (OrdinalScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="OrdinalScale"/>.
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
        /// Resolve the properties of the current <see cref="OrdinalScale"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.OrdinalScale;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current OrdinalScale POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
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
            this.Name = dto.Name;
            this.NegativeValueConnotation = dto.NegativeValueConnotation;
            this.NumberSet = dto.NumberSet;
            this.PositiveValueConnotation = dto.PositiveValueConnotation;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.ThingPreference = dto.ThingPreference;
            this.Unit = this.Cache.Get<MeasurementUnit>(dto.Unit, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementUnit>();
            this.UseShortNameValues = dto.UseShortNameValues;
            this.ValueDefinition.ResolveList(dto.ValueDefinition, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="OrdinalScale"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.OrdinalScale(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
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
            dto.Name = this.Name;
            dto.NegativeValueConnotation = this.NegativeValueConnotation;
            dto.NumberSet = this.NumberSet;
            dto.PositiveValueConnotation = this.PositiveValueConnotation;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.ThingPreference = this.ThingPreference;
            dto.Unit = this.Unit != null ? this.Unit.Iid : Guid.Empty;
            dto.UseShortNameValues = this.UseShortNameValues;
            dto.ValueDefinition.AddRange(this.ValueDefinition.Select(x => x.Iid));

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
