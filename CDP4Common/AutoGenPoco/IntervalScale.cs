// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntervalScale.cs" company="RHEA System S.A.">
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
    /// kind of MeasurementScale that has ordered values, a measurement unit and
    /// an arbitrary zero value
    /// Note 1: The measurement unit defines how to interpret an interval of one
    /// on the scale.
    /// Note 2: Two interval scales of measurement for the same quantity kind do
    /// not need to have coincident zero values. In other words, the zero value
    /// can be chosen arbitrarily.
    /// Note 3: On an interval scale of measurement it is possible to take the
    /// difference between two values or to compute the average (arithmetic
    /// mean) of two or more values. Addition or multiplication of values is not
    /// defined. It is however possible to add a quantity value defined on a
    /// compatible ratio scale to a quantity value defined on an interval scale:
    /// e.g. add a temperature difference of 2 kelvin to a temperature of 100
    /// degree Celsius.
    /// Note 4: The numerical value of a quantity expressed on one interval
    /// scale can be converted to the value of the same quantity expressed on a
    /// second (different) interval scale if the ratio between the respective
    /// measurement units is known (the "conversion factor") as well as the
    /// value on the second scale that represents the same quantity as zero on
    /// the first scale (the "conversion offset").
    /// Example 1: The Celsius and Fahrenheit temperature scales are common
    /// examples of interval scales.
    /// Example 2: A "Performance" interval scale with values 0: "very low";
    /// 5: "medium"; 10: "very high"; can be used to compute weighted average
    /// performance for a simple system for which for each of its elements a
    /// separate "Performance" measure is given.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public partial class IntervalScale : MeasurementScale
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
        /// Initializes a new instance of the <see cref="IntervalScale"/> class.
        /// </summary>
        public IntervalScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalScale"/> class.
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
        public IntervalScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();

            dictionary.Add("Alias", this.Alias.Select(x => x.Iid));

            dictionary.Add("Definition", this.Definition.Select(x => x.Iid));

            dictionary.Add("ExcludedDomain", this.ExcludedDomain.Select(x => x.Iid));

            dictionary.Add("ExcludedPerson", this.ExcludedPerson.Select(x => x.Iid));

            dictionary.Add("HyperLink", this.HyperLink.Select(x => x.Iid));

            dictionary.Add("MappingToReferenceScale", this.MappingToReferenceScale.Select(x => x.Iid));

            if (this.Unit != null)
            {
                dictionary.Add("Unit", new [] { this.Unit.Iid });
            }

            dictionary.Add("ValueDefinition", this.ValueDefinition.Select(x => x.Iid));

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
                    case "Unit":
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
        /// Creates and returns a copy of this <see cref="IntervalScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IntervalScale"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (IntervalScale)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="IntervalScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IntervalScale"/>.
        /// </returns>
        public new IntervalScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (IntervalScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="IntervalScale"/>.
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
        /// Resolve the properties of the current <see cref="IntervalScale"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.IntervalScale;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current IntervalScale POCO.");
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
            this.ValueDefinition.ResolveList(dto.ValueDefinition, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="IntervalScale"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.IntervalScale(this.Iid, this.RevisionNumber);

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
