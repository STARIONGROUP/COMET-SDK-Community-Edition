// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscription.cs" company="Starion Group S.A.">
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
    /// representation of a subscription to a Parameter or ParameterOverride taken by a DomainOfExpertise that is not the owner of the Parameter or ParameterOverride
    /// Note: ParameterSubscriptions represent parameters used as inputs in concurrent engineering workbooks.
    /// </summary>
    [Container(typeof(ParameterOrOverrideBase), "ParameterSubscription")]
    public partial class ParameterSubscription : ParameterBase
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NONE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSubscription"/> class.
        /// </summary>
        public ParameterSubscription()
        {
            this.ValueSet = new ContainerList<ParameterSubscriptionValueSet>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSubscription"/> class.
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
        public ParameterSubscription(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ValueSet = new ContainerList<ParameterSubscriptionValueSet>(this);
        }

        /// <summary>
        /// Gets or sets the Group.
        /// </summary>
        /// <remarks>
        /// group derived from associated Parameter or ParameterOverride for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Group property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ParameterGroup Group
        {
            get { return this.GetDerivedGroup(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.Group"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsOptionDependent.
        /// </summary>
        /// <remarks>
        /// assertion, derived from the container Parameter or ParameterOverride, whether the values of this depend on the Options defined in the associated Iteration or not
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The IsOptionDependent property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override bool IsOptionDependent
        {
            get { return this.GetDerivedIsOptionDependent(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.IsOptionDependent"); }
        }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// parameterType derived from associated Parameter or ParameterOverride for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ParameterType property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ParameterType ParameterType
        {
            get { return this.GetDerivedParameterType(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.ParameterType"); }
        }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// scale derived from associated Parameter or ParameterOverride for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Scale property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override MeasurementScale Scale
        {
            get { return this.GetDerivedScale(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.Scale"); }
        }

        /// <summary>
        /// Gets or sets the StateDependence.
        /// </summary>
        /// <remarks>
        /// stateDependence derived from associated Parameter or ParameterOverride for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The StateDependence property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ActualFiniteStateList StateDependence
        {
            get { return this.GetDerivedStateDependence(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.StateDependence"); }
        }

        /// <summary>
        /// Gets or sets a list of contained ParameterSubscriptionValueSet.
        /// </summary>
        /// <remarks>
        /// representation of the switch and values of this ParameterSubscription
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParameterSubscriptionValueSet> ValueSet { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ParameterSubscription"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ValueSet);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterSubscription"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterSubscription"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ParameterSubscription)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ValueSet = cloneContainedThings ? new ContainerList<ParameterSubscriptionValueSet>(clone) : new ContainerList<ParameterSubscriptionValueSet>(this.ValueSet, clone);

            if (cloneContainedThings)
            {
                clone.ValueSet.AddRange(this.ValueSet.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterSubscription"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterSubscription"/>.
        /// </returns>
        public new ParameterSubscription Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterSubscription)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterSubscription"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var valueSetCount = this.ValueSet.Count();
            if (valueSetCount < 1)
            {
                errorList.Add("The number of elements in the property ValueSet is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ParameterSubscription"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ParameterSubscription;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current ParameterSubscription POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;
            this.ValueSet.ResolveList(dto.ValueSet, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ParameterSubscription"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ParameterSubscription(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;
            dto.ValueSet.AddRange(this.ValueSet.Select(x => x.Iid));

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
