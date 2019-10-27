// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSet.cs" company="RHEA System S.A.">
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
    /// representation of the switch setting and all values of a ParameterSubscription
    /// </summary>
    [Container(typeof(ParameterSubscription), "ValueSet")]
    public sealed partial class ParameterSubscriptionValueSet : Thing, IOwnedThing
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
        /// Initializes a new instance of the <see cref="ParameterSubscriptionValueSet"/> class.
        /// </summary>
        public ParameterSubscriptionValueSet()
        {
            this.Manual = new ValueArray<string>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSubscriptionValueSet"/> class.
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
        public ParameterSubscriptionValueSet(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Manual = new ValueArray<string>(this);
        }

        /// <summary>
        /// Gets or sets the ActualOption.
        /// </summary>
        /// <remarks>
        /// convenience property that derives the <i>actualOption</i> from the <i>subscribedValueSet</i>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualOption property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public Option ActualOption
        {
            get { return this.GetDerivedActualOption(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.ActualOption"); }
        }

        /// <summary>
        /// Gets or sets the ActualState.
        /// </summary>
        /// <remarks>
        /// convenience property that derives the <i>actualState</i> from the <i>subscribedValueSet</i>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualState property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public ActualFiniteState ActualState
        {
            get { return this.GetDerivedActualState(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.ActualState"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// derived actual value of this ParameterSubscriptionValueSet depending on the <i>valueSwitch</i> setting
        /// Note: The <i>actualValue</i> is derived in the following (obvious) way:
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualValue property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public ValueArray<string> ActualValue
        {
            get { return this.GetDerivedActualValue(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.ActualValue"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// parameter value derived from the subscribed Parameter or ParameterOverride
        /// Note: This value is derived from the <i>published</i> value of ParameterValueSet that is referenced through <i>subscribedValueSet</i>. In other words, it is the value as set by the owner (DomainOfExpertise) of the subscribed Parameter or  ParameterOverride.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Computed property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public ValueArray<string> Computed
        {
            get { return this.GetDerivedComputed(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.Computed"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// manually assigned parameter subscription value
        /// Note: The <i>manual</i> value is typically used in the beginning of the modelling process, when meaningful computed values are not yet available from the associated Parameters or ParameterOverrides. By assigning a manual value and setting the <i>valueSwitch</i> to MANUAL, computations can be started with the actual value of ParameterSubscriptions.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public ValueArray<string> Manual { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// owner (DomainOfExpertise) derived from the containing ParameterSubscription
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public DomainOfExpertise Owner
        {
            get { return this.GetDerivedOwner(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.Owner"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// reference parameter value that is derived to be identical to the <i>reference</i> property of the <i>subscribedValueSet</i>
        /// Note: The reference value is typically a value originating from outside the current EngineeringModel to be used as a reference to be compared with the (newly) computed value. However the reference values may be used for any purpose that a modelling activity deems useful.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Reference property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public ValueArray<string> Reference
        {
            get { return this.GetDerivedReference(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscriptionValueSet.Reference"); }
        }

        /// <summary>
        /// Gets or sets the SubscribedValueSet.
        /// </summary>
        /// <remarks>
        /// reference to the ParameterValue or ParameterOverrideValue that this ParameterSubscriptionValue is subscribing to
        /// Note: The Parameter associated with the referenced ParameterValue must be the same as the Parameter containing the ParameterSubscription that contains this ParameterSubscriptionValue. Alternatively, the ParameterOverride associated with the referenced ParameterOverrideValue must be the same as the ParameterOverride containing the ParameterSubscription that contains this ParameterSubscriptionValue.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterValueSetBase SubscribedValueSet { get; set; }

        /// <summary>
        /// Gets or sets the ValueSwitch.
        /// </summary>
        /// <remarks>
        /// switch that determines which value is actually used
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterSwitchKind ValueSwitch { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterSubscriptionValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterSubscriptionValueSet"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ParameterSubscriptionValueSet)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.Manual = new ValueArray<string>(this.Manual, this);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterSubscriptionValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterSubscriptionValueSet"/>.
        /// </returns>
        public new ParameterSubscriptionValueSet Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterSubscriptionValueSet)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterSubscriptionValueSet"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var manualCount = this.Manual.Count();
            if (manualCount < 1)
            {
                errorList.Add("The number of elements in the property Manual is wrong. It should be at least 1.");
            }

            if (this.SubscribedValueSet == null || this.SubscribedValueSet.Iid == Guid.Empty)
            {
                errorList.Add("The property SubscribedValueSet is null.");
                this.SubscribedValueSet = SentinelThingProvider.GetSentinel<ParameterValueSetBase>();
                this.sentinelResetMap["SubscribedValueSet"] = () => this.SubscribedValueSet = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ParameterSubscriptionValueSet"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ParameterSubscriptionValueSet;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ParameterSubscriptionValueSet POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.Manual = new ValueArray<string>(dto.Manual, this);
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.SubscribedValueSet = this.Cache.Get<ParameterValueSetBase>(dto.SubscribedValueSet, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterValueSetBase>();
            this.ValueSwitch = dto.ValueSwitch;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ParameterSubscriptionValueSet(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.Manual = new ValueArray<string>(this.Manual, this);
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.SubscribedValueSet = this.SubscribedValueSet != null ? this.SubscribedValueSet.Iid : Guid.Empty;
            dto.ValueSwitch = this.ValueSwitch;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
