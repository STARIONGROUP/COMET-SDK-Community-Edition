// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverride.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
    /// representation of a parameter at ElementUsage level that allows to override the values of a Parameter defined at ElementDefinition level
    /// Note 1: The <i>parameter</i> that is overridden must be a Parameter of the ElementDefinition that is the <i>elementDefinition</i> of the containing ElementUsage.
    /// Note 2: The owner DomainOfExpertise of this ParameterOverride is the same as the owner of the elementDefinition.
    /// </summary>
    [Container(typeof(ElementUsage), "ParameterOverride")]
    public sealed partial class ParameterOverride : ParameterOrOverrideBase
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
        /// Initializes a new instance of the <see cref="ParameterOverride"/> class.
        /// </summary>
        public ParameterOverride()
        {
            this.ValueSet = new ContainerList<ParameterOverrideValueSet>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterOverride"/> class.
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
        public ParameterOverride(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ValueSet = new ContainerList<ParameterOverrideValueSet>(this);
        }

        /// <summary>
        /// Gets or sets the Group.
        /// </summary>
        /// <remarks>
        /// group derived from associated Parameter for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Group property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ParameterGroup Group
        {
            get { return this.GetDerivedGroup(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverride.Group"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsOptionDependent.
        /// </summary>
        /// <remarks>
        /// isOptionDependent derived from associated Parameter for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The IsOptionDependent property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override bool IsOptionDependent
        {
            get { return this.GetDerivedIsOptionDependent(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverride.IsOptionDependent"); }
        }

        /// <summary>
        /// Gets or sets the Parameter.
        /// </summary>
        /// <remarks>
        /// reference to the Parameter whose values this ParameterOverride (possibly) overrides
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Parameter Parameter { get; set; }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// parameterType derived from associated Parameter for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ParameterType property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ParameterType ParameterType
        {
            get { return this.GetDerivedParameterType(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverride.ParameterType"); }
        }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// scale derived from associated Parameter for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Scale property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override MeasurementScale Scale
        {
            get { return this.GetDerivedScale(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverride.Scale"); }
        }

        /// <summary>
        /// Gets or sets the StateDependence.
        /// </summary>
        /// <remarks>
        /// stateDependence derived from associated Parameter for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The StateDependence property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ActualFiniteStateList StateDependence
        {
            get { return this.GetDerivedStateDependence(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverride.StateDependence"); }
        }

        /// <summary>
        /// Gets or sets a list of contained ParameterOverrideValueSet.
        /// </summary>
        /// <remarks>
        /// representation of the switch and values of this ParameterOverride
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParameterOverrideValueSet> ValueSet { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ParameterOverride"/>.
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
        /// Creates and returns a copy of this <see cref="ParameterOverride"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterOverride"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ParameterOverride)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ParameterSubscription = cloneContainedThings ? new ContainerList<ParameterSubscription>(clone) : new ContainerList<ParameterSubscription>(this.ParameterSubscription, clone);
            clone.ValueSet = cloneContainedThings ? new ContainerList<ParameterOverrideValueSet>(clone) : new ContainerList<ParameterOverrideValueSet>(this.ValueSet, clone);

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
        /// Creates and returns a copy of this <see cref="ParameterOverride"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterOverride"/>.
        /// </returns>
        public new ParameterOverride Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterOverride)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterOverride"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Parameter == null || this.Parameter.Iid == Guid.Empty)
            {
                errorList.Add("The property Parameter is null.");
                this.Parameter = SentinelThingProvider.GetSentinel<Parameter>();
                this.sentinelResetMap["Parameter"] = () => this.Parameter = null;
            }

            var valueSetCount = this.ValueSet.Count();
            if (valueSetCount < 1)
            {
                errorList.Add("The number of elements in the property ValueSet is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ParameterOverride"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ParameterOverride;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ParameterOverride POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.Parameter = this.Cache.Get<Parameter>(dto.Parameter, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Parameter>();
            this.ParameterSubscription.ResolveList(dto.ParameterSubscription, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ValueSet.ResolveList(dto.ValueSet, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ParameterOverride"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ParameterOverride(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.Parameter = this.Parameter != null ? this.Parameter.Iid : Guid.Empty;
            dto.ParameterSubscription.AddRange(this.ParameterSubscription.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ValueSet.AddRange(this.ValueSet.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
