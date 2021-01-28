// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnit.cs" company="RHEA System S.A.">
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
    /// specialization of ConversionBasedUnit that defines a MeasurementUnit with a
    /// multiple or submultiple UnitPrefix
    /// Example: Measurement units like "kilogram", "millimetre", "nanovolt",
    /// "gibibyte" etc.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public sealed partial class PrefixedUnit : ConversionBasedUnit
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
        /// Initializes a new instance of the <see cref="PrefixedUnit"/> class.
        /// </summary>
        public PrefixedUnit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixedUnit"/> class.
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
        public PrefixedUnit(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ConversionFactor.
        /// </summary>
        /// <remarks>
        /// applicable conversion factor derived from <i>prefix</i>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ConversionFactor property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override string ConversionFactor
        {
            get { return this.GetDerivedConversionFactor(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.ConversionFactor"); }
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// derived name of this PrefixUnit
        /// Note: The name is derived as the concatenation of name of the <i>prefix</i> and the name of the <i>referenceUnit</i>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override string Name
        {
            get { return this.GetDerivedName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.Name"); }
        }

        /// <summary>
        /// Gets or sets the Prefix.
        /// </summary>
        /// <remarks>
        /// reference to the applicable UnitPrefix
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public UnitPrefix Prefix { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <remarks>
        /// derived symbol of this PrefixUnit
        /// Note: The symbol is derived as the concatenation of <i>shortName</i> of the <i>prefix</i> and the <i>shortName</i> of the <i>referenceUnit</i>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ShortName property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override string ShortName
        {
            get { return this.GetDerivedShortName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.ShortName"); }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="PrefixedUnit"/>
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

            if (this.Prefix != null)
            {
                yield return this.Prefix;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="PrefixedUnit"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="PrefixedUnit"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (PrefixedUnit)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
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
        /// Creates and returns a copy of this <see cref="PrefixedUnit"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="PrefixedUnit"/>.
        /// </returns>
        public new PrefixedUnit Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (PrefixedUnit)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="PrefixedUnit"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Prefix == null || this.Prefix.Iid == Guid.Empty)
            {
                errorList.Add("The property Prefix is null.");
                this.Prefix = SentinelThingProvider.GetSentinel<UnitPrefix>();
                this.sentinelResetMap["Prefix"] = () => this.Prefix = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="PrefixedUnit"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.PrefixedUnit;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current PrefixedUnit POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Prefix = this.Cache.Get<UnitPrefix>(dto.Prefix, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<UnitPrefix>();
            this.ReferenceUnit = this.Cache.Get<MeasurementUnit>(dto.ReferenceUnit, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementUnit>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="PrefixedUnit"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.PrefixedUnit(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Prefix = this.Prefix != null ? this.Prefix.Iid : Guid.Empty;
            dto.ReferenceUnit = this.ReferenceUnit != null ? this.ReferenceUnit.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
