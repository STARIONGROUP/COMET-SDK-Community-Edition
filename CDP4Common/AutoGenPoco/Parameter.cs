// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    /// representation of a parameter that defines a characteristic or property of an ElementDefinition
    /// Note 1: The concurrent engineering process is centered around a multi-disciplinary parametric definition of the system of interest. Parameters (with values) assigned to ElementDefinitions, ElementUsages and possibly NestedElements are the essential mechanism by which each DomainOfExpertise characterises, quantifies, communicates and shares their part of a design solution with all other domains of expertise (DomainOfExpertise).
    /// Note 2: The associated ParameterType (through the parameterType property) provides name, shortName, and optionally alias, definition and hyperLink for this Parameter.
    /// </summary>
    [Container(typeof(ElementDefinition), "Parameter")]
    public sealed partial class Parameter : ParameterOrOverrideBase
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
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
        {
            this.ValueSet = new ContainerList<ParameterValueSet>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
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
        public Parameter(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ValueSet = new ContainerList<ParameterValueSet>(this);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowDifferentOwnerOfOverride.
        /// </summary>
        /// <remarks>
        /// assertion whether a ParameterOverride associated with this Parameter may have a different owner DomainOfExpertise or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool AllowDifferentOwnerOfOverride { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ExpectsOverride.
        /// </summary>
        /// <remarks>
        /// assertion whether a ParameterOverride is expected for this Parameter in ElementUsages of the ElementDefinition that contains this Parameter
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool ExpectsOverride { get; set; }

        /// <summary>
        /// Gets or sets the RequestedBy.
        /// </summary>
        /// <remarks>
        /// optional reference to the DomainOfExpertise that has requested this Parameter
        /// Note: This property is used to signify that a Parameter has not been created (i.e. added to an ElementDefinition) by the owner DomainOfExpertise by is requested by a different DomainOfExpertise. When the value is unset (i.e. set to null) it signifies that the Parameter has been accepted by the owner DomainOfExpertise.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DomainOfExpertise RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ParameterValueSet.
        /// </summary>
        /// <remarks>
        /// representation of the switch and values of this Parameter
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParameterValueSet> ValueSet { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Parameter"/>.
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
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Parameter"/>
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

            if (this.RequestedBy != null)
            {
                yield return this.RequestedBy;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Parameter"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Parameter"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Parameter)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ParameterSubscription = cloneContainedThings ? new ContainerList<ParameterSubscription>(clone) : new ContainerList<ParameterSubscription>(this.ParameterSubscription, clone);
            clone.ValueSet = cloneContainedThings ? new ContainerList<ParameterValueSet>(clone) : new ContainerList<ParameterValueSet>(this.ValueSet, clone);

            if (cloneContainedThings)
            {
                clone.ParameterSubscription.AddRange(this.ParameterSubscription.Select(x => x.Clone(true)));
                clone.ValueSet.AddRange(this.ValueSet.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Parameter"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Parameter"/>.
        /// </returns>
        public new Parameter Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Parameter)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Parameter"/>.
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
        /// Resolve the properties of the current <see cref="Parameter"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Parameter;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current Parameter POCO.", dtoThing.GetType()));
            }

            this.AllowDifferentOwnerOfOverride = dto.AllowDifferentOwnerOfOverride;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ExpectsOverride = dto.ExpectsOverride;
            this.Group = (dto.Group.HasValue) ? this.Cache.Get<ParameterGroup>(dto.Group.Value, dto.IterationContainerId) : null;
            this.IsOptionDependent = dto.IsOptionDependent;
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.ParameterSubscription.ResolveList(dto.ParameterSubscription, dto.IterationContainerId, this.Cache);
            this.ParameterType = this.Cache.Get<ParameterType>(dto.ParameterType, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterType>();
            this.RequestedBy = (dto.RequestedBy.HasValue) ? this.Cache.Get<DomainOfExpertise>(dto.RequestedBy.Value, dto.IterationContainerId) : null;
            this.RevisionNumber = dto.RevisionNumber;
            this.Scale = (dto.Scale.HasValue) ? this.Cache.Get<MeasurementScale>(dto.Scale.Value, dto.IterationContainerId) : null;
            this.StateDependence = (dto.StateDependence.HasValue) ? this.Cache.Get<ActualFiniteStateList>(dto.StateDependence.Value, dto.IterationContainerId) : null;
            this.ThingPreference = dto.ThingPreference;
            this.ValueSet.ResolveList(dto.ValueSet, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Parameter"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Parameter(this.Iid, this.RevisionNumber);

            dto.AllowDifferentOwnerOfOverride = this.AllowDifferentOwnerOfOverride;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ExpectsOverride = this.ExpectsOverride;
            dto.Group = this.Group != null ? (Guid?)this.Group.Iid : null;
            dto.IsOptionDependent = this.IsOptionDependent;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.ParameterSubscription.AddRange(this.ParameterSubscription.Select(x => x.Iid));
            dto.ParameterType = this.ParameterType != null ? this.ParameterType.Iid : Guid.Empty;
            dto.RequestedBy = this.RequestedBy != null ? (Guid?)this.RequestedBy.Iid : null;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Scale = this.Scale != null ? (Guid?)this.Scale.Iid : null;
            dto.StateDependence = this.StateDependence != null ? (Guid?)this.StateDependence.Iid : null;
            dto.ThingPreference = this.ThingPreference;
            dto.ValueSet.AddRange(this.ValueSet.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
