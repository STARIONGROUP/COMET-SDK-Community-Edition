// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScale.cs" company="RHEA System S.A.">
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
    /// representation of a logarithmic MeasurementScale
    /// Note: The logarithmic ratio quantity value <i>v</i> is computed as follows: <i>v</i> = <i>f</i> · log<sub>base</sub>( (<i>x</i> / <i>x<sub>ref</sub></i> )<i><sup>a</sup></i> ), where <i>f</i> is a multiplication factor, <i>base</i> is the base of the log function, <i>x</i> is the actual quantity, <i>x<sub>ref</sub></i> is a reference quantity, and <i>a</i> is an exponent.
    /// Example 1: The base 10 logarithmic measurement scale for "sound pressure level" in "decibel", with <i>factor</i> is "10", <i>exponent</i> is "2", <i>referenceQuantityKind</i> is "sound pressure" and <i>referenceQuantityValue</i>.value is "20" on the "µPa" RatioScale. Source: ISO 80000-08.
    /// Example 2: The natural logarithmic measurement scale for "electric field strength" in "neper".
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public sealed partial class LogarithmicScale : MeasurementScale
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
        /// Initializes a new instance of the <see cref="LogarithmicScale"/> class.
        /// </summary>
        public LogarithmicScale()
        {
            this.ReferenceQuantityValue = new ContainerList<ScaleReferenceQuantityValue>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogarithmicScale"/> class.
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
        public LogarithmicScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ReferenceQuantityValue = new ContainerList<ScaleReferenceQuantityValue>(this);
        }

        /// <summary>
        /// Gets or sets the Exponent.
        /// </summary>
        /// <remarks>
        /// exponent used in the definition formula for the quantity value for this LogarithmicScale
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Exponent { get; set; }

        /// <summary>
        /// Gets or sets the Factor.
        /// </summary>
        /// <remarks>
        /// factor used in the definition formula for the quantity value for this LogarithmicScale
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Factor { get; set; }

        /// <summary>
        /// Gets or sets the LogarithmBase.
        /// </summary>
        /// <remarks>
        /// base of the logarithmic function used on this LogarithmicScale
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public LogarithmBaseKind LogarithmBase { get; set; }

        /// <summary>
        /// Gets or sets the ReferenceQuantityKind.
        /// </summary>
        /// <remarks>
        /// reference to the applicable QuantityKind for the quotient of quantities in the definition formula of this LogarithmicScale
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public QuantityKind ReferenceQuantityKind { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ScaleReferenceQuantityValue.
        /// </summary>
        /// <remarks>
        /// optional value for the reference quantity in the definition formula for this LogarithmicScale
        /// Note: A logarithmic scale may define a fixed reference quantity. See also <a href="http://www.nist.gov/pml/pubs/sp811/index.cfm">NIST SP811</a> for many more details.
        /// Example: The base 10 logarithmic scale for "sound pressure level" in decibel is defined with respect to a reference sound pressure <i>p<sub>0</sub></i> = 20 µPa. The sound pressure level value on such a scale for a corresponding sound pressure <i>p</i> would then be 10·log<sub>10</sub>((<i>p</i>/<i>p<sub>0</sub></i>)<sup>2</sup>) dB.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ScaleReferenceQuantityValue> ReferenceQuantityValue { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="LogarithmicScale"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ReferenceQuantityValue);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="LogarithmicScale"/>
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

            if (this.ReferenceQuantityKind != null)
            {
                yield return this.ReferenceQuantityKind;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="LogarithmicScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="LogarithmicScale"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (LogarithmicScale)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.MappingToReferenceScale = cloneContainedThings ? new ContainerList<MappingToReferenceScale>(clone) : new ContainerList<MappingToReferenceScale>(this.MappingToReferenceScale, clone);
            clone.ReferenceQuantityValue = cloneContainedThings ? new ContainerList<ScaleReferenceQuantityValue>(clone) : new ContainerList<ScaleReferenceQuantityValue>(this.ReferenceQuantityValue, clone);
            clone.ValueDefinition = cloneContainedThings ? new ContainerList<ScaleValueDefinition>(clone) : new ContainerList<ScaleValueDefinition>(this.ValueDefinition, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.MappingToReferenceScale.AddRange(this.MappingToReferenceScale.Select(x => x.Clone(true)));
                clone.ReferenceQuantityValue.AddRange(this.ReferenceQuantityValue.Select(x => x.Clone(true)));
                clone.ValueDefinition.AddRange(this.ValueDefinition.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="LogarithmicScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="LogarithmicScale"/>.
        /// </returns>
        public new LogarithmicScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (LogarithmicScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="LogarithmicScale"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Exponent))
            {
                errorList.Add("The property Exponent is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.Factor))
            {
                errorList.Add("The property Factor is null or empty.");
            }

            if (this.ReferenceQuantityKind == null || this.ReferenceQuantityKind.Iid == Guid.Empty)
            {
                errorList.Add("The property ReferenceQuantityKind is null.");
                this.ReferenceQuantityKind = SentinelThingProvider.GetSentinel<QuantityKind>();
                this.sentinelResetMap["ReferenceQuantityKind"] = () => this.ReferenceQuantityKind = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="LogarithmicScale"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.LogarithmicScale;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current LogarithmicScale POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.Exponent = dto.Exponent;
            this.Factor = dto.Factor;
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.IsMaximumInclusive = dto.IsMaximumInclusive;
            this.IsMinimumInclusive = dto.IsMinimumInclusive;
            this.LogarithmBase = dto.LogarithmBase;
            this.MappingToReferenceScale.ResolveList(dto.MappingToReferenceScale, dto.IterationContainerId, this.Cache);
            this.MaximumPermissibleValue = dto.MaximumPermissibleValue;
            this.MinimumPermissibleValue = dto.MinimumPermissibleValue;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.NegativeValueConnotation = dto.NegativeValueConnotation;
            this.NumberSet = dto.NumberSet;
            this.PositiveValueConnotation = dto.PositiveValueConnotation;
            this.ReferenceQuantityKind = this.Cache.Get<QuantityKind>(dto.ReferenceQuantityKind, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<QuantityKind>();
            this.ReferenceQuantityValue.ResolveList(dto.ReferenceQuantityValue, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.ThingPreference = dto.ThingPreference;
            this.Unit = this.Cache.Get<MeasurementUnit>(dto.Unit, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementUnit>();
            this.ValueDefinition.ResolveList(dto.ValueDefinition, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="LogarithmicScale"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.LogarithmicScale(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.Exponent = this.Exponent;
            dto.Factor = this.Factor;
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.IsMaximumInclusive = this.IsMaximumInclusive;
            dto.IsMinimumInclusive = this.IsMinimumInclusive;
            dto.LogarithmBase = this.LogarithmBase;
            dto.MappingToReferenceScale.AddRange(this.MappingToReferenceScale.Select(x => x.Iid));
            dto.MaximumPermissibleValue = this.MaximumPermissibleValue;
            dto.MinimumPermissibleValue = this.MinimumPermissibleValue;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.NegativeValueConnotation = this.NegativeValueConnotation;
            dto.NumberSet = this.NumberSet;
            dto.PositiveValueConnotation = this.PositiveValueConnotation;
            dto.ReferenceQuantityKind = this.ReferenceQuantityKind != null ? this.ReferenceQuantityKind.Iid : Guid.Empty;
            dto.ReferenceQuantityValue.AddRange(this.ReferenceQuantityValue.Select(x => x.Iid));
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
