// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndependentParameterTypeAssignment.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    /// a pairing of an assigned ParameterType and a MeasurementScale, specific to independent parameter types of a SampledFunctionParameterType, in case a QuantityKind is selected. The MeasurementScale must be in the array of possible MeasurementScales of the the ParameterType.
    /// </summary>
    [CDPVersion("1.2.0")]
    [Container(typeof(SampledFunctionParameterType), "IndependentParameterType")]
    public partial class IndependentParameterTypeAssignment : Thing, IParameterTypeAssignment
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
        /// Initializes a new instance of the <see cref="IndependentParameterTypeAssignment"/> class.
        /// </summary>
        public IndependentParameterTypeAssignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndependentParameterTypeAssignment"/> class.
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
        public IndependentParameterTypeAssignment(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the MeasurementScale.
        /// </summary>
        /// <remarks>
        /// the MeasurementScale applicable to the ParameterType of the selection. Null if the ParameterType is not a QuantityKind. Must be in the array of possible MeasurementScales of the selected ParameterType.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public MeasurementScale MeasurementScale { get; set; }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// the selected ParameterType assignment.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterType ParameterType { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="IndependentParameterTypeAssignment"/>
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

            if (this.MeasurementScale != null)
            {
                yield return this.MeasurementScale;
            }

            if (this.ParameterType != null)
            {
                yield return this.ParameterType;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="IndependentParameterTypeAssignment"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IndependentParameterTypeAssignment"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (IndependentParameterTypeAssignment)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="IndependentParameterTypeAssignment"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IndependentParameterTypeAssignment"/>.
        /// </returns>
        public new IndependentParameterTypeAssignment Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (IndependentParameterTypeAssignment)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="IndependentParameterTypeAssignment"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.ParameterType == null || this.ParameterType.Iid == Guid.Empty)
            {
                errorList.Add("The property ParameterType is null.");
                this.ParameterType = SentinelThingProvider.GetSentinel<ParameterType>();
                this.sentinelResetMap["ParameterType"] = () => this.ParameterType = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="IndependentParameterTypeAssignment"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.IndependentParameterTypeAssignment;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current IndependentParameterTypeAssignment POCO.");
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.MeasurementScale = (dto.MeasurementScale.HasValue) ? this.Cache.Get<MeasurementScale>(dto.MeasurementScale.Value, dto.IterationContainerId) : null;
            this.ModifiedOn = dto.ModifiedOn;
            this.ParameterType = this.Cache.Get<ParameterType>(dto.ParameterType, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterType>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="IndependentParameterTypeAssignment"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.IndependentParameterTypeAssignment(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.MeasurementScale = this.MeasurementScale != null ? (Guid?)this.MeasurementScale.Iid : null;
            dto.ModifiedOn = this.ModifiedOn;
            dto.ParameterType = this.ParameterType != null ? this.ParameterType.Iid : Guid.Empty;
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
