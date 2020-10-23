// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameter.cs" company="RHEA System S.A.">
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
    /// representation of a parameter with a value of a NestedElement
    /// Note: The NestedParameter effectively represents the data on a parameter row of a fully expanded workbook / explicit architectural decomposition for the combination of one DomainOfExpertise and one Option.
    /// </summary>
    [Container(typeof(NestedElement), "NestedParameter")]
    public sealed partial class NestedParameter : Thing, IOwnedThing, IVolatileThing
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
        /// Initializes a new instance of the <see cref="NestedParameter"/> class.
        /// </summary>
        public NestedParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedParameter"/> class.
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
        public NestedParameter(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ActualState.
        /// </summary>
        /// <remarks>
        /// reference to the applicable ActualFiniteState for this NestedParameter if it references a state-dependent <i>associatedParameter</i>, otherwise null
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ActualFiniteState ActualState { get; set; }

        /// <summary>
        /// Gets or sets the ActualValue.
        /// </summary>
        /// <remarks>
        /// <i>actualValue</i> of the applicable ParameterValueSet, ParameterOverrideValueSet or ParameterSubscriptionValueSet
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string ActualValue { get; set; }

        /// <summary>
        /// Gets or sets the AssociatedParameter.
        /// </summary>
        /// <remarks>
        /// reference to the Parameter, ParameterOverride or ParameterSubscription with which this NestedParameter is associated
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterBase AssociatedParameter { get; set; }

        /// <summary>
        /// Gets or sets the Formula.
        /// </summary>
        /// <remarks>
        /// <i>formula</i> for the actualValue of this NestedParameter
        /// Note: Property is TBC. Allowing formulas here is opening up a second level of inserting parameter values in a workbook. Perhaps just having read-only NestedParameters is good enough.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Formula { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsVolatile.
        /// </summary>
        /// <remarks>
        /// Note: When an instance is marked volatile it will not be persisted in the persistent data store. This meant to allow for runtime-only use of such instances in a client application.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsVolatile { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to a DomainOfExpertise that is the owner of this OwnedThing
        /// Note: Ownership in this data model implies the responsibility for the presence and content of this OwnedThing. The owner is always a DomainOfExpertise. The Participant or Participants representing an owner DomainOfExpertise are thus responsible for (i.e. take ownership of) a coherent set of concerns in a concurrent engineering activity.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DomainOfExpertise Owner { get; set; }

        /// <summary>
        /// Gets or sets the Path.
        /// </summary>
        /// <remarks>
        /// derived unique short name path to this NestedParameter
        /// Note: The path string consists of the following backslash separated parts: (1) path to the <i>nestedElement</i>, (2) path to the <i>associatedParameter</i>, (3) path for the <i>actualState</i> or empty string if that is null, (4) <i>shortName</i> of the <i>container</i> Option. Any nested parts of the path name are dot separated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Path property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string Path
        {
            get { return this.GetDerivedPath(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property NestedParameter.Path"); }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="NestedParameter"/>
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

            yield return this.ActualState;

            yield return this.AssociatedParameter;

            yield return this.Owner;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="NestedParameter"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="NestedParameter"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (NestedParameter)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="NestedParameter"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="NestedParameter"/>.
        /// </returns>
        public new NestedParameter Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (NestedParameter)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="NestedParameter"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.ActualValue))
            {
                errorList.Add("The property ActualValue is null or empty.");
            }

            if (this.AssociatedParameter == null || this.AssociatedParameter.Iid == Guid.Empty)
            {
                errorList.Add("The property AssociatedParameter is null.");
                this.AssociatedParameter = SentinelThingProvider.GetSentinel<ParameterBase>();
                this.sentinelResetMap["AssociatedParameter"] = () => this.AssociatedParameter = null;
            }

            if (string.IsNullOrWhiteSpace(this.Formula))
            {
                errorList.Add("The property Formula is null or empty.");
            }

            if (this.Owner == null || this.Owner.Iid == Guid.Empty)
            {
                errorList.Add("The property Owner is null.");
                this.Owner = SentinelThingProvider.GetSentinel<DomainOfExpertise>();
                this.sentinelResetMap["Owner"] = () => this.Owner = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="NestedParameter"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.NestedParameter;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current NestedParameter POCO.", dtoThing.GetType()));
            }

            this.ActualState = (dto.ActualState.HasValue) ? this.Cache.Get<ActualFiniteState>(dto.ActualState.Value, dto.IterationContainerId) : null;
            this.ActualValue = dto.ActualValue;
            this.AssociatedParameter = this.Cache.Get<ParameterBase>(dto.AssociatedParameter, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterBase>();
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.Formula = dto.Formula;
            this.IsVolatile = dto.IsVolatile;
            this.ModifiedOn = dto.ModifiedOn;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.RevisionNumber = dto.RevisionNumber;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="NestedParameter"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.NestedParameter(this.Iid, this.RevisionNumber);

            dto.ActualState = this.ActualState != null ? (Guid?)this.ActualState.Iid : null;
            dto.ActualValue = this.ActualValue;
            dto.AssociatedParameter = this.AssociatedParameter != null ? this.AssociatedParameter.Iid : Guid.Empty;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.Formula = this.Formula;
            dto.IsVolatile = this.IsVolatile;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
