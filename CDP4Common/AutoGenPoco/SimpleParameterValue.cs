// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleParameterValue.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    /// representation of a single parameter with value for a SimpleParameterizableThing
    /// Note: This allows attaching "user-defined attributes" to SimpleParameterizableThings by using ParameterTypes defined in a ReferenceDataLibrary, i.e. reusing the concepts already defined for Parameters of ElementDefinitions.
    /// </summary>
    [Container(typeof(SimpleParameterizableThing), "ParameterValue")]
    public sealed partial class SimpleParameterValue : Thing, IOwnedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleParameterValue"/> class.
        /// </summary>
        public SimpleParameterValue()
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleParameterValue"/> class.
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
        public SimpleParameterValue(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to a DomainOfExpertise that is the owner of this SimpleParameterValue
        /// Note: The <i>owner</i> is the same as the <i>owner</i> of the SimpleParameterizableThing that contains this SimpleParameterValue.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public DomainOfExpertise Owner
        {
            get { return this.GetDerivedOwner(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property SimpleParameterValue.Owner"); }
        }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// reference to the applicable ParameterType for this SimpleParameterValue
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterType ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// reference to the applicable MeasurementScale if the <i>parameterType</i> is a QuantityKind
        /// Note: The MeasurementScale must be one of the <i>possibleScale</i> defined for the QuantityKind.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public MeasurementScale Scale { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// value of this SimpleParameterValue
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public ValueArray<string> Value { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="SimpleParameterValue"/>
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

            if (this.ParameterType != null)
            {
                yield return this.ParameterType;
            }

            if (this.Scale != null)
            {
                yield return this.Scale;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SimpleParameterValue"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SimpleParameterValue"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (SimpleParameterValue)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.Value = new ValueArray<string>(this.Value, this);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SimpleParameterValue"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SimpleParameterValue"/>.
        /// </returns>
        public new SimpleParameterValue Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (SimpleParameterValue)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="SimpleParameterValue"/>.
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

            var valueCount = this.Value.Count();
            if (valueCount < 1)
            {
                errorList.Add("The number of elements in the property Value is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="SimpleParameterValue"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.SimpleParameterValue;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current SimpleParameterValue POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.ParameterType = this.Cache.Get<ParameterType>(dto.ParameterType, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterType>();
            this.RevisionNumber = dto.RevisionNumber;
            this.Scale = (dto.Scale.HasValue) ? this.Cache.Get<MeasurementScale>(dto.Scale.Value, dto.IterationContainerId) : null;
            this.ThingPreference = dto.ThingPreference;
            this.Value = new ValueArray<string>(dto.Value, this);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="SimpleParameterValue"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.SimpleParameterValue(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.ParameterType = this.ParameterType != null ? this.ParameterType.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Scale = this.Scale != null ? (Guid?)this.Scale.Iid : null;
            dto.ThingPreference = this.ThingPreference;
            dto.Value = new ValueArray<string>(this.Value, this);

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
