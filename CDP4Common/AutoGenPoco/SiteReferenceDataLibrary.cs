// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibrary.cs" company="Starion Group S.A.">
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
    /// ReferenceDataLibrary that can be (re-)used by multiple EngineeringModels / EngineeringModelSetups
    /// Note 1: A SiteReferenceDataLibrary typically contains more generic concepts that can be used across different concurrent engineering studies and families of studies.
    /// Note 2: As a rule there shall be only one "top" SiteReferenceDataLibrary, i.e. only one that has <i>requiredRdl</i> unspecified.
    /// </summary>
    [Container(typeof(SiteDirectory), "SiteReferenceDataLibrary")]
    public partial class SiteReferenceDataLibrary : ReferenceDataLibrary, IDeprecatableThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NONE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteReferenceDataLibrary"/> class.
        /// </summary>
        public SiteReferenceDataLibrary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteReferenceDataLibrary"/> class.
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
        public SiteReferenceDataLibrary(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteReferenceDataLibrary"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteReferenceDataLibrary"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (SiteReferenceDataLibrary)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.BaseQuantityKind = new OrderedItemList<QuantityKind>(this.BaseQuantityKind, this);
            clone.BaseUnit = new List<MeasurementUnit>(this.BaseUnit);
            clone.Constant = cloneContainedThings ? new ContainerList<Constant>(clone) : new ContainerList<Constant>(this.Constant, clone);
            clone.DefinedCategory = cloneContainedThings ? new ContainerList<Category>(clone) : new ContainerList<Category>(this.DefinedCategory, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.FileType = cloneContainedThings ? new ContainerList<FileType>(clone) : new ContainerList<FileType>(this.FileType, clone);
            clone.Glossary = cloneContainedThings ? new ContainerList<Glossary>(clone) : new ContainerList<Glossary>(this.Glossary, clone);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.ParameterType = cloneContainedThings ? new ContainerList<ParameterType>(clone) : new ContainerList<ParameterType>(this.ParameterType, clone);
            clone.ReferenceSource = cloneContainedThings ? new ContainerList<ReferenceSource>(clone) : new ContainerList<ReferenceSource>(this.ReferenceSource, clone);
            clone.Rule = cloneContainedThings ? new ContainerList<Rule>(clone) : new ContainerList<Rule>(this.Rule, clone);
            clone.Scale = cloneContainedThings ? new ContainerList<MeasurementScale>(clone) : new ContainerList<MeasurementScale>(this.Scale, clone);
            clone.Unit = cloneContainedThings ? new ContainerList<MeasurementUnit>(clone) : new ContainerList<MeasurementUnit>(this.Unit, clone);
            clone.UnitPrefix = cloneContainedThings ? new ContainerList<UnitPrefix>(clone) : new ContainerList<UnitPrefix>(this.UnitPrefix, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Constant.AddRange(this.Constant.Select(x => x.Clone(true)));
                clone.DefinedCategory.AddRange(this.DefinedCategory.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.FileType.AddRange(this.FileType.Select(x => x.Clone(true)));
                clone.Glossary.AddRange(this.Glossary.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.ParameterType.AddRange(this.ParameterType.Select(x => x.Clone(true)));
                clone.ReferenceSource.AddRange(this.ReferenceSource.Select(x => x.Clone(true)));
                clone.Rule.AddRange(this.Rule.Select(x => x.Clone(true)));
                clone.Scale.AddRange(this.Scale.Select(x => x.Clone(true)));
                clone.Unit.AddRange(this.Unit.Select(x => x.Clone(true)));
                clone.UnitPrefix.AddRange(this.UnitPrefix.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteReferenceDataLibrary"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteReferenceDataLibrary"/>.
        /// </returns>
        public new SiteReferenceDataLibrary Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (SiteReferenceDataLibrary)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="SiteReferenceDataLibrary"/>.
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
        /// Resolve the properties of the current <see cref="SiteReferenceDataLibrary"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.SiteReferenceDataLibrary;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current SiteReferenceDataLibrary POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.BaseQuantityKind.ResolveList(dto.BaseQuantityKind, dto.IterationContainerId, this.Cache);
            this.BaseUnit.ResolveList(dto.BaseUnit, dto.IterationContainerId, this.Cache);
            this.Constant.ResolveList(dto.Constant, dto.IterationContainerId, this.Cache);
            this.DefinedCategory.ResolveList(dto.DefinedCategory, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.FileType.ResolveList(dto.FileType, dto.IterationContainerId, this.Cache);
            this.Glossary.ResolveList(dto.Glossary, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.ParameterType.ResolveList(dto.ParameterType, dto.IterationContainerId, this.Cache);
            this.ReferenceSource.ResolveList(dto.ReferenceSource, dto.IterationContainerId, this.Cache);
            this.RequiredRdl = (dto.RequiredRdl.HasValue) ? this.Cache.Get<SiteReferenceDataLibrary>(dto.RequiredRdl.Value, dto.IterationContainerId) : null;
            this.RevisionNumber = dto.RevisionNumber;
            this.Rule.ResolveList(dto.Rule, dto.IterationContainerId, this.Cache);
            this.Scale.ResolveList(dto.Scale, dto.IterationContainerId, this.Cache);
            this.ShortName = dto.ShortName;
            this.ThingPreference = dto.ThingPreference;
            this.Unit.ResolveList(dto.Unit, dto.IterationContainerId, this.Cache);
            this.UnitPrefix.ResolveList(dto.UnitPrefix, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="SiteReferenceDataLibrary"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.SiteReferenceDataLibrary(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.BaseQuantityKind.AddRange(this.BaseQuantityKind.ToDtoOrderedItemList());
            dto.BaseUnit.AddRange(this.BaseUnit.Select(x => x.Iid));
            dto.Constant.AddRange(this.Constant.Select(x => x.Iid));
            dto.DefinedCategory.AddRange(this.DefinedCategory.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.FileType.AddRange(this.FileType.Select(x => x.Iid));
            dto.Glossary.AddRange(this.Glossary.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.ParameterType.AddRange(this.ParameterType.Select(x => x.Iid));
            dto.ReferenceSource.AddRange(this.ReferenceSource.Select(x => x.Iid));
            dto.RequiredRdl = this.RequiredRdl != null ? (Guid?)this.RequiredRdl.Iid : null;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Rule.AddRange(this.Rule.Select(x => x.Iid));
            dto.Scale.AddRange(this.Scale.Select(x => x.Iid));
            dto.ShortName = this.ShortName;
            dto.ThingPreference = this.ThingPreference;
            dto.Unit.AddRange(this.Unit.Select(x => x.Iid));
            dto.UnitPrefix.AddRange(this.UnitPrefix.Select(x => x.Iid));

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
